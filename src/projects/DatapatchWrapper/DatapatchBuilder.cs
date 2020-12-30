// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;

namespace DatapatchWrapper
{
    public static class DatapatchBuilder
    {
        private static readonly string s_WrapperHeader =
@"-- SSDT-CD Datapatch Wrapper v1.0
-- ---------------------------------------------
-- | The content was changed by a tool         |
-- ---------------------------------------------
";
        public static void WrapScriptAsDatapatch(IEditorOperations editorOperations)
        {
            var textView = editorOperations.TextView;

            if (
                textView.ScriptContentIsNotValid()
                ||
                textView.PatchIsAppliedAlready()
                ||
                editorOperations.TheQuotesAreNotEven()
                ||
                editorOperations.ScriptContentIsNotValidAsPatch()
                )
            {
                return;
            }

            var quotesApplied = TryReplaceQuotesWithPairs(editorOperations);
            if (!quotesApplied)
            {
                return;
            }

            AddDatapatchStartSection(textView, editorOperations);

            AddDatapatchEndSection(editorOperations);
        }

        private static bool TryReplaceQuotesWithPairs(this IEditorOperations editorOperations)
        {
            var matches = editorOperations.ReplaceAllMatches("'", "''", true, false, false);

            if (matches % 2 == 1)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// Counting the number of quotes by a fake replacement
        /// </summary>
        /// <param name="editorOperations"></param>
        /// <returns></returns>
        private static bool TheQuotesAreNotEven(this IEditorOperations editorOperations)
        {
            var matches = editorOperations.ReplaceAllMatches("'", "'", true, false, false);

            if (matches % 2 == 1)
            {
                return true;
            }

            return false;
        }

        private static void AddDatapatchEndSection(IEditorOperations editorOperations)
        {
            editorOperations.MoveToEndOfDocument(extendSelection: false);
            editorOperations.InsertNewLine();
            editorOperations.InsertText($"', @author = '{System.Environment.UserName}';");
            editorOperations.InsertNewLine();
        }

        private static void AddDatapatchStartSection(ITextView textView, IEditorOperations editorOperations)
        {
            editorOperations.MoveToStartOfDocument(extendSelection: false);
            editorOperations.InsertNewLine();

            editorOperations.MoveToStartOfDocument(extendSelection: false);
            textView.TextBuffer.Insert(0, s_WrapperHeader);

            editorOperations.MoveToEndOfLine(extendSelection: false);
            editorOperations.InsertNewLine();
            editorOperations.InsertText("EXEC sp_execute_script @sql ='");
        }

        /// <summary>
        /// It detects a valid datapatch by containing INSERT, UPDATE or DELETE keywords
        /// It normalize the keywords as upper case
        /// TODO: More logic to be added
        /// </summary>
        /// <param name="textView"></param>
        /// <returns></returns>
        private static bool ScriptContentIsNotValidAsPatch(this IEditorOperations editorOperations)
        {
            var matchesInsert = editorOperations.ReplaceAllMatches("INSERT", "INSERT", false, true, false);
            var matchesUpdate = editorOperations.ReplaceAllMatches("UPDATE", "UPDATE", false, true, false);
            var matchesDelete = editorOperations.ReplaceAllMatches("DELETE", "DELETE", false, true, false);

            if ((matchesInsert + matchesUpdate + matchesDelete) > 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// It detects a valid minimal content
        /// </summary>
        /// <param name="textView"></param>
        /// <returns></returns>
        private static bool ScriptContentIsNotValid(this ITextView textView)
        {
            if (textView.TextViewLines.FormattedSpan.Snapshot.Length < 10)
            {
                return true;
            }

            return false;
        }

        private static bool PatchIsAppliedAlready(this ITextView textView)
        {
            var matchCount = 10;

            var header = textView.TextViewLines.FormattedSpan.Snapshot.GetText(0, matchCount);

            if (s_WrapperHeader.Substring(0, matchCount) == header)
            {
                return true;
            }

            return false;
        }
    }
}

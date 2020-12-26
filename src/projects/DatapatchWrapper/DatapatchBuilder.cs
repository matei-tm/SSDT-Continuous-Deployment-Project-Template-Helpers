/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

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
        public static void WrapScriptAsDatapatch(ITextView textView, IEditorOperations editorOperations)
        {
            if (PatchIsAppliedAlready(textView))
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

        private static bool TryReplaceQuotesWithPairs(IEditorOperations editorOperations)
        {

            var matches = editorOperations.ReplaceAllMatches("'", "''", true, false, false);

            if (matches % 2 == 1)
            {
                // TODO: implement undo operation for odd number of quotes
                return false;
            }

            return true;
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

        private static bool PatchIsAppliedAlready(ITextView textView)
        {
            var matchCount = 20;
            var header = textView.TextViewLines.FormattedSpan.Snapshot.GetText(0, matchCount);

            if (s_WrapperHeader.Substring(0, matchCount) == header)
            {
                return true;
            }

            return false;
        }
    }
}

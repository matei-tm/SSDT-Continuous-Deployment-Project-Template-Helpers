/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using DatapatchWrapper;
using Microsoft.VisualStudio.Commanding;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace ModernCommandHandler
{
    [Export(typeof(ICommandHandler))]
    [ContentType("text")]
    [Name(nameof(JoinLinesCommandHandler))]
    public class JoinLinesCommandHandler : ICommandHandler<JoinLinesCommandArgs>
    {
        public string DisplayName => "Wrap sql script as datapatch";

        [Import]
        private IEditorOperationsFactoryService EditorOperations = null;

        public CommandState GetCommandState(JoinLinesCommandArgs args)
        {
            return !args.SubjectBuffer.ContentType.IsOfType("SQL Server Tools") ? CommandState.Unavailable : CommandState.Available;
        }

        public bool ExecuteCommand(JoinLinesCommandArgs args, CommandExecutionContext context)
        {
            using (context.OperationContext.AddScope(allowCancellation: false, description: "Wrapping. Producing datapatch structure..."))
            {
                args.TextView.TextBuffer.Insert(0, "// Invoked from modern command handler\r\n");
                DatapatchBuilder.WrapScriptAsDatapatch(args.TextView, EditorOperations.GetEditorOperations(args.TextView));
            }

            return true;
        }
    }
}

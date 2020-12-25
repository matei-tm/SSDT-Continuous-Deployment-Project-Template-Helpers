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

namespace DatapatchWrapperCommandHandler
{
    [Export(typeof(ICommandHandler))]
    [ContentType("text")]
    [Name(nameof(DatapatchWrapperCommandHandler))]
    public class DatapatchWrapperCommandHandler : ICommandHandler<DatapatchWrapperCommandArgs>
    {
        public string DisplayName => "Wrap sql script as datapatch";

        [Import]
        private readonly IEditorOperationsFactoryService _editorOperations = null;

        public CommandState GetCommandState(DatapatchWrapperCommandArgs args)
        {
            return !args.SubjectBuffer.ContentType.IsOfType("SQL Server Tools") ? CommandState.Unavailable : CommandState.Available;
        }

        public bool ExecuteCommand(DatapatchWrapperCommandArgs args, CommandExecutionContext context)
        {
            using (context.OperationContext.AddScope(allowCancellation: false, description: "Wrapping. Producing datapatch structure..."))
            {
                DatapatchBuilder.WrapScriptAsDatapatch(args.TextView, _editorOperations.GetEditorOperations(args.TextView));
            }

            return true;
        }
    }
}

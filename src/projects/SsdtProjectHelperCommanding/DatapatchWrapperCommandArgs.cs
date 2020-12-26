/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.Commanding;

namespace SsdtProjectHelperCommanding
{
    [SuppressMessage("NDepend", "ND1207:NonStaticClassesShouldBeInstantiatedOrTurnedToStatic", Justification = "Used by MEF")]
    public class DatapatchWrapperCommandArgs : EditorCommandArgs
    {
        public DatapatchWrapperCommandArgs(ITextView textView, ITextBuffer textBuffer)
            : base(textView, textBuffer)
        {
        }
    }
}

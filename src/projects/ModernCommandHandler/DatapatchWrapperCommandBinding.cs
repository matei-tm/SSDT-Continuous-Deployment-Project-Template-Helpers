/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using Microsoft.VisualStudio.Editor.Commanding;
using System;
using System.ComponentModel.Composition;

namespace DatapatchWrapperCommandHandler
{
    public class DatapatchWrapperCommandBinding
    {
        private const int DatapatchWrapperCommandId = 0x0100;
        private const string DatapatchWrapperCommandSet = "2b5c526e-368f-47c2-81e3-3ea1eb7c79c7";

        [Export]
        [CommandBinding(DatapatchWrapperCommandSet, DatapatchWrapperCommandId, typeof(DatapatchWrapperCommandArgs))]
        internal CommandBindingDefinition datapatchWrapperCommandBinding;
    }
}

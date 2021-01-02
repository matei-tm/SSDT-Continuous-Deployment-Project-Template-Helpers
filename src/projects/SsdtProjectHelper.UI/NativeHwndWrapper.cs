// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Windows.Forms;

namespace SsdtProjectHelper.UI
{
    public partial class DestinationPicker
    {
        class NativeHwndWrapper : IWin32Window
        {
            readonly IntPtr _handle;

            public NativeHwndWrapper(IntPtr handle)
            {
                _handle = handle;
            }

            public IntPtr Handle
            {
                get { return _handle; }
            }
        }
    }
}

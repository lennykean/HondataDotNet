﻿using System.Runtime.InteropServices;

using HondataDotNet.Datalog.Core;

namespace HondataDotNet.Datalog.KPro
{
    partial class KProDatalogComment : IDatalogComment
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct Metadata
        {
            public double Offset;
            public int Length;
        }

        public readonly static int StructSize = Marshal.SizeOf<Metadata>();
    }
}
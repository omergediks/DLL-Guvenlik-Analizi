using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DefensiveMonitoring
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MEMORY_BASIC_INFORMATION
    {
        public IntPtr BaseAddress;
        public IntPtr AllocationBase;
        public uint AllocationProtect;
        public IntPtr RegionSize;
        public uint State;
        public uint Protect;
        public uint Type;
    }

    public class MemoryScanner
    {
        [DllImport("kernel32.dll")]
        static extern int VirtualQueryEx(IntPtr hProcess, IntPtr lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, uint dwLength);

        public static List<MEMORY_BASIC_INFORMATION> ScanMemory(IntPtr processHandle)
        {
            List<MEMORY_BASIC_INFORMATION> regions = new List<MEMORY_BASIC_INFORMATION>();
            long address = 0;
            long maxAddress = 0x7fffffffffff;
            while (address < maxAddress)
            {
                MEMORY_BASIC_INFORMATION mbi;
                int result = VirtualQueryEx(processHandle, (IntPtr)address, out mbi, (uint)Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION)));
                if (result == 0) break;

                regions.Add(mbi);
                address += (long)mbi.RegionSize;
            }
            return regions;
        }
    }
}
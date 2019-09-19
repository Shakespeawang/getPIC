using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace IMemory
{

    public unsafe class memory
    {

        static int ph = GetProcessHeap();

        private memory() { }

        public static void* Alloc(int size)
        {
            void* result = HeapAlloc(ph, HEAP_ZERO_MEMORY, size);

            if (result == null) throw new OutOfMemoryException();

            return result;
        }

        public static void free(void* block)
        {
            if (!HeapFree(ph, 0, block)) throw new InvalidOperationException();
        }

        // Heap API flags
        const int HEAP_ZERO_MEMORY = 0x00000008;

        // Heap API functions
        [DllImport("kernel32")]

        static extern int GetProcessHeap();
        [DllImport("kernel32")]

        static extern void* HeapAlloc(int hHeap, int flags, int size);
        [DllImport("kernel32")]

        static extern bool HeapFree(int hHeap, int flags, void* block);
        [DllImport("kernel32")]

        static extern void* HeapReAlloc(int hHeap, int flags, void* block, int size);

        [DllImport("kernel32")]
        static extern int HeapSize(int hHeap, int flags, void* block);
    }
}


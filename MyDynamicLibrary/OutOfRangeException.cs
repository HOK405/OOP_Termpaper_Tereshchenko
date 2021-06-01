using System;
using System.Collections.Generic;
using System.Text;

namespace MyDynamicLibrary
{
    public class OutOfRangeException : Exception { public OutOfRangeException() : base("Вихід за встановлені числові межі") { } }
}

using System;

namespace MyDynamicLibrary
{
    public class IsNotDigitException : Exception { public IsNotDigitException() : base("Введений символ чи строка не є числом") { } }
}

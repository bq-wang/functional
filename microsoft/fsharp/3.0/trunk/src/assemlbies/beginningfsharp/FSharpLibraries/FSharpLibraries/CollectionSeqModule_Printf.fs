module CollectionSeqModule_Printf

// what will be covered in this chapter 
//   1. Printf

(*
    Flag   Descriptoin
     %b   Bool, formatted as "true" or "false"
     %s   string, formatted as its unescaped contents
     %d,%i Any basic integer type (that is, sbyte, byte, int16, uint16, int32, uint32, int64, uint64, nativeint, or unativeint) formatted as a decimal integer, signed if the basic integer type is signed
     %u    Any basic integer type formatted as an unsigned decimal integer
     %x, %X, %o Any basic integer type formatted as an unsigned hexadecimal, (a-f)/Hexadecimal (AF)/Octal integer
     %e, %E Any basic floating-point type (that is, float or float32), formatted using a C-style floatingpoint format specification, signed value having the form [-]d.dddde[sign]ddd where d is a single decimal digit, dddd is one or more decimal digits, ddd is exactly three decimal digits, and sign is + or –
     %f    Any basic floating-point type, formatted using a C-style floating-point format specification, signed value having the form [-]dddd.dddd, where dddd is one or more decimal digits. The number of digits before the decimal point depends on the magnitude of the number, and the number of digits after the decimal point depends on the requested precision
     %g, %G Any basic floating-point type, formatted using a C-style floating-point format specification, signed value printed in f or e format, whichever is more compact for the given value and precision
    %M System.Decimal value
    %O Any value, printed by boxing the object and using its ToString method(s)
    %A Any value, values will be pretty printed allowing the user to see the values of properties and fields
    %a A general format specifier; requires two arguments: A function that accepts two arguments: a context parameter of the appropriate type for the given formatting function (such as a System.IO.TextWriter) and a value to print that either outputs or returns appropriate text. The particular value to print 
    %t A general format specifier; requires one argument: a function that accepts a context parameter of the appropriate type for the given formatting function (such as a System.IO.TextWriter) and that either outputs or returns appropriate text 0 A flag that adds zeros instead of spaces to make up the required width
    - A flag that left justifies the result within the width specified
    + A flag that adds a + character if the number is positive (to match the – sign for negatives)
    ‘ ’ Adds an extra space if the number is positive (to match the – sign for negatives)
*)
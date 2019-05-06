using System;

[Flags]
public enum Flags : short
{
    Query = 0x00,
    Response = 0x01,
    OpCode = 0x02,
    Truncated = 0x04,
    Recursion = 0x08,
    Reserved = 0x16,
}
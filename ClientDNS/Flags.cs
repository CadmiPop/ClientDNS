using System;

[Flags]
public enum Flags : ushort
{
    None = 0,
    FormatError = 1,
    ServerFailture = 2,
    NoSuchName = 3,
    NameError = 4,
    NotImplemented = 8,
    Refused = 9,
    NonAuthenticatedData = 16,
    AnswerAuthenticated = 32,
    RecursionAvailable = 64,
    RecursionDesired = 256,
    Truncated = 512,
    Authoritative = 1024,
    InverseQuerry = 2048,
    Response = 32786,

}
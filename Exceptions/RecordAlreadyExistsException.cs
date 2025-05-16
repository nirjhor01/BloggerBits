using System;

namespace BloggerBits.Exceptions;
public class RecordAlreadyExistsException : Exception
{
    public RecordAlreadyExistsException(string message) : base(message) { }
    public RecordAlreadyExistsException(string message, Exception? innerException) : base(message, innerException){ }
}
using System.Runtime.CompilerServices;

namespace OnionDemo.Application.Exceptions;

public class ValidationException : Exception
{
    public ValidationException() : base("Validation Error Occured")
    {
        
    }
    
    public ValidationException(string Message) : base(Message)
    {
        
    }
    
    public ValidationException(Exception ex) : this(ex.Message)
    {
        
    }
}
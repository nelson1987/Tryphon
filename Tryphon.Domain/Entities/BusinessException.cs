namespace Tryphon.Domain.Entities;

public class BusinessException : Exception
{
    public BusinessException(string message) : base(message)
    {
        
    }
}
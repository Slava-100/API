
namespace TechnoTest.Core.CustomExceptions
{
    internal class ValidationException : Exception
    {  
        public ValidationException(string message) : base(message) { }
    }
    
}

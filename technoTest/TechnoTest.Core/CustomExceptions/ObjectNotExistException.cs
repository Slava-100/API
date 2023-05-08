
namespace TechnoTest.Core.CustomExceptions
{
    public class ObjectNotExistException : Exception
    {
        public ObjectNotExistException(string message) : base(message) { }
    }
}

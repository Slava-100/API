
namespace TechnoTest.Core.CustomExceptions
{
    public class RepetativeActionException : Exception
    {
        public RepetativeActionException(string message) : base(message) { }
    }
}

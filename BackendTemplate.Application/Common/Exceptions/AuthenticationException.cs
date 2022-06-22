namespace BackendTemplate.Application.Common.Exceptions
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException() :
            base("Authentication failed. Wrong username or password")
        {

        }
    }
}

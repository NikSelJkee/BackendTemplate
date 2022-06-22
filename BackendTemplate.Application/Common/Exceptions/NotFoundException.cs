namespace BackendTemplate.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
            : base()
        {

        }

        public NotFoundException(string name, object key)
            : base($"Entity '{name}' with ID: {key} was not found.")
        {

        }
    }
}

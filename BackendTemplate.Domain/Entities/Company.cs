using BackendTemplate.Domain.Common;

namespace BackendTemplate.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; } = null!;

        public IList<Game> Games { get; private set; } = new List<Game>();
    }
}

using BackendTemplate.Domain.Common;
using BackendTemplate.Domain.Enums;
using BackendTemplate.Domain.ValueObjects;

namespace BackendTemplate.Domain.Entities
{
    public class Game : BaseEntity
    {
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public GameInfo Info { get; set; } = null!;
        public Genre Genre { get; set; }

        public long CompanyId { get; set; }
        public Company Company { get; set; } = null!;
    }
}

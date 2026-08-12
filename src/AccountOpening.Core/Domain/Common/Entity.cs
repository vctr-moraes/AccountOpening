namespace AccountOpening.Core.Domain.Common
{
    internal abstract class Entity
    {
        public Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}

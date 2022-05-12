namespace Catalog.Domain.Contracts.Persistance
{
    public interface IEntityDocument
    {
        string BsonId { get; set; }
    }
}

using Entities.Abstract;

namespace Entities.Concrete;

public class Customer : IEntity
{
    public int Id { get; set; }
    public string ContactName { get; set; }
    public string CompanyName { get; set; }
    public string City { get; set; }
}
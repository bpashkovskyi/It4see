namespace It4see.Domain;

public class Category
{
    public int Id { get; set; }

    public string Title { get; set; }

    public ICollection<Product> Products { get; set; }
}
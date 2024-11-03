using LivrariaOnline.Enums;

namespace LivrariaOnline.Entities;
public class Book
{
    public int Id { get; private set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public Genre Genre { get; set; }
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }

    public Book()
    {
        Random random = new Random();
        Id = random.Next(1, 1000);
    }
}
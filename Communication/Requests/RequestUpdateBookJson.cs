using LivrariaOnline.Enums;

namespace LivrariaOnline.Communication.Requests;

public class RequestUpdateBookJson
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public Genre Genre { get; set; }
    public decimal Price { get; set; } 
    public int QuantityInStock { get; set; }
}
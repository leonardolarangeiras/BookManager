namespace BookManager.Communication.Requests;

public class RequestCreateBookJson
{
    public string Title { get; set; }
    public string Author { get; set; }
    public BookGenres Genre { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
}

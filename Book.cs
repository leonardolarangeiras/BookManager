namespace BookManager;

public class Book
{
    public int Id { get; set; } = Random.Shared.Next(1, 1000);
    public string Title { get; set; }
    public string Author { get; set; }
    public BookGenres Genre { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;

    public bool isValidBook()
    {
        bool isTitleANdAuthorValid = !string.IsNullOrWhiteSpace(Title) && !string.IsNullOrWhiteSpace(Author);
        bool isGenreValid = Enum.IsDefined(typeof(BookGenres), Genre);
        bool isPriceValid = Price >= 0;
        bool isStockValid = Stock >= 0;

        // Add validation logic here
        return isTitleANdAuthorValid && isGenreValid && isPriceValid && isStockValid;
    }
}

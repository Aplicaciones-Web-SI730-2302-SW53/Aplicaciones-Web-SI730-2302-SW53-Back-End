namespace _3._Data.Model;

public class Tutorial :ModelBase
{
    public string Title { get; set; }
    public int Year { get; set; }
    public int Author { get; set; }
    
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
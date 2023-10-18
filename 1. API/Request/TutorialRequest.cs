using System.ComponentModel.DataAnnotations;

namespace _1._API.Request;

public class TutorialRequest
{
    [Required]
    [MaxLength(20)]
    public string Title { get; set; }
    
    [Required]
    [Range(1990,2023)]
    public int Year { get; set; }
    public int Author { get; set; }
    
    [Required]
    public int CategoryId { get; set; }
    
}
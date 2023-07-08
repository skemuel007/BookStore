using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Dtos.Book;

public class BookAddDto
{
    [Required(ErrorMessage = "This field {0} is required.")]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "This field {0} is required.")]
    [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters.", MinimumLength = 2)]
    public string Name { get; set; }

    [Required(ErrorMessage = "This field {0} is required.")]
    [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters.", MinimumLength = 2)]
    public string Author { get; set; }

    public string Description { get; set; }
    public double Value { get; set; }
    public DateTime PublishDate { get; set; }
}

public class BookEditDto
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "This field {0} is required.")]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "This field {0} is required.")]
    [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters.", MinimumLength = 2)]
    public string Name { get; set; }

    [Required(ErrorMessage = "This field {0} is required.")]
    [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters.", MinimumLength = 2)]
    public string Author { get; set; }

    public string Description { get; set; }
    public double Value { get; set; }
    public DateTime PublishDate { get; set; }
}

public class BookResultDto
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }

    public string Name { get; set; }

    public string Author { get; set; }

    public string Description { get; set; }
    public double Value { get; set; }
    public DateTime PublishDate { get; set; }
    
}
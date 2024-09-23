using System.ComponentModel.DataAnnotations;

namespace UnitTest.MVC.Models.Entities;

public class Product
{
    public long Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
}
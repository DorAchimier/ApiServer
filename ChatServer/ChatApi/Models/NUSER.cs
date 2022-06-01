using System.ComponentModel.DataAnnotations;

namespace ChatApi.Models;

public class NUSER
{
    
    [Key]
    public string Username { get; set; }
    
    [Required] 
    public string Name { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public string Server { get; set; }
}
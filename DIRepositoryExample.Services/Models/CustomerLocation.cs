using System.ComponentModel.DataAnnotations;

namespace DIRepositoryExample.Services.Services
{
    public class CustomerLocation
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Address { get; set; }
    }
}

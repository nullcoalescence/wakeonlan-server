using System.ComponentModel.DataAnnotations;

namespace wakeonlan_server.Models
{
    public class Device
    {
        [Required()]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50, ErrorMessage = "Name must be 50 characters or less")] 
        public string Name { get; set; }

        [MaxLength(255, ErrorMessage = "Description must be 255 characters or less")]
        public string? Description { get; set; }

        // https://stackoverflow.com/questions/4260467/what-is-a-regular-expression-for-a-mac-address
        [Required(ErrorMessage = "Mac address is required")]
        [RegularExpression("^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$", ErrorMessage = "Mac address must be in the format 'A1:B2:C3:D4:E5:F6'")]
        [Display(Name="Mac Address")]
        public string MacAddress { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace wakeonlan_server.Models
{
    public class Device
    {
        [Required()]
        public int Id { get; set; }

        [MaxLength(50)] 
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        //[RegularExpression("^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})|([0-9a-fA-F]{4}\\.[0-9a-fA-F]{4}\\.[0-9a-fA-F]{4})$")]
        [Display(Name="Mac Address")]
        public string MacAddress { get; set; }
    }
}

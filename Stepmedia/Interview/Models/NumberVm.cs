using System.ComponentModel.DataAnnotations;

namespace Interview.Models
{
    public class NumberVm
    {
        [Required]
        public string RequestNumber { get; set; }

        public string Result { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace web.Models.Application
{
    public class CertificationsViewModel
    {
        [Required(ErrorMessage = "Certification is required.")]
        [Display(Name = "Certification")]
        public string? Certification { get; set; }

        [Required(ErrorMessage = "Institution is required.")]
        [Display(Name = "Institution")]
        public string? Institution { get; set; }

        [Required(ErrorMessage = "Document is required.")]
        [Display(Name = "Document")]
        public IFormFile? Document { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace web.Models.Application
{
    public class StatutoryViewModel
    {
        [Required(ErrorMessage = "Good Conduct Certificate is required.")]
        public IFormFile GoodConductCertificate { get; set; } = null!;

        [Required(ErrorMessage = "HELB Clearance Certificate is required.")]
        public IFormFile HelbClearanceCertificate { get; set; } = null!;

        [Required(ErrorMessage = "Tax Compliance Certificate is required.")]
        public IFormFile TaxComplianceCertificate { get; set; } = null!;

        [Required(ErrorMessage = "Ethics and Anti-Corruption Clearance is required.")]
        public IFormFile EthicsAntiCorruptionClearance { get; set; } = null!;

        [Required(ErrorMessage = "CRB Certificate is required.")]
        public IFormFile CrbCerficate { get; set; } = null!;
    }

}

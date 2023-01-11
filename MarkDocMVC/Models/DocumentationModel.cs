using System.ComponentModel.DataAnnotations;

namespace MarkDocMVC.Models {
    public class DocumentationModel {
        [Required]
        public string DocumentContent { get; set; }
        [Required]
        [MinLength(2)]
        public string DocumentationFileName { get; set; }
    }
}

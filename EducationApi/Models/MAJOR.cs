using System.ComponentModel.DataAnnotations;

namespace EducationApi.Models {
    public class MAJOR {

        public int Id { get; set; }

        [StringLength(4)]
        [Required]
        public string Code { get; set; } = null!;

        [StringLength(50)]
        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public int MinSat { get; set; }

    }
}

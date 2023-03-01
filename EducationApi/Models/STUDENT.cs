using System.ComponentModel.DataAnnotations;

namespace EducationApi.Models {
    public class STUDENT {

        public int Id { get; set; }
        [StringLength(30)]

        [Required]
        public string Name { get; set; } = string.Empty;

        [StringLength(2)]
        [Required]
        public string StateCode { get; set; } = string.Empty;

        public int? SAT { get; set; }

        [Required]
        public decimal GPA { get; set; }

        //fk's & virtual props

        [Required]
        public int MajorId { get; set; }

        public virtual MAJOR? MAJOR { get; set; }
    }
}

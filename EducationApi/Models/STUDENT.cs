using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        [Column(TypeName = "decimal(3,2)")]
        [Required]
        public decimal GPA { get; set; }

        //fk's & virtual props

        [Required]
        public int MajorId { get; set; }
        //[JsonIgnore] b/c we want the major when reading the student
        public virtual MAJOR? MAJOR { get; set; }
    }
}

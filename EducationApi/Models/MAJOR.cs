using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EducationApi.Models {
    [Index("Code", IsUnique = true)]
    public class MAJOR {

        public int Id { get; set; }

        [StringLength(4)]
        [Required]
        public string Code { get; set; } = string.Empty;

        [StringLength(50)]
        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int MinSat { get; set; }

        [JsonIgnore]
        public virtual ICollection<STUDENT>? STUDENTs { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace J3DX0H_GUI.Models
{
    public class Band
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }


        [Required]
        public int TimeOfFoundation { get; set; }

        [Required]
        public bool StillActive { get; set; }

        [Required]
        public string CountryOfFoundation { get; set; }

        [Required]
        public string TownOfOrigin { get; set; }

        //1 Band has many Albums
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Album> Albums { get; set; }

    }
}

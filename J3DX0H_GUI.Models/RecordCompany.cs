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
    public class RecordCompany
    {
        public RecordCompany()
        {

        }

        public RecordCompany(int id, string name, int established, string country, string city, string founder, string webPage, ICollection<Album> albums)
        {
            Id = id;
            Name = name;
            Established = established;
            Country = country;
            City = city;
            Founder = founder;
            WebPage = webPage;
            Albums = albums;
        }

        public RecordCompany(int id, string name, int established, string country, string city, string founder, string webPage)
        {
            Id = id;
            Name = name;
            Established = established;
            Country = country;
            City = city;
            Founder = founder;
            WebPage = webPage;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int Established { get; set; }

        [Required]
        [MaxLength(50)]
        public string Country { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        public string Founder { get; set; }

        [Required]
        [MaxLength(100)]
        public string WebPage { get; set; }

        //1 RecordCompany has many Albums, but 1 album has only 1 recordcompany(in this model at least)
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Album> Albums { get; set; }
    }
}

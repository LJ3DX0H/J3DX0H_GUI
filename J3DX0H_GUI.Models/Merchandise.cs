using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace J3DX0H_GUI.Models
{
    public class Merchandise
    {
        public Merchandise()
        {
        }

        public Merchandise(int id, int albumId, MerchType typeOfMerch, string merchName, MerchSize sizeOfMerch, double price, bool available, Album album)
        {
            Id = id;
            AlbumId = albumId;
            TypeOfMerch = typeOfMerch;
            MerchName = merchName;
            SizeOfMerch = sizeOfMerch;
            Price = price;
            Available = available;
            Album = album;
        }

        public Merchandise(int id, int albumId, MerchType typeOfMerch, string merchName, MerchSize sizeOfMerch, double price, bool available)
        {
            Id = id;
            AlbumId = albumId;
            TypeOfMerch = typeOfMerch;
            MerchName = merchName;
            SizeOfMerch = sizeOfMerch;
            Price = price;
            Available = available;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int AlbumId { get; set; }
        [Required]
        public MerchType TypeOfMerch { get; set; }
        [Required]
        public string MerchName { get; set; }
        //If not Clothing value is NULL
        [Required]
        public MerchSize SizeOfMerch { get; set; }
        //in dollar
        [Required]
        public double Price { get; set; }
        [Required]
        public bool Available { get; set; }

        //1 merchandize belongs to 1 album but 1 album can have multiple merchandizes
        [NotMapped]
        [JsonIgnore]
        public virtual Album Album { get; set; }
    }
}

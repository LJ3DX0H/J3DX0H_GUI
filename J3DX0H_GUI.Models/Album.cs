using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace J3DX0H_GUI.Models
{
    public class Album
    {
        public Album()
        {

        }

        public Album(int id, int recordCompanyId, int bandId, string albumTitle, int yearOfPublishing, int albumLength, int numberOfTracks, int copiesSold, Band band, RecordCompany recordCompany, ICollection<Merchandise> merchandises)
        {
            Id = id;
            RecordCompanyId = recordCompanyId;
            BandId = bandId;
            AlbumTitle = albumTitle;
            YearOfPublishing = yearOfPublishing;
            AlbumLength = albumLength;
            NumberOfTracks = numberOfTracks;
            CopiesSold = copiesSold;
            Band = band;
            RecordCompany = recordCompany;
            Merchandises = merchandises;
        }

        public Album(int id, int recordCompanyId, int bandId, string albumTitle, int yearOfPublishing, int albumLength, int numberOfTracks, int copiesSold)
        {
            Id = id;
            RecordCompanyId = recordCompanyId;
            BandId = bandId;
            AlbumTitle = albumTitle;
            YearOfPublishing = yearOfPublishing;
            AlbumLength = albumLength;
            NumberOfTracks = numberOfTracks;
            CopiesSold = copiesSold;
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        [ForeignKey(nameof(RecordCompany))]
        public int RecordCompanyId { get; set; }


        [Required]
        [ForeignKey(nameof(Band))]
        public int BandId { get; set; }

        [Required]
        [MaxLength(100)]
        public string AlbumTitle { get; set; }

        [Required]

        public int YearOfPublishing { get; set; }

        //Using int to store seconds, but will show in mm:ss format using timespan
        [Required]

        public int AlbumLength { get; set; }

        [Required]

        public int NumberOfTracks { get; set; }

        [Required]

        public int CopiesSold { get; set; }

        // 1 Band many albums
        [NotMapped]
        [JsonIgnore]
        public virtual Band Band { get; set; }

        // 1 Recordcompany many albums, but 1 album is only under 1 Recordcompany
        [NotMapped]
        [JsonIgnore]
        public virtual RecordCompany RecordCompany { get; set; }

        //1 album many merchandise
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Merchandise> Merchandises { get; set; }
    }
}


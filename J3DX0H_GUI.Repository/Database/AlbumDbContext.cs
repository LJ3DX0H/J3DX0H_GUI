using J3DX0H_GUI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3DX0H_GUI.Repository.Database
{
    public class AlbumDbContext : DbContext
    {
        //All queries should be done via Albums
        public DbSet<Album> Albums { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<Merchandise> Merchandises { get; set; }
        public DbSet<RecordCompany> RecordCompanys { get; set; }

        public AlbumDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseInMemoryDatabase("AlbumsDb");

            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity => entity
                .HasOne(x => x.Band)
                .WithMany(al => al.Albums)
                .HasForeignKey(fk => fk.BandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                );

            modelBuilder.Entity<Album>(entity => entity
                .HasOne(x => x.RecordCompany)
                .WithMany(al => al.Albums)
                .HasForeignKey(fk => fk.RecordCompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                );


            modelBuilder.Entity<Merchandise>(entity => entity
                .HasOne(x => x.Album)
                .WithMany(mc => mc.Merchandises)
                .HasForeignKey(alk => alk.AlbumId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                );



            //seed data for recordompanies, mostly from wiki, some shortcuts were made, like SVB is just Napalm
            modelBuilder.Entity<RecordCompany>().HasData(new RecordCompany[] {
                    new RecordCompany { Id = 1, Name = "Peaceville Records", Established = 1987, Country = "United Kingdom", City = "Dewsbury", Founder = "Paul Halmshaw", WebPage = "www.peaceville.com" },
                    new RecordCompany { Id = 2, Name = "Music For Nations (Original)", Established = 1983, Country = "United Kingdom", City = "London", Founder = "Martin Hooker", WebPage = "www.musicfornations.co.uk" },
                    new RecordCompany { Id = 3, Name = "Electric and Musical Idustries(EMI)", Established = 1931, Country ="United Kingdom" , City ="London" , Founder ="Columbia Graphophone Co. & Gramophone Company" , WebPage ="emirecords.com"  },
                    new RecordCompany { Id = 4, Name = "Gun Records", Established =1992 , Country ="Germany" , City ="Bochum" , Founder ="Bogdan Kopec & Wolfgang Funk" , WebPage ="gunrecords.com"  },
                    new RecordCompany { Id = 5, Name = "Century Media Records", Established =1988 , Country ="Germany" , City ="Dortmund" , Founder ="Robert Kampf & Oliver Withöft" , WebPage ="cmdistro.com"  },
                    new RecordCompany { Id = 6, Name = "Nuclear Blast", Established =1987 , Country ="Germany" , City ="Donzdorf" , Founder ="Markus Staiger" , WebPage ="www.nuclearblast.de"  },
                    new RecordCompany { Id = 7, Name = "Roadrunner Records", Established =1980 , Country ="United States" , City ="New York" , Founder = "Cees Wessels" , WebPage ="roadrunnerrecords.co.uk"  },
                    new RecordCompany { Id = 8, Name = "Napalm Records", Established = 1992, Country ="Austria" , City ="Eisenerz" , Founder ="Markus Riedler" , WebPage ="label.napalmrecords.com"  },
                    new RecordCompany { Id = 9, Name = "Atomic Fire", Established =2021 , Country ="Germany" , City ="Donzdorf" , Founder ="Markus Staiger" , WebPage =  "www.atomicfire-records.com"},
                    new RecordCompany { Id = 10, Name = "Kscope", Established = 2008, Country ="United Kingdom" , City ="London" , Founder ="Steven Wilson" , WebPage = "kscopemusic.com" }
            });

            //seed data for bands, mostly from wiki
            modelBuilder.Entity<Band>().HasData(new Band[] {
                    new Band { Id = 1, Name = "Paradise Lost", TimeOfFoundation =1988, StillActive = true, CountryOfFoundation = "United Kingdom", TownOfOrigin = "Halifax" },
                    new Band { Id = 2, Name = "Type O Negative", TimeOfFoundation =1989, StillActive = false, CountryOfFoundation = "United States", TownOfOrigin = "New York" },
                    new Band { Id = 3, Name = "The Gathering", TimeOfFoundation =1989, StillActive = true, CountryOfFoundation = "Netherlands", TownOfOrigin = "Oss" },
                    new Band { Id = 4, Name = "Eluveitie", TimeOfFoundation =2002, StillActive = true, CountryOfFoundation = "Switzerland", TownOfOrigin = "Winterthur" },
                    new Band { Id = 5, Name = "Moonspell", TimeOfFoundation =1992, StillActive = true, CountryOfFoundation = "Portugal", TownOfOrigin = "Brandoa" },
                    new Band { Id = 6, Name = "Lacuna Coil", TimeOfFoundation =1997, StillActive = true, CountryOfFoundation = "Italy", TownOfOrigin = "Milan" },
                    new Band { Id = 7, Name = "In Flames", TimeOfFoundation =1990, StillActive = true, CountryOfFoundation = "Sweden", TownOfOrigin = "Gothenburg" },
                    new Band { Id = 8, Name = "Amorphis", TimeOfFoundation =1990, StillActive = true, CountryOfFoundation = "Finland", TownOfOrigin = "Helsinki" },
                    new Band { Id = 9, Name = "Iced Earth", TimeOfFoundation =1984, StillActive = true, CountryOfFoundation = "United States", TownOfOrigin = "Tampa" },
                    new Band { Id = 10, Name = "Lamb of God", TimeOfFoundation =1994, StillActive = true, CountryOfFoundation = "United States", TownOfOrigin = "Richmond" },
                    new Band { Id = 11, Name = "Sonata Arctica", TimeOfFoundation =1995, StillActive = true, CountryOfFoundation = "Finland", TownOfOrigin = "Kemi" },
                    new Band { Id = 12, Name = "Anathema", TimeOfFoundation =1990, StillActive = false, CountryOfFoundation = "United Kingdom", TownOfOrigin = "Liverpool" },
                    new Band { Id = 13, Name = "Katatonia", TimeOfFoundation =1991, StillActive = true, CountryOfFoundation = "Sweden", TownOfOrigin = "Stockholm" },
                    new Band { Id = 14, Name = "Arkona", TimeOfFoundation =2002, StillActive = true, CountryOfFoundation = "Russia", TownOfOrigin = "Moscow" },
                    new Band { Id = 15, Name = "Hatebreed", TimeOfFoundation =1994, StillActive = true, CountryOfFoundation = "United States", TownOfOrigin = "Bridgeport" }

            });
            //Copiessold will be just randomized guesses for the Album seed data
            modelBuilder.Entity<Album>().HasData(new Album[] {
                    new Album { Id = 1, RecordCompanyId = 1, BandId = 1, AlbumTitle = "Gothic", YearOfPublishing = 1991, AlbumLength = 2364, NumberOfTracks = 10, CopiesSold = 100000 },
                    new Album { Id = 2, RecordCompanyId = 2, BandId = 1, AlbumTitle = "Icon", YearOfPublishing = 1993, AlbumLength = 3030, NumberOfTracks = 13, CopiesSold = 200000 },
                    new Album { Id = 3, RecordCompanyId = 2, BandId = 1, AlbumTitle = "Draconian Times", YearOfPublishing = 1994, AlbumLength = 2939, NumberOfTracks = 12, CopiesSold =380000  },
                    new Album { Id = 4, RecordCompanyId = 3, BandId = 1, AlbumTitle = "Believe in Nothing", YearOfPublishing = 2001, AlbumLength = 2754, NumberOfTracks = 12, CopiesSold = 150000 },
                    new Album { Id = 5, RecordCompanyId = 4, BandId = 1, AlbumTitle = "Symbol of Life", YearOfPublishing = 2002, AlbumLength = 2492, NumberOfTracks = 11, CopiesSold = 240000 },
                    new Album { Id = 6, RecordCompanyId = 4, BandId = 1, AlbumTitle = "Paradise Lost", YearOfPublishing = 2005, AlbumLength = 2831, NumberOfTracks = 12, CopiesSold =  260000},
                    new Album { Id = 7, RecordCompanyId = 5, BandId = 1, AlbumTitle = "Faith Divides Us - Death Unites Us", YearOfPublishing = 2009, AlbumLength = 2762, NumberOfTracks = 10, CopiesSold = 300000 },
                    new Album { Id = 8, RecordCompanyId = 5, BandId = 1, AlbumTitle = "Tragic Idol", YearOfPublishing = 2012, AlbumLength = 2765, NumberOfTracks = 10, CopiesSold = 330000 },
                    new Album { Id = 9, RecordCompanyId = 6, BandId = 1, AlbumTitle = "Medusa", YearOfPublishing = 2017, AlbumLength = 2561, NumberOfTracks = 8, CopiesSold = 290000 },
                    new Album { Id = 10, RecordCompanyId = 7, BandId = 2, AlbumTitle = "Bloody Kisses", YearOfPublishing = 1993, AlbumLength = 4408, NumberOfTracks = 14, CopiesSold = 270000 },
                    new Album { Id = 11, RecordCompanyId = 7, BandId = 2, AlbumTitle = "October Rust", YearOfPublishing = 1996, AlbumLength = 4369, NumberOfTracks = 15, CopiesSold = 320000 },
                    new Album { Id = 12, RecordCompanyId = 5, BandId = 3, AlbumTitle = "Mandylion", YearOfPublishing = 1995, AlbumLength =3160 , NumberOfTracks = 8, CopiesSold = 180000 },
                    new Album { Id = 13, RecordCompanyId = 5, BandId = 3, AlbumTitle = "Nighttime Birds", YearOfPublishing = 1997, AlbumLength = 2924, NumberOfTracks = 9, CopiesSold = 160000 },
                    new Album { Id = 14, RecordCompanyId = 6, BandId = 4, AlbumTitle = "Slania", YearOfPublishing = 2008, AlbumLength = 2922, NumberOfTracks = 12, CopiesSold = 330000 },
                    new Album { Id = 15, RecordCompanyId = 6, BandId = 4, AlbumTitle = "Helvetios", YearOfPublishing = 2012, AlbumLength = 3552, NumberOfTracks = 17, CopiesSold = 290000 },
                    new Album { Id = 16, RecordCompanyId = 6, BandId = 4, AlbumTitle = "Irreligious", YearOfPublishing = 1996, AlbumLength = 2723, NumberOfTracks = 11, CopiesSold = 245000},
                    new Album { Id = 17, RecordCompanyId = 5, BandId = 5, AlbumTitle = "Sin/Pecado", YearOfPublishing = 1998, AlbumLength = 3713, NumberOfTracks = 13, CopiesSold = 240000 },
                    new Album { Id = 18, RecordCompanyId = 5, BandId = 5, AlbumTitle = "The Butterfly Effect", YearOfPublishing = 1999, AlbumLength = 3444, NumberOfTracks = 12, CopiesSold = 220000 },
                    new Album { Id = 19, RecordCompanyId = 8, BandId = 5, AlbumTitle = "Extinct", YearOfPublishing = 2015, AlbumLength = 2738, NumberOfTracks = 10, CopiesSold = 195000 },
                    new Album { Id = 20, RecordCompanyId = 5, BandId = 6, AlbumTitle = "Comalies", YearOfPublishing = 2002, AlbumLength = 3104, NumberOfTracks = 13, CopiesSold = 220000 },
                    new Album { Id = 21, RecordCompanyId = 5, BandId = 6, AlbumTitle = "Dark Adrenaline", YearOfPublishing = 2012, AlbumLength = 2710, NumberOfTracks = 12, CopiesSold = 310000 },
                    new Album { Id = 22, RecordCompanyId = 6, BandId = 7, AlbumTitle = "Clayman", YearOfPublishing = 2000, AlbumLength = 2624, NumberOfTracks = 11, CopiesSold = 280000 },
                    new Album { Id = 23, RecordCompanyId = 6, BandId = 7, AlbumTitle = "Come Clarity", YearOfPublishing = 2006, AlbumLength = 2886, NumberOfTracks = 13, CopiesSold = 330000 },
                    new Album { Id = 24, RecordCompanyId = 3, BandId = 8, AlbumTitle = "Far From the Sun", YearOfPublishing = 2003, AlbumLength = 2631, NumberOfTracks = 10, CopiesSold = 210000 },
                    new Album { Id = 25, RecordCompanyId = 6, BandId = 8, AlbumTitle = "Eclipse", YearOfPublishing = 2006, AlbumLength = 2507, NumberOfTracks = 10, CopiesSold = 220000 },
                    new Album { Id = 26, RecordCompanyId = 6, BandId = 8, AlbumTitle = "Silent Waters", YearOfPublishing = 2007, AlbumLength = 2794, NumberOfTracks = 10, CopiesSold = 340000 },
                    new Album { Id = 27, RecordCompanyId = 9, BandId = 8, AlbumTitle = "Atomic Fire", YearOfPublishing = 2022, AlbumLength = 3346, NumberOfTracks = 11, CopiesSold = 270000 },
                    new Album { Id = 28, RecordCompanyId = 5, BandId = 9, AlbumTitle = "Alive in Athens", YearOfPublishing = 1999, AlbumLength = 10806, NumberOfTracks = 31, CopiesSold = 350000 },
                    new Album { Id = 29, RecordCompanyId = 8, BandId = 9, AlbumTitle = "The Glorious Burden", YearOfPublishing = 2004, AlbumLength = 4727, NumberOfTracks = 12, CopiesSold = 230000 },
                    new Album { Id = 30, RecordCompanyId = 7, BandId = 10, AlbumTitle = "Wrath", YearOfPublishing = 2009, AlbumLength = 2692, NumberOfTracks = 11, CopiesSold = 182000 },
                    new Album { Id = 31, RecordCompanyId = 7, BandId = 10, AlbumTitle = "Resolution", YearOfPublishing = 2012, AlbumLength = 3381, NumberOfTracks = 14, CopiesSold = 178000 },
                    new Album { Id = 32, RecordCompanyId = 6, BandId = 11, AlbumTitle = "Reckoning Night", YearOfPublishing = 2004, AlbumLength = 3320, NumberOfTracks = 12, CopiesSold = 240000 },
                    new Album { Id = 33, RecordCompanyId = 6, BandId = 11, AlbumTitle = "Unia", YearOfPublishing = 2007, AlbumLength = 3515, NumberOfTracks = 12, CopiesSold = 217000 },
                    new Album { Id = 34, RecordCompanyId = 1, BandId = 12, AlbumTitle = "The Silent Enigma", YearOfPublishing = 1995, AlbumLength = 3277, NumberOfTracks = 9, CopiesSold = 170000 },
                    new Album { Id = 35, RecordCompanyId = 1, BandId = 12, AlbumTitle = "Alternative 4", YearOfPublishing = 1998, AlbumLength = 2697, NumberOfTracks = 10, CopiesSold = 270000 },
                    new Album { Id = 36, RecordCompanyId = 2, BandId = 12, AlbumTitle = "Judgement", YearOfPublishing = 1999, AlbumLength = 3416, NumberOfTracks = 13, CopiesSold = 220000 },
                    new Album { Id = 37, RecordCompanyId = 1, BandId = 13, AlbumTitle = "Tonight's Decision", YearOfPublishing = 1999, AlbumLength = 3374, NumberOfTracks = 11, CopiesSold = 90000 },
                    new Album { Id = 38, RecordCompanyId = 1, BandId = 13, AlbumTitle = "Last Fair Deal Gone", YearOfPublishing = 2001, AlbumLength = 3039, NumberOfTracks = 11, CopiesSold = 105000 },
                    new Album { Id = 39, RecordCompanyId = 8, BandId = 14, AlbumTitle = "Ot serdstsa k nebu", YearOfPublishing = 2007, AlbumLength = 3651, NumberOfTracks = 12, CopiesSold = 137000 },
                    new Album { Id = 40, RecordCompanyId = 8, BandId = 14, AlbumTitle = "Slove", YearOfPublishing = 2011, AlbumLength = 3444, NumberOfTracks = 14, CopiesSold = 217650 },
                    new Album { Id = 41, RecordCompanyId = 7, BandId = 15, AlbumTitle = "Supremacy", YearOfPublishing = 2006, AlbumLength = 2183, NumberOfTracks = 13, CopiesSold = 210000 },
                    new Album { Id = 42, RecordCompanyId = 6, BandId = 15, AlbumTitle = "The Concrete Confessional", YearOfPublishing = 2016, AlbumLength = 2008, NumberOfTracks = 13, CopiesSold = 185000 }

            });

            //seed data for merchandise, will not have for all bands
            modelBuilder.Entity<Merchandise>().HasData(new Merchandise[] {
                new Merchandise { Id = 1, AlbumId = 1, TypeOfMerch = MerchType.Clothing, MerchName ="T-shirt" , SizeOfMerch = MerchSize.XL, Price = 34.49, Available =true },
                new Merchandise { Id = 2, AlbumId = 1, TypeOfMerch = MerchType.Clothing, MerchName = "T-shirt", SizeOfMerch = MerchSize.XXL, Price = 34.49, Available =false },
                new Merchandise { Id = 3, AlbumId = 2, TypeOfMerch = MerchType.Clothing, MerchName = "T-shirt", SizeOfMerch = MerchSize.XL, Price = 29.49, Available = true },
                new Merchandise { Id = 4, AlbumId = 3, TypeOfMerch = MerchType.Badge, MerchName = "Badge", SizeOfMerch = MerchSize.NULL, Price = 15.25, Available = true },
                new Merchandise { Id = 5, AlbumId = 3, TypeOfMerch = MerchType.Clothing, MerchName = "T-shirt", SizeOfMerch = MerchSize.M, Price = 32.29, Available =false },
                new Merchandise { Id = 6, AlbumId = 3, TypeOfMerch = MerchType.Clothing, MerchName = "T-shirt", SizeOfMerch = MerchSize.L, Price = 32.29, Available = false },
                new Merchandise { Id = 7, AlbumId = 3, TypeOfMerch = MerchType.Clothing, MerchName = "T-shirt", SizeOfMerch = MerchSize.XL, Price = 32.29, Available = true },
                new Merchandise { Id = 8, AlbumId = 4, TypeOfMerch = MerchType.Clothing, MerchName = "Jacket", SizeOfMerch = MerchSize.XL, Price = 65.39, Available = false },
                new Merchandise { Id = 9, AlbumId = 5, TypeOfMerch = MerchType.Other, MerchName = "Pick", SizeOfMerch =MerchSize.NULL , Price = 4.99, Available = false },
                new Merchandise { Id = 10, AlbumId = 5, TypeOfMerch = MerchType.Clothing, MerchName = "Hoodie", SizeOfMerch = MerchSize.XL, Price = 48.99, Available = false },
                new Merchandise { Id = 11, AlbumId = 6, TypeOfMerch = MerchType.Mug, MerchName = "Paradise Lost Mug", SizeOfMerch =MerchSize.NULL , Price = 9.99, Available = true},
                new Merchandise { Id = 12, AlbumId = 6, TypeOfMerch = MerchType.Clothing, MerchName = "Hoodie", SizeOfMerch = MerchSize.XXL, Price = 49.99, Available = true },
                new Merchandise { Id = 13, AlbumId = 7, TypeOfMerch = MerchType.Clothing, MerchName = "T-shirt", SizeOfMerch = MerchSize.L, Price = 29.99, Available = false },
                new Merchandise { Id = 14, AlbumId = 7, TypeOfMerch = MerchType.Clothing, MerchName = "T-shirt", SizeOfMerch = MerchSize.XL, Price = 29.99, Available = false },
                new Merchandise { Id = 15, AlbumId = 8, TypeOfMerch = MerchType.Clothing, MerchName = "T-shirt", SizeOfMerch = MerchSize.M, Price = 31.49, Available = false },
                new Merchandise { Id = 16, AlbumId = 8, TypeOfMerch = MerchType.Clothing, MerchName = "Hoodie", SizeOfMerch = MerchSize.S, Price = 48.49, Available = true },
                new Merchandise { Id = 17, AlbumId = 9, TypeOfMerch = MerchType.Clothing, MerchName = "Hoodie", SizeOfMerch = MerchSize.M, Price = 53.49, Available = true },
                new Merchandise { Id = 18, AlbumId = 9, TypeOfMerch = MerchType.Clothing, MerchName = "Hoodie", SizeOfMerch = MerchSize.L, Price = 53.49, Available = true },
                new Merchandise { Id = 19, AlbumId = 9, TypeOfMerch = MerchType.Clothing, MerchName = "Hoodie", SizeOfMerch = MerchSize.XL, Price = 53.49, Available = true },
                new Merchandise { Id = 20, AlbumId = 10, TypeOfMerch = MerchType.Clothing, MerchName = "T-shirt", SizeOfMerch = MerchSize.L , Price = 49.99, Available = true },
                new Merchandise { Id = 21, AlbumId = 10, TypeOfMerch = MerchType.Clothing, MerchName = "T-shirt", SizeOfMerch = MerchSize.XL, Price = 49.99, Available = false },
                new Merchandise { Id = 22, AlbumId = 10, TypeOfMerch = MerchType.Clothing, MerchName = "Hoodie", SizeOfMerch = MerchSize.XL, Price = 65.49, Available = true },
                new Merchandise { Id = 23, AlbumId = 10, TypeOfMerch = MerchType.Clothing, MerchName = "Jacket", SizeOfMerch = MerchSize.XXL, Price = 84.39, Available = false },
                new Merchandise { Id = 24, AlbumId = 11, TypeOfMerch = MerchType.Clothing, MerchName = "Hoodie", SizeOfMerch = MerchSize.S, Price = 58.49, Available = false },
                new Merchandise { Id = 25, AlbumId = 11, TypeOfMerch = MerchType.Clothing, MerchName = "Hoodie", SizeOfMerch = MerchSize.M, Price = 58.99, Available = true },
                new Merchandise { Id = 26, AlbumId = 11, TypeOfMerch = MerchType.Clothing, MerchName = "Hoodie", SizeOfMerch = MerchSize.L, Price = 59.49, Available = false },
                new Merchandise { Id = 27, AlbumId = 12, TypeOfMerch = MerchType.Clothing, MerchName = "T-shirt", SizeOfMerch = MerchSize.M, Price = 18.99, Available = false },
                new Merchandise { Id = 28, AlbumId = 12, TypeOfMerch = MerchType.Clothing, MerchName = "T-shirt", SizeOfMerch = MerchSize.L, Price = 19.49, Available = false },
                new Merchandise { Id = 29, AlbumId = 12, TypeOfMerch = MerchType.Clothing, MerchName = "T-shirt", SizeOfMerch = MerchSize.XXL, Price = 19.99, Available = true },
                new Merchandise { Id = 30, AlbumId = 12, TypeOfMerch = MerchType.Clothing, MerchName = "T-shirt", SizeOfMerch = MerchSize.XXXL, Price = 20.49, Available = true },
                new Merchandise { Id = 31, AlbumId = 13, TypeOfMerch = MerchType.Mug, MerchName = "Gathering Mug", SizeOfMerch = MerchSize.NULL, Price = 8.99, Available = true },
                new Merchandise { Id = 32, AlbumId = 13, TypeOfMerch = MerchType.Poster, MerchName = "Concert Tour Poster", SizeOfMerch = MerchSize.NULL, Price = 3.49 , Available = true },
                new Merchandise { Id = 33, AlbumId = 14, TypeOfMerch = MerchType.Clothing, MerchName = "T-shirt", SizeOfMerch = MerchSize.S, Price = 17.99, Available = true },
                new Merchandise { Id = 34, AlbumId = 14, TypeOfMerch = MerchType.Clothing, MerchName = "T-shirt", SizeOfMerch = MerchSize.M, Price = 18.49, Available = true },
                new Merchandise { Id = 35, AlbumId = 14, TypeOfMerch = MerchType.Clothing, MerchName = "T-shirt", SizeOfMerch = MerchSize.L, Price = 18.99, Available = true },
                new Merchandise { Id = 36, AlbumId = 14, TypeOfMerch = MerchType.Clothing, MerchName = "T-shirt", SizeOfMerch = MerchSize.XL, Price = 19.49, Available = true },
                new Merchandise { Id = 37, AlbumId = 15, TypeOfMerch = MerchType.Clothing, MerchName = "Hoodie", SizeOfMerch = MerchSize.XL, Price = 38.49, Available = true },
                new Merchandise { Id = 38, AlbumId = 15, TypeOfMerch = MerchType.Clothing, MerchName = "Hoodie", SizeOfMerch = MerchSize.XXL, Price = 38.99, Available = false },
                new Merchandise { Id = 39, AlbumId = 16, TypeOfMerch = MerchType.Badge, MerchName = "Badge", SizeOfMerch =MerchSize.NULL , Price = 5.49, Available = true },
                new Merchandise { Id = 40, AlbumId = 16, TypeOfMerch = MerchType.Bag, MerchName = "Bag", SizeOfMerch = MerchSize.NULL, Price = 22.99, Available = false },
                new Merchandise { Id = 41, AlbumId = 16, TypeOfMerch = MerchType.Mug, MerchName = "Moonspell Mug", SizeOfMerch = MerchSize.NULL, Price = 8.99, Available = false },
                new Merchandise { Id = 42, AlbumId = 17, TypeOfMerch = MerchType.Clothing, MerchName = "T-shirt", SizeOfMerch = MerchSize.M, Price = 13.49, Available = false },
                new Merchandise { Id = 43, AlbumId = 17, TypeOfMerch = MerchType.Clothing, MerchName = "T-shirt", SizeOfMerch = MerchSize.L, Price = 13.99, Available = true },
                new Merchandise { Id = 44, AlbumId = 17, TypeOfMerch = MerchType.Clothing, MerchName = "T-shirt", SizeOfMerch = MerchSize.XL, Price = 14.19, Available = true },
                new Merchandise { Id = 45, AlbumId = 17, TypeOfMerch = MerchType.Clothing, MerchName = "T-shirt", SizeOfMerch = MerchSize.XXL, Price = 14.39, Available = false },
                new Merchandise { Id = 46, AlbumId = 18, TypeOfMerch = MerchType.Other, MerchName = "Pick", SizeOfMerch = MerchSize.NULL , Price = 4.39, Available = true},
                new Merchandise { Id = 47, AlbumId = 18, TypeOfMerch = MerchType.Clothing, MerchName = "Jacket", SizeOfMerch = MerchSize.M, Price = 58.99, Available = false},
                new Merchandise { Id = 48, AlbumId = 19, TypeOfMerch = MerchType.Clothing, MerchName = "Hoodie", SizeOfMerch = MerchSize.S, Price = 38.29, Available = true},
                new Merchandise { Id = 49, AlbumId = 19, TypeOfMerch = MerchType.Clothing, MerchName = "Hoodie", SizeOfMerch = MerchSize.M, Price = 38.29, Available = true},
                new Merchandise { Id = 50, AlbumId = 19, TypeOfMerch = MerchType.Clothing, MerchName = "Hoodie", SizeOfMerch = MerchSize.L, Price = 38.29, Available = true},
                new Merchandise { Id = 51, AlbumId = 20, TypeOfMerch = MerchType.Bag, MerchName = "Comalies Bag", SizeOfMerch =MerchSize.NULL , Price = 24.99, Available = false },
                new Merchandise { Id = 52, AlbumId = 20, TypeOfMerch = MerchType.Mug, MerchName = "Lacuna Coil Mug", SizeOfMerch = MerchSize.NULL, Price = 6.99, Available = false },
                new Merchandise { Id = 53, AlbumId = 21, TypeOfMerch = MerchType.Bag, MerchName = "Dark Adrenaline Bag", SizeOfMerch = MerchSize.NULL, Price = 32.49, Available = false},
                new Merchandise { Id = 54, AlbumId = 21, TypeOfMerch = MerchType.Other, MerchName = "Pick", SizeOfMerch = MerchSize.NULL, Price = 2.99, Available = false }


            });
        }
    }
}

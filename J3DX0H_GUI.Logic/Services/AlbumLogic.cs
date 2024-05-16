using J3DX0H_GUI.Logic.Interfaces;
using J3DX0H_GUI.Models;
using J3DX0H_GUI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3DX0H_GUI.Logic.Services
{
    public class Eredmeny
    {
        public string Name { get; set; }
        public int Sold { get; set; }

        public Eredmeny()
        {

        }
    }

    public class Eredmeny2
    {
        public string Name { get; set; }

        public Eredmeny2() { }
    }


    public class AlbumIdAlreadyExistsException : Exception
    {
        public AlbumIdAlreadyExistsException(string message) : base(message)
        {
        }
    }
    public class BandIdAlreadyExistsException : Exception
    {
        public BandIdAlreadyExistsException(string message) : base(message)
        {
        }
    }
    public class RecordCompanyIdAlreadyExistsException : Exception
    {
        public RecordCompanyIdAlreadyExistsException(string message) : base(message)
        {
        }
    }
    public class MerchandiseIdAlreadyExistsException : Exception
    {
        public MerchandiseIdAlreadyExistsException(string message) : base(message)
        {
        }
    }

    public class AlbumLogic : IAlbumLogic
    {
        //A create method affects multiple tables, therefore the tables with higher relations need to be shown
        IRepository<Album> repo;

        public AlbumLogic(IRepository<Album> repo)
        {
            this.repo = repo;
        }

        public IEnumerable<Album> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public Album Read(int id)
        {
            var album = this.repo.Read(id);
            if (album == null)
            {
                throw new ArgumentException("No such Album exist.");
            }
            else
            {
                return this.repo.Read(id);
            }

        }

        public void Update(Album album)
        {
            this.repo.Update(album);
        }

        public void Create(Album album)
        {
            if (album == null)
            {
                throw new ArgumentNullException($"Entity {album} does not contain any values, is null.");
            }
            if (string.IsNullOrEmpty(album.AlbumTitle))
            {
                throw new ArgumentException("Album must have a title.");
            }
            else
            {
                var albumtitle = this.repo.ReadAll().FirstOrDefault(x => x.AlbumTitle == album.AlbumTitle);
                if (albumtitle == null)
                {
                    this.repo.Create(album);

                }
                else
                {
                    throw new ArgumentException($"{album.AlbumTitle} already exists as record.");
                }
            }
        }
        public void Delete(int id)
        {
            var album = this.repo.Read(id);
            if (album == null)
            {
                throw new ArgumentException($"No such album exists, delete cannot be performed.");
            }
            else
            {
                this.repo.Delete(id);
            }

        }
        //returns each RecordCompany + Sum number of sold Copies of albums
        public IEnumerable<Eredmeny> CopiesSold(IRepository<RecordCompany> rRepo)
        {
            IRepository<RecordCompany> repo2 = rRepo;

            var part1 = repo.ReadAll().ToList();
            var part2 = repo2.ReadAll().ToList();

            var result1 = part1.OrderBy(t => t.RecordCompanyId)
                .GroupBy(t => t.RecordCompanyId)
                .Select(t => new
                {
                    RecordCompanyId = t.Key,
                    CopiesSold = t.Sum(t => t.CopiesSold)
                }).ToList();

            var result2 = from x in result1
                          join y in part2 on x.RecordCompanyId equals y.Id
                          select (new Eredmeny
                          {
                              Name = y.Name,
                              Sold = x.CopiesSold
                          });

            return result2;
        }


        //returns each Band + sum number of sold Copies of albums
        public IEnumerable<Eredmeny> CopiesSold2(IRepository<Band> bRepo)
        {

            IRepository<Band> repo2 = bRepo;
            var part1 = repo.ReadAll().ToList();

            var part2 = repo2.ReadAll().ToList();

            var result1 = part1.OrderBy(t => t.BandId)
                .GroupBy(t => t.BandId)
                .Select(t => new
                {
                    BandId = t.Key,
                    CopiesSold = t.Sum(t => t.CopiesSold)
                }).ToList();


            var result2 = from x in result1
                          join y in part2 on x.BandId equals y.Id
                          select (new Eredmeny
                          {
                              Name = y.Name,
                              Sold = x.CopiesSold
                          });

            return result2;
        }

        //returns with those bands who have mugs as merch
        public IEnumerable<Eredmeny2> HasMug(IRepository<Band> bRepo)
        {
            var part1 = repo.ReadAll().ToList();
            var part2 = bRepo.ReadAll().ToList();

            var result1 = part1.OrderBy(t => t.Id)
                .SelectMany(x => x.Merchandises)
                .Where(x => x.TypeOfMerch.Equals(MerchType.Mug))
                .Select(t => new
                {
                    AlbumId = t.AlbumId,
                    MerchName = t.MerchName
                });

            var result2 = from x in part1
                          join y in result1 on x.Id equals y.AlbumId
                          select new
                          {
                              BandId = x.BandId,
                              AlbumId = y.AlbumId,
                              MerchName = y.MerchName
                          };

            var result3 = from x in result2
                          join y in part2 on x.BandId equals y.Id
                          select (new Eredmeny2
                          {
                              Name = y.Name
                          });

            var result4 = result3.GroupBy(t => t.Name)
                            .Select(t => (new Eredmeny2
                            {
                                Name = t.Key
                            })).ToList();

            return result4;

        }

        //returns with those bands names who have among their merch XXL sized T-shirts
        public IEnumerable<Eredmeny2> HasTshirtXXL(IRepository<Band> bRepo)
        {
            var part1 = repo.ReadAll().ToList();
            var part2 = bRepo.ReadAll().ToList();

            var result1 = part1.OrderBy(t => t.Id)
                .SelectMany(x => x.Merchandises)
                //.Where(x => x.TypeOfMerch.Equals(MerchType.Clothing))
                .Where(x => x.MerchName == "T-shirt")
                .Where(x => x.SizeOfMerch == MerchSize.XXL)
                .Select(t => new
                {
                    AlbumId = t.AlbumId,
                    MerchName = t.MerchName
                });

            var result2 = from x in part1
                          join y in result1 on x.Id equals y.AlbumId
                          select new
                          {
                              BandId = x.BandId,
                              AlbumId = y.AlbumId,
                              MerchName = y.MerchName
                          };

            var result3 = from x in result2
                          join y in part2 on x.BandId equals y.Id
                          select (new Eredmeny2
                          {
                              Name = y.Name
                          });

            var result4 = result3.GroupBy(t => t.Name)
                            .Select(t => (new Eredmeny2
                            {
                                Name = t.Key
                            })).ToList();

            return result4;

        }
        //returns all those band names who have sold over 500K albums 
        public IEnumerable<Eredmeny> Over500K(IRepository<Band> bRepo)
        {
            var part1 = repo.ReadAll().ToList();

            var part2 = bRepo.ReadAll().ToList();

            var result1 = part1.OrderBy(t => t.BandId)
                .GroupBy(t => t.BandId)
                .Select(t => new
                {
                    BandId = t.Key,
                    CopiesSold = t.Sum(t => t.CopiesSold)
                }).ToList();

            var result2 = result1
                .Where(x => x.CopiesSold >= 500000)
                .Select(t => new
                {
                    BandId = t.BandId,
                    CopiesSold = t.CopiesSold
                });

            var result3 = from x in result2
                          join y in part2 on x.BandId equals y.Id
                          select (new Eredmeny
                          {
                              Name = y.Name,
                              Sold = x.CopiesSold
                          });

            return result3;
        }
    }
}

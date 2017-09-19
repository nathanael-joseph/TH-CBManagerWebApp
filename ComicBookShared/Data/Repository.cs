using ComicBookShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ComicBookShared.Data
{
    public class Repository
    {
        private Context _context = null;
        public Repository(Context context)
        {
            _context = context;
        }
       
        public IList<Series> GetSeriesList()
        {
            return _context.Series.OrderBy(s => s.Title).ToList();
        }

        public IList<Artist> GetArtistsList()
        {
            return _context.Artists.OrderBy(a => a.Name).ToList();
        }

        public IList<Role> GetRolesList()
        {
            return _context.Roles.OrderBy(r => r.Name).ToList();
        }

        public void AddComicBookArtist(ComicBookArtist comicBookArtist)
        {
            _context.ComicBookArtists.Add(comicBookArtist);
            _context.SaveChanges();
        }

        public ComicBookArtist GetComicBookArtist(int id)
        {
            return _context.ComicBookArtists
                .Include(cba => cba.Artist)
                .Include(cba => cba.Role)
                .Include(cba => cba.ComicBook.Series)
                .Where(cba => cba.Id == id)
                .SingleOrDefault();
        }

        public void DeleteComicBookArtist(int id)
        {
            var comicBookArtist = new ComicBookArtist()
            {
                Id = id
            };
            _context.Entry(comicBookArtist).State = EntityState.Deleted;
            _context.SaveChanges();
        }


    }
}

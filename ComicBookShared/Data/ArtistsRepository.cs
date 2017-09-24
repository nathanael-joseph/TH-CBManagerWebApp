using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicBookShared.Models;
using System.Data.Entity;

namespace ComicBookShared.Data
{
    public class ArtistsRepository : BaseRepository<Artist>
    {
        public ArtistsRepository(Context context) : base(context) { }

        public override Artist Get(int id, bool IncludeRelatedEntities = true)
        {
            var artists = Context.Artists.AsQueryable();
            if(IncludeRelatedEntities)
            {
                artists = artists
                    .Include(s => s.ComicBooks.Select(a => a.ComicBook.Series))
                    .Include(s => s.ComicBooks.Select(a => a.Role));                   
            }
            return artists.Where(a => a.Id == id)
                .SingleOrDefault();
        }

        public override IList<Artist> GetList()
        {
            return Context.Artists
                .OrderBy(a => a.Name)
                .ToList();
        }  
        
        public bool ArtistsHasName(int id, string name)
        {
            return Context.Artists.Any(a => a.Id != id && a.Name == name);
        }
    }
}

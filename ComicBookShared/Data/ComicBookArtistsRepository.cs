using ComicBookShared.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookShared.Data
{
    public class ComicBookArtistsRepository : BaseRepository<ComicBookArtist>
    {

        public ComicBookArtistsRepository(Context context) : base(context) { }
        
        public override ComicBookArtist Get(int id, bool IncludeRelatedEntities = true)
        {
            var comicBookArtists = Context.ComicBookArtists.AsQueryable();
            if(IncludeRelatedEntities)
            {
                comicBookArtists = comicBookArtists
                    .Include(cba => cba.Artist)
                    .Include(cba => cba.Role)
                    .Include(cba => cba.ComicBook.Series);
            }
            return   comicBookArtists
                    .Where(cba => cba.Id == id)
                    .SingleOrDefault();
        }

        public override IList<ComicBookArtist> GetList()
        {
            throw new NotImplementedException();
        }
    }
}

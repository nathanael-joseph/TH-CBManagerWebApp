using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicBookShared.Models;
using System.Data.Entity;

namespace ComicBookShared.Data
{
    public class SeriesRepository : BaseRepository<Series>
    {
        public SeriesRepository(Context context) : base(context) { }

        public override Series Get(int id, bool IncludeRelatedEntities = true)
        {
            var series = Context.Series.AsQueryable();
            if(IncludeRelatedEntities)
            {
                series = series.Include(s => s.ComicBooks);
            }
            return series.Where(s => s.Id == id).SingleOrDefault();
            
        }

        public override IList<Series> GetList()
        {
            return Context.Series
                .OrderBy(s => s.Title)
                .ToList();
        }

        public bool SeriesHasTitle(int SeriesId, string title)
        {
            return Context.Series
                .Any(s => s.Id != SeriesId && s.Title == title);
        }
    }
}

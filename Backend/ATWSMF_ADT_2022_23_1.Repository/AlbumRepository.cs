using ATWSMF_ADT_2022_23_1.Data;
using ATWSMF_ADT_2022_23_1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ATWSMF_ADT_2022_23_1.Repository
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(DbContext context) : base(context)
        {

        }

        public override Album GetOne(int id)
        {
            return (base.context as SongContext).Albums.FirstOrDefault(c => c.Id == id);
        }
    }
}

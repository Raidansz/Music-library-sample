using ATWSMF_ADT_2022_23_1.Data;
using ATWSMF_ADT_2022_23_1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATWSMF_ADT_2022_23_1.Repository
{
    public class SongRepository : Repository<Song>, ISongRepository
    {
        public SongRepository(DbContext context) : base(context)
        {
        }

        public override Song GetOne(int id)
        {
            return (base.context as SongContext).Songs.FirstOrDefault(c => c.Id == id);
        }
    }
}

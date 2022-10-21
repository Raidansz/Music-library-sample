using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATWSMF_ADT_2022_23_1.Models
{
   public  class Song
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Duration { get; set; }
        //Navigation prop
        public virtual Artist Artist { get; set; }
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }

    }
}

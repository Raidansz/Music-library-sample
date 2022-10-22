using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATWSMF_ADT_2022_23_1.Models
{
   public  class Album
    {
        public string Name { get; set; }
        public int Id { get; set; }
        // public DateTime Release_date { get; set; }


        //Navigation prop
        public virtual ICollection<Song> Songs { get; set; }

        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ATWSMF_SGUI_2022_23_2.Models
{
    [Table("Songs")]
    public  class Song
    {

        public string Name { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Duration { get; set; }
        //Navigation prop
        
        public virtual Artist Artist { get; set; }
        //public int ArtistId { get; set; } this causes a cycle 
        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }

    }
}

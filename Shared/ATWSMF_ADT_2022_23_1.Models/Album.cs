using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ATWSMF_ADT_2022_23_1.Models
{
    [Table("Albums")]
    public  class Album
    {
        public string Name { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        // public DateTime Release_date { get; set; }


        //Navigation prop
        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Song> Songs { get; set; }

        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ATWSMF_ADT_2022_23_1.Models
{
    [Table("Artists")]
    public  class Artist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        //public DateTime Age { get; set; }


        //Navigation prop
        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Song> Songs { get; set; }
        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Album> Albums { get; set; }
    }
}

using ATWSMF_ADT_2022_23_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATWSMF_ADT_2022_23_1.Logic
{
    public interface IArtistLogic
    {
        Artist GetOneArtist(int id);
        
        IList<Artist> GetAllArtist();
        void AddArtist(Artist newArtist);
    }
}

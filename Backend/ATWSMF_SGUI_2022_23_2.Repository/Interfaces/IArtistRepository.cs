using ATWSMF_SGUI_2022_23_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ATWSMF_SGUI_2022_23_2.Repository.Interfaces
{
    public interface IArtistRepository : IRepository<Artist>
    {

        void AddNewArtist(Artist artist);
        void UpdateArtist(Artist artist);
        void DeleteArtistById(int id);
        void DeleteArtistByName(string name);
    }
}

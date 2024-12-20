﻿using ATWSMF_SGUI_2022_23_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ATWSMF_SGUI_2022_23_2.Repository.Interfaces
{
    public interface ISongRepository : IRepository<Song>
    {
        void ChangeTitle(int id, string newTitle);
        void AddNewSong(Song song);
        void UpdateSong(Song song);
        void DeleteSongById(int id);
        void DeleteSongByTitle(string title);
    }
}

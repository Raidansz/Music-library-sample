﻿using ATWSMF_ADT_2022_23_1.Data;
using ATWSMF_ADT_2022_23_1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ATWSMF_ADT_2022_23_1.Repository
{
    public class SongRepository : Repository<Song>, ISongRepository
    {
        public SongRepository(DbContext context) : base(context)
        {
        }

        public void AddNewSong(Song song)
        {
            context.Add(song);
            context.SaveChanges();
        }

        public void ChangeTitle(int id, string newTitle)
        {
            var song = GetOne(id);
            song.Name = newTitle;
            context.SaveChanges();
        }

        public void DeleteSongById(int id)
        {
            var toDelete = GetOne(id);
            context.Remove(toDelete);
            context.SaveChanges();
        }

        public void DeleteSongByTitle(string title)
        {
            var toDelete = GetOneByName(title);
            context.Remove(toDelete);
            context.SaveChanges();
        }

        public override Song GetOne(int id)
        {
            return (base.context as SongContext).Songs.FirstOrDefault(c => c.Id == id);
        }

        public override Song GetOneByName(string title)
        {
            return (base.context as SongContext).Songs.FirstOrDefault(c => c.Name == title);
        }

        public void UpdateSong(Song song)
        {
            var toUpdate = GetOne(song.Id);

            toUpdate = song;
           

            context.SaveChanges();
        }
    }
}

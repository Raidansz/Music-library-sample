using ATWSMF_ADT_2022_23_1.Logic;
using ATWSMF_ADT_2022_23_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ATWSMF_ADT_2022_23_1.Endpoint.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SongController: ControllerBase
    {
      
            ISongLogic SongLogic;

            public SongController(ISongLogic songLogic)
            {
                SongLogic = songLogic;
            }

        // GET: api/Song
        [HttpGet]
            public IEnumerable<Song> Get()
            {
                return this.SongLogic.GetAllSongs();
            }

        // GET: api/Song/5
        [HttpGet("{id}")]
            public Song Get(int id)
            {
                return this.SongLogic.GetOneSong(id);
            }

        // POST: api/Song
        [HttpPost]
        //TODO ADD SONG
        public void Post([FromBody] Song song)
        {
            this.SongLogic.AddNewSong(song);
       }

        //TODO
        // PUT: api/Song/5
        [HttpPut("{id}")]
        //public void Put(int id, [FromBody] Song value)
        //{

        //    this.SongLogic.UpdateCommentContentById(id, value.Content);
        //}

        // DELETE: api/Comment/5
        [HttpDelete("{id}")]
            public void Delete(int id)
            {
                this.SongLogic.DeleteSong(id);
            }
        }
    }

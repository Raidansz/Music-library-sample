using ATWSMF_SGUI_2022_23_2.Logic.Interfaces;
using ATWSMF_SGUI_2022_23_2.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ATWSMF_SGUI_2022_23_2.Endpoint.Controllers
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


        // GET
        #region
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

        #endregion


        // POST
        #region
        // POST: api/Song
        [HttpPost]
        
        public void Post([FromBody] Song song)
        {
            this.SongLogic.AddNewSong(song);
        }
        #endregion

        // PUT
        #region
        
        // PUT: api/Song/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

            this.SongLogic.ChangeSongTitle(id,value);
            
        }
        #endregion

        // DELETE
        #region
        // DELETE: api/Song/5
        [HttpDelete("{id}")]
            public void Delete(int id)
            {
                this.SongLogic.DeleteSong(id);
            }
        #endregion
    }
}

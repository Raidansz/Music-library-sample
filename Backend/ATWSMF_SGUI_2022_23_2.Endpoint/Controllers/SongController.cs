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
    public class SongController : ControllerBase
    {
        private readonly ISongLogic _songLogic;

        public SongController(ISongLogic songLogic)
        {
            _songLogic = songLogic;
        }

        // GET: api/Song
        [HttpGet]
        public IEnumerable<Song> Get()
        {
            return _songLogic.GetAllSongs();
        }

        // GET: api/Song/5
        [HttpGet("{id}")]
        public ActionResult<Song> Get(int id)
        {
            var song = _songLogic.GetOneSong(id);
            if (song == null)
            {
                return NotFound();
            }
            return song;
        }

        // POST: api/Song
        [HttpPost]
        public ActionResult<Song> Post([FromBody] Song song)
        {
            _songLogic.AddNewSong(song);
            return CreatedAtAction("Get", new { id = song.Id }, song);
        }

        // PUT: api/Song/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            _songLogic.ChangeSongTitle(id, value);
            return NoContent();
        }

        // DELETE: api/Song/5
        [HttpDelete("{id}")]
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult Delete(int id)
        {
            var song = _songLogic.GetOneSong(id);
            if (song == null)
            {
                return NotFound();
            }
            _songLogic.DeleteSong(id);
            return NoContent();
        }
    }
}





















//using ATWSMF_SGUI_2022_23_2.Logic.Interfaces;
//using ATWSMF_SGUI_2022_23_2.Models;
//using Microsoft.AspNetCore.Cors;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;

//namespace ATWSMF_SGUI_2022_23_2.Endpoint.Controllers
//{

//    [Route("api/[controller]")]
//    [ApiController]

//    public class SongController: ControllerBase
//    {
//            ISongLogic SongLogic;

//            public SongController(ISongLogic songLogic)
//            {
//                SongLogic = songLogic;
//            }


//        // GET
//        #region
//        // GET: api/Song
//        [HttpGet]
//            public IEnumerable<Song> Get()
//            {
//                return this.SongLogic.GetAllSongs();
//            }

//        // GET: api/Song/5
//        [HttpGet("{id}")]
//            public Song Get(int id)
//            {
//                return this.SongLogic.GetOneSong(id);
//            }

//        #endregion


//        // POST
//        #region
//        // POST: api/Song
//        [HttpPost]

//        public void Post([FromBody] Song song)
//        {
//            this.SongLogic.AddNewSong(song);
//        }
//        #endregion

//        // PUT
//        #region

//        // PUT: api/Song/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {

//            this.SongLogic.ChangeSongTitle(id,value);

//        }
//        #endregion

//        // DELETE
//        #region
//        // DELETE: api/Song/5
//        [HttpDelete("{id}")]
//        [EnableCors("AllowSpecificOrigin")]
//        public void Delete(int id)
//            {
//                this.SongLogic.DeleteSong(id);
//            }
//        #endregion
//    }
//}

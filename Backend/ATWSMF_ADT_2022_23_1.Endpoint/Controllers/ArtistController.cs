using ATWSMF_ADT_2022_23_1.Logic;
using ATWSMF_ADT_2022_23_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ATWSMF_ADT_2022_23_1.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController: ControllerBase
    {
        IArtistLogic ArtistLogic;

        public ArtistController(IArtistLogic artistLogic)
        {
            ArtistLogic = artistLogic;
        }

        // GET: api/Artist
        [HttpGet]
        public IEnumerable<Artist> Get()
        {
            return this.ArtistLogic.GetAllArtist();
        }

        // GET: api/Artist/5
        [HttpGet("{id}")]
        public Artist Get(int id)
        {
            return this.ArtistLogic.GetOneArtist(id);
        }

        // POST: api/Artist
        [HttpPost]
        //TODO ADD SONG
        public void Post([FromBody] Artist value)
        {
            this.ArtistLogic.AddArtist(value);
        }

        //TODO
        // PUT: api/Comment/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] Song value)
        //{

        //    this.SongLogic.UpdateCommentContentById(id, value.Content);
        //}


        //TODO

        // DELETE: api/Comment/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    this.ArtistLogic.Dele
        //}
    }

}


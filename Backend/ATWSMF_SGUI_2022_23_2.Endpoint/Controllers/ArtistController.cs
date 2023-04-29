using ATWSMF_SGUI_2022_23_2.Logic.Interfaces;
using ATWSMF_SGUI_2022_23_2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ATWSMF_SGUI_2022_23_2.Endpoint.Controllers
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

        // GET
        #region
        // GET: api/Artist
        [HttpGet]
        public IEnumerable<Artist> Get()
        {
            return this.ArtistLogic.GetAllArtists();
        }

        // GET: api/Artist/5
        [HttpGet("{id}")]
        public Artist Get(int id)
        {
            return this.ArtistLogic.GetOneArtist(id);
        }

        #endregion


        // POST
        #region
        // POST: api/Artist
        [HttpPost]

        public void Post([FromBody] Artist artist)
        {
            this.ArtistLogic.AddArtist(artist);
        }
        #endregion

        // PUT
        #region

        // PUT: api/Artist/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

            var artist = this.ArtistLogic.GetOneArtist(id);
            artist.Name = value;
            this.ArtistLogic.UpdateArtist(artist);

        }
        #endregion

        // DELETE
        #region
        // DELETE: api/Artist/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.ArtistLogic.DeleteArtist(id);
        }
        #endregion
    }

}


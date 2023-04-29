using ATWSMF_SGUI_2022_23_2.Logic.Interfaces;
using ATWSMF_SGUI_2022_23_2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ATWSMF_SGUI_2022_23_2.Endpoint.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        IAlbumLogic AlbumLogic;

        public AlbumController(IAlbumLogic albumLogic)
        {
            AlbumLogic = albumLogic;
        }




        // GET
        #region
        // GET: api/Album
        [HttpGet]
        public IEnumerable<Album> Get()
        {
            return this.AlbumLogic.GetAllAlbums();
        }

        // GET: api/Album/5
        [HttpGet("{id}")]
        public Album Get(int id)
        {
            return this.AlbumLogic.GetOneAlbum(id);
        }

        #endregion


        // POST
        #region
        // POST: api/Album
        [HttpPost]

        public void Post([FromBody] Album album)
        {
            this.AlbumLogic.AddNewAlbum(album);
        }
        #endregion

        // PUT
        #region

        // PUT: api/Album/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

            var album = this.AlbumLogic.GetOneAlbum(id);
            album.Name = value;
            this.AlbumLogic.UpdateAlbum(album);

        }
        #endregion

        // DELETE
        #region
        // DELETE: api/Album/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.AlbumLogic.DeleteAlbum(id);
        }
        #endregion
    }

}
    

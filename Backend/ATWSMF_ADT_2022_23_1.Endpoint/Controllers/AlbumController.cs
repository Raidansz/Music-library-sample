using ATWSMF_ADT_2022_23_1.Logic;
using ATWSMF_ADT_2022_23_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ATWSMF_ADT_2022_23_1.Endpoint.Controllers
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

        // POST: api/Comment
        // [HttpPost]
        //TODO 
        //public void Post([FromBody] Album value)
        //{
        //    this.AlbumLogic.add
        //}

        //TODO
        // PUT: api/Comment/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] Song value)
        //{

        //    this.SongLogic.UpdateCommentContentById(id, value.Content);
        //}


        //TODO

       // DELETE: api/Comment/5
       // [HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    this.AlbumLogic.Delete
        //}
    }

}
    

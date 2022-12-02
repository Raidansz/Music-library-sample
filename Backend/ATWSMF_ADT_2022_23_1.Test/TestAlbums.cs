using NUnit.Framework;
using Moq;
using ATWSMF_ADT_2022_23_1.Logic;
using System.Collections.Generic;
using ATWSMF_ADT_2022_23_1.Models;
using System.Linq;
using System;
using System.Runtime.Intrinsics.X86;
using ATWSMF_ADT_2022_23_1.Repository.Interfaces;
using ATWSMF_ADT_2022_23_1.Logic.Interfaces;
using ATWSMF_ADT_2022_23_1.Logic.Classes;

namespace ATWSMF_ADT_2022_23_1.Test
{
    public class TestAlbums
    {
        private IAlbumLogic AlbumLogic;
        private Mock<IAlbumRepository> mock;

        [SetUp]
        public void Setup()
        {
            mock = new Mock<IAlbumRepository>();

            var albums = new List<Album>() {  new Album { Id = 1, Name = "Speak Now" },
           new Album { Id = 2, Name = " Common Culture, Vol. V by Connor Franta" },
           new Album { Id = 3, Name = "Future Nostalgia" } };

            mock.Setup((m) => m.Entities).Returns(albums);
            mock.Setup((m) => m.GetAll()).Returns(() => albums.AsQueryable());
            mock
                .Setup((m) => m.GetOne(It.Is<int>(value => value == 1)))
                .Returns(() => albums[1]);
            AlbumLogic = new AlbumLogic(mock.Object);
        }

        [Test]
        public void CallingGetAll_ShouldReturn_Albums()
        {
            var albums = AlbumLogic.GetAllAlbums();
            // Assert

            mock.Verify(m => m.GetAll(), Times.AtLeast(1));
            Assert.That(albums, Is.Not.Null);
        }

        [Test]
        public void CallingGetOneWithAnyOtherValue_Should_Fail()
        {
            // Act

            var album = AlbumLogic.GetOneAlbum(2);

            // Assertion

            mock.Verify(m => m.GetOne(It.Is<int>(v => v == 1)), Times.Never);
            Assert.That(album, Is.Null);
        }

        [Test]
        public void CallingGetOneWithOne_Should_Return_Album()
        {
            var album = AlbumLogic.GetOneAlbum(1);
            

            mock.Verify(m => m.GetOne(It.Is<int>(value => value == 1)), Times.Once);
            Assert.That(album, Is.Not.Null);

        }


    }
}
using NUnit.Framework;
using Moq;
using ATWSMF_SGUI_2022_23_2.Logic;
using System.Collections.Generic;
using ATWSMF_SGUI_2022_23_2.Models;
using System.Linq;
using System;
using ATWSMF_SGUI_2022_23_2.Repository.Interfaces;
using ATWSMF_SGUI_2022_23_2.Logic.Interfaces;
using ATWSMF_SGUI_2022_23_2.Logic.Classes;

namespace ATWSMF_SGUI_2022_23_2.Test
{
    public class TestSongs
    {
        private  ISongLogic SongLogic;
        private Mock<ISongRepository> mock;

        [SetUp]
        public void Setup()
        {
            mock = new Mock<ISongRepository>();

            var songs = new List<Song>() { new Song { Id = 1, Name = "Sparks Fly", Duration = 150 },
            new Song { Id = 2, Name = "Mine", Duration = 150 },
            new Song { Id = 3, Name = "Mean", Duration = 150 } };

            mock.Setup((m) => m.Entities).Returns(songs);
            mock.Setup((m) => m.GetAll()).Returns(() => songs.AsQueryable());
            mock
                .Setup((m) => m.GetOne(It.Is<int>(value => value == 1)))
                .Returns(() => songs[1]);
            SongLogic = new SongLogic (mock.Object);
        }

        [Test]
        public void CallingGetAll_ShouldReturn_Songs()
        {
            var songs = SongLogic.GetAllSongs();
            // Assert

            mock.Verify(m => m.GetAll(), Times.AtLeast(1));
            Assert.That(songs, Is.Not.Null);
        }

        [Test]
        public void CallingGetOneWithAnyOtherValue_Should_Fail()
        {
            // Act

            var song = SongLogic.GetOneSong(2);

            // Assertion

            mock.Verify(m => m.GetOne(It.Is<int>(v => v == 1)), Times.Never);
            Assert.That(song, Is.Null);
        }

        [Test]
        public void CallingGetOneWithOne_Should_Return_Song()
        {
            var song = SongLogic.GetOneSong(1);
           

            mock.Verify(m => m.GetOne(It.Is<int>(value => value == 1)), Times.Once);
            Assert.That(song, Is.Not.Null);
           
        }

       
    }
}
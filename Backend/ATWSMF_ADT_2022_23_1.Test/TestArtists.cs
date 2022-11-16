using NUnit.Framework;
using Moq;
using ATWSMF_ADT_2022_23_1.Logic;
using ATWSMF_ADT_2022_23_1.Repository;
using System.Collections.Generic;
using ATWSMF_ADT_2022_23_1.Models;
using System.Linq;
using System;
using System.Runtime.Intrinsics.X86;

namespace ATWSMF_ADT_2022_23_1.Test
{
    public class TestArtists
    {
        private IArtistLogic ArtistLogic;
        private Mock<IArtistRepository> mock;

        [SetUp]
        public void Setup()
        {
            mock = new Mock<IArtistRepository>();

            var Artists = new List<Artist>() {  new Artist { Id = 1, Name = "Billie Eilish", Nationality = "American" },
           new Artist { Id = 2, Name = "Ava Max", Nationality = "Albanian" } };

            mock.Setup((m) => m.Entities).Returns(Artists);
            mock.Setup((m) => m.GetAll()).Returns(() => Artists.AsQueryable());
            mock
                .Setup((m) => m.GetOne(It.Is<int>(value => value == 1)))
                .Returns(() => Artists[1]);
            ArtistLogic = new ArtistLogic(mock.Object);
        }

        [Test]
        public void CallingGetAll_ShouldReturn_Artists()
        {
            var artist = ArtistLogic.GetAllArtist();
            // Assert

            mock.Verify(m => m.GetAll(), Times.AtLeast(1));
            Assert.That(artist, Is.Not.Null);
        }

        [Test]
        public void CallingGetOneWithAnyOtherValue_Should_Fail()
        {
            // Act

            var artist = ArtistLogic.GetOneArtist(2);

            // Assertion

            mock.Verify(m => m.GetOne(It.Is<int>(v => v == 1)), Times.Never);
            Assert.That(artist, Is.Null);
        }

        [Test]
        public void CallingGetOneWithOne_Should_Return_Artist()
        {
            var artist = ArtistLogic.GetOneArtist(1);
        

            mock.Verify(m => m.GetOne(It.Is<int>(value => value == 1)), Times.Once);
            Assert.That(artist, Is.Not.Null);

        }


        [Test]
        public void CallingGetArtistByName_Should_Artist()
        {
             

            var artist = ArtistLogic.GetArtistByName("Ava Max");

           
            Assert.That(artist, Is.Not.Null);

        }
    }
}
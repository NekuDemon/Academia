﻿using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProjectPatricia.Application.Features.Rooms;
using ProjectPatricia.Common.Tests.Features;
using ProjectPatricia.Domain.Exceptions;
using ProjectPatricia.Domain.Features.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Application.Tests.Features.Rooms
{
    [TestFixture]
    class RoomApplicationTest
    {
        private Mock<IRoomRepository> _mockRepository;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRoomRepository>();

        }

        [Test]
        public void RoomService_Add_ShouldBeOK()
        {
            Room room = ObjectMother.GetRoom();
            _mockRepository.Setup(m => m.Save(room)).Returns(new Room() { Id = 1 });
            RoomService service = new RoomService(_mockRepository.Object);

            Room result = service.Save(room);

            result.Should().NotBeNull();
            result.Id.Should().BeGreaterThan(0);
            _mockRepository.Verify(repository => repository.Save(room));
        }

        [Test]
        public void RoomService_Update_ShouldBeOK()
        {
            Room room = ObjectMother.GetRoom();
            room.Id = 2;

            _mockRepository.Setup(m => m.Update(room)).Returns(room);

            RoomService service = new RoomService(_mockRepository.Object);


            Room result = service.Update(room);

            result.Should().NotBeNull();
            result.Name.Should().Be("Sala de reunião");
            _mockRepository.Verify(repository => repository.Update(room));
        }

        [Test]
        public void RoomService_Get_ShouldBeOk()
        {

            Room room = ObjectMother.GetRoom();
            room.Id = 3;

            _mockRepository.Setup(m => m.Get(3)).Returns(room);

            RoomService service = new RoomService(_mockRepository.Object);
            Room result = service.Get(3);

            result.Should().NotBeNull();
            _mockRepository.Verify(repository => repository.Get(3));
        }

        [Test]
        public void RoomService_GetAll_ShouldBeOk()
        {

            _mockRepository.Setup(m => m.GetAll()).Returns(new List<Room>());

            RoomService service = new RoomService(_mockRepository.Object);

            IEnumerable<Room> result = service.GetAll();

            result.Should().NotBeNull();
            _mockRepository.Verify(repository => repository.GetAll());
        }

        [Test]
        public void RoomService_Delete_ShouldBeOk()
        {
            Room modelo = ObjectMother.GetRoom();
            modelo.Id = 1;

            _mockRepository.Setup(m => m.Delete(modelo));


            RoomService service = new RoomService(_mockRepository.Object);

            service.Delete(modelo);

            _mockRepository.Verify(repository => repository.Delete(modelo));
        }


        [Test]
        public void RoomService_Add_ShouldBeFail()
        {

            Room modelo = ObjectMother.GetInvalidNameRoom();

            RoomService service = new RoomService(_mockRepository.Object);

            Action comparison = () => service.Save(modelo);

            comparison.Should().Throw<RoomEmptyNameException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void RoomService_Update_Invalid_Id_ShouldBeFail()
        {

            Room modelo = ObjectMother.GetRoom();
            modelo.Id = 0;

            RoomService service = new RoomService(_mockRepository.Object);

            Action update = () => service.Update(modelo);

            update.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void PostService_Get_Invalid_Id_ShouldBeFail()
        {

            RoomService service = new RoomService(_mockRepository.Object);
            Room room = new Room()
            {
                Id = 0
            };
            Action comparison = () => service.Update(room);

            comparison.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }
    }
}

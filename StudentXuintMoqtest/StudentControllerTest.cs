using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StudentEF.Controllers;
using StudentEF.Interface;
using StudentEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentXuintMoqtest
{
    public class StudentControllerTest
    {
        private Mock<IStudent> _studentRepoMock;
        private Fixture _fixture;
        private StudentsController _controller;

        public StudentControllerTest()
        {
            _fixture = new Fixture();
            _studentRepoMock = new Mock<IStudent>();
        }

        [Fact]
        public async Task Get_Student_Return_Ok()
        {
            var studentList = _fixture.CreateMany<Student>(3).ToList();
            _studentRepoMock.Setup(repo => repo.GetStudents()).Returns(studentList);
            _controller = new StudentsController(_studentRepoMock.Object);

            var result = await _controller.GetStudents();
            var obj = result as ObjectResult;
            Assert.Equal(200, obj.StatusCode);

        }


        [Fact]
        public async Task Get_Student_ThrowException()
        {

            _studentRepoMock.Setup(repo => repo.GetStudents()).Throws(new Exception());
            _controller = new StudentsController(_studentRepoMock.Object);

            var result = await _controller.GetStudents();
            var obj = result as ObjectResult;
            Assert.Equal(400, obj.StatusCode);

        }

        [Fact]
        public async Task Get_StudentById_Return_Ok()
        {
            var student = _fixture.Create<Student>();
            _studentRepoMock.Setup(repo => repo.GetStudentById(student.StudentId)).Returns(student);
            _studentRepoMock.Setup(repo => repo.checkId(student.StudentId)).Returns(true);
            _controller = new StudentsController(_studentRepoMock.Object);

            var result = await _controller.GetStudent(student.StudentId);
            var obj = result as ObjectResult;
            Assert.Equal(200, obj.StatusCode);

        }
        [Fact]
        public async Task Get_StudentById_Return_NotFound()
        {
            var student = _fixture.Create<Student>();
            _studentRepoMock.Setup(repo => repo.GetStudentById(student.StudentId)).Returns(student);
            _studentRepoMock.Setup(repo => repo.checkId(student.StudentId)).Returns(false);
            _controller = new StudentsController(_studentRepoMock.Object);

            var result = await _controller.GetStudent(student.StudentId);
            var obj = result as ObjectResult;
            Assert.Equal(404, obj.StatusCode);

        }

        [Fact]
        public async Task Get_StudentById_ThrowException()
        {

            _studentRepoMock.Setup(repo => repo.GetStudentById(It.IsAny<int>())).Throws(new Exception());
            _studentRepoMock.Setup(repo => repo.checkId(It.IsAny<int>())).Returns(true);
            _controller = new StudentsController(_studentRepoMock.Object);

            var result = await _controller.GetStudent(It.IsAny<int>());
            var obj = result as ObjectResult;
            Assert.Equal(400, obj.StatusCode);

        }

        [Fact]
        public async Task Post_Student_Return_Ok()
        {
            var student = _fixture.Create<Student>();
            _studentRepoMock.Setup(repo => repo.PostStudent(It.IsAny<Student>())).Returns(student);
           
            _controller = new StudentsController(_studentRepoMock.Object);

            var result = await _controller.PostStudent(student);
            var obj = result as ObjectResult;
            Assert.Equal(200, obj.StatusCode);

        }

        [Fact]
        public async Task Post_Student_Return_BadRequest()
        {
            var student = _fixture.Create<Student>();
            _studentRepoMock.Setup(repo => repo.PostStudent(It.IsAny<Student>())).Throws(new Exception());
            
            _controller = new StudentsController(_studentRepoMock.Object);

            var result = await _controller.PostStudent(student);
            var obj = result as ObjectResult;
            Assert.Equal(400, obj.StatusCode);

        }

       

        [Fact]
        public async Task Put_Student_Return_Ok()
        {
            var student = _fixture.Create<Student>();
            _studentRepoMock.Setup(repo => repo.PutStudent(It.IsAny<Student>())).Returns(student);
            _studentRepoMock.Setup(repo => repo.checkId(student.StudentId)).Returns(true);

            _controller = new StudentsController(_studentRepoMock.Object);

            var result = await _controller.PutStudent(student.StudentId, student);
            var obj = result as ObjectResult;
            Assert.Equal(200, obj.StatusCode);

        }




        [Fact]
        public async Task Put_Student_Return_NotFound()
        {
            var student = _fixture.Create<Student>();
            _studentRepoMock.Setup(repo => repo.PutStudent(It.IsAny<Student>())).Returns(student);
            _studentRepoMock.Setup(repo => repo.checkId(student.StudentId)).Returns(false);

            _controller = new StudentsController(_studentRepoMock.Object);

            var result = await _controller.PutStudent(student.StudentId, student);
            var obj = result as ObjectResult;
            Assert.Equal(404, obj.StatusCode);

        }

        [Fact]
        public async Task Put_Student_Return_BadRequest()
        {
            var student = _fixture.Create<Student>();
            _studentRepoMock.Setup(repo => repo.PutStudent(It.IsAny<Student>())).Throws(new Exception());
            _studentRepoMock.Setup(repo => repo.checkId(student.StudentId)).Returns(true);
            _controller = new StudentsController(_studentRepoMock.Object);

            var result = await _controller.PutStudent(student.StudentId,student);
            var obj = result as ObjectResult;
            Assert.Equal(400, obj.StatusCode);

        }



        [Fact]
        public async Task Delete_Student_Return_Ok()
        {
            var student = _fixture.Create<Student>();
            _studentRepoMock.Setup(repo => repo.DeleteStudent(student.StudentId)).Returns(true);
            _studentRepoMock.Setup(repo => repo.checkId(student.StudentId)).Returns(true);
            _controller = new StudentsController(_studentRepoMock.Object);

            var result = await _controller.DeleteStudent(student.StudentId);
            var obj = result as ObjectResult;
            Assert.Equal(200, obj.StatusCode);

        }

        [Fact]
        public async Task Delete_Student_Return_NotFound()
        {
            var student = _fixture.Create<Student>();
            _studentRepoMock.Setup(repo => repo.DeleteStudent(student.StudentId)).Returns(true);
            _studentRepoMock.Setup(repo => repo.checkId(student.StudentId)).Returns(false);
            _controller = new StudentsController(_studentRepoMock.Object);

            var result = await _controller.DeleteStudent(student.StudentId);
            var obj = result as ObjectResult;
            Assert.Equal(404, obj.StatusCode);

        }



        [Fact]
        public async Task Delete_Student_Return_BadRequest()
        {
            var student = _fixture.Create<Student>();
            _studentRepoMock.Setup(repo => repo.DeleteStudent(student.StudentId)).Throws(new Exception());
            _studentRepoMock.Setup(repo => repo.checkId(student.StudentId)).Returns(true);

            _controller = new StudentsController(_studentRepoMock.Object);

            var result = await _controller.DeleteStudent(student.StudentId);
            var obj = result as ObjectResult;
            Assert.Equal(400, obj.StatusCode);

        }


      
    }
}


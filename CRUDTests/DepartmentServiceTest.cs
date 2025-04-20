using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using ContactsManager.Core.ServiceContracts;
using ContactsManager.Core.Services;
using FluentAssertions;
using Moq;
using MyWebApi.Models;
using MyWebApi.Repositories;
using MyWebApi.RepositoryContracts;

namespace CRUDTests
{
    public class DepartmentServiceTest
    {
        private readonly IDepartmentAdderService _departmentAdderService;
        private readonly IDepartmentGetterService _departmentGetterService;
        private readonly IDepartmentUpdaterService _departmentUpdaterService;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDepartmentDeleterService _departmentDeleterService;
        private readonly Mock<IDepartmentRepository> _departmentRepositoryMock;
        private readonly IFixture _fixture;
        public DepartmentServiceTest()
        {
            _fixture = new Fixture();
            _departmentRepositoryMock = new Mock<IDepartmentRepository>();
            _departmentRepository = _departmentRepositoryMock.Object;
            _departmentAdderService = new DepartmentAdderService(_departmentRepository);
            _departmentGetterService = new DepartmentGetterService(_departmentRepository);
            _departmentUpdaterService = new DepartmentUpdaterService(_departmentRepository);
            _departmentDeleterService = new DepartmentDeleterService(_departmentRepository);
        }
        [Fact]
        public async Task AddDepartment_Test()
        {
            Department department = _fixture.Create<Department>();
            _departmentRepositoryMock.Setup(u => u.AddDepartment(It.IsAny<Department>())).ReturnsAsync(department);
            Department Adddepartment =
                await _departmentAdderService.AddDepartment(department);
            Adddepartment.Id.Should().NotBe(0);
        }

        [Fact]
        public void GetAllDepartmentEmptyTest()
        {

            _departmentRepositoryMock.Setup(x => x.GetAllDepartments()).Returns(new List<Department>());
            List<Department> allDepartment =
                _departmentGetterService.GetAllDepartments().ToList();
            allDepartment.Should().BeEmpty();
            //_departmentGetterService.GetAllDepartments().Should().HaveCount(1);
        }
        [Fact]
        public void GetAllDepartmentTest()
        {
            List<Department> allDepartment = new List<Department>()
            {
                _fixture.Create<Department>(),
                _fixture.Create<Department>(),
                _fixture.Create<Department>(),
            };
            _departmentRepositoryMock.Setup(x => x.GetAllDepartments()).Returns(allDepartment);
            List<Department> returnallDepartment =
                _departmentGetterService.GetAllDepartments().ToList();
            allDepartment.Should().BeEquivalentTo(returnallDepartment);
        }
        [Fact]
        public async Task GetDepartmentById_Test()
        {
            Department department = _fixture.Create<Department>();
             _departmentRepositoryMock.Setup(x => x.GetDepartmentById(It.IsAny<int>())).ReturnsAsync(department);
            Department getDepartment =
                await _departmentGetterService.GetDepartmentById(department.Id);
            department.Should().Be(getDepartment);
            //_departmentGetterService.GetDepartmentById(1).Should().NotBeNull();
        }
        [Fact]
        public async Task UpdateDepartment_Test()
        {
            Department department = _fixture.Build<Department>().With(t => t.Id,1).With(t=> t.Name,"mostafa").Create();
            _departmentRepositoryMock.Setup(x => x.UpdateDepartment(It.IsAny<int>(),It.IsAny<string>())).ReturnsAsync(department);
            Department UpdateDepartment =
                await _departmentUpdaterService.UpdateDepartment(department.Id,"ahmed");
            department.Should().Be(UpdateDepartment);
        }

        [Fact]
        public async Task DeleteDepartment_test()
        {
            Department department = _fixture.Build<Department>().With(t => t.Id, 2).With(t => t.Name, "ahmed").Create();
            _departmentRepositoryMock.Setup(x => x.DeleteDepartment(It.IsAny<int>())).ReturnsAsync(true);
            _departmentRepositoryMock.Setup(x => x.GetDepartmentById(It.IsAny<int>())).ReturnsAsync(department);
            bool Delete =
                await _departmentDeleterService.DeleteDepartment(department.Id);
            Assert.True(Delete);
        }
    }
}

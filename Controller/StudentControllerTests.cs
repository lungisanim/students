using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using University.Controllers;
using University.Models;
using Microsoft.AspNetCore.Mvc;

[TestFixture]
public class StudentControllerTests
{
    // Mocked DbContext for testing
    private Mock<StudentContext> _mockContext;
    private DbSet<Student> _mockStudentsDbSet;
    private StudentsController _studentController;

    [SetUp]
    public void Setup()
    {
        // Initialize the mocked DbContext and DbSet
        _mockContext = new Mock<StudentContext>();
        _mockStudentsDbSet = new Mock<DbSet<Student>>().Object;
        _mockContext.Setup(c => c.Student).Returns(_mockStudentsDbSet);

        // Initialize the StudentController with the mocked DbContext
        _studentController = new StudentsController(_mockContext.Object);
    }

    [Test]
    public async Task GetStudents_ReturnsListOfStudents()
    {
        // Arrange
        var students = new List<Student>
        {
            new Student { Id = 1, FirstName = "lungisani", LastName = "nhlengethwa", Gender = "M", Grade = "89" },
            new Student { Id = 2, FirstName = "lungelo", LastName = "nhlengethwa", Gender = "M", Grade = "95"},
        };

        // Act
        var result = await _studentController.GetStudents();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<ActionResult<IEnumerable<Student>>>(result.Result);
        var studentsResult = ((ActionResult<IEnumerable<Student>>)result.Result).Value;
        Assert.AreEqual(students.Count, studentsResult.Count());
        Assert.IsTrue(studentsResult.Any(s => s.Id == 1 && s.FirstName == "lungisani"));
        Assert.IsTrue(studentsResult.Any(s => s.Id == 2 && s.FirstName == "lungelo"));
    }

    [Test]
    public async Task GetStudents_ReturnsNotFoundResult_WhenStudentsIsNull()
    {
        // Arrange
        _mockContext.Setup(c => c.Student).Returns((DbSet<Student>)null);

        // Act
        var result = await _studentController.GetStudents();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<NotFoundResult>(result.Result);
    }

    [Test]
    public async Task GetStudents_HandlesException_WhenErrorOccurs()
    {
        // Arrange
        _mockContext.Setup(c => c.Student).Throws(new Exception("An error occurred."));

        // Act
        var result = await _studentController.GetStudents();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<ObjectResult>(result.Result);
        var objectResult = (ObjectResult)result.Result;
        Assert.AreEqual(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
    }
}

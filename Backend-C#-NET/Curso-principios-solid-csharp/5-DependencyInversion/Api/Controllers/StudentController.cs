using Microsoft.AspNetCore.Mvc;

namespace DependencyInversion.Controllers;

[ApiController, Route("student")]
public class StudentController : ControllerBase
{
    //StudentRepository studentRepository = new StudentRepository();
    //Logbook logbook = new Logbook();

    IStudentRepository studentRepository;
    ILogbook logbook;

    //solo le interesa saber que dependencias tiene dentro del código pero no como están implementadas 
    public StudentController(IStudentRepository studentRepository, ILogbook logbook)
    {
        this.studentRepository = studentRepository;
        this.logbook = logbook;
    }

    [HttpGet]
    public IEnumerable<Student> Get()
    {
        logbook.Add($"returning student's list");
        return studentRepository.GetAll();
    }

    [HttpPost]
    public void Add([FromBody]Student student)
    {
        studentRepository.Add(student);
        logbook.Add($"The Student {student.Fullname} have been added");
    }
}

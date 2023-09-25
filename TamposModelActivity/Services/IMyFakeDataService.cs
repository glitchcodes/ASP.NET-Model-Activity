using TamposModelActivity.Models;

namespace TamposModelActivity.Services;

public interface IMyFakeDataService
{
    List<Student> StudentList { get; }
    List<Instructor> InstructorList { get; }
}
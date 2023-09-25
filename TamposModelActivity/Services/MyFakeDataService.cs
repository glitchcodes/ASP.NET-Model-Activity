using TamposModelActivity.Models;
using TamposModelActivity.Services;

namespace TamposModelActivity.Services;

public class MyFakeDataService : IMyFakeDataService
{
    public List<Student> StudentList { get; }
    public List<Instructor> InstructorList { get;  }
    
    public MyFakeDataService()
    {
        StudentList = new List<Student>()
        {
            new Student()
            {
                Id = 1, FirstName = "Vincent", LastName = "Tampos", Course = Course.BSIT,
                AdmissionDate = DateTime.Parse("2022-09-11"),
                GPA = 1.2, Email = "vincentpaul.tampos.cics@ust.edu.ph"
            },
            new Student()
            {
                Id = 2, FirstName = "Ellen", LastName = "Richmond", Course = Course.BSCS,
                AdmissionDate = DateTime.Parse("2022-01-23"),
                GPA = 1.3, Email = "ellen.richmond.cics@ust.edu.ph"
            },
            new Student()
            {
                Id = 3, FirstName = "Paris", LastName = "Morris", Course = Course.BSIT,
                AdmissionDate = DateTime.Parse("2021-03-08"),
                GPA = 1.5, Email = "paris.morris.cics@ust.edu.ph"
            }
        };
        
        InstructorList = new List<Instructor>
        {
            new Instructor()
            {
                Id = 1, FirstName = "Nancy", LastName = "Carrillo", Rank = Rank.Instructor, HiringDate = DateTime.Parse("2022-09-11"),
                IsTenured = true
            },
            new Instructor()
            {
                Id = 2, FirstName = "Coleman", LastName = "Copeland", Rank = Rank.AssistantProfessor, HiringDate = DateTime.Parse("2022-09-11"),
                IsTenured = false
            },
            new Instructor()
            {
                Id = 3, FirstName = "Josiah", LastName = "Trujillo", Rank = Rank.AssociateProfessor, HiringDate = DateTime.Parse("2021-03-08"),
                IsTenured = true,
            },
            new Instructor()
            {
                Id = 4, FirstName = "Arron", LastName = "Braun", Rank = Rank.Professor, HiringDate = DateTime.Parse("2020-01-21"),
                IsTenured = true,
            },
        };
    }
}
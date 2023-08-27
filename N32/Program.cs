using N32;
using System.Linq;
using System.Text.Json;

var folderName = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString());
var filePath = Path.Combine(folderName, "Student.json");
var fileStream = File.Open(filePath, FileMode.Open);
var studentList = JsonSerializer.Deserialize<List<Student>>(fileStream);
filePath = Path.Combine(folderName, "Speciality.json");
fileStream = File.Open(filePath, FileMode.Open);
var specialityList = JsonSerializer.Deserialize<List<Speciality>>(fileStream);
filePath = Path.Combine(folderName, "Location.json");
fileStream = File.Open(filePath, FileMode.Open);
var locationList = JsonSerializer.Deserialize<List<Location>>(fileStream);
//1
var specialityOfStudent = specialityList.GroupJoin(studentList,
    speciality => speciality.id,
    student => student.speciality_id,
    (speciality, students) =>
    new
    {
        Speciality = speciality,
        Students = students,
        studentCount = students.Count()
    });
//Console.WriteLine(JsonSerializer.Serialize(specialityOfStudent));

//2
var locationOfStudent = locationList.GroupJoin(studentList,
    location => location.id,
    student => student.location_id,
    (location, students) =>
    new
    {
        Location = location,
        Students = students,
        AverageAgeOfStudents = (int)students.ToList().Average(s => DateTime.Now.Year - DateTime.Parse($"{s.birth_day.Split('/')[1]}/{s.birth_day.Split('/')[0]}/{s.birth_day.Split('/')[2]}").Year)
    }).ToList();
//Console.WriteLine(JsonSerializer.Serialize(locationOfStudent));

//3

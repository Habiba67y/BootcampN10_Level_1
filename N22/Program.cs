using N22;

var university = new University<Student<Guid, int>, Guid, int>();
var student1 = new Student<Guid, int>(Guid.NewGuid(), "Falonchi", 45);
var student2 = new Student<Guid, int>(Guid.NewGuid(), "Palonchi", 47);
var course1 = new Course("Qandaysir bir kurs");
var course2 = new Course("Yana qandaysir bir kurs");
university.EnrollStudent(student1, course1);
university.EnrollStudent(student2, course2);
Console.WriteLine(university.ToString());
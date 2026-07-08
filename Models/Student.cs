namespace ProductConsoleOOP.Models;

public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }

    public Student()
    {
        FullName = string.Empty;
    }

    public Student(int id, string fullName, DateTime dateOfBirth)
    {
        Id = id;
        FullName = fullName;
        DateOfBirth = dateOfBirth;
    }

    public int GetAge()
    {
        DateTime today = DateTime.Today;
        int age = today.Year - DateOfBirth.Year;

        DateTime birthdayThisYear = DateOfBirth.AddYears(age);

        if (birthdayThisYear > today)
        {
            age--;
        }

        return age;
    }

    public override string ToString()
    {
        return $"Id: {Id}, FullName: {FullName}, DateOfBirth: {DateOfBirth:dd/MM/yyyy}, Age: {GetAge()}";
    }
}

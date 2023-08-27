
Person person1 = new("Sadık", "Sünbül", Department.C, 100, 10);
//Person person2 = new("Ahmet", "Sünbül", Department.C, 100, 10);


Person person2 = person1.Clone(); //Ctor tetiklenmez arkada yeniden new operatoru yapmaz
person2.Name = "Ahmet";

Console.WriteLine();

//Abstract Prototype
interface IPersonCloneable
{
    Person Clone();
}

//Concrete Prototype
class Person : IPersonCloneable
{
    public Person(string name, string surname, Department department, int salary, int premium)
    {
        Name = name;
        Surname = surname;
        Department = department;
        Salary = salary;
        Premium = premium;
        Console.WriteLine("Person nesnesi oluşturuldu.");
    }

    public string Name { get; set; }
    public string Surname { get; set; }
    public Department Department { get; set; }
    public int Salary { get; set; }
    public int Premium { get; set; }

    public Person Clone()
    {
        //Objecten gelen bir member var ordan klonlama ıslemı yapabılırız objecten geldiği için bunu cast veya as etmek gerekir
        return (Person)base.MemberwiseClone();
    }
}

enum Department
{
    A, B, C
}
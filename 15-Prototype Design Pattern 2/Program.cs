
Person person1 = new("Sadık", "Sümbül", Department.A, 2500, 500);

//Person person2 = (Person)person1.Clone();
Person? person2 = person1.Clone() as Person;//Ctor tetiklenmez arkada yeniden new operatoru yapmaz
person2.Name = "Ahmet";
person2.Salary = 1000;

Console.WriteLine();

//Concrete Prototype
class Person : ICloneable //hazır sınıfva .net de bu da kullanılabilir
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

    public object Clone()
    {
        //Objecten gelen bir member var ordan klonlama ıslemı yapabılırız objecten geldiği için bunu cast veya as etmek gerekir
        return base.MemberwiseClone();
    }
}

enum Department
{
    A, B, C
}
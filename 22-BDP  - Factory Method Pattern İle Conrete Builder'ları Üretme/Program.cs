//ArabaDirector arabaDirector = new ArabaDirector();

//Araba opel = arabaDirector.Build(new OpelBuilder());
//opel.ToString();

//Araba mercedes = arabaDirector.Build(new MercedesBuilder());
//mercedes.ToString();

ArabaDirector arabaDirector = new ArabaDirector();

Araba opel = arabaDirector.Build(BuilderCreator.Create(BuilderType.Opel));
opel.ToString();

Araba mercedes = arabaDirector.Build(BuilderCreator.Create(BuilderType.Mercedes));
mercedes.ToString();




Console.WriteLine();


//Product
class Araba
{
    public string Marka { get; set; }
    public string Model { get; set; }
    public double Km { get; set; }
    public bool Vites { get; set; }
    public override string ToString()
    {
        Console.WriteLine($"{Marka} marka araba {Model} modelinde {Km} kilometrede {Vites} vites olarak üretilmiştir");
        return base.ToString();
    }
}

//Abstract builder & Product
abstract class ArabaBuilder
{
    //Bu maliyetleri bu sınıfa yükledik
    protected Araba araba; //kalıtılan sınıflardan erısmek için yaptık protected i 
    public Araba Araba { get => araba; } //Dışarıdan bir araba veyahutta bir instanc almıycaz ondan get abstract oldugu ıcın bu sınıf artık dıger kalıtılan sınıflar ıcerısıne araba ımplament edılmıycek 
    public ArabaBuilder()
        => araba = new(); //burada uretıcez arabayı 


    public abstract ArabaBuilder SetMarka();
    public abstract ArabaBuilder SetModel();
    public abstract ArabaBuilder SetKm();
    public abstract ArabaBuilder SetVites();
}

//fACTORY DESİNG PATERN LARDA BUNLAR Product dir

//Concrete Builder
class OpelBuilder : ArabaBuilder
{
    //public Araba Araba { get; } //Abstract kullanırsak bu propertyı luzumsuz yere tanımlamak zorunda kalmayız
    //public OpelBuilder()
    //    => Araba = new();

    public override ArabaBuilder SetKm()
    {
        araba.Km = 0;
        return this;
    }

    public override ArabaBuilder SetMarka()
    {
        araba.Marka = "Opel";
        return this;
    }

    public override ArabaBuilder SetModel()
    {
        araba.Model = "...";
        return this;
    }

    public override ArabaBuilder SetVites()
    {
        araba.Vites = true;
        return this;
    }
}
//Concrete Builder
class MercedesBuilder : ArabaBuilder
{
    public override ArabaBuilder SetKm()
    {
        araba.Km = 100;
        return this;
    }

    public override ArabaBuilder SetMarka()
    {
        araba.Marka = "Mercedes";
        return this;
    }

    public override ArabaBuilder SetModel()
    {
        araba.Model = "xyz";
        return this;
    }

    public override ArabaBuilder SetVites()
    {
        araba.Vites = true;
        return this;
    }
}
//Concrete Builder
class BMWBuilder : ArabaBuilder
{
    public override ArabaBuilder SetKm()
    {
        araba.Km = 10;
        return this;
    }

    public override ArabaBuilder SetMarka()
    {
        araba.Marka = "BMW";
        return this;
    }

    public override ArabaBuilder SetModel()
    {
        araba.Model = "abc";
        return this;
    }

    public override ArabaBuilder SetVites()
    {
        araba.Vites = false;
        return this;
    }
}


//Director
class ArabaDirector
{
    public Araba Build(ArabaBuilder arabaBuilder)
    {
        //Fluent patern calısma mantıgı 
        return arabaBuilder
                    .SetMarka()
                    .SetModel()
                    .SetKm()
                    .SetVites()
                    .Araba;
    }
}


//Creator
enum BuilderType
{
    Opel,
    Mercedes,
    BMW
}
class BuilderCreator
{
    public static ArabaBuilder Create(BuilderType builderType)
    {
        return builderType switch
        {
            BuilderType.Opel => new OpelBuilder(),
            BuilderType.Mercedes => new MercedesBuilder(),
            BuilderType.BMW => new BMWBuilder()
        };
    }
}

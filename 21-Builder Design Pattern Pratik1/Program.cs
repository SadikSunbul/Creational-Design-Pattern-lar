


#region Interface ile abstract builder in tasarımı 
////Buradaki malıtey kısmı propertlere deger ekeleme sırasında olucaktır bu yapılandırma oldugu zaman builder design pattern kullanılıabilir

////Mercedes e özel
////Araba mercedes = new();
////mercedes.Km = 0;
////mercedes.Marka = "Mercedes";
////mercedes.Model = "e250";
////mercedes.Vites = true;

////Bmw ye özel
////Araba bmw = new();
////bmw.Km = 10;
////bmw.Marka = "BMW";
////bmw.Model = "..";
////bmw.Vites = false;

////Uygun kullanım 
//ArabaDirector arabaDirector = new ArabaDirector();

//Araba opel = arabaDirector.Build(new OpelBuilder());
//opel.ToString();

//Araba mercedes = arabaDirector.Build(new MercedesBuilder());
//mercedes.ToString();

//Console.WriteLine();
////Product
//class Araba
//{
//    public string Marka { get; set; }
//    public string Model { get; set; }
//    public double Km { get; set; }
//    public bool Vites { get; set; }
//    public override string ToString()
//    {
//        Console.WriteLine($"{Marka} marka araba {Model} modelinde {Km} kilometrede {Vites} vites olarak üretilmiştir");
//        return base.ToString();
//    }
//}

////Abstract builder
//interface IArabaBuilder
//{
//    Araba Araba { get; } //Dışarıdan bir araba veyahutta bir instanc almıycaz
//    IArabaBuilder SetMarka();
//    IArabaBuilder SetModel();
//    IArabaBuilder SetKm();
//    IArabaBuilder SetVites();
//}

////Concrete Builder
//class OpelBuilder : IArabaBuilder
//{
//    public Araba Araba { get; } //Abstract kullanırsak bu propertyı luzumsuz yere tanımlamak zorunda kalmayız
//    public OpelBuilder()
//        => Araba = new();

//    public IArabaBuilder SetKm()
//    {
//        Araba.Km = 0;
//        return this;
//    }

//    public IArabaBuilder SetMarka()
//    {
//        Araba.Marka = "Opel";
//        return this;
//    }

//    public IArabaBuilder SetModel()
//    {
//        Araba.Model = "...";
//        return this;
//    }

//    public IArabaBuilder SetVites()
//    {
//        Araba.Vites = true;
//        return this;
//    }
//}
////Concrete Builder
//class MercedesBuilder : IArabaBuilder
//{
//    public Araba Araba { get; }
//    public MercedesBuilder()
//        => Araba = new();

//    public IArabaBuilder SetKm()
//    {
//        Araba.Km = 100;
//        return this;
//    }

//    public IArabaBuilder SetMarka()
//    {
//        Araba.Marka = "Mercedes";
//        return this;
//    }

//    public IArabaBuilder SetModel()
//    {
//        Araba.Model = "xyz";
//        return this;
//    }

//    public IArabaBuilder SetVites()
//    {
//        Araba.Vites = true;
//        return this;
//    }
//}
////Concrete Builder
//class BMWBuilder : IArabaBuilder
//{
//    public Araba Araba { get; }
//    public BMWBuilder()
//        => Araba = new();

//    public IArabaBuilder SetKm()
//    {
//        Araba.Km = 10;
//        return this;
//    }

//    public IArabaBuilder SetMarka()
//    {
//        Araba.Marka = "BMW";
//        return this;
//    }

//    public IArabaBuilder SetModel()
//    {
//        Araba.Model = "abc";
//        return this;
//    }

//    public IArabaBuilder SetVites()
//    {
//        Araba.Vites = false;
//        return this;
//    }
//}


////Director
//class ArabaDirector
//{
//    public Araba Build(IArabaBuilder arabaBuilder)
//    {
//        //Fluent patern calısma mantıgı 
//        return arabaBuilder
//                    .SetMarka()
//                    .SetModel()
//                    .SetKm()
//                    .SetVites()
//                    .Araba;
//    }
//}

#endregion

#region Abstract class ile Abstract builder in tasarlanması
ArabaDirector arabaDirector = new ArabaDirector();

Araba opel = arabaDirector.Build(new OpelBuilder());
opel.ToString();

Araba mercedes = arabaDirector.Build(new MercedesBuilder());
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

//Abstract builder
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

#endregion
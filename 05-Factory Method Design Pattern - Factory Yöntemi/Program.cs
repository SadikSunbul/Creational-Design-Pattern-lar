/*
 recinde ihtiyaç olan nesnelerin
türüne/sınıfına/referansına odaklanmaksızın bu
nesnelerin Üretİlrnesİ gerekmektedir

Factory Method Design Pattern, nesne oluşturma
sorumluluğunu yardımcı bir sınıfa devrederek bu
sürecin maliyetini ihtiyaç anından soyutlamaktadır.

İşte böyle durumlarda nesne
oluşturma kodunu, nesneyi
gerçekten kullanacağımız
koddan arındırmamız
gerekmektedir.
 */


#region Factory  Design Pattern - Factory Yöntemi

// A a = new A(); //burada bır problem varr demektir burada ctor un bırsuru parametresı oldugunu dusun burada pek bır malıyet yok sadece sembol olsun dıyerekten söyluyorum bunu 

A? a = (A)ProductCreater.GetInstance(ProductType.A); //Nesneye ihtiyaç oldugunda drekt uretmektense isteme işlemi yaptık burada 
a.Run();

B? b = ProductCreater.GetInstance(ProductType.B) as B;
b?.Run();

//ihtiyacımızın olan nesneyi olusturmuyoruz istiyoruz 
//boylece uretım malıyetını kodun yazıldıfı yerde uretım malıyetınden arındırdık 
//gün geldı degısıklık yapılmak ıstendı nesnenın ctorundan tek bır yerde patlak verıcektır merkezıyetleştirmiş olduk 

#region Abstract Product
interface IProduct
{
    void Run();
}

#endregion

#region Ürün grubu -> Concrete Product 
class A : IProduct
{
    public void Run()
    {
        throw new NotImplementedException();
    }
}

class B : IProduct
{
    public void Run()
    {
        throw new NotImplementedException();
    }
}

class C : IProduct
{
    public void Run()
    {
        throw new NotImplementedException();
    }
}
#endregion

#region Creater
enum ProductType
{
    A,
    B,
    C
}
class ProductCreater
{
    static public IProduct GetInstance(ProductType productType)
    {
        //return productType switch
        //{
        //    ProductType.A => new A(),
        //    ProductType.B => new B(),
        //    ProductType.C => new C()
        //};

        IProduct product = null;
        switch (productType)
        {
            case ProductType.A:
                product = new A();
                //... a ile ilgili işlem yapcaksan gene yap buradan 
                break;
            case ProductType.B:
                product = new B();
                break;
            case ProductType.C:
                product = new C();
                break;
            default:
                break;
        }
        return product;
    }
}
#endregion

#endregion
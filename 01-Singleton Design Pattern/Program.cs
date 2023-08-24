

//Singleton Design Pattern


Example ex = Example.GetInstance;
Example ex1 = Example.GetInstance;
Example ex2 = Example.GetInstance;
Example ex3 = Example.GetInstance;
Example ex4 = Example.GetInstance;
Example ex5 = Example.GetInstance;

//Bunların hepsi tek bir nesnedir burada tek bir nesne uretildi ve hepsı o nesneyi kullanıyor 


class Example //singleton yapıcaz
{/*
  1-> Ctor u private yapmalıyız nesne artık uretilmiycektir
  2-> static bir şekilde tekbir nesneyi tutucaz 
  */
    private Example()
    {
        Console.WriteLine($"{nameof(Example)} NESNESİ OLUŞTURURLDU");
    }
    #region 2. Yöntem için 
    static Example() //Static ctor uygulama bu sınıfa yaptığı ilk istek sonucunda çalışıcaktır 2. veya daha sonraki çagirilması durumunda çalışmıycaktır yani bize 1 tane nesne vermiş olucaktır
    {
        _example = new Example();
    }
    #endregion

    //Singleton nesnesine ulaşmasını sağlar

    private static Example _example; //referans tutucak
    public static Example GetInstance //kontrollu bır sekılde dısarıya acarız burada
    {
        get
        {
            #region 1. Yöntem
            //if (_example == null)
            //{
            //    _example = new Example();//yukarıda ctor private yaptık new lenemez demistik bu erişim sınıfın kendi içerisi için geçerli değildir dışarıdan erişilemez
            //}
            //return _example;
            #endregion

            #region 2. Yöntem
            return _example;
            #endregion
        }
    }
}


//Yukarıdaki kod tek sorumluluğa aykırıdır şöyleki bu sınıf kendı yapıcağı iştende sorumlu hemde kendisinin oluşumundan da sorumludur
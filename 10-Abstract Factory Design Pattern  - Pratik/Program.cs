
#region Hatalı (kullanım)
//Computer computer = new();

//CPU cpu = new();
//computer.CPU = cpu;

//RAM ram = new();
//computer.RAM = ram;

//VideoCard videoCard = new VideoCard();
//computer.VideoCard = videoCard;
//Computer computer1 = new Computer(new(), new(), new());
#endregion

ComputerCreater creater = new();
Computer asus = creater.CreateComputer(new AsusFactory());//asus ıle ılgılı nesneyı uretmıs olucaz 


class Computer
{
    public Computer(ICPU cPU, IRAM rAM, IVideoCard videoCard)
    {
        CPU = cPU;
        RAM = rAM;
        VideoCard = videoCard;
    }

    public ICPU CPU { get; set; }
    public IRAM RAM { get; set; }
    public IVideoCard VideoCard { get; set; }
}

#region Abstract Product
interface ICPU { }
interface IRAM { }
interface IVideoCard { }
#endregion

#region Concrate product

class CPU : ICPU
{
    public CPU(string text) => Console.WriteLine(text);
}
class RAM : IRAM
{
    public RAM(string text) => Console.WriteLine(text);
}
class VideoCard : IVideoCard
{
    public VideoCard(string text) => Console.WriteLine(text);
}

#endregion

#region Abstract Factory
interface IComputerFactory
{
    ICPU CreateCPU();
    IRAM CreateRAM();
    IVideoCard CreateVideoCard();
}
#endregion

#region Concrate Factories
class AsusFactory : IComputerFactory
{
    public ICPU CreateCPU()
        => new CPU("Asus Cpu üretildi");

    public IRAM CreateRAM()
        => new RAM("Asus Ram üretildi");

    public IVideoCard CreateVideoCard()
        => new VideoCard("Asus VideoCard üretildi");
}

class ToshibaFactory : IComputerFactory
{
    public ICPU CreateCPU()
        => new CPU("Toshiba Cpu üretildi");

    public IRAM CreateRAM()
        => new RAM("Toshiba Ram üretildi");

    public IVideoCard CreateVideoCard()
        => new VideoCard("Toshiba VideoCard üretildi");
}

class MSIFactory : IComputerFactory
{
    public ICPU CreateCPU()
        => new CPU("MSI Cpu üretildi");

    public IRAM CreateRAM()
        => new RAM("MSI Ram üretildi");

    public IVideoCard CreateVideoCard()
        => new VideoCard("MSI VideoCard üretildi");
}
#endregion

#region Creator
class ComputerCreater
{
    ICPU _cpu;
    IRAM _rAM;
    IVideoCard _videoCard;
    public Computer CreateComputer(IComputerFactory computerFactory)
    {//asus verırsek asusun parcalarını uretirir
        _cpu = computerFactory.CreateCPU();
        _rAM = computerFactory.CreateRAM();
        _videoCard = computerFactory.CreateVideoCard();

        return new(_cpu, _rAM, _videoCard);
    }
}
#endregion
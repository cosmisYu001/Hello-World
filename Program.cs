using System;
#nullable disable

class Dool
{
    public event Action Kin;   
      
    public string Kai {  get; set; }
    public void Swipe()
    {
        Console.WriteLine("刷卡中"+"卡号"+Kai);

        Console.WriteLine("刷卡成功！");

        Kin?.Invoke();
    }

    
}


class Kiu
{
    public static void Sun()
    {
        Dool myDool= new Dool();

        myDool.Kai = "A8888";


        myDool.Kin += UN;

        myDool.Kin += Nu;

        myDool.Swipe();

    }
    public static void UN()
    {
        Console.WriteLine("识别到最高级别权限！！");

        Console.WriteLine("门已开，请确保周围环境正常情况下进入基地。");
    }

    public static void Nu()
    {
        Console.WriteLine("欢迎您再次回到这里！");
    }
    class Program
    {
        static void Main()
        {
            Kiu.Sun();   // 调用程序入口
        }
        
    }
}

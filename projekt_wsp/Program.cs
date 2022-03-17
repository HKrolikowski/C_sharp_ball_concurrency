using System;

namespace projekt_wsp
{

    class Program
    {
        //Console.WriteLine();
        static void Main(string[] args)
        {
            Bajt bajt = new Bajt(65);
            Console.WriteLine("Bajt ma wartosc: " + bajt.Wartosc);
            bajt.setBitZero(0);
            Console.WriteLine("Bajt ma wartosc: " + bajt.Wartosc);
            bajt.setBitOne(0);
            Console.WriteLine("Bajt ma wartosc: " + bajt.Wartosc);
            if (bajt.isBit(0) == true)
            {
                Console.WriteLine("Bajt na pozycji 0 ma 1");
            }
            else Console.WriteLine("Bajt na pozycji 0 ma 0");


        }
    }
}


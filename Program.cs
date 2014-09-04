using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Totalsumman och belopp erhållet.
            Console.Write("Ange totalsumma        : ");
            double total = double.Parse(Console.ReadLine());
            Console.Write("Ange erhållet belopp   : ");
            double recieved = int.Parse(Console.ReadLine());

            //Att betala efter öresavrundning och öresavrundningen.
            uint toPay = (uint)Math.Round(total, MidpointRounding.AwayFromZero); //MidpointRounding.AwayFromZero gör så att x.5 avrundar upp och inte ner.
            double roundOff = toPay - total;

            //Pengar tillbaka
            uint change = (uint)recieved - toPay;

            uint fivehundred = change / 500;
            uint hundred = (change % 500) / 100;
            uint fifty = (change % 100) / 50;
            uint twenty = (change % 50) / 20;
            uint ten = (change % 20) / 10;
            uint five = (change % 10) / 5;
            uint one = (change % 5);


            Console.WriteLine(fivehundred);
            Console.WriteLine(hundred);
            Console.WriteLine(fifty);
            Console.WriteLine(twenty);
            Console.WriteLine(ten);
            Console.WriteLine(five);
            Console.WriteLine(one);

            //kvitto
            Math.Round(roundOff, 0, MidpointRounding.AwayFromZero);
            Console.WriteLine("totalt                 : {0}", total);
            Console.WriteLine("öresavrundning         : {0:f2}", roundOff);
            Console.WriteLine("att betala             : {0}", toPay);
            Console.WriteLine("Kontant                : {0}", recieved);
            Console.WriteLine("Växel                  : {0}", change);



        }
    }
}


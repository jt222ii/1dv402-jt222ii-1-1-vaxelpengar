using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        // tst
        static void Main(string[] args)
        {
            start:
            Console.Clear();
            //Totalsumman och belopp erhållet.
        total:
            
            Console.Write("Ange totalsumma        : ");
            double total = double.Parse(Console.ReadLine());

            if (total < 1)
            { Console.WriteLine("Felaktig totalsumma! {0:c} kan ej tolkas som en giltig summa pengar! vänligen försök igen.", total); //Konsolen skriver ut att det är fel och sedan återgår den till att man ska skriva in totalsumman
            goto total;
            }

            recieved:
            Console.Write("Ange erhållet belopp   : ");
            double recieved = int.Parse(Console.ReadLine());
            if (recieved < total)
            {
                Console.WriteLine("{0:c} täcker ej det belopp som förväntas betalas: {1:c} Vänligen försök  igen!", recieved, total); //Konsolen skriver ut att det är fel och sedan återgår den till att man ska skriva in det erhållna beloppet.
                goto recieved;
            }


            //Att betala efter öresavrundning och öresavrundningen.
            uint toPay = (uint)Math.Round(total, MidpointRounding.AwayFromZero); //MidpointRounding.AwayFromZero gör så att x.5 avrundar upp och inte ner.
            double roundOff = toPay - total;

            //Pengar tillbaka
            uint change = (uint)recieved - toPay;

            //kvitto
            Console.WriteLine();
            Console.WriteLine("KVITTO");
            Console.WriteLine("----------------------------------------");
            Math.Round(roundOff, 0, MidpointRounding.AwayFromZero);
            Console.WriteLine("totalt                 : {0}", total);
            Console.WriteLine("öresavrundning         : {0:f2}", roundOff);
            Console.WriteLine("att betala             : {0}", toPay);
            Console.WriteLine("Kontant                : {0}", recieved);
            Console.WriteLine("Växel                  : {0}", change);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();

            uint changeBills;
            changeBills = change / 500;
            if (changeBills > 0)
            {
                Console.WriteLine("500-lappar             : {0}", changeBills);
            }
            changeBills = (change % 500) / 100;
            if (changeBills > 0)
            {
                Console.WriteLine("100-lappar             : {0}", changeBills);
            }
            changeBills = (change % 100) / 50;
            if (changeBills > 0)
            {
                Console.WriteLine("50-lappar              : {0}", changeBills);
            }
            changeBills = (change % 50) / 20;
            if (changeBills > 0)
            {
                Console.WriteLine("20-lappar              : {0}", changeBills);
            }
            changeBills = (change % 20) / 10;
            if (changeBills > 0)
            {
                Console.WriteLine("10-kronor              : {0}", ten);
            }
            changeBills = (change % 10) / 5;

            if (five > 0)
            {
                Console.WriteLine("5-kronor               : {0}", five);
            }
            changeBills = (change % 5);

            if (one > 0)
            {
                Console.WriteLine("1-kronor               : {0}", one);
            }

            

           

            

            

            




            Console.WriteLine("tryck ESC för att avsluta eller valfri tangent för att påbörja en ny uträkning!");
            ConsoleKeyInfo buttonpress = Console.ReadKey();
            if (buttonpress.Key == ConsoleKey.Escape)
            { Environment.Exit(0); }
            else
            { goto start; }

        }
    }
}



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
            double total;
            double recieved;
            uint toPay;
            double roundOff;
            uint change;
            uint changeBills;


        start:
            Console.Clear();
        //Totalsumman och belopp erhållet.
        total:

            try
            {
                Console.Write("Ange totalsumma        : ");
                total = double.Parse(Console.ReadLine());

                if (Math.Round(total, MidpointRounding.AwayFromZero) < 1)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Felaktig totalsumma! {0:c} kan ej tolkas som en giltig summa pengar! vänligen försök igen.", total); //Konsolen skriver ut att det är fel och sedan återgår den till att man ska skriva in totalsumman
                    Console.ResetColor();
                    goto total;
                }
            }

            catch
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Felaktigt värde!");
                Console.ResetColor();
                goto total;

            }

        recieved:
        

            try
            {
                Console.Write("Ange erhållet belopp   : ");
                recieved = int.Parse(Console.ReadLine());
                if (recieved < total)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0:c} täcker ej det belopp som förväntas betalas: {1:c} Vänligen försök  igen!", recieved, total); //Konsolen skriver ut att det är fel och sedan återgår den till att man ska skriva in det erhållna beloppet.
                    Console.ResetColor();
                    goto recieved;
                }
            }
            catch
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Felaktigt värde!");
                Console.ResetColor();
                goto recieved;

            }


            //Att betala efter öresavrundning och öresavrundningen.
            toPay = (uint)Math.Round(total, MidpointRounding.AwayFromZero); //MidpointRounding.AwayFromZero gör så att x.5 avrundar upp och inte ner.
            roundOff = toPay - total;

            //Pengar tillbaka
            change = (uint)recieved - toPay;

            //kvitto
            Console.WriteLine();
            Console.WriteLine("KVITTO");
            Console.WriteLine("----------------------------------------");
            Math.Round(roundOff, 0, MidpointRounding.AwayFromZero);
            Console.WriteLine("totalt                 : {0,15:c}", total);
            Console.WriteLine("öresavrundning         : {0,15:c}", roundOff);
            Console.WriteLine("att betala             : {0,15:c}", toPay);
            Console.WriteLine("Kontant                : {0,15:c}", recieved);
            Console.WriteLine("Växel                  : {0,15:c}", change);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();


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
                Console.WriteLine("10-kronor              : {0}", changeBills);
            }
            changeBills = (change % 10) / 5;

            if (changeBills > 0)
            {
                Console.WriteLine("5-kronor               : {0}", changeBills);
            }
            changeBills = (change % 5);

            if (changeBills > 0)
            {
                Console.WriteLine("1-kronor               : {0}", changeBills);
            }


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("tryck ESC för att avsluta eller valfri tangent för att påbörja en ny uträkning!");
            Console.ResetColor();
            ConsoleKeyInfo buttonpress = Console.ReadKey();
            if (buttonpress.Key == ConsoleKey.Escape)
            { Environment.Exit(0); }
            else
            { goto start; }

        }
    }
}



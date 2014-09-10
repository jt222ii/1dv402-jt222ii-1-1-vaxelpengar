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

            while (true)
            {
                Console.Clear(); // console clear för att applicationen loopar om man inte trycker escape i slutet när programmet frågar om man vill börja om eller avsluta

                double total = 0d;
                double recieved = 0d;
                uint toPay = 0;
                double roundOff = 0d;
                uint change = 0;
                uint changeBills = 0;

                //Totalsumman
                Boolean check = false;
                while (check == false)
                {
                    try
                    {
                        Console.Write("Ange totalsumma        : ");
                        total = double.Parse(Console.ReadLine());
                        check = true;
                       
                    }

                    catch
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Felaktigt värde!");
                        Console.ResetColor();
                    }
                    
                }

                //är den totala summan efter avrundning mindre än ett?
                if (Math.Round(total, MidpointRounding.AwayFromZero) < 1)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Felaktig totalsumma! {0:c} är en för liten summa!Köpet kunde inte genomföras", total); //Konsolen skriver ut att det är fel och stänger av programmet
                    Console.ResetColor();
                    break;
                }


                // erhållet belopp
                check = false;
                while (check == false)
                {
                    try
                    {
                        Console.Write("Ange erhållet belopp   : ");
                        recieved = double.Parse(Console.ReadLine());
                        check = true;  
                    }
                    catch
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Felaktigt värde!");
                        Console.ResetColor();
                    }

                }
                // är det erhållna beloppet mindre än vad som förväntas att betalas?     
                if (recieved < total)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Det erhållna beloppet {0:c} är för litet och köpet kunde inte genomföras.", recieved, total);
                    Console.ResetColor();
                    break;
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
                Console.WriteLine("att betala             : {0,15:c0}", toPay);
                Console.WriteLine("Kontant                : {0,15:c0}", recieved);
                Console.WriteLine("Växel                  : {0,15:c0}", change);
                Console.WriteLine("----------------------------------------");
                Console.WriteLine();

                // Antal kronor och lappar som ska fås tillbaka
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

                // Ny uträkning eller avsluta?
                Console.ForegroundColor = ConsoleColor.Green;                   
                Console.WriteLine("tryck ESC för att avsluta eller valfri tangent för att påbörja en ny uträkning!");
                Console.ResetColor();
                ConsoleKeyInfo buttonpress = Console.ReadKey();

                if (buttonpress.Key == ConsoleKey.Escape)       // denna if-satsen stänger av programmet om man trycker escape 
                {
                    break;
                }
                
                
            }
        }
        
    }
}



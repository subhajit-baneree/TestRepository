using Autofac;
using Honeywell.App.Business.Library.Enums;
using Honeywell.App.Business.Library.Helpers;
using Honeywell.App.Business.Library.Interfaces;
using System;

namespace HoneywellApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var container = Factory.ConfigureApp();
            var timeConverter = container.Resolve<ITimeConverter>();
            var stringCheker = container.Resolve<IStringChecker>();

            Logger.InitiateLogger("HoneyWell_Test_app");
            

            Console.WriteLine("Welcome to the application");
            while (true) 
            {
                Console.WriteLine("Press 1 for Time Converter application, 2 for string converter application:");
                int input = 0;
                try
                {
                    input = int.Parse(Console.ReadLine());
                    Logger.Log(input.ToString());
                    if (input == 1) 
                    {
                        Console.WriteLine("Enter Time zone:");
                        var timeZone = Console.ReadLine();
                        if (timeZone.Equals(Timezone.CST.ToString()) || timeZone.Equals(Timezone.CST.ToString().ToLower()))
                        {
                            Logger.Log("CST");
                            Console.WriteLine("CST time is : " + timeConverter.ConvertToSelectedTimeZone(Timezone.CST));
                        }

                        else if (timeZone.Equals(Timezone.EST.ToString()) || timeZone.Equals(Timezone.EST.ToString().ToLower()))
                        {
                            Logger.Log("EST");
                            Console.WriteLine("EST time is : " + timeConverter.ConvertToSelectedTimeZone(Timezone.EST));
                        }

                        else if (timeZone.Equals(Timezone.PST.ToString()) || timeZone.Equals(Timezone.PST.ToString().ToLower()))
                        {
                            Logger.Log("PST");
                            Console.WriteLine("PST time is : " + timeConverter.ConvertToSelectedTimeZone(Timezone.PST));
                        }

                        else if (timeZone.Equals(Timezone.IST.ToString()) || timeZone.Equals(Timezone.IST.ToString().ToLower()))
                        {
                            Logger.Log("IST");
                            Console.WriteLine("IST time is : " + timeConverter.ConvertToSelectedTimeZone(Timezone.IST));
                        }

                        else 
                        {
                            Logger.Log("Invalid input");
                            Console.WriteLine("Invalid input");
                        }
                    }
                    else if (input == 2) 
                    {
                        Console.WriteLine("Enter string for conversion:");
                        var stringInput = Console.ReadLine();

                        Logger.Log("String converter app chosen. Input string :" + stringInput);
                        if (!string.IsNullOrEmpty(stringInput)) 
                        {
                            Console.WriteLine("Modified string:" + stringCheker.GetModifiedString(stringInput));
                        }
                    }
                    else 
                    {
                        Console.WriteLine("Invalid Input:");
                    }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine("Invalid input.");
                }

                try
                {
                    Console.WriteLine("Press 5 to continue/ 6 to exit");
                    var exitParam = int.Parse(Console.ReadLine());
                    if (exitParam == 6)
                    {
                        break;
                    }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine("Inavlid choice.");
                }

            }
        }

        
    }
}

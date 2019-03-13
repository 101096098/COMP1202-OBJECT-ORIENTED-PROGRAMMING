using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenataMoura
{
    class Renata_CenterApp
    {
       
        static void Main(string [] args)
        {            
            Renata_Center[] centerArray = new Renata_Center[50];
            centerArray = InputData();
            Display(centerArray);
       
            Console.ReadKey();
        }
        public static string[] Month = new string[] { "January", "February", "March", "April", "May",
            "June", "July","August","Septembter","Octuber","November","December"};

        public static void Display(Renata_Center[] theArray)
        {
            for(int i = 0; i<5;i++)
            {
                if(theArray[i] != null)
                {
                    theArray[i].Display();
                    Console.WriteLine();
                }
            }
        }

       public static Renata_Center[] InputData() // method
        {
            int numMonth, numcenter;
            int numOfAdult, numOfChild;
            double ticketPrice;
            Renata_Center [] tempObject = new Renata_Center[50]; // object
           
            // Informations for each center
            while (true)
            {
                
                Console.WriteLine("\nCenter Statistic study (Renata Moura analisys");
                Console.WriteLine("\nHow many centres would you like to enter and view statistical data?");
                if (!int.TryParse(Console.ReadLine(), out numcenter))
                {
                    Console.WriteLine("Invalid data entered. Please enter number of center:");
                    continue;
                }
                break;
            }

            for (int i = 0; i < numcenter; i++)
            {
                tempObject[i] = new Renata_Center();
                while (true)
                {
                    Console.WriteLine("Enter Centre Name"); // Input center name
                    string centerName = Console.ReadLine();
                    if (centerName == "")// center name validation( Data entered by the user must be validated:
                        //name of the centre cannot be blank. )
                    {
                        Console.WriteLine("Invalid data entered. Please enter a valid name:");
                        continue;
                    }
                    tempObject[i].CenterName = centerName;
                    break;
                }
                // Input Center City
                Console.WriteLine("Enter Centre City:");
                string centerCity = Console.ReadLine();
                tempObject[i].CenterCity = centerCity;

                // Input Ticket price. Data entered by the user must be validated:
               //- price for adult visitor cannot be less than $20.00 and more than $40.00. 
                while (true)
                {
                    Console.WriteLine("Input Ticket price per day(Adult):");
                    if (double.TryParse(Console.ReadLine(), out ticketPrice) && ticketPrice >= 20 && ticketPrice <= 40)
                    {
                        tempObject[i].TicketPrice = ticketPrice;
                        break;
                    }
                    Console.WriteLine("Invalid Price entered. Please enter a valid price:");
                }

                // Input number of months and data for months. Data entered by the user must be validated:
                //- month must be an integer and valid (i.e 1 to 12)
                while (true)
                {
                    while (true)
                    {
                        Console.WriteLine("Please enter number of the month:");
                        if (!int.TryParse(Console.ReadLine(), out numMonth) || numMonth < 0 || numMonth > 12)
                        {
                            Console.Write("Invalid Month. Please re-enter:");
                            continue;
                        }
                        break;
                    }

                    // Input number of adults. Data entered by the user must be validated:
                    //-visitors(adults/children) can be zero or more (i.e. it cannot be negative)

                    while (true)
                    {
                        Console.WriteLine("Please enter number of Adults:");

                        if (int.TryParse(Console.ReadLine(), out numOfAdult) && numOfAdult >= 0)
                        {

                            tempObject[i].NumberOfAdults[numMonth - 1] = numOfAdult;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid value.");
                        }
                    }

                    // Input number of childrenData entered by the user must be validated:
                    //-visitors(adults/children) can be zero or more (i.e. it cannot be negative)

                    while (true)
                    {
                        Console.WriteLine("Please enter number of Children:");
                 
                        if (int.TryParse(Console.ReadLine(), out numOfChild) && numOfChild >= 0)
                        {
                            tempObject[i].NumberOfChildren[numMonth - 1] = numOfChild;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid value.");
                        }

                    }

                    Console.Write("Would you like to enter another month (y/n)?\n");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        continue;
                    }
                    break;
                }
            }
               
            return tempObject;
        }
    }

        
}
    



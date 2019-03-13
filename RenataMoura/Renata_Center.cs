/*
 *Comments: - Assignment C#     Summer 2017.
 * Author: Renata Moura  - Student ID: 101096098
 * This class defines Centers characteristsc including
 * Name, city, price for adult tickets, number of adutls
 * and children visits.
 */

 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenataMoura
{
    class Renata_Center
    {
        // variables definition:

        private string centerName; // Center Name
        private string centerCity; // Center City
        private double ticketPrice; // Price for each month

        private int[] numberOfAdults; // Number of adults per month
        private int[] numberOfChildren; // Number of Children per month

        // Default constructor

        public Renata_Center()
        {
            numberOfAdults = new int[12];
            numberOfChildren = new int[12];
        }


        // Constructors

        // Constructor for Center Name, Center City, Center Price, Number of Adults and Number of children
        public Renata_Center(string CenterName, string CenterCity, double TicketPrice, int[] numberOfAdults, int[] numberOfChildren)
        {
            centerCity = CenterCity;
            centerName = CenterName;
            ticketPrice = TicketPrice;
            this.numberOfAdults = numberOfAdults;
            this.numberOfChildren = numberOfChildren;

        }

        // Properties
        public int[] NumberOfAdults
        {
            get { return numberOfAdults; }
            set { numberOfAdults = value; }
        }

        public int[] NumberOfChildren
        {
            get { return numberOfChildren; }
            set { numberOfChildren = value; }
        }

        public string CenterName
        {
            get { return centerName; }
            set { centerName = value; }
        }

        public string CenterCity
        {
            get { return centerCity; }
            set { centerCity = value; }
        }

        public double TicketPrice
        {
            get { return ticketPrice; }
            set { ticketPrice = value; }
        }

        //- statistics showing the month and year for the:
        //- highest one-day visits by adults
        public string MaxMonth(int[] tempmonth)
        {
            int maxIndex = 0;
            for (int i = 0; i < tempmonth.Length; i++)
                if (tempmonth[i] > tempmonth[maxIndex])
                    maxIndex = i;
            return Renata_CenterApp.Month[maxIndex];
        }
        //- statistics showing the month and year for the:
        //- highest one-day visits by children

        public string MinMonth(int[] tempmonth)
        {
            int minIndex = 0;
            for (int i = 0; i < 12; i++)
                if (numberOfAdults[i] != 0)
                {
                    minIndex = i;
                    break;
                }
            for (int i = 0; i < tempmonth.Length; i++)
                if (tempmonth[i] < tempmonth[minIndex] && numberOfAdults[i] != 0)
                    minIndex = i;
            return Renata_CenterApp.Month[minIndex];
        }

        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("----------------------------------------------------------------------");
            Console.ResetColor();

            Console.WriteLine("\nDisplaying Data for Center {0}:", centerName);
            Console.WriteLine("\nYear 2016\n");
            for (int i = 0; i < 12; i++)
            {
                if (NumberOfAdults[i] != 0 && numberOfChildren[i] != 0)
                {
                    Console.WriteLine("Month: {0}", Renata_CenterApp.Month[i]);
                    Console.WriteLine("\tNumber of Adults: {0}", NumberOfAdults[i]);
                    Console.WriteLine("\tNumber of Children: {0}", NumberOfChildren[i]);
                    Console.WriteLine("\tSales for {0} : {1:C2}", Renata_CenterApp.Month[i],
                        ticketPrice * NumberOfAdults[i]); // total sales for this month 
                }
            }
            Console.WriteLine("\nDisplaying Statistic Report for {0}", centerName);
            Console.WriteLine("\tHighest one-day visit by adults: {0}", MaxMonth(NumberOfAdults));
            Console.WriteLine("\tHighest one-day visit by childten: {0}", MaxMonth(NumberOfChildren));
            Console.WriteLine("\tMonth of Least Sale: {0}", MinMonth(NumberOfAdults));
            Console.WriteLine("\tAmount of Sale in {0}: {1:C2}", MinMonth(NumberOfAdults),
                numberOfAdults[Array.IndexOf(Renata_CenterApp.Month, MinMonth(numberOfAdults))]
                * ticketPrice);  // - least total revenue collected along with the amount. 
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("----------------------------------------------------------------------");
            Console.ResetColor();
        }
    }
}
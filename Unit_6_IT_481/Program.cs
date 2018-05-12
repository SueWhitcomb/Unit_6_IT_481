using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_6_IT_481
{
    public class Scenario
    {

        private static readonly Random generator = new Random();

        public static object DateTimeHelper { get; private set; }

        public static void Main(string[] args)
        {
            //create new thread pool
            ExecutorService application = Executors.newCachedThreadPool();

            //create new scanner
            
            Console.WriteLine("Dressing Rooms Testing vs 1.0 SW");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Enter the number of dressing rooms to test: ");
            int numberOfRooms = sc.Next();
            Console.WriteLine("Enter the number of customers to test: ");
            int numberOfCustomers = sc.Next();
            long startTime = NewMethod();
            Console.WriteLine();
            Console.WriteLine("Customer Actions");
            Console.WriteLine("-----------------------------------------");
            sc.close();

            //create dressingRooms and customers
            DressingRooms dressingRoom = new DressingRooms(numberOfRooms);
            int items = 0;
            int time = 0;
            int totalCustomers = numberOfCustomers;
            while (numberOfCustomers > 0)
            { //loop thru the number of customers
                try
                {
                    Customer customer = new Customer(dressingRoom);
                    application.execute(customer); //customer instance created
                    items += customer.NumberOfitems(); //add items count
                    time += customer.TotalTime(); //add time in room count

                    //random time between customer arrivals
                    Thread.Sleep(generator.Next(30000));
                }
                catch (InterruptedException ex)
                {
                    Console.WriteLine(ex.ToString());
                    Console.Write(ex.StackTrace);
                } //end try/catch

                numberOfCustomers--; //decrement customer count
            } //end while loop

            application.shutdown();
            try
            {
                application.awaitTermination(5, TimeUnit.MINUTES); //wait till threads finish or timeout
                int avgItems = items / totalCustomers;
                double avgTime = time / totalCustomers;
                long avgWait = dressingRoom.averageWait();
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Total number of customers: " + totalCustomers);
                Console.WriteLine("Average number of items per customer: " + avgItems);
                Console.WriteLine("Average dressing room time per customer: " + avgTime / 1000 + " seconds.");
                Console.WriteLine("The average wait time per customer was: " + avgWait / 1000 + " seconds.");
            }
            catch (InterruptedException ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Write(ex.StackTrace);
            } //end try/catch

            long endTime = DateTimeHelper.CurrentUnixTimeMillis(); //end scenario time
            Console.WriteLine("The whole scenario took " + ((endTime - startTime) / 1000) + " seconds");

        } //end main method

        private static long NewMethod() => DateTimeHelper.CurrentUnixTimeMillis();//start scenario time
    } //end class Scenario

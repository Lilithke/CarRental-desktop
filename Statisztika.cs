using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace CarRental_desktop
{
    internal static class Statisztika
    {
        static List<Car> cars;
        public static void Run()
        {
            try
            {
                ReadAllCars();
                //cars.ForEach(car => Console.WriteLine(car.License_plate_number));

                Console.WriteLine("20.000 Ft-nál olcsóbb napidíjú autók száma:{0}", Cars20000Daily_cost());
                Console.WriteLine("{0} az adatok között 26.000 Ft-nál drágább napidíjú autó", (bool)PriceMore26000() ? "Van" : "Nincs");
                Car MostExpensive = MostDailyCost();
                Console.WriteLine("Legdrágább napidíjú autó:{0}-{1}-{2}-{3} Ft",MostExpensive.License_plate_number,MostExpensive.Brand,MostExpensive.Model,MostExpensive.Daily_cost);
                Console.WriteLine("Autók száma:");
                foreach (var item in cars.GroupBy(a => a.Brand).Select(b => new {Marka = b.Key, db = b.Count()}))
                {
                    Console.WriteLine($"\t{item.Marka}: {item.db}");
                }
                Console.Write("Adjon meg egy rendszámot: ");
                string license_plate_number = Console.ReadLine();
                PrintLisence(license_plate_number);
                Console.ReadKey();

            }
            catch (MySqlException ex)
            {

                Console.WriteLine("Hiba történt az adatbázis kapcsolat kiépítésekor:");
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintLisence(string license_plate_number)
        {
            int i = 0;
            while (i < cars.Count && cars[i].License_plate_number != license_plate_number)
            {
                i++;
            }

            if (i < cars.Count)
            {
                if (cars[i].Daily_cost <=25000)
                {
                    Console.WriteLine("A megadott autó napidíja nem nagyobb mint 25000 FT");
                }
                else { Console.WriteLine("A megadott autó napidíja nagyobb mint 25000 FT"); }

            }
            else
            {
                Console.WriteLine("Nincs ilyen autó");
            }
            
        }

       /* private static object GroupCars()
        {
            //nem tudom;
        } */
        

        private static Car MostDailyCost() //Maximum kiválasztás
        {
            Car MostExpensive = cars[0];
            for (int i = 1; i < cars.Count; i++)
            {
                if (cars[i].Daily_cost > MostExpensive.Daily_cost)
                {
                    MostExpensive = cars[i];
                }
            }
            return MostExpensive;

        }

        private static object PriceMore26000() //Eldöntés
        {
            int i = 0;
            while (i < cars.Count && !(cars[i].Daily_cost > 26000)) 
            {
                i++;
            }
            return i < cars.Count;
        }

        private static object Cars20000Daily_cost() //Megszámolás
        {
            int i = 0;
            foreach (Car car in cars)
            {
                if (car.Daily_cost < 20000)
                {
                    i++;
                }
            }return i;
        }

        private static void ReadAllCars()
        {
            CarService carService = new CarService();
            cars = carService.GetCars();
        }
    }
}

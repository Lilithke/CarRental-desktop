using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_desktop
{
    internal class CarService
    {
        private static string DB_HOST = "localhost";
        private static string DB_USER = "root";
        private static string DB_PASSWORD = "";
        private static string DB_DBNAME = "cars";

        private MySqlConnection connection;

        public CarService()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = DB_HOST;
            builder.UserID = DB_USER;
            builder.Password = DB_PASSWORD;
            builder.Database = DB_DBNAME;

            this.connection = new MySqlConnection(builder.ConnectionString);
            this.connection.Open();
        }

        public List<Car> GetCars()
        {
            List<Car> list = new List<Car>();

            string sql = "SELECT * FROM cars";

            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = sql;
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string license_plate_number = reader.GetString("license_plate_number");
                    string brand = reader.GetString("brand");
                    string model = reader.GetString("model");
                    int daily_cost = reader.GetInt32("daily_cost");

                    Car car = new Car(id,license_plate_number, brand, model, daily_cost);
                    list.Add(car);
                }
            }
            return list;
        }


        internal bool DeleteCar(int id)
        {
            string sql = "DELETE FROM cars WHERE id = @id";
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@id", id);
            return command.ExecuteNonQuery()==1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Contract
{
    class WeatherDB
    {
        public static void CreateDatabase()
        {
            SQLiteConnection.CreateFile("Weather.sqlite");

            SQLiteConnection connection = new SQLiteConnection("Data Source=Weather.sqlite;Version=3;");
            connection.Open();

            string sql1 = "CREATE TABLE cities (" +
                          "id INTEGER PRIMARY KEY, " +
                          "count INTEGER, " +
                          "lastrequest DATETIME)";
            SQLiteCommand command1 = new SQLiteCommand(sql1, connection);
            command1.ExecuteNonQuery();

            string sql2 = "CREATE TABLE current (" +
                          "id INTEGER UNIQUE, " +
                          "lastupdate DATETIME, " +
                          "weatherjson TEXT," +
                          "FOREIGN KEY(id) REFERENCES cities(id) ON DELETE CASCADE)";
            SQLiteCommand command2 = new SQLiteCommand(sql2, connection);
            command2.ExecuteNonQuery();

            string sql3 = "CREATE TABLE forecast (" +
                          "id INTEGER UNIQUE, " +
                          "lastupdate DATETIME, " +
                          "weatherjson TEXT," +
                          "FOREIGN KEY(id) REFERENCES cities(id) ON DELETE CASCADE)";
            SQLiteCommand command3 = new SQLiteCommand(sql3, connection);
            command3.ExecuteNonQuery();
            
            connection.Close();
        }

        public static void InsertCity(SQLiteConnection connection, int id)
        {
            string sql = String.Format("insert into cities (id, count, lastrequest) values ({0}, 1, CURRENT_TIMESTAMP);" +
                                        "insert into current (id) values ({0});" +
                                        "insert into forecast (id) values ({0});", id);
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteReader();
        }

        public static void SelectAllCurrent(SQLiteConnection connection)
        {
            string sql = "select id, lastupdate, weatherjson from current";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("id: " + reader["id"] + "\tlastupdate: " + reader["lastupdate"] + "\tweather: " + reader["weatherjson"]);
        }

        public static void SelectAllForecast(SQLiteConnection connection)
        {
            string sql = "select id, lastupdate, weatherjson from forecast";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("id: " + reader["id"] + "\tlastupdate: " + reader["lastupdate"] + "\tweather: " + reader["weatherjson"]);
        }

        public static void SelectAllCities(SQLiteConnection connection)
        {
            string sql = "select id, count, lastrequest from cities";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("id: " + reader["id"] + "\tcount: " + reader["count"] + "\tlastrequest: " + reader["lastrequest"]);
        }

        public static void InsertCurrent(SQLiteConnection connection, int id, string weather)
        {
            string sql = String.Format("UPDATE current SET lastupdate = CURRENT_TIMESTAMP, weatherjson = '{0}' WHERE id = {1}", weather, id);
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteReader();
        }

        public static void InsertForecast(SQLiteConnection connection, int id, object weather)
        {
            string sql = String.Format("UPDATE forecast SET lastupdate = CURRENT_TIMESTAMP, weatherjson = '{0}' WHERE id = {1}", weather, id);
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteReader();
        }

        public static void GetCurrentWeather(SQLiteConnection connection, int id)
        {
            string sql = String.Format("select weatherjson from current WHERE id = {0}", id);
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            Console.WriteLine(reader);
        }

        public static void UpdateWhenSelected(SQLiteConnection connection, int id)
        {
            string sql = String.Format("select id, count, lastrequest from cities WHERE id = {0}", id);
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            sql = String.Format("UPDATE cities SET count = {0}+1, lastrequest = CURRENT_TIMESTAMP WHERE id = {1}", reader["count"], id);
            command = new SQLiteCommand(sql, connection);
            command.ExecuteReader();
        }
    }
}

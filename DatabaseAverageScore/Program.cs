using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic;

namespace ConnectToDatabase
{
    internal class Program
    {
        const string connectionString = "Server=223-10;Database=Market;Trusted_Connection=true;Encrypt=false";
        const string connectionStringStudents = "Server=223-10;Database=Scores;Trusted_Connection=true;Encrypt=false";
        static void Main(string[] args)
        {

            try
            {
                getMinimalSubjects();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }



        }

        public static int getOverallPrice(string connectionString)
        {

            //return price*quantity;

            const string sqlQuery = "SELECT * FROM dbo.MyInventory";
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            using var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var name = reader["name"].ToString();
                var price = reader["price"];
                var quantity = reader["quantity"];


                Console.WriteLine($"name - {name}, price - {price}, quantity - {quantity}");
                //int fullprice = Convert.ToInt32(price) * Convert.ToInt32(quantity);
                int overall = Convert.ToInt32(price) * Convert.ToInt32(quantity);
                Console.WriteLine("Overall: " + overall);

            }
            return 0;
        }

        private static void showTotalPrice()
        {

            //return price*quantity;

            const string sqlQuery = "SELECT * FROM dbo.MyInventory";

            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            using var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var name = reader["name"].ToString();
                var price = reader.GetInt32(i: 1);
                var quantity = reader.GetInt32(i: 2);

                var totalPrice = price * quantity;
                Console.WriteLine($"name - {name}, totalprice - {totalPrice}");

            }
        }

        private static void isConnectedToDatabase()
        {
            const string sqlQuery = "SELECT * FROM dbo.StudentScores";

            using var sqlConnection = new SqlConnection(connectionStringStudents);

            sqlConnection.Open();

            Console.WriteLine("Connection opened");


        }

        private static void getAllStudents()
        {
            const string sqlQuery = "SELECT * FROM dbo.StudentScores";

            using var sqlConnection = new SqlConnection(connectionStringStudents);

            sqlConnection.Open();

            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            using var reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                var sId = reader["id"].ToString();
                var sName = reader["name"].ToString();
                var sAverageScore = reader["avgScore"].ToString();
                var sMinSubject = reader["minSubject"].ToString();
                var sMaxSubject = reader["maxSubject"].ToString();

                Console.WriteLine($"{sId}) {sName} avg: {sAverageScore}, min: {sMinSubject}, max: {sMaxSubject}");
            }
        }
        private static void getAllStudentsNames()
        {
            const string sqlQuery = "SELECT * FROM dbo.StudentScores";

            using var sqlConnection = new SqlConnection(connectionStringStudents);

            sqlConnection.Open();

            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            using var reader = sqlCommand.ExecuteReader();
            int i = 0;

            while (reader.Read())
            {
                var sName = reader["name"].ToString();
                i++;
                Console.WriteLine($"{i} - {sName} ");
            }
        }
        private static void getAllStudentsAvgScores()
        {
            const string sqlQuery = "SELECT * FROM dbo.StudentScores";

            using var sqlConnection = new SqlConnection(connectionStringStudents);

            sqlConnection.Open();

            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            using var reader = sqlCommand.ExecuteReader();
            int i = 0;

            while (reader.Read())
            {
                var avgScore = reader["avgScore"].ToString();
                i++;
                Console.WriteLine($"{1} - {avgScore}");

            }
        }
        private static void getStudentsTreshold()
        {
            double threshold = Convert.ToDouble(Console.ReadLine());

            const string sqlQuery = "SELECT * FROM dbo.StudentScores";

            using var sqlConnection = new SqlConnection(connectionStringStudents);

            sqlConnection.Open();

            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            using var reader = sqlCommand.ExecuteReader();
            int i = 0;

            while (reader.Read())
            {
                var sName = reader["name"].ToString();
                var sAvgScore = reader["avgScore"].ToString();

                if(Convert.ToDouble(sAvgScore) >= threshold)
                {
                    Console.WriteLine($"{sName} - {sAvgScore}");
                }
            }
        }
        private static void getMinimalSubjects()
        {
            const string sqlQuery = "SELECT * FROM dbo.StudentScores";

            using var sqlConnection = new SqlConnection(connectionStringStudents);

            sqlConnection.Open();

            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            using var reader = sqlCommand.ExecuteReader();

            Dictionary<string, string> minSubjects = new Dictionary<string, string>();
            int i = 0;

            while (reader.Read())
            {
                var minSubject = reader["minSubject"].ToString();
                if (!minSubjects.ContainsKey(minSubject))
                {
                    minSubjects.Add(minSubject, minSubject);
                }
                
            }

            foreach (var item in minSubjects)
            {
                Console.WriteLine(item.Value);
            }
        }

        //4 task


    }
}
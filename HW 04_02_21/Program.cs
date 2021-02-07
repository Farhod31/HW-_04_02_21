using System;
using System.Data;
using System.Data.SqlClient;
namespace HW_04_02_21
{
    class Program
    {
        static void Main()
        {
            const string connectionString = @"Data source= DESKTOP-H6C3FQ5; initial catalog=Hw.04.02.21; Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);



            connection.Open();
            if (connection.State == ConnectionState.Open)
            {


                Console.WriteLine("Connected Successfuly ");
            }
            int number;
            Console.WriteLine("Введите число: \n1  Insert (Добавление) \n2  Select All(Выбрать всё) \n3  Select by Id (Выбрать один по Id) \n4  Update (Обновить каждый столбец кроме Id) \n5 Delete (Удалить один по Id)");
            number = Convert.ToInt32(Console.ReadLine());
            SqlCommand command = connection.CreateCommand();
            if (number == 1)
            {
                Console.Write("LastName = ");
                string LastName = Console.ReadLine();
                Console.Write("FistName = ");
                string FistName = Console.ReadLine();
                Console.Write("MiddleName = ");
                string MiddleName = Console.ReadLine();
                Console.Write("BirthDate = ");
                string BirthDate = Console.ReadLine();
                command.CommandText = $"Insert into Person ([LastName],[FistName],[MiddleName], [BirthDate]) values ('{LastName}', '{FistName}', '{MiddleName}', '{BirthDate}')";
                var result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("The person is added!");
                }

            }

            if (number == 2)
            {
                command.CommandText = "Select * from Person";
                var reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Console.WriteLine($"Id: {reader["Id"]}, LastName: {reader["LastName"]}, FirstName: {reader["Firstame"]}, MiddleName: {reader["MiddleName"]}, BirthDate{reader["BirthDate"]}");
                }

            }
            if (number == 3)
            {
                int id;
                Console.WriteLine("Введите Id чел. от 1 до 5 ");
                id = Convert.ToInt32(Console.ReadLine());
                command.CommandText = $"Select *from Person where Id = {id}";

                var reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Console.WriteLine($"Id: {reader["Id"]}, LastName: {reader["LastName"]}, FirstName: {reader["FirstName"]}, MiddleName: {reader["MiddleName"]}, BirthDate{reader["BirthDate"]}");
                }

            }
            if (number == 4)
            {
                int idnumber = 0;
                Console.WriteLine("Введите ID = ");
                idnumber = Convert.ToInt32(Console.ReadLine());

                string updatelastname;
                Console.WriteLine("Новую  Фамилию введите = ");
                updatelastname = Console.ReadLine();
                string updatefirstname;
                Console.WriteLine("Введите новое имя = ");
                updatefirstname = Console.ReadLine();
                string updatemiddlename;
                Console.WriteLine("Введите новое отчество = ");
                updatemiddlename = Console.ReadLine();
                string updatebirthdate;
                Console.WriteLine("Введите новую дату рождения = ");
                updatebirthdate = Console.ReadLine();
                command.CommandText = "update person set " + "LastName = " + $"'{updatelastname}'," + "FirstName = " + $"'{updatefirstname}'," + "MiddleName = " + $"'{updatemiddlename}'," + "BirthDate = " + $"'{updatebirthdate} '" + "where Id = " + $"'{idnumber}'";

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    Console.WriteLine("Seccessfully uploaded information!");
                }
            
                var reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Console.WriteLine($"Id: {reader["Id"]}, LastName: {reader["v"]}, FirstName: {reader["FirstName"]}, MiddleName: {reader["MiddleName"]}, BirthDate{reader["BirthDate"]}");
                }


            }
            if (number == 5)
            {
                int id;
                Console.WriteLine("Введите ID человека которого хотите  удалить = ");
                id = Convert.ToInt32(Console.ReadLine());
                command.CommandText = $"Delete Person where Id = {id}";
                int result1 = command.ExecuteNonQuery();
                if (result1 > 0)
                {
                    Console.WriteLine("Seccessfully deleted the person under ID = " + id);
                }

            }



        }
    }
}

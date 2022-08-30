//Спроектируйте систему учета посещаемости студентов по датам (в консольном приложении)
//1.При вводе в консоль команды “статистика” программа должна выводить информации о посещаемости
//1.1. Создать таблицу: “Посещаемость” (id, ФИО студента, дата)
//1.2.Заполнить эту таблицу тестовыми данными
//ДЗ:
//2.Добавьте возможность добавления новых студентов через консоль
//3. Добавьте возможность указывать инфо о посещаемости для студента по дате

using Npgsql;
using System.Collections.Generic;
using System.IO;

var db_path = "Server=localhost;Port=5432;Username=postgres;Password=admin;Database=attendance";
using var DB_connection = new NpgsqlConnection(db_path);
DB_connection.Open();
Console.WriteLine("OK");
using var executing_commands = new NpgsqlCommand();
executing_commands.Connection = DB_connection;

//executing_commands.CommandText = @"CREATE TABLE statistics(
//        id SERIAL PRIMARY KEY,
//        FIO VARCHAR(70), data date)";
//executing_commands.ExecuteNonQuery();



//executing_commands.CommandText = "INSERT INTO statistics(FIO, data) VALUES('Тест1','2022-08-30')";
//executing_commands.ExecuteNonQuery();

//executing_commands.CommandText = @"ALTER TABLE statistics               
//                                  ADD info_students CHARACTER VARYING(30) NOT NULL DEFAULT 'Присутствует'";      // для автоматического заполнения последнего столбца
//executing_commands.ExecuteNonQuery();

Console.WriteLine("Хотите ли вы просметреть статистику?");
Viewstatistics();
Console.WriteLine("Хотите ли вы добавить еще студента");
Add_a_student();


Console.WriteLine("OK ");

void Viewstatistics () {
   
   var a = Console.ReadLine();
if (a == "статистика")
{
        string sql = "SELECT * FROM statistics";
        using var executing_commands_ = new NpgsqlCommand(sql, DB_connection);

        using NpgsqlDataReader read_the_data = executing_commands_.ExecuteReader();

        while (read_the_data.Read())
        {
            Console.WriteLine("{0} {1} {2}", read_the_data.GetInt32(0), read_the_data.GetString(1),
            read_the_data.GetDate(2));
        }
    
    }
else
{
        Console.WriteLine("Вы пропустили данный пункт");
    }
}
void Add_a_student()
{
    var da = Console.ReadLine();
    if (da == "да")
    {
        Console.WriteLine("Введите ФИО студента и дату его прибытия");
        executing_commands.CommandText = "INSERT INTO statistics(FIO, data) VALUES" + Console.ReadLine();
        executing_commands.ExecuteNonQuery();
    }
    else
    {
        Console.WriteLine("Вы пропустили данный этап");
    }
}















/// пока не додумал///

//Console.WriteLine("Добавить информация посещаемости о студенте");
//var stud = Console.ReadLine();
//if (stud == "да")
//{
//    Console.WriteLine("Введите интересующую Вас дату");
//    //var data_1 = Console.ReadLine();
//    string sql = $"select data,FIO from statistics where data ='2022-02-01'";
//    using var executing_commands_ = new NpgsqlCommand(sql, DB_connection);

//    using NpgsqlDataReader read_the_data = executing_commands_.ExecuteReader();

//    while (read_the_data.Read())
//    {
//        Console.WriteLine("{0} {1} {2}", read_the_data.GetInt32(0), read_the_data.GetDate(1), read_the_data.GetString(2)
//        );
//    }

//}

//executing_commands.CommandText = @"CREATE TABLE info1(
//        id_info SERIAL PRIMARY KEY,
//        InfoId INTEGER NOT NULL REFERENCES statistics(id) ON DELETE CASCADE,
//        pos VARCHAR(70))";         
//       executing_commands.ExecuteNonQuery();





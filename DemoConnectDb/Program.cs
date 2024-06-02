// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

internal class Program
{
    static void ShowDataTable(DataTable table)
    {
        Console.WriteLine("Bảng: " + table.TableName);
        // Hiện thị các cột
        foreach (DataColumn column in table.Columns)
        {
            Console.Write($"{column.ColumnName,15}");
        }
        Console.WriteLine();

        // Hiện thị các dòng dữ liệu
        int number_cols = table.Columns.Count;
        foreach (DataRow row in table.Rows)
        {
            for (int i = 0; i < number_cols; i++)
            {
                Console.Write($"{row[i],15}");
            }
            Console.WriteLine();
        }

    }
    private static void Main(string[] args)
    {
        try
        {
            string sqlconnectStr = "Data Source=localhost;Initial Catalog=LAYLOIHOI_DB;User ID=sa;Password=123456";
            var connection = new SqlConnection(sqlconnectStr);
            connection.Open();
            // dùng sqlcommand thi hành sql  
            //string sql = "select top(2) * from khach_hang";

            //// khoi tao 1 doi tuong commmad
            //using DbCommand command = new SqlCommand(sql, connection);
            //// thiet lap cac thuoc tinh thong qua chuoi string connection 
            //var reader = command.ExecuteReader(); //ket qua tra ve nhieu dong 
            //                                      //command.executescalar(); ket qua tra ve 1 ban ghi (detail)
            //                                      //command.executenonquery(); dung de insert, update, delete
            //                                      // đọc kết quả truy vấn
            //Console.WriteLine("\r\ncác kh:");
            //Console.WriteLine($"{"makh ",10} {"tenkh "}");
            //while (reader.Read())
            //{
            //    Console.WriteLine($"{reader["makh"],10} {reader["tenkh"]}");
            //}
            // data apter data set 
            // tao doi tuong anh xa tu csdl den dataset 
            var adapter = new SqlDataAdapter();
            // tao ra thuoc tinh 
            adapter.TableMappings.Add("table", "KHACH_HANG");

            // dataadapter lay data ve do vao bang (tbale) 
            adapter.SelectCommand = new SqlCommand("select * from KHACH_HANG", connection);

            //dataset tao ra luu tru table ko connect vs csdl lam vc doc lap
            var dataSet = new DataSet();
            adapter.Fill(dataSet, "KHACH_HANG");

            DataTable tabale1 = dataSet.Tables["KHACH_HANG"];
            ShowDataTable(tabale1);

            // không dùng đến kết nối thì phải đóng lại (giải phóng)
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
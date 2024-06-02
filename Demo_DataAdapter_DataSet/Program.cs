using Microsoft.Data.SqlClient;
using System.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            string sqlconnectStr = "Data Source=localhost;Initial Catalog=LAYLOIHOI_DB;User ID=sa;Password=123456";
            var connection = new SqlConnection(sqlconnectStr);
            connection.Open();
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

            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

}
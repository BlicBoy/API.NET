using MySql.Data.MySqlClient;

namespace api;


public class DataBaseConnection
{

    private MySqlConnection conn;

    public DataBaseConnection()
    {
        string cs = @"server=localhost;userid=root;password=;database=testeAPI";      //Alterar aqui a ligação
        conn = new MySqlConnection(cs);
        conn.Open();
    }

    public MySqlDataReader DbQuery(String query)
    {
        var cmd = new MySqlCommand(query, conn);
        return cmd.ExecuteReader();
    }

    
    public int DBNonQuery(String query)
    {
        var cmd = new MySqlCommand(query, conn);
        return cmd.ExecuteNonQuery();
    }


    public void Close()
    {
        conn.Close();
    }

}
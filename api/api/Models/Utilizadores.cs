namespace api.Models;

public class Utilizadores
{
    public int id { get; set; }
    public string nome { get; set; }
    public string morada { get; set; }
    public string codigoPostal { get; set; }
    public string dataNascimento { get; set; }

    public static List<Utilizadores> GetAllItems()
    {
        List<Utilizadores> utilizadoresList = new List<Utilizadores>();

        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM utilizadores;");

        while (reader.Read())
        {
            var utilizadores = new Utilizadores();
            utilizadores.id = reader.GetInt32(0);
            utilizadores.nome = reader.GetString(1);
            utilizadores.morada = reader.GetString(2);
            utilizadores.codigoPostal = reader.GetString(3);
            utilizadores.dataNascimento = reader.GetString(4);
            
            
            utilizadoresList.Add(utilizadores);
        }
        
        dbCon.Close();
        return utilizadoresList;
    }


    public static Utilizadores? GetItem(string id)
    {
        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM utilizadores WHERE id = " + id + ";");

        if (reader.Read())
        {
            var utilizador = new Utilizadores();
            utilizador.id = reader.GetInt32(0);
            utilizador.nome = reader.GetString(1);
            utilizador.morada = reader.GetString(2);
            utilizador.codigoPostal = reader.GetString(3);
            utilizador.dataNascimento = reader.GetString(4);
            dbCon.Close();
            return utilizador;
        }
        else
        {
            dbCon.Close();
            return null;
        }
    }

    public static string CreateUser(Utilizadores user)
    {
        var dbCon = new DataBaseConnection();
        var result = dbCon.DBNonQuery("INSERT INTO utilizadores(nome,morada,codigoPostal,dataNascimento) " +
                                      "VALUES('" 
                                      + user.nome + "','" 
                                      + user.morada + "','" 
                                      + user.codigoPostal + "','" +
                                      user.dataNascimento + "')");
        
        dbCon.Close();
        if (result > 0)
        {
            return "{ \"status\" :\"ok\" }";
        }
        else
        {
            return "{ \"status\" :\"error\" }";
        }
    }

    public static string UpdateUser(string id, Utilizadores user)
    {
        var dbCon = new DataBaseConnection();
        
        String strQuery =
            "UPDATE utilizadores  SET " +
            "nome          = '" + user.nome           +"', "+
            "morada      = '" + user.morada       +"', "+
            "codigoPostal               = '" + user.codigoPostal             +"', "+
            "dataNascimento                  = '" + user.dataNascimento                 +"' " +
            "WHERE id = '" + id + "'";
        
        
        var result = dbCon.DBNonQuery(strQuery);

         
        dbCon.Close();
        if (result > 0)
        {
            return "{ \"status\" :\"ok\" }";
        }
        else
        {
            return "{ \"status\" :\"error\" }";
        }
    }

    public static string Delete(string id)
    {
        var dbCon = new DataBaseConnection();

        int result = dbCon.DBNonQuery("DELETE FROM utilizadores WHERE id = '" + id + "'");
    
        dbCon.Close();
        if (result > 0)
        {
            return "{ \"status\" :\"ok\" }";
        }
        else
        {
            return "{ \"status\" :\"error\" }";
        }
    }


}
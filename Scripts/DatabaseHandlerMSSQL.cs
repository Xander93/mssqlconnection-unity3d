using UnityEngine;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

public class DatabaseHandlerMSSQL : MonoBehaviour
{
    public string host, database, user, password;

    private string _conString = @"Data Source = 127.0.0.1; 
     user id = Username;
     password = Password;
     Initial Catalog = DatabaseName;";

    void Awake() {
        _conString = @"Data Source =" + host + ";user id =" + user + ";password=" + password + ";Initial Catalog =" + database + ";";
    }

    public string SimpleQuery(string _query)
    {
        using (SqlConnection dbCon = new SqlConnection(_conString))
        {
            SqlCommand cmd = new SqlCommand(_query, dbCon);
            try
            {
                dbCon.Open();
                string _returnQuery = (string)cmd.ExecuteScalar();
                return _returnQuery;
            }
            catch (SqlException _exception)
            {
                Debug.LogWarning(_exception.ToString());
                return null;
            }
        }
    }

    //then you can use something like this
    void Start()
    {
        string _stringRequest = SimpleQuery("SELECT TOP 1 ColumnName FROM TableName WHERE ColumnName2 = 'SomeValue'");
        print(_stringRequest);
    }
}
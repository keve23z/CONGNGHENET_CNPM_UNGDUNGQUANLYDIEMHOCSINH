using System;
using System.Data;
using System.Data.SqlClient;

namespace UNGDUNGQUANLYDIEMHOCSINH.Services
{
    public class DBConnect
    {
        private SqlConnection _conn;
        private DataSet _dataSet;

        private string _strConnect;
        private string _strServerName;
        private string _strDBName;
        private string _strUserID;
        private string _strPassword;

        public SqlConnection Conn
        {
            get { return _conn; }
            set { _conn = value; }
        }

        public DataSet DataSet
        {
            get { return _dataSet; }
            set { _dataSet = value; }
        }

        public string StrConnect
        {
            get { return _strConnect; }
            set { _strConnect = value; }
        }

        public string StrServerName
        {
            get { return _strServerName; }
            set { _strServerName = value; }
        }

        public string StrDBName
        {
            get { return _strDBName; }
            set { _strDBName = value; }
        }

        public string StrUserID
        {
            get { return _strUserID; }
            set { _strUserID = value; }
        }

        public string StrPassword
        {
            get { return _strPassword; }
            set { _strPassword = value; }
        }

        public DBConnect(string connectionString)
        {
            StrConnect = connectionString;
            Conn = new SqlConnection(StrConnect);
            DataSet = new DataSet(StrConnect);
        }

        public DBConnect(string pServerName, string pDBName)
        {
            StrServerName = pServerName;
            StrDBName = pDBName;
            StrUserID = "";
            StrPassword = "";

            StrConnect = @"Data Source=" + StrServerName + ";Initial Catalog=" + StrDBName + ";Integrated Security=true";
            Conn = new SqlConnection(StrConnect);
            DataSet = new DataSet(StrConnect);
        }

        public DBConnect(string pServerName, string pDBName, string pUserID, string pPassword)
        {
            StrServerName = pServerName;
            StrDBName = pDBName;
            StrUserID = pUserID;
            StrPassword = pPassword;

            StrConnect = @"Data Source=" + StrServerName + ";Initial Catalog=" + StrDBName + ";User ID=" + StrUserID + ";Password=" + StrPassword;
            Conn = new SqlConnection(StrConnect);
            DataSet = new DataSet(StrConnect);
        }

        public void OpenConnect()
        {
            if (Conn.State == ConnectionState.Closed)
            {
                Conn.Open();
            }
        }

        public void CloseConnect()
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
        }

        public void DisposeConnect()
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
            Conn.Dispose();
        }

        public void UpdateToDataBase(string strSQL)
        {
            OpenConnect();

            SqlCommand cmd = GetSQLCommand(Conn, strSQL);

            cmd.ExecuteNonQuery();
            CloseConnect();
        }

        public int GetCount(string strSQL)
        {
            OpenConnect();
            SqlCommand cmd = GetSQLCommand(Conn, strSQL);

            int count = (int) cmd.ExecuteScalar();

            CloseConnect();
            return count;
        }


        public bool CheckExist(string tableName, string fieldName, string fieldValue)
        {
            string strSQL = "SELECT COUNT(*) FROM " + tableName + " WHERE " + fieldName + "='" + fieldValue + "'";

            return GetCount(strSQL) > 0;
        }

        private SqlCommand GetSQLCommand(SqlConnection connection, string commandText)
        {
            return new SqlCommand()
            {
                CommandText = commandText,
                Connection = connection
            };
        }

        public SqlDataReader GetDataReader(string strSQL)
        {
            OpenConnect();

            SqlCommand cmd = new SqlCommand()
            {
                CommandText = strSQL,
                Connection = Conn
            };

            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            return sqlDataReader;
        }

        public SqlDataAdapter GetDataAdapter(string strSQL, string tableName)
        {
            OpenConnect();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(strSQL, Conn);

            sqlDataAdapter.Fill(DataSet, tableName);

            CloseConnect();
            return sqlDataAdapter;
        }

        public DataTable GetDataTable(string strSQL, string tableName)
        {
            OpenConnect();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(strSQL, Conn);
            sqlDataAdapter.Fill(DataSet, tableName);

            CloseConnect();
            return DataSet.Tables[tableName];
        }

        public DataTable GetDataTable(string strSQL, string tableName, params string[] keyNames)
        {
            OpenConnect();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(strSQL, Conn);
            sqlDataAdapter.Fill(DataSet, tableName);

            int keyLength = keyNames.Length;

            DataColumn[] primaryKey = new DataColumn[keyLength];

            for (int i = 0; i < keyLength; ++i)
            {
                primaryKey[i] = DataSet.Tables[tableName].Columns[keyNames[i]];
            }

            DataSet.Tables[tableName].PrimaryKey = primaryKey;

            CloseConnect();
            return DataSet.Tables[tableName];
        }

        public object ExecuteScalar(string strSQL)
        {
            OpenConnect();

            SqlCommand cmd = new SqlCommand()
            {
                CommandText = strSQL,
                Connection = Conn
            };

            object result = cmd.ExecuteScalar();
            CloseConnect();

            return result;
        }

        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(StrConnect))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}

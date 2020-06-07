using Dapper;
using Quantium.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quantium
{
    class DataAccess
    {
        private static SQLiteCommand m_sqlCmd = new SQLiteCommand();
//        private static SQLiteConnection m_dbConn;
        const string pointsListTableName = "pointslist";
        const string methodicTableName = "methodic";
        const string methodicListTableName = "methodiclist";
        const string diseaseListTableName = "diseaselist";

        const string dbFileName = "quantum.db";
        //id_point,time,power,name,memo,coordX,coordY,channel,side,pointname
        const int ID_IDX = 0;
        const int POINT_TIME_IDX = 1;
        const int POINT_POWER_IDX = 2;
        const int METHODIC_NAME_IDX = 3;
        const int METHODIC_MEMO_IDX = 4;
        const int COORD_X_IDX = 5;
        const int COORD_Y_IDX = 6;
        const int CHANNEL_IDX = 7;
        const int SIDE_IDX = 8;
        const int POINT_NAME_IDX = 9;

        public static int selectedPointId { get; set; }

        public static List<int> listPointsId = new List<int>();

        public static void CreateTables()
        {
            if (!File.Exists(@dbFileName)) 
            {
                SQLiteConnection.CreateFile(@dbFileName);
            }

            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source="+ dbFileName+"; Version=3;")) 
            {
                Connect.Open();
                string commandText = "CREATE TABLE IF NOT EXISTS ["+ pointsListTableName+ "] ( [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [coordX] INT, [coordY] INT, [channel] INT, [side] NVARCHAR(10), [pointname] NVARCHAR(10))"; 
                SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
                Command.ExecuteNonQuery();

                commandText = "CREATE TABLE IF NOT EXISTS [" + methodicTableName + "] ( [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [id_methodic] INT, [id_point] INT, [time] INT, [power] INT," +
                    "FOREIGN KEY ([id_point]) REFERENCES [" + pointsListTableName + "]([id]), FOREIGN KEY ([id_methodic]) REFERENCES [" + methodicListTableName + "]([id]))";
                Command = new SQLiteCommand(commandText, Connect);
                Command.ExecuteNonQuery();

                commandText = "CREATE TABLE IF NOT EXISTS [" + methodicListTableName + "] ( [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [name] NVARCHAR(10), [memo] MEMO, [map_front] MEMO, [map_back] MEMO, [human_front] MEMO ,[human_back] MEMO)"; 
                Command = new SQLiteCommand(commandText, Connect);
                Command.ExecuteNonQuery();

                commandText = "CREATE TABLE IF NOT EXISTS [" + diseaseListTableName + "] ( [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [name] NVARCHAR(20))";
                Command = new SQLiteCommand(commandText, Connect);
                Command.ExecuteNonQuery();

                Connect.Close(); 
            }
        }

        public static void AddPointToTable(PointModel pointModel)
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=" + dbFileName + "; Version=3;"))
            {
                Connect.Open();
                string commandText = "INSERT INTO " + pointsListTableName + " ('coordX', 'coordY', 'channel', 'side', 'pointname') VALUES(" + 
                    pointModel.coordX.ToString() + ", " + 
                    pointModel.coordY.ToString() + ", " +
                    pointModel.channel + ", '" +
                    pointModel.side + "', '" +
                    pointModel.pointname + "')";
                
                SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
                Command.Parameters.AddWithValue("@coordX", pointModel.coordX);
                Command.Parameters.AddWithValue("@coordY", pointModel.coordY);
                Command.Parameters.AddWithValue("@channel", pointModel.channel);
                Command.Parameters.AddWithValue("@side", pointModel.side);
                Command.Parameters.AddWithValue("@pointname", pointModel.pointname);
                Command.ExecuteNonQuery();
                //Connect.Close();
            }
        }

        public static void AddNewMethodic(String name, String memo, String mapFrontFileName, String mapBackFileName, String humanModelFrontFileName, String humanModelBackFileName)
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=" + dbFileName + "; Version=3;"))
            {
                Connect.Open();
                
                string commandText = "INSERT INTO " + methodicListTableName + " ('name', 'memo', 'map_front', 'map_back','human_front', 'human_back') VALUES('" + 
                    name + "', '" + memo + "', '" + 
                    mapFrontFileName + "', '" + mapBackFileName + "', '" + 
                    humanModelFrontFileName + "', '" + humanModelBackFileName + "')";
                
                SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
                Command.Parameters.AddWithValue("@name", name);
                Command.Parameters.AddWithValue("@memo", memo);
                Command.Parameters.AddWithValue("@map_front", mapFrontFileName);
                Command.Parameters.AddWithValue("@map_back", mapBackFileName);
                Command.Parameters.AddWithValue("@human_front", humanModelFrontFileName);
                Command.Parameters.AddWithValue("@human_back", humanModelBackFileName);
                Command.ExecuteNonQuery();
                //Connect.Close();
            }
        }
        public static void AddDisease(String name)
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=" + dbFileName + "; Version=3;"))
            {
                Connect.Open();

                string commandText = "INSERT INTO " + diseaseListTableName + " ('name') VALUES('" +
                    name + "')";

                SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
                Command.Parameters.AddWithValue("@name", name);
                Command.ExecuteNonQuery();
                //Connect.Close();
            }
        }

        public static void AddPointToMethodic(int methodic_id, int pointid, int time, int power)
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=" + dbFileName + "; Version=3;"))
            {
                Connect.Open();
                string commandText = "INSERT INTO " + methodicTableName + " ('id_methodic', 'id_point', 'time', 'power') VALUES(" + methodic_id + ", " + pointid + ", " + time + ", " + power + ")";

                SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
                Command.Parameters.AddWithValue("@id_methodic", methodic_id);
                Command.Parameters.AddWithValue("@id_point", pointid);
                Command.Parameters.AddWithValue("@time", time);
                Command.Parameters.AddWithValue("@power", power);
                Command.ExecuteNonQuery();
                //Connect.Close();
            }
        }

        public static void UpdatePointsModel(List<PointModel> pointModels)
        {
            DataTable dTable = new DataTable();
            String sqlQuery;

            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=" + dbFileName + "; Version=3;"))
            {
                Connect.Open();
                if (Connect.State != ConnectionState.Open)
                {
                    MessageBox.Show("Open connection with database");
                    return;
                }
                try
                {
                    sqlQuery = "SELECT * FROM " + pointsListTableName;
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, Connect);
                    adapter.Fill(dTable);

                    if (dTable.Rows.Count > 0)
                    {
                        pointModels.Clear();
                        for (int i = 0; i < dTable.Rows.Count; i++)
                        {
                            pointModels.Add(new PointModel(
                                Convert.ToInt32(dTable.Rows[i].ItemArray[1]),
                                Convert.ToInt32(dTable.Rows[i].ItemArray[2]),
                                Convert.ToInt32(dTable.Rows[i].ItemArray[3]),
                                dTable.Rows[i].ItemArray[4].ToString(),
                                dTable.Rows[i].ItemArray[5].ToString(),
                                Convert.ToInt32(dTable.Rows[i].ItemArray[0])));
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        public static void ReadPointsTable(List<PointModel> pointModels)
        {
            DataTable dTable = new DataTable();
            String sqlQuery;

            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=" + dbFileName + "; Version=3;"))
            {
                Connect.Open();
                if (Connect.State != ConnectionState.Open)
                {
                    MessageBox.Show("Open connection with database");
                    return;
                }
                try
                {
                    sqlQuery = "SELECT * FROM " + pointsListTableName;
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, Connect);
                    adapter.Fill(dTable);

                    if (dTable.Rows.Count > 0)
                    {
                        pointModels.Clear();
                        for (int i = 0; i < dTable.Rows.Count; i++)
                        {
                            pointModels.Add(new PointModel(
                                Convert.ToInt32(dTable.Rows[i].ItemArray[1]),
                                Convert.ToInt32(dTable.Rows[i].ItemArray[2]),
                                Convert.ToInt32(dTable.Rows[i].ItemArray[3]),
                                dTable.Rows[i].ItemArray[4].ToString(),
                                dTable.Rows[i].ItemArray[5].ToString(),
                                Convert.ToInt32(dTable.Rows[i].ItemArray[0])));
                        }                            
                    }
                    else {
                        //Form1 form = new Form1();
                    }
                        //MessageBox.Show("Database is empty");
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        public static void PointsListId(List<int> listPointsId)
        {
            DataTable dTable = new DataTable();
            String sqlQuery;

            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=" + dbFileName + "; Version=3;"))
            {
                Connect.Open();
                if (Connect.State != ConnectionState.Open)
                {
                    MessageBox.Show("Open connection with database");
                    return;
                }
                try
                {
                    sqlQuery = "SELECT * FROM " + pointsListTableName;
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, Connect);
                    adapter.Fill(dTable);

                    if (dTable.Rows.Count > 0)
                    {
                        listPointsId.Clear();
                        for (int i = 0; i < dTable.Rows.Count; i++)
                        {
                            listPointsId.Add(Convert.ToInt32(dTable.Rows[i].ItemArray[0]));
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        public static int GetPointIdFromList(int index)
        {
            DataTable dTable = new DataTable();
            String sqlQuery;

            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=" + dbFileName + "; Version=3;"))
            {
                Connect.Open();
                if (Connect.State != ConnectionState.Open)
                {
                    MessageBox.Show("Open connection with database");
                    return -1;
                }
                try
                {
                    sqlQuery = "SELECT * FROM " + pointsListTableName + " WHERE id=" + listPointsId.ElementAt(index); 
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, Connect);
                    adapter.Fill(dTable);

                    if (dTable.Rows.Count == 1)
                    {
                        return Convert.ToInt32(dTable.Rows[0].ItemArray[0]);
                    }
                    else
                    {
                        return -1;
                    }
                    //MessageBox.Show("Database is empty");
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return -1;
                }
            }
        }

        public static void ReadMethodicListTable(List<MethodicItemModel> methodicItemModels)//ComboBox combobox, List<FilePathModel> filePathModelList, Form1 form)
        {
            DataTable dTable = new DataTable();
            String sqlQuery;

            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=" + dbFileName + "; Version=3;"))
            {
                Connect.Open();
                if (Connect.State != ConnectionState.Open)
                {
                    MessageBox.Show("Open connection with database");
                    return;
                }
                try
                {
                    sqlQuery = "SELECT name, memo,map_front,map_back,human_front,human_back FROM " + methodicListTableName;
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, Connect);
                    adapter.Fill(dTable);

                    if (dTable.Rows.Count > 0)
                    {
                        methodicItemModels.Clear();

                        for (int i = 0; i < dTable.Rows.Count; i++)
                        {
                            methodicItemModels.Add(new MethodicItemModel(
                                dTable.Rows[i].ItemArray[0].ToString(),
                                dTable.Rows[i].ItemArray[1].ToString(),
                                dTable.Rows[i].ItemArray[2].ToString(),
                                dTable.Rows[i].ItemArray[3].ToString(),
                                dTable.Rows[i].ItemArray[4].ToString(),
                                dTable.Rows[i].ItemArray[5].ToString()
                                ));
                        }
                    }
                    else
                    {
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        public static void ReadMethodicTable(List<MethodicModel> methodicModels, int methodicId)//ComboBox combobox, int  methodicId, List<PointModel> pointModels)
        {
            String sqlQuery;
            
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=" + dbFileName + "; Version=3;"))
            {
                Connect.Open();
                if (Connect.State != ConnectionState.Open)
                {
                    MessageBox.Show("Open connection with database");
                    return;
                }
                try
                {
                    sqlQuery = "SELECT id_point,time,power,name,memo,coordX,coordY,channel,side,pointname FROM " + methodicTableName+" JOIN " + 
                        methodicListTableName +" ON "+methodicListTableName+".id = id_methodic JOIN " + 
                        pointsListTableName +" ON "+pointsListTableName + ".id = id_point WHERE id_methodic=" + methodicId.ToString();
                    
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, Connect);
                    DataTable dTable = new DataTable();
                    adapter.Fill(dTable);
                    methodicModels.Clear();
                    if (dTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dTable.Rows.Count; i++)
                        {
                            methodicModels.Add(new MethodicModel(
                                dTable.Rows[i].ItemArray[METHODIC_NAME_IDX].ToString(),
                                dTable.Rows[i].ItemArray[POINT_NAME_IDX].ToString(),
                                Convert.ToInt32(dTable.Rows[i].ItemArray[COORD_X_IDX]),
                                Convert.ToInt32(dTable.Rows[i].ItemArray[COORD_Y_IDX]),
                                Convert.ToInt32(dTable.Rows[i].ItemArray[CHANNEL_IDX]),
                                dTable.Rows[i].ItemArray[SIDE_IDX].ToString(),
                                Convert.ToInt32(dTable.Rows[i].ItemArray[ID_IDX]),
                                Convert.ToInt32(dTable.Rows[i].ItemArray[POINT_TIME_IDX]),
                                Convert.ToInt32(dTable.Rows[i].ItemArray[POINT_POWER_IDX])
                                ));
                        }
                    }
                     
                    else
                    {
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        public static void RemoveRecordFromMethodicTable()
        {
            DataTable dTable = new DataTable();
            String sqlQuery;

            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=" + dbFileName + "; Version=3;"))
            {
                Connect.Open();
                if (Connect.State != ConnectionState.Open)
                {
                    MessageBox.Show("Open connection with database");
                    return;
                }
                try
                {
                    sqlQuery = "DELETE FROM " + pointsListTableName+ " WHERE id="+selectedPointId;
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, Connect);
                    adapter.Fill(dTable);
                    MessageBox.Show("Point deleted");
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}


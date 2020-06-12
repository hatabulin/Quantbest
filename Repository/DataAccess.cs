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

        const string humanPointsListTableName = "human_points_list";
        const string humanModelTableListName = "human_models_list";
        const string methodicListTableName = "methodi_clist";
        const string diseaseListTableName = "disease_list";
        const string mainPointsListTableName = "main_points_list";
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
        const int HUMAN_MODEL_IDX = 10;

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
                SQLiteCommand Command;
                string commandText;
                Connect.Open();

                commandText = "CREATE TABLE IF NOT EXISTS [" + methodicListTableName + "] ( [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [methodic_name] NVARCHAR(10), [methodic_memo] MEMO, [human_model_id] INT)";
                Command = new SQLiteCommand(commandText, Connect);
                Command.ExecuteNonQuery();

                commandText = "CREATE TABLE IF NOT EXISTS [" + diseaseListTableName + "] ( [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [name] NVARCHAR(20))";
                Command = new SQLiteCommand(commandText, Connect);
                Command.ExecuteNonQuery();

                commandText = "CREATE TABLE IF NOT EXISTS [" + humanModelTableListName + "] ( [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [human_model_name] NVARCHAR(20), [map_front] MEMO, [map_back] MEMO, [body_front] MEMO ,[body_back] MEMO)";
                Command = new SQLiteCommand(commandText, Connect);
                Command.ExecuteNonQuery();

                commandText = "CREATE TABLE IF NOT EXISTS ["+ humanPointsListTableName+ "] ( [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, " +
                    "[coord_X] INT, [coord_Y] INT, [channel_number] INT, [side] NVARCHAR(10), [point_name] NVARCHAR(10), " +
                    "[human_model_id] INT, FOREIGN KEY ([human_model_id]) REFERENCES [" + humanModelTableListName +"]([id]))";
                Command = new SQLiteCommand(commandText, Connect);
                Command.ExecuteNonQuery();

                commandText = "CREATE TABLE IF NOT EXISTS [" + mainPointsListTableName + "] ( [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, " +
                    "[coord_X] INT, [coord_Y] INT, [channel_number] INT, [time] INT, [power] INT, [side] NVARCHAR(10), [point_name] NVARCHAR(10), " +
                    "[human_model_id] INT, FOREIGN KEY ([human_model_id]) REFERENCES [" + humanModelTableListName + "]([id]))";
                Command = new SQLiteCommand(commandText, Connect);
                Command.ExecuteNonQuery();
                Connect.Close(); 
            }
        }

        public static void AddToHumanPointsTable(PointModel pointModel)
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=" + dbFileName + "; Version=3;"))
            {
                Connect.Open();
                string commandText = "INSERT INTO " + humanPointsListTableName + " ('coord_X', 'coord_Y', 'channel_number', 'side', 'point_name', 'human_model_id') VALUES(" + 
                    pointModel.coordX.ToString() + ", " + 
                    pointModel.coordY.ToString() + ", " +
                    pointModel.channel + ", '" +
                    pointModel.side + "', '" +
                    pointModel.pointname + "', " +
                    pointModel.id_human_model + ")";
                
                SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
                Command.Parameters.AddWithValue("@coord_X", pointModel.coordX);
                Command.Parameters.AddWithValue("@coord_Y", pointModel.coordY);
                Command.Parameters.AddWithValue("@channel_number", pointModel.channel);
                Command.Parameters.AddWithValue("@side", pointModel.side);
                Command.Parameters.AddWithValue("@point_name", pointModel.pointname);
                Command.Parameters.AddWithValue("@human_model_id", pointModel.id_human_model);
                Command.ExecuteNonQuery();
                //Connect.Close();
            }
        }

        public static void AddToMethodicList(String name, String memo, int humanModelId)
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=" + dbFileName + "; Version=3;"))
            {
                Connect.Open();
                
                string commandText = "INSERT INTO " + methodicListTableName + " ('methodic_name', 'methodic_memo', 'human_model_id') VALUES('" + 
                    name + "', '" + memo + "', " + humanModelId +")";
                
                SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
                Command.Parameters.AddWithValue("@methodic_name", name);
                Command.Parameters.AddWithValue("@methodic_memo", memo);
                Command.Parameters.AddWithValue("@human_model_id", humanModelId);
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

        public static void AddToHumanModelList(HumanModel humanModel)
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=" + dbFileName + "; Version=3;"))
            {
                Connect.Open();

                string commandText = "INSERT INTO " + humanModelTableListName + " ('human_model_name', 'map_front', 'map_back', 'body_front', 'body_back') VALUES('" +
                    humanModel.name + "', '" + humanModel.mapFrontPath + "', '" + humanModel.mapBackPath + "', '" + humanModel.bodyFrontPath + "', '" + humanModel.bodyBackPath + "')";

                SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
                Command.Parameters.AddWithValue("@human_model_name", humanModel.name);
                Command.Parameters.AddWithValue("@map_front", humanModel.mapFrontPath);
                Command.Parameters.AddWithValue("@map_back", humanModel.mapBackPath);
                Command.Parameters.AddWithValue("@body_front", humanModel.bodyFrontPath);
                Command.Parameters.AddWithValue("@body_back", humanModel.bodyBackPath);
                Command.ExecuteNonQuery();
                //Connect.Close();
            }
        }
        public static void ReadHumanModelsList(List<HumanModel> humanModels)
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
                    sqlQuery = "SELECT * FROM " + humanModelTableListName;
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, Connect);
                    adapter.Fill(dTable);

                    if (dTable.Rows.Count > 0)
                    {
                        humanModels.Clear();
                        for (int i = 0; i < dTable.Rows.Count; i++)
                        {
                            humanModels.Add(new HumanModel(
                                Convert.ToInt32(dTable.Rows[i].ItemArray[0]),
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

        public static void ReadPointsFromHumanTable(List<PointModel> pointModels, int humanModelId)
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
                    sqlQuery = "SELECT * FROM " + humanPointsListTableName + " WHERE human_model_id = " + humanModelId;
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, Connect);
                    adapter.Fill(dTable);

                    pointModels.Clear();
                    if (dTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dTable.Rows.Count; i++)
                        {
                            pointModels.Add(new PointModel(
                                Convert.ToInt32(dTable.Rows[i].ItemArray[1]),
                                Convert.ToInt32(dTable.Rows[i].ItemArray[2]),
                                Convert.ToInt32(dTable.Rows[i].ItemArray[3]),
                                dTable.Rows[i].ItemArray[4].ToString(),
                                dTable.Rows[i].ItemArray[5].ToString(),
                                Convert.ToInt32(dTable.Rows[i].ItemArray[0]),
                                Convert.ToInt32(dTable.Rows[i].ItemArray[6])));
                        }
                    }
                    else
                    {
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
        public static void GetPointsFromMainTable(List<PointModel> pointModels, int methodicId)
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
                    sqlQuery = "SELECT * FROM " + mainPointsListTableName + " WHERE id = " + methodicId;
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, Connect);
                    adapter.Fill(dTable);

                    pointModels.Clear();
                    if (dTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dTable.Rows.Count; i++)
                        {
                            pointModels.Add(new PointModel(
                                Convert.ToInt32(dTable.Rows[i].ItemArray[1]),
                                Convert.ToInt32(dTable.Rows[i].ItemArray[2]),
                                Convert.ToInt32(dTable.Rows[i].ItemArray[3]),
                                dTable.Rows[i].ItemArray[4].ToString(),
                                dTable.Rows[i].ItemArray[5].ToString(),
                                Convert.ToInt32(dTable.Rows[i].ItemArray[0]),
                                Convert.ToInt32(dTable.Rows[i].ItemArray[6])));
                        }
                    }
                    else
                    {
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

        /*
         *                     sqlQuery = "SELECT id_point,time,power,name model_name,memo,coordX,coordY,channel,side,pointname FROM " + methodicTableName + " JOIN " +
                                methodicListTableName + " ON " + methodicListTableName + ".id = id_methodic JOIN " +
                                pointsListTableName + " ON " + pointsListTableName + ".id = id_point JOIN " +
                                humanModelTableListName + " ON " + humanModelTableListName + ".id = id_human_model WHERE id_methodic=" + methodicId.ToString();

         */
        public static void ReadMethodicListTable(List<MethodicItemModel> methodicItemModels)
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
                    sqlQuery = "SELECT "+ methodicListTableName+ ".id,methodic_name, methodic_memo, human_model_name, human_model_id FROM " + methodicListTableName + " JOIN " + humanModelTableListName + " ON " + humanModelTableListName + ".id=human_model_id";
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, Connect);
                    adapter.Fill(dTable);

                    if (dTable.Rows.Count > 0)
                    {
                        methodicItemModels.Clear();

                        for (int i = 0; i < dTable.Rows.Count; i++) // public MethodicItemModel(int methodicId, string name, string memo, int humanModelId, string humanModelName)
                        {
                            methodicItemModels.Add(new MethodicItemModel(
                                Convert.ToInt32(dTable.Rows[i].ItemArray[0]),
                                dTable.Rows[i].ItemArray[1].ToString(),
                                dTable.Rows[i].ItemArray[2].ToString(),
                                Convert.ToInt32(dTable.Rows[i].ItemArray[0]),
                                dTable.Rows[i].ItemArray[3].ToString()
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
                    sqlQuery = "DELETE FROM " + humanPointsListTableName + " WHERE id=" + selectedPointId;
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


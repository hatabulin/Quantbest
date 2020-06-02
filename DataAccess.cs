using Dapper;
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
        const string pointsTableName = "points";
        const string methodicTableName = "methodic";
        const string methodicListTableName = "methodiclist";
        const string dbFileName = "quantum.db";

        const int COORD_X_IDX = 7;
        const int COORD_Y_IDX = 8;
        const int CHANNEL_IDX = 9;
        const int SIDE_IDX = 10;
        const int POINT_NAME_IDX = 11;
        const int ID_IDX = 6;
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
                string commandText = "CREATE TABLE IF NOT EXISTS ["+ pointsTableName+"] ( [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [coordX] INT, [coordY] INT, [channel] INT, [side] NVARCHAR(10), [pointname] NVARCHAR(10))"; 
                SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
                Command.ExecuteNonQuery();

                commandText = "CREATE TABLE IF NOT EXISTS [" + methodicTableName + "] ( [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [id_methodic] INT, [id_point] INT, FOREIGN KEY ([id_point]) REFERENCES ["+pointsTableName+"]([id])," +
                    "FOREIGN KEY ([id_methodic]) REFERENCES [" + methodicListTableName + "]([id]))";
                Command = new SQLiteCommand(commandText, Connect);
                Command.ExecuteNonQuery();

                commandText = "CREATE TABLE IF NOT EXISTS [" + methodicListTableName + "] ( [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [name] NVARCHAR(10), [memo] MEMO )"; 
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
                string commandText = "INSERT INTO " + pointsTableName + " ('coordX', 'coordY', 'channel', 'side', 'pointname') VALUES(" + 
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

        public static void AddMethodicName(String name, String memo)
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=" + dbFileName + "; Version=3;"))
            {
                Connect.Open();
                string commandText = "INSERT INTO " + methodicListTableName + " ('name', 'memo') VALUES('" + name + "', '" + memo +"')";
                SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
                Command.Parameters.AddWithValue("@name", name);
                Command.Parameters.AddWithValue("@memo", memo);
                Command.ExecuteNonQuery();
                //Connect.Close();
            }
        }

        public static void AddPointToMethodic(int methodic_id, int pointid)
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=" + dbFileName + "; Version=3;"))
            {
                Connect.Open();
                string commandText = "INSERT INTO " + methodicTableName + " ('id_methodic', 'id_point') VALUES(" + methodic_id + ", " + pointid + ")";

                SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
                Command.Parameters.AddWithValue("@id_methodic", methodic_id);
                Command.Parameters.AddWithValue("@id_point", pointid);
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
                    sqlQuery = "SELECT * FROM " + pointsTableName;
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
        public static void ReadPointsTable(DataGridView dataGridView, Form1 form, List<PointModel> pointModels)
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
                    sqlQuery = "SELECT * FROM " + pointsTableName;
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, Connect);
                    adapter.Fill(dTable);

                    if (dTable.Rows.Count > 0)
                    {
                        dataGridView.Rows.Clear();
                        pointModels.Clear();
                        for (int i = 0; i < dTable.Rows.Count; i++)
                        {
                            dataGridView.Rows.Add(dTable.Rows[i].ItemArray);
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
                        form.VisibleTablePointsEmpty(true); 
                    }
                        //MessageBox.Show("Database is empty");
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        public static void PointsList(ComboBox combobox)
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
                    sqlQuery = "SELECT * FROM " + pointsTableName;
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, Connect);
                    adapter.Fill(dTable);

                    if (dTable.Rows.Count > 0)
                    {
                        combobox.Items.Clear();
                        listPointsId.Clear();
                        for (int i = 0; i < dTable.Rows.Count; i++)
                        {
                            combobox.Items.Add(dTable.Rows[i].ItemArray[5]);
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
                    sqlQuery = "SELECT * FROM " + pointsTableName + " WHERE id=" + listPointsId.ElementAt(index); 
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

        public static void ReadMethodicListTable(ComboBox combobox, Form1 form)
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
                    sqlQuery = "SELECT * FROM " + methodicListTableName;
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, Connect);
                    adapter.Fill(dTable);

                    if (dTable.Rows.Count > 0)
                    {
                        combobox.Items.Clear();

                        for (int i = 0; i < dTable.Rows.Count; i++)
                            combobox.Items.Add(dTable.Rows[i].ItemArray[1]);
                        combobox.SelectedIndex = 0;
                        combobox.Enabled = true;
                    }
                    else
                    {
                        combobox.Enabled = false;
                        combobox.SelectedIndex = -1;
                        combobox.Text = null;
                        MessageBox.Show("Database is empty");
                        //form.VisibleTablePointsEmpty(true);
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        public static void ReadMethodicTable(ComboBox combobox, int  methodicId, List<PointModel> pointModels)
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
                    sqlQuery = "SELECT * FROM "+methodicTableName+" JOIN methodiclist ON methodiclist.id = id_methodic JOIN points ON points.id = id_point WHERE id_methodic=" + methodicId.ToString();
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, Connect);
                    DataTable dTable = new DataTable();
                    adapter.Fill(dTable);

                    combobox.Items.Clear();
                    pointModels.Clear();

                    if (dTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dTable.Rows.Count; i++)
                        {
                            combobox.Items.Add(dTable.Rows[i].ItemArray[11]);
                            pointModels.Add(new PointModel(Convert.ToInt32(dTable.Rows[i].ItemArray[COORD_X_IDX]),
                                Convert.ToInt32(dTable.Rows[i].ItemArray[COORD_Y_IDX]),
                                Convert.ToInt32(dTable.Rows[i].ItemArray[CHANNEL_IDX]),
                                dTable.Rows[i].ItemArray[SIDE_IDX].ToString(),
                                dTable.Rows[i].ItemArray[POINT_NAME_IDX].ToString(),
                                Convert.ToInt32(dTable.Rows[i].ItemArray[ID_IDX])));
                        }
                        combobox.Enabled = true;
                        combobox.SelectedIndex = 0;
                    }
                    else
                    {
                        combobox.Items.Clear();
                        combobox.Text = "";
                        combobox.Enabled = false;
                        //MessageBox.Show("Database is empty");
                        //form.VisibleTablePointsEmpty(true);
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
                    sqlQuery = "DELETE FROM " + pointsTableName+ " WHERE id="+selectedPointId;
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


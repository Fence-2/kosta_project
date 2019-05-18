using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace kosta_project_Chistyakov_Dmitrii_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            LoadData(SELECT_Empoyee_query, EmpoyeeColumnsCount, true);
            //LoadData(SELECT_Department_query, DepartmentColumnsCount, true);
        }

        int column_count;

        private void DeleteAllColumns()
        {
            column_count = dataGridView1.Columns.Count;
            for (int i = 0; i < column_count; i++)
            {
                dataGridView1.Columns.RemoveAt(0);
            }
        }

        //Создание столбцов для таблицы "Empoyee"
        private void editDGV_dbo_Empoyee()
        {
            DeleteAllColumns();

            var column_ID = new DataGridViewColumn();
            column_ID.HeaderText = "ID";
            column_ID.ReadOnly = true;
            column_ID.Name = "ID";
            column_ID.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(column_ID);

            var column_FirstName = new DataGridViewColumn();
            column_FirstName.HeaderText = "FirstName";
            column_FirstName.ReadOnly = true;
            column_FirstName.Name = "FirstName";
            column_FirstName.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(column_FirstName);

            var column_SurName = new DataGridViewColumn();
            column_SurName.HeaderText = "SurName";
            column_SurName.ReadOnly = true;
            column_SurName.Name = "SurName";
            column_SurName.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(column_SurName);

            var column_Patronymic = new DataGridViewColumn();
            column_Patronymic.HeaderText = "Patronymic";
            column_Patronymic.ReadOnly = true;
            column_Patronymic.Name = "Patronymic";
            column_Patronymic.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(column_Patronymic);

            var column_DateOfBirth = new DataGridViewColumn();
            column_DateOfBirth.HeaderText = "DateOfBirth";
            column_DateOfBirth.ReadOnly = true;
            column_DateOfBirth.Name = "DateOfBirth";
            column_DateOfBirth.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(column_DateOfBirth);

            var column_DocSeries = new DataGridViewColumn();
            column_DocSeries.HeaderText = "DocSeries";
            column_DocSeries.ReadOnly = true;
            column_DocSeries.Name = "DocSeries";
            column_DocSeries.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(column_DocSeries);

            var column_DocNumber = new DataGridViewColumn();
            column_DocNumber.HeaderText = "DocNumber";
            column_DocNumber.ReadOnly = true;
            column_DocNumber.Name = "DocNumber";
            column_DocNumber.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(column_DocNumber);

            var column_Position = new DataGridViewColumn();
            column_Position.HeaderText = "Position";
            column_Position.ReadOnly = true;
            column_Position.Name = "Position";
            column_Position.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(column_Position);

            var column_DepartmentID = new DataGridViewColumn();
            column_DepartmentID.HeaderText = "DepartmentID";
            column_DepartmentID.ReadOnly = true;
            column_DepartmentID.Name = "DepartmentID";
            column_DepartmentID.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(column_DepartmentID);
        }

        //Создание столбцов для таблицы "Department"
        private void editDGV_dbo_Department()
        {
            DeleteAllColumns();

            var column_ID = new DataGridViewColumn();
            column_ID.HeaderText = "ID";
            column_ID.ReadOnly = true;
            column_ID.Name = "ID";
            column_ID.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(column_ID);

            var column_Name = new DataGridViewColumn();
            column_Name.HeaderText = "Name";
            column_Name.ReadOnly = true;
            column_Name.Name = "Name";
            column_Name.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(column_Name);

            var column_Code = new DataGridViewColumn();
            column_Code.HeaderText = "Code";
            column_Code.ReadOnly = true;
            column_Code.Name = "Code";
            column_Code.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(column_Code);

            var column_ParentDepartmentID = new DataGridViewColumn();
            column_ParentDepartmentID.HeaderText = "ParentDepartmentID";
            column_ParentDepartmentID.ReadOnly = true;
            column_ParentDepartmentID.Name = "ParentDepartmentID";
            column_ParentDepartmentID.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(column_ParentDepartmentID);
        }

        //Метод для заполнения DataGridView
        private void dgvFill(int columnsCount, List<string[]> data)
        {
            if (columnsCount == EmpoyeeColumnsCount)
                editDGV_dbo_Empoyee();
            else
                editDGV_dbo_Department();

            foreach (string[] s in data)
            {
                dataGridView1.Rows.Add(s);
            }
        }

        List<string[]> data = new List<string[]>();

        //Установка параметров для запросов
        string SELECT_Empoyee_query = "SELECT * FROM Empoyee ORDER BY ID;";
        int EmpoyeeColumnsCount = 9;

        string SELECT_Department_query = "SELECT * FROM Department ORDER BY ID;";
        int DepartmentColumnsCount = 4;

        private void LoadData(string query, int columnsCount, bool dgvWillChange)
        {
            string connStr = "Data Source=.\\SQLEXPRESS;Initial Catalog=kosta_test;Integrated Security=true;";

            SqlConnection myConnection = new SqlConnection(connStr);

            myConnection.Open();


            SqlCommand command = new SqlCommand(query, myConnection);

            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                data.Add(new string[columnsCount]);
                for (int i = 0; i < columnsCount; i++)
                {
                    data[data.Count - 1][i] = reader[i].ToString();
                }
            }
            reader.Close();

            myConnection.Close();
            if (dgvWillChange)
                dgvFill(columnsCount, data);

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (listBox1.Visible)
                listBox1.Visible = false;
            else
                listBox1.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            data.Clear();
            LoadData(SELECT_Department_query, DepartmentColumnsCount, false);

            string[] departments = new string[data.Count];
            for (int i = 0; i < data.Count; i++)
            {
                departments[i] = data[i][1];
            }
            listBox1.Items.AddRange(departments);
            listBox1.SelectedIndex = 0;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedDepartment = listBox1.SelectedItem.ToString();

            string listbox_SELECT_Department_query = $"SELECT * FROM Empoyee Inner Join Department on Empoyee.DepartmentID = Department.ID WHERE Department.Name='{selectedDepartment}';";

            LoadData(listbox_SELECT_Department_query, EmpoyeeColumnsCount, true);
            data.Clear();
            listBox1.Visible = false;
        }
    }
}

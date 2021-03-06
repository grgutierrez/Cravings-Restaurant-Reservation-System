﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Web;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        DataTable dt = new DataTable();

        public static string LastName1;
        public static string FirstName1;
        public static string MiddleName1;
        public static string Address1;
        public static string ContactNo1;
        public static string Date1;
        public static string NoOfPeople1;
        public static string TableNo1;
        public static string TypeOfMeal1;
        public static string transactionNo;
        public bool button2_Clicked = false;

        public Form4()
        {
            InitializeComponent();
            string FolderPath = System.IO.Directory.GetCurrentDirectory();
            var connectionPath = FolderPath.Replace("\\Buffet Cravings Restaurant (CS)\\bin\\Debug", "") + "\\" + "Reservation.accdb";
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + connectionPath;
        }

        private void btnHome4_Click(object sender, EventArgs e)
        {
            var myForm1 = new Form1();
            myForm1.Show();
            Visible = false;
        }

        private void btnCreate4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("          Select the date, table and meal\n"+"        first at the Home bar to proceed.");
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label29_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //Use a variable to hold the SQL statement.
            string query = "SELECT TransactionNo, FirstName, MiddleName, LastName, ContactNo, Address, TypeOfMeal, Date, NoOfPeople, TableNo FROM Reservation ORDER BY TransactionNo ASC ";

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connection.ConnectionString))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn)) 
                    {
                        DataSet dataset = new DataSet();
                        adapter.Fill(dataset);
                        dataGridView1.DataSource = dataset.Tables[0];
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //button2_Clicked = true;
            //LastName1 = null;
            //FirstName1 = null;
            //MiddleName1 = null;
            //Address1 = null;
            //ContactNo1 = null;
            //TypeOfMeal1 = null;
            //NoOfPeople1 = null;
            //TableNo1 = null;

            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            try
            {
                //command.CommandText = "INSERT INTO Reservation (TransactionNo, FirstName, LastName, MiddleName, ContactNo, Address, TypeOfMeal, [Date], NoOfPeople, TableNo) VALUES (@transactionNo, @firstName, @lastName, @middleName, @contactNo, @address, @typeOfMeal, @datee, @noOfPeople, @tableNo)";

                command.CommandText = "UPDATE Reservation set FirstName = @firstName, LastName = @lastName, MiddleName = @middleName, ContactNo = @contactNo, Address = @address, Date = @datee, NoOfPeople = @noOfPeople, TableNo = @tableNo, TypeOfMeal = @typeOfMeal WHERE TransactionNo = @textBox1";

                //command.CommandText = "INSERT INTO Reservation (FirstName) VALUES ('  firstNameLabel1.Text  ')";
                //command.CommandText = "INSERT INTO Reservation (LastName) VALUES ('   lastNameLabel1.Text   ')";
                //command.CommandText = "INSERT INTO Reservation (MiddleName) VALUES ('middleNameLabel1.Text')";
                //command.CommandText = "INSERT INTO Reservation (ContactNo) VALUES ('contactNoLabel1.Text')";
                //command.CommandText = "INSERT INTO Reservation (Address) VALUES ('addressLabel1.Text')";
                //command.CommandText = "INSERT INTO Reservation (Date) VALUES ('dateLabel1.Text')";
                //command.CommandText = "INSERT INTO Reservation (NoOfPeople) VALUES ('noOfPeopleLabel1.Text')";
                //command.CommandText = "INSERT INTO Reservation (TableNo) VALUES ('tableNoLabel1.Text')";
                //command.CommandText = "INSERT INTO Reservation (TypeOfMeal) VALUES ('typeOfMealLabel1.Text')";

                //string transactionNo = textBox1.Text;
                //string firstName = firstNameTextBox.Text;
                //string lastName = lastNameTextBox.Text;
                //string middleName = middleNameTextBox.Text;
                //string contactNo = contactNoTextBox.Text;
                //string address = addressTextBox.Text;
                //string typeOfMeal = typeOfMealComboBox.Text;
                //string date = dateDateTimePicker.Text;
                //string noOfPeople = noOfPeopleNumericUpDown.Text;
                //string tableNo = tableNoTextBox.Text;

                //command.Parameters.AddWithValue("@transactionNo", transactionNo);
                //command.Parameters.AddWithValue("@firstName", firstName);
                //command.Parameters.AddWithValue("@lastName", lastName);
                //command.Parameters.AddWithValue("@middleName", middleName);
                //command.Parameters.AddWithValue("@contactNo", contactNo);
                //command.Parameters.AddWithValue("@address", address);
                //command.Parameters.AddWithValue("@typerOfMeal", typeOfMeal);
                //command.Parameters.AddWithValue("@datee", date);
                //command.Parameters.AddWithValue("@noOfPeople", noOfPeople);
                //command.Parameters.AddWithValue("@tableNo", tableNo);

                command.ExecuteNonQuery();
                command.Parameters.Clear();
                MessageBox.Show("Saved");
                command.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
                command.Connection.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Update")
            {
                if (MessageBox.Show("Are you sure you want to update this record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    reservationBindingSource.EndEdit();
            }
        }
    }
}

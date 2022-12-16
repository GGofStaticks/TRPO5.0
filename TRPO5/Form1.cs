using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRPO5
{
    public partial class Form1 : Form
    {
        List<T> toys = new List<T>();
        bool ist = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            toys.Add(new T() { type = "Машинка", cout = 3 });
            toys.Add(new T() { type = "Плюшевая игрушка", cout = 2 });
            toys.Add(new T() { type = "Самолетик", cout = 6 });
            toys.Add(new T() { type = "Мяч", cout = 7 });
            toys.Add(new T() { type = "Шарики", cout = 8 });

            if (ist)
            {
                for (int i = 0; i < toys.Count; i++)
                {
                    comboBox1.Items.Add($"Игрушка: {toys[i].type} | Количество: {toys[i].cout}");
                }
            }
            ist = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string password = textBox2.Text;

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `name` = @un AND `password` = @up", db.getConnection());

            command.Parameters.Add("@un", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@up", MySqlDbType.Int32).Value = password;

            adapter.SelectCommand = command;

            try
            {
                adapter.Fill(table);
            }
            catch
            {
                MessageBox.Show("Заполните все поля");
            }


            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Добро пожаловать");
                comboBox1_SelectedIndexChanged(this, null);
            }
            else MessageBox.Show("Пользователь не найден");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pass = textBox2.Text;
            string nam = textBox1.Text;

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`id`, `name`, `password`) VALUES (NULL, @NA, @PA)", db.getConnection());

            command.Parameters.Add("@NA", MySqlDbType.VarChar).Value = nam;
            command.Parameters.Add("@PA", MySqlDbType.Int32).Value = pass;

            db.openConnection();

            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Вы зарегистрированы");
                }
            }
            catch
            {
                MessageBox.Show("Заполните все поля");
            }

            db.closeConnection();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tip = "";
            int tip1 = 0;

            try
            {
                tip = textBox3.Text;
                tip1 = Convert.ToInt32(textBox4.Text);
                comboBox1.Items.Add($"Игрушка: {tip} | Количество: {tip1}");
            }
            catch
            {
                MessageBox.Show("Заполните все поля");
            }
        }
    }
}

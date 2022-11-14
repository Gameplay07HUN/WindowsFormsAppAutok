using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsAppAuutók
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = null;
        MySqlCommand cmd = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "autók";
            conn=new MySqlConnection(builder.ConnectionString);
            try
            {
                //--terv szerint
                conn.Open();
                cmd = conn.CreateCommand();
            }
            catch (MySqlException ex)
            {
                //--váratlan hiba
                MessageBox.Show(ex.Message + Environment.NewLine + "A program leáll!");
                Environment.Exit(0);
            }
            finally
            {
                //--hiba és terv szerinti esetén is lefut
                conn.Close();
            }
            Autok_lista_update();
        }

        /**
         * private void Autok_lista_update()
         * autók listájának frissítése az adatbázisból
         */
        private void Autok_lista_update()
        {
            listBox1.Items.Clear();
            cmd.CommandText = "SELECT `id`,`rendszám`,`üzembehelyezve`,`szín`FROM `autók` WHERE 1;";
            conn.Open();
            using(MySqlDataReader dr=cmd.ExecuteReader())
            {
                while(dr.Read())
                {
                    Auto uj = new Auto(dr.GetInt32("id"), dr.GetString("rendszám"), dr.GetInt32("üzembehelyezve"), dr.GetString("szín"));
                    listBox1.Items.Add(uj);
                }
            }
            conn.Close();
        }

        private void buttonUjAuto_Click(object sender, EventArgs e)
        {
            //--Szükséges adatok ellenörzése
            if (string.IsNullOrEmpty(textBoxRendszam.Text))
            {
                MessageBox.Show("Adjon meg rendszámot!");
                textBoxRendszam.Focus();
                return;
            }
            if (numericUpDownEvJarat.Value>DateTime.Now.Year)
            {
                MessageBox.Show("Érvénytelen évjárat!");
                numericUpDownEvJarat.Value=DateTime.Now.Year;
                numericUpDownEvJarat.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textBoxSzin.Text))
            {
                MessageBox.Show("Nem adott meg színt!");
                textBoxSzin.Focus();
                return;
            }
            //-- Kiírjuk az adatbázisba ------
            cmd.CommandText = "INSERT INTO `autók` (`id`, `rendszám`, `üzembehelyezve`, `szín`) VALUES (NULL, @rendszam, @evszam, @szin);";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@rendszam", textBoxRendszam.Text);
            cmd.Parameters.AddWithValue("@evszam", numericUpDownEvJarat.Value.ToString());
            cmd.Parameters.AddWithValue("@szin", textBoxSzin.Text);
            conn.Open();
            try
            {
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Sikeresen rögzítve!");
                    textBoxId.Text = "";
                    numericUpDownEvJarat.Value = numericUpDownEvJarat.Minimum;
                    textBoxSzin.Text = "";
                    textBoxRendszam.Text = "";
                }
                else
                {
                    MessageBox.Show("Sikertelen rögzítés!");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
            conn.Close();
            Autok_lista_update();
        }
    }
}

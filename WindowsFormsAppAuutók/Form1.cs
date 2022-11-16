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
using Org.BouncyCastle.Utilities.Collections;

namespace WindowsFormsAppAuutók
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = null;
        MySqlCommand cmd = null;
        private bool nincsenek;

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
            if (nincsenek_adatok())
            {
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

        private bool nincsenek_adatok()
        {
            //--Szükséges adatok ellenörzése
            if (string.IsNullOrEmpty(textBoxRendszam.Text))
            {
                MessageBox.Show("Adjon meg rendszámot!");
                textBoxRendszam.Focus();
                return true;
            }
            if (numericUpDownEvJarat.Value > DateTime.Now.Year)
            {
                MessageBox.Show("Érvénytelen évjárat!");
                numericUpDownEvJarat.Value = DateTime.Now.Year;
                numericUpDownEvJarat.Focus();
                return true;
            }
            if (string.IsNullOrEmpty(textBoxSzin.Text))
            {
                MessageBox.Show("Nem adott meg színt!");
                textBoxSzin.Focus();
                return true;
            }
            return false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (listBox1.SelectedIndex < 0)
            {
                return;
            }
            //--A felhasználó kijelöl egy elemet a listában -------
            Auto kivalaszott_auto = (Auto)listBox1.SelectedItem;
            textBoxId.Text = kivalaszott_auto.Id.ToString();
            textBoxRendszam.Text = kivalaszott_auto.Rendszam;
            textBoxSzin.Text = kivalaszott_auto.Szin;
            numericUpDownEvJarat.Value = kivalaszott_auto.Evjarat;

        }

        private void buttonModositas_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex<0)
            {
                MessageBox.Show("Nincs kijelölve autó!");
                return;
            }
            cmd.CommandText= "UPDATE `autók` SET `rendszám` = '@rendszám', `üzembehelyezve` = '@üzembehelyezve', `szín` = '@szín' WHERE `autók`.`id` = @id;";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", textBoxId.Text);
            cmd.Parameters.AddWithValue("@rendszám", textBoxRendszam.Text);
            cmd.Parameters.AddWithValue("@üzembehelyezve", numericUpDownEvJarat.Value);
            cmd.Parameters.AddWithValue("@szín", textBoxSzin.Text);
            conn.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Módosítás sikeres!");
                conn.Close();
                textBoxId.Text = "";
                textBoxRendszam.Text = "";
                textBoxSzin.Text = "";
                numericUpDownEvJarat.Value = numericUpDownEvJarat.Minimum;
                Autok_lista_update();
            }
            else
            {
                MessageBox.Show("Az adatok modosítása sikerleten!");
            }
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private void buttonTorles_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex<0)
            {
                return;
            }
            cmd.CommandText = "DELETE FROM `autók` WHERE `id` = @id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", textBoxId.Text);
            conn.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Törlés sikeres!");
                conn.Close();
                textBoxId.Text = "";
                textBoxRendszam.Text = "";
                textBoxSzin.Text = "";
                numericUpDownEvJarat.Value = numericUpDownEvJarat.Minimum;
                Autok_lista_update();
            }
            else
            {
                MessageBox.Show("Törlés sikertelen!");
            }
        }
    }
}

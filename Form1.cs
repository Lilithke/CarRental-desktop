using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental_desktop
{
    public partial class Form1 : Form
    {
        private CarService carservice;
        public Form1()
        {
            InitializeComponent();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (CarGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Törléshez előbb válasszon ki autót.");
                return;
            }
            DialogResult result = MessageBox.Show("Biztos szeretné törölni a kiválasztott autót?","Biztos?",MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                return;
            }
            try
            {
                Car selected = CarGrid.SelectedRows[0].DataBoundItem as Car;
                if (carservice.DeleteCar(selected.Id))
                {
                    MessageBox.Show("Sikeres törlés!");
                }
                else
                {
                    MessageBox.Show("Ez az autó már korrábban törlésre került.", "hiba történt a törlés során.");
                }
                cartableRefresh();
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message, "Hiba történt a törlés során!");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                carservice = new CarService();
                cartableRefresh();
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Hiba történt az adatbázis kapcsolat kialakításakor");
                this.Close();
            }
        }

        private void cartableRefresh()
        {
            CarGrid.DataSource = carservice.GetCars();
            CarGrid.ClearSelection();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProectMedecinaAIS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void hide_all() {
            panelBolnich.Visible = false;
            panelDoctor.Visible = false;
            panelLogin.Visible = false;
            panelMedlist.Visible = false;
            panelPacient.Visible = false;
            panelProc.Visible = false;
            panelPusta.Visible = false;
            panelZap.Visible = false;
            panel4.Visible = false;
        }
        private void Load_Medlist()
        {
            Connector connection = new Connector();
            using (MySqlCommand command = new MySqlCommand("SELECT pacients.FamPacient FROM pacients", connection.GetConnection()))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                comboBoxMedlistPac.DisplayMember = "FamPacient";
                comboBoxMedlistPac.DataSource = Table;
            }
            using (MySqlCommand command = new MySqlCommand("SELECT priem.DateInput FROM priem", connection.GetConnection()))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                comboBoxMedlistDatN.DisplayMember = "DateInput";
                comboBoxMedlistDatN.DataSource = Table;
            }
            using (MySqlCommand command = new MySqlCommand("SELECT vrachi.FamVrach FROM vrachi", connection.GetConnection()))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                comboBoxMedlistDoctor.DisplayMember = "FamVrach";
                comboBoxMedlistDoctor.DataSource = Table;
            }
            using (MySqlCommand command = new MySqlCommand("SELECT bolnicni.Diagnoz FROM bolnicni", connection.GetConnection()))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                comboBoxMedlistDiagnoz.DisplayMember = "Diagnoz";
                comboBoxMedlistDiagnoz.DataSource = Table;
            }

        }
        private void Load_ZAP()
        {
            Connector connection = new Connector();
            using (MySqlCommand command = new MySqlCommand("SELECT pacients.FamPacient FROM pacients", connection.GetConnection()))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                comboBoxZapPac.DisplayMember = "FamPacient";
                comboBoxZapPac.DataSource = Table;
            }
            using (MySqlCommand command = new MySqlCommand("SELECT proceduri.Dataprocedur FROM proceduri", connection.GetConnection()))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                comboBoxZapDat.DisplayMember = "Dataprocedur";
                comboBoxZapDat.DataSource = Table;
            }
            using (MySqlCommand command = new MySqlCommand("SELECT proceduri.Vrema FROM proceduri", connection.GetConnection()))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                comboBoxZapVrema.DisplayMember = "Vrema";
                comboBoxZapVrema.DataSource = Table;
            }
            using (MySqlCommand command = new MySqlCommand("SELECT vrachi.FamVrach FROM vrachi", connection.GetConnection()))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                comboBoxZapDoctor.DisplayMember = "FamVrach";
                comboBoxZapDoctor.DataSource = Table;
            }
            using (MySqlCommand command = new MySqlCommand("SELECT vrachi.Kab FROM vrachi", connection.GetConnection()))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                comboBoxZapNumCab.DisplayMember = "Kab";
                comboBoxZapNumCab.DataSource = Table;
            }


        }

        private void panelPusta_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Connector connection = new Connector();
                MySqlCommand command = new MySqlCommand("DELETE FROM pacients WHERE pacients.FamPacient =" + "'" + dataGridViewPacient[0, dataGridViewPacient.CurrentRow.Index].Value.ToString() + "'", connection.GetConnection());
                connection.GetConnection().Open();
                command.ExecuteNonQuery();
                connection.GetConnection().Close();
                command.Parameters.Clear();

                command.CommandText = "SELECT * FROM pacients";
                MySqlDataAdapter adapter = new MySqlDataAdapter(command.CommandText, connection.GetConnection());
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                dataGridViewPacient.DataSource = Table;
                dataGridViewPacient_Rename();
            }
            catch
            {
                MessageBox.Show("Таблица Пустая или не выделен нужный элемент");
            }
        }

        private void buttonMedList_Click(object sender, EventArgs e)
        {
            hide_all();
            Load_Medlist();
            Connector connection = new Connector();
            MySqlCommand command = new MySqlCommand("SELECT * FROM medlist", connection.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter(command.CommandText, connection.GetConnection());
            DataTable Table = new DataTable();
            adapter.Fill(Table);
            dataGridViewMedlist.DataSource = Table;
            dataGridViewMedlist_Rename();
            panelMedlist.Visible = true;


        }

        private void buttonPacient_Click(object sender, EventArgs e)
        {
            hide_all();
            Connector connection = new Connector();
            MySqlCommand command = new MySqlCommand("SELECT * FROM pacients", connection.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter(command.CommandText, connection.GetConnection());
            DataTable Table = new DataTable();
            adapter.Fill(Table);
            dataGridViewPacient.DataSource = Table;
            dataGridViewPacient_Rename();
            panelPacient.Visible = true;

        }
        //
        private void buttonVrach_Click(object sender, EventArgs e)
        {
            hide_all();
            Connector connection = new Connector();
            MySqlCommand command = new MySqlCommand("SELECT * FROM vrachi", connection.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter(command.CommandText, connection.GetConnection());
            DataTable Table = new DataTable();
            adapter.Fill(Table);
            dataGridViewDoctor.DataSource = Table;
            dataGridViewDoctor_Rename();
            panelDoctor.Visible = true;

        }

        private void buttonZapisPriem_Click(object sender, EventArgs e)
        {
            hide_all();
            Connector connection = new Connector();
            MySqlCommand command = new MySqlCommand("SELECT * FROM zapispriem", connection.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter(command.CommandText, connection.GetConnection());
            DataTable Table = new DataTable();
            adapter.Fill(Table);
            dataGridViewZap.DataSource = Table;
            dataGridViewZap_Rename();
            Load_ZAP();
            panelZap.Visible = true;

        }

        private void buttonProcedur_Click(object sender, EventArgs e)
        {
            hide_all();
            panelProc.Visible = true;
        }

        private void buttonBolnich_Click(object sender, EventArgs e)
        {
            hide_all();
            panelBolnich.Visible = true;
            try
            {
                MessageBox.Show("Подключение успешно");
            }
            catch{
                MessageBox.Show("Ошибка подключения");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelMainCnopci.Visible = false;
        }

        private void dataGridViewMedlist_Rename(){
            dataGridViewMedlist.Columns[0].HeaderText = "Пациент";
            dataGridViewMedlist.Columns[1].HeaderText = "Врач";
            dataGridViewMedlist.Columns[2].HeaderText = "Дата приема";
            dataGridViewMedlist.Columns[3].HeaderText = "Диагноз";
            dataGridViewMedlist.Columns[4].HeaderText = "Вид лечения";
            dataGridViewMedlist.Columns[5].HeaderText = "Лечение";
        }
        private void dataGridViewPacient_Rename()
        {
            dataGridViewPacient.Columns[0].HeaderText = "Фамилия";
            dataGridViewPacient.Columns[1].HeaderText = "Имя";
            dataGridViewPacient.Columns[2].HeaderText = "Отчество";
            dataGridViewPacient.Columns[3].HeaderText = "Дата рождения";
            dataGridViewPacient.Columns[4].HeaderText = "Адрес";
            dataGridViewPacient.Columns[5].HeaderText = "Номер Телефона";

        }
        private void dataGridViewZap_Rename()
        {
            dataGridViewZap.Columns[0].HeaderText = "Пациент";
            dataGridViewZap.Columns[1].HeaderText = "Врач";
            dataGridViewZap.Columns[2].HeaderText = "Кабинет";
            dataGridViewZap.Columns[3].HeaderText = "Дата";
            dataGridViewZap.Columns[4].HeaderText = "Время";

        }
        private void dataGridViewDoctor_Rename()
        {
            dataGridViewDoctor.Columns[0].HeaderText = "Код";
            dataGridViewDoctor.Columns[1].HeaderText = "Фамилия";
            dataGridViewDoctor.Columns[2].HeaderText = "Имя";
            dataGridViewDoctor.Columns[3].HeaderText = "Отчество";
            dataGridViewDoctor.Columns[4].HeaderText = "Профессия";
            dataGridViewDoctor.Columns[5].HeaderText = "Кабинет";
            dataGridViewDoctor.Columns[6].HeaderText = "Ставка";

        }

        private void buttonMedlistDobavit_Click(object sender, EventArgs e)
        {
            Connector connection = new Connector();
            MySqlCommand command = new MySqlCommand("INSERT INTO medlist (medlist.Pacient, medlist.Vrach, medlist.DatPriem,medlist.Diagnoz,medlist.VidLechenia,medlist.Lechenie) VALUES(@Pacient, @Vrach, @DatPriem,@Diagnoz,@VidLechenia,@Lechenie)", connection.GetConnection());
            
                    command.Parameters.AddWithValue("Pacient", comboBoxMedlistPac.Text);
                    command.Parameters.AddWithValue("Vrach", comboBoxMedlistDoctor.Text);
                    command.Parameters.AddWithValue("DatPriem", comboBoxMedlistDatN.Text);
                    command.Parameters.AddWithValue("Diagnoz", comboBoxMedlistDiagnoz.Text);
                    command.Parameters.AddWithValue("VidLechenia", textBoxTypeLec.Text);
                    command.Parameters.AddWithValue("Lechenie", textBoxLec.Text);

                    connection.GetConnection().Open();
                    command.ExecuteNonQuery();
                    connection.GetConnection().Close();
                    command.Parameters.Clear();


              

             
             

                

                command.CommandText = "SELECT * FROM medlist";
                MySqlDataAdapter adapter = new MySqlDataAdapter(command.CommandText, connection.GetConnection());
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                dataGridViewMedlist.DataSource = Table;
                dataGridViewMedlist_Rename();
            }

        private void buttonMedlistIzmenit_Click(object sender, EventArgs e)
        {
            Connector connection = new Connector();
            try
            {
                MySqlCommand command = new MySqlCommand("UPDATE medlist SET Pacient = @Pacient, Vrach = @Vrach,DatPriem = @DatPriem,Diagnoz = @Diagnoz,VidLechenia = @VidLechenia,Lechenie = @Lechenie WHERE medlist.Pacient=" + "'" + dataGridViewMedlist[0, dataGridViewMedlist.CurrentRow.Index].Value.ToString() + "'", connection.GetConnection());

                command.Parameters.AddWithValue("Pacient", comboBoxMedlistPac.Text);
                command.Parameters.AddWithValue("Vrach", comboBoxMedlistDoctor.Text);
                command.Parameters.AddWithValue("DatPriem", comboBoxMedlistDatN.Text);
                command.Parameters.AddWithValue("Diagnoz", comboBoxMedlistDiagnoz.Text);
                command.Parameters.AddWithValue("VidLechenia", textBoxTypeLec.Text);
                command.Parameters.AddWithValue("Lechenie", textBoxLec.Text);


                connection.GetConnection().Open();
                command.ExecuteNonQuery();
                connection.GetConnection().Close();

                command.Parameters.Clear();

                command.CommandText = "SELECT * FROM medlist";
                MySqlDataAdapter adapter = new MySqlDataAdapter(command.CommandText, connection.GetConnection());
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                dataGridViewMedlist.DataSource = Table;
                dataGridViewMedlist_Rename();
            }
            catch
            {
                MessageBox.Show("Проверьте пустая таблица и выделен ли элемент");
            }

                

        }

        private void buttonMedlistYdalit_Click(object sender, EventArgs e)
        {
            try
            {
                Connector connection = new Connector();
                MySqlCommand command = new MySqlCommand("DELETE FROM medlist WHERE medlist.Pacient ="+"'" + dataGridViewMedlist[0, dataGridViewMedlist.CurrentRow.Index].Value.ToString()+"'", connection.GetConnection());
                connection.GetConnection().Open();
                command.ExecuteNonQuery();
                connection.GetConnection().Close();
                command.Parameters.Clear();

                command.CommandText = "SELECT * FROM medlist";
                MySqlDataAdapter adapter = new MySqlDataAdapter(command.CommandText, connection.GetConnection());
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                dataGridViewMedlist.DataSource = Table;
                dataGridViewMedlist_Rename();
            }
            catch
            {
                MessageBox.Show("Таблица Пустая или не выделен нужный элемент");
            }
        }

        private void buttonPacDobavit_Click(object sender, EventArgs e)
        {
            Connector connection = new Connector();
            MySqlCommand command = new MySqlCommand("INSERT INTO pacients ( pacients.FamPacient,  pacients.NamePacient,  pacients.SurnamePacient, pacients.DateStart, pacients.Adress, pacients.Numer) VALUES(@FamPacient, @NamePacient, @SurnamePacient,@DateStart,@Adress,@Numer)", connection.GetConnection());

            command.Parameters.AddWithValue("FamPacient", textBoxPacientFam.Text);
            command.Parameters.AddWithValue("NamePacient", textBoxPacientName.Text);
            command.Parameters.AddWithValue("SurnamePacient", textBoxPacientOtch.Text);
            command.Parameters.AddWithValue("DateStart", textBoxPacientDenRo.Text);
            command.Parameters.AddWithValue("Adress", textBoxPacientNumber.Text);
            command.Parameters.AddWithValue("Numer", textBoxPacientMestoJitelstva.Text);

            connection.GetConnection().Open();
            command.ExecuteNonQuery();
            connection.GetConnection().Close();
            command.Parameters.Clear();




            command.CommandText = "SELECT * FROM pacients";
            MySqlDataAdapter adapter = new MySqlDataAdapter(command.CommandText, connection.GetConnection());
            DataTable Table = new DataTable();
            adapter.Fill(Table);
            dataGridViewPacient.DataSource = Table;
            dataGridViewPacient_Rename();
        }

        private void buttonPacIzmenit_Click(object sender, EventArgs e)
        {
           
                Connector connection = new Connector();
                MySqlCommand command = new MySqlCommand("UPDATE pacients SET FamPacient = @FamPacient, NamePacient = @NamePacient,SurnamePacient = @SurnamePacient,DateStart = @DateStart,Adress = @Adress,Numer = @Numer WHERE pacients.FamPacient=" + "'" + dataGridViewPacient[0, dataGridViewPacient.CurrentRow.Index].Value.ToString() + "'", connection.GetConnection());

                command.Parameters.AddWithValue("FamPacient", textBoxPacientFam.Text);
                command.Parameters.AddWithValue("NamePacient", textBoxPacientName.Text);
                command.Parameters.AddWithValue("SurnamePacient", textBoxPacientOtch.Text);
                command.Parameters.AddWithValue("DateStart", textBoxPacientDenRo.Text);
                command.Parameters.AddWithValue("Adress", textBoxPacientNumber.Text);
                command.Parameters.AddWithValue("Numer", textBoxPacientMestoJitelstva.Text);


                connection.GetConnection().Open();
                command.ExecuteNonQuery();
                connection.GetConnection().Close();

                command.Parameters.Clear();

                command.CommandText = "SELECT * FROM pacients";
                MySqlDataAdapter adapter = new MySqlDataAdapter(command.CommandText, connection.GetConnection());
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                dataGridViewPacient.DataSource = Table;
                dataGridViewPacient_Rename();
        


        }

        private void buttonAftorezacia_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите это выбрать", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Connector connection = new Connector();
                string login = textBoxLogin.Text;
                string password = textBoxPassword.Text;
                MySqlCommand command = new MySqlCommand("SELECT * FROM manager WHERE manager.Login = @login AND manager.Password = @password", connection.GetConnection());
                command.Parameters.Add("login", MySqlDbType.VarChar).Value = login;
                command.Parameters.Add("password", MySqlDbType.VarChar).Value = password;

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                if (Table.Rows.Count > 0)
                {
                    hide_all();
                    panelPusta.Visible = true;
                    MessageBox.Show("Добро пожаловать");
                    panelMainCnopci.Visible = true;
                }
                else
                {
                    MessageBox.Show("Попробуйте ввести заново Проверьте Логин или Пароль");
                }
            }
        }

        private void buttonZapDobavit_Click(object sender, EventArgs e)
        {
            Connector connection = new Connector();
            MySqlCommand command = new MySqlCommand("INSERT INTO zapispriem ( zapispriem.Pacient,  zapispriem.Vrach,  zapispriem.Cabinet, zapispriem.Data, zapispriem.Time) VALUES(@Pacient, @Vrach, @Cabinet,@Data,@Time)", connection.GetConnection());

            command.Parameters.AddWithValue("Pacient", comboBoxZapPac.Text);
            command.Parameters.AddWithValue("Vrach", comboBoxZapDoctor.Text);
            command.Parameters.AddWithValue("Cabinet", comboBoxZapNumCab.Text);
            command.Parameters.AddWithValue("Data", comboBoxZapDat.Text);
            command.Parameters.AddWithValue("Time", comboBoxZapVrema.Text);

            connection.GetConnection().Open();
            command.ExecuteNonQuery();
            connection.GetConnection().Close();
            command.Parameters.Clear();




            command.CommandText = "SELECT * FROM zapispriem";
            MySqlDataAdapter adapter = new MySqlDataAdapter(command.CommandText, connection.GetConnection());
            DataTable Table = new DataTable();
            adapter.Fill(Table);
            dataGridViewZap.DataSource = Table;
            dataGridViewZap_Rename();

        }

        private void buttonZapIzmenit_Click(object sender, EventArgs e)
        {
            Connector connection = new Connector();
            MySqlCommand command = new MySqlCommand("UPDATE zapispriem SET Pacient = @Pacient, Vrach = @Vrach,Cabinet = @Cabinet,Data = @Data,Time = @Time WHERE zapispriem.Pacient=" + "'" + dataGridViewZap[0, dataGridViewZap.CurrentRow.Index].Value.ToString() + "'", connection.GetConnection());

            command.Parameters.AddWithValue("Pacient", comboBoxZapPac.Text);
            command.Parameters.AddWithValue("Vrach", comboBoxZapDoctor.Text);
            command.Parameters.AddWithValue("Cabinet", comboBoxZapNumCab.Text);
            command.Parameters.AddWithValue("Data", comboBoxZapDat.Text);
            command.Parameters.AddWithValue("Time", comboBoxZapVrema.Text);

            connection.GetConnection().Open();
            command.ExecuteNonQuery();
            connection.GetConnection().Close();
            command.Parameters.Clear();


            command.CommandText = "SELECT * FROM zapispriem";
            MySqlDataAdapter adapter = new MySqlDataAdapter(command.CommandText, connection.GetConnection());
            DataTable Table = new DataTable();
            adapter.Fill(Table);
            dataGridViewZap.DataSource = Table;
            dataGridViewZap_Rename();
        
        }

        private void buttonZapYdalit_Click(object sender, EventArgs e)
        {
            try
            {
                Connector connection = new Connector();
                MySqlCommand command = new MySqlCommand("DELETE FROM zapispriem WHERE zapispriem.Pacient =" + "'" + dataGridViewZap[0, dataGridViewZap.CurrentRow.Index].Value.ToString() + "'", connection.GetConnection());
                connection.GetConnection().Open();
                command.ExecuteNonQuery();
                connection.GetConnection().Close();
                command.Parameters.Clear();

                command.CommandText = "SELECT * FROM zapispriem";
                MySqlDataAdapter adapter = new MySqlDataAdapter(command.CommandText, connection.GetConnection());
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                dataGridViewZap.DataSource = Table;
                dataGridViewZap_Rename();
            }
            catch
            {
                MessageBox.Show("Таблица Пустая или не выделен нужный элемент");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
        
            Connector connection = new Connector();
            MySqlCommand command = new MySqlCommand("INSERT INTO vrachi (vrachi.Kod_vrach,  vrachi.FamVrach,  vrachi.NameVrach, vrachi.SurnameVrach, vrachi.Professional,vrachi.Kab,vrachi.Stavka) VALUES(@Kod_vrach, @FamVrach, @NameVrach,@SurnameVrach,@Professional,@Kab,@Stavka)", connection.GetConnection());

            command.Parameters.AddWithValue("Kod_vrach", textBoxKodVrach.Text);
            command.Parameters.AddWithValue("FamVrach", comboBoxZapPac.Text);
            command.Parameters.AddWithValue("NameVrach", comboBoxZapDoctor.Text);
            command.Parameters.AddWithValue("SurnameVrach", comboBoxZapNumCab.Text);
            command.Parameters.AddWithValue("Professional", comboBoxZapDat.Text);
            command.Parameters.AddWithValue("Kab", comboBoxZapVrema.Text);
            command.Parameters.AddWithValue("Stavka", comboBoxZapDat.Text);
          

            connection.GetConnection().Open();
            command.ExecuteNonQuery();
            connection.GetConnection().Close();
            command.Parameters.Clear();




            command.CommandText = "SELECT * FROM vrachi";
            MySqlDataAdapter adapter = new MySqlDataAdapter(command.CommandText, connection.GetConnection());
            DataTable Table = new DataTable();
            adapter.Fill(Table);
            dataGridViewDoctor.DataSource = Table;
            dataGridViewDoctor_Rename();
    
            
         
                MessageBox.Show("Таблица Пустая или не выделен нужный элемент или номер уже занят");
          

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Connector connection = new Connector();
            MySqlCommand command = new MySqlCommand("UPDATE vrachi SET Kod_vrach = @Kod_vrach, FamVrach = @FamVrach,NameVrach= @NameVrach,SurnameVrach = @SurnameVrach,Professional = @Professional,Kab = @Kab, Stavka = @Stavka WHERE vrachi.Kod_vrach=" + dataGridViewDoctor[0, dataGridViewDoctor.CurrentRow.Index].Value.ToString(), connection.GetConnection());

            command.Parameters.AddWithValue("Kod_vrach", textBoxKodVrach.Text);
            command.Parameters.AddWithValue("FamVrach", comboBoxZapPac.Text);
            command.Parameters.AddWithValue("NameVrach", comboBoxZapDoctor.Text);
            command.Parameters.AddWithValue("SurnameVrach", comboBoxZapNumCab.Text);
            command.Parameters.AddWithValue("Professional", comboBoxZapDat.Text);
            command.Parameters.AddWithValue("Kab", comboBoxZapVrema.Text);
            command.Parameters.AddWithValue("Stavka", comboBoxZapDat.Text);

            connection.GetConnection().Open();
            command.ExecuteNonQuery();
            connection.GetConnection().Close();
            command.Parameters.Clear();

            command.CommandText = "SELECT * FROM vrachi";
            MySqlDataAdapter adapter = new MySqlDataAdapter(command.CommandText, connection.GetConnection());
            DataTable Table = new DataTable();
            adapter.Fill(Table);
            dataGridViewDoctor.DataSource = Table;
            dataGridViewDoctor_Rename();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Connector connection = new Connector();
                MySqlCommand command = new MySqlCommand("DELETE FROM vrachi WHERE vrachi.Kod_vrach =" + "'" + dataGridViewDoctor[0, dataGridViewDoctor.CurrentRow.Index].Value.ToString() + "'", connection.GetConnection());
                connection.GetConnection().Open();
                command.ExecuteNonQuery();
                connection.GetConnection().Close();
                command.Parameters.Clear();

                command.CommandText = "SELECT * FROM zapispriem";
                MySqlDataAdapter adapter = new MySqlDataAdapter(command.CommandText, connection.GetConnection());
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                dataGridViewDoctor.DataSource = Table;
                dataGridViewDoctor_Rename();
            }
            catch
            {
                MessageBox.Show("Таблица Пустая или не выделен нужный элемент");
            }
        }
        
    }
}

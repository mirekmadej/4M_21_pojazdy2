using MySql.Data;
using MySql.Data.MySqlClient;
using System.Runtime.CompilerServices;

namespace _4M_21_pojazdy2
{
    public partial class MainPage : ContentPage
    {
        int nr = 1;
        int min = 1;
        int maks = 0;
        static string con = "server=localhost;user=root;" +
            "database=pojazd;port=3306;password=";
        static MySqlConnection conConn = new MySqlConnection(con);

        public MainPage()
        {
            
            conConn.Open();

            string sql = "select min(id) from pojazd";
            string s = "";
            MySqlCommand w1 = new MySqlCommand(sql, conConn);
            MySqlDataReader reader1 = w1.ExecuteReader();
            while (reader1.Read())
                s = reader1[0].ToString();
            reader1.Close();
            nr = int.Parse(s);
            min = nr;

            sql = "select max(id) from pojazd";
            s="";
            MySqlCommand w = new MySqlCommand(sql, conConn);
            MySqlDataReader reader = w.ExecuteReader();
            while(reader.Read())
                s = reader[0].ToString();          
            reader.Close();
            maks = int.Parse(s);

            InitializeComponent();
            sql = $"SELECT * from POJAZD where id={nr}";
            MySqlCommand w2= new MySqlCommand(sql, conConn);
            MySqlDataReader r2 = w2.ExecuteReader();
            while (r2.Read())
            {
                lblNr.Text = r2[0].ToString();
                lblMarka.Text = r2[1].ToString();
                lblModel.Text = r2[2].ToString();
                lblKolor.Text = r2[3].ToString();
                lblRocznik.Text = r2[4].ToString()+" km";
                lblPrzebieg.Text = r2[5].ToString();
                lblCena.Text = r2[6].ToString() + " zł";
            }
            r2.Close();
            
        }
        ~MainPage()
        {
            conConn.Close();
        }
        private void btnPoprzedniClicked(object sender, EventArgs e)
        {
            nr--;
            string sql = $"SELECT * from POJAZD where id={nr}";
            MySqlCommand w2 = new MySqlCommand(sql, conConn);
            MySqlDataReader r2 = w2.ExecuteReader();

            while (r2.Read())
            {
                lblNr.Text = r2[0].ToString();
                lblMarka.Text = r2[1].ToString();
                lblModel.Text = r2[2].ToString();
                lblKolor.Text = r2[3].ToString();
                lblRocznik.Text = r2[4].ToString() + " km";
                lblPrzebieg.Text = r2[5].ToString();
                lblCena.Text = r2[6].ToString() + " zł";
            }
            r2.Close();
            btnNastepny.IsEnabled = true;
            if (nr == min) btnPoprzedni.IsEnabled = false;
        }
        private void btnNastepnyClicked(object sender, EventArgs e)
        {
            nr++;
            string sql = $"SELECT * from POJAZD where id={nr}";
            MySqlCommand w2 = new MySqlCommand(sql, conConn);
            MySqlDataReader r2 = w2.ExecuteReader();
            while (r2.Read())
            {
                lblNr.Text = r2[0].ToString();
                lblMarka.Text = r2[1].ToString();
                lblModel.Text = r2[2].ToString();
                lblKolor.Text = r2[3].ToString();
                lblRocznik.Text = r2[4].ToString() + " km";
                lblPrzebieg.Text = r2[5].ToString();
                lblCena.Text = r2[6].ToString() + " zł";
            }
            r2.Close();
            btnPoprzedni.IsEnabled = true;
            if(nr == maks) btnNastepny.IsEnabled = false;
        }
    }
}
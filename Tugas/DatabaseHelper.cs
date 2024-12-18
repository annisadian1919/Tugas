using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;


namespace Tugas
{
   
    public class DatabaseHelper
    {
        private string connectionString = "server=localhost;port=3307;database=db_sigmafarma;uid=root;pwd=Password123!";
        private MySqlConnection connection;

        // Constructor
        public DatabaseHelper()
        {
            connection = new MySqlConnection(connectionString); // Inisialisasi koneksi
        }

        // Membuka koneksi ke database
        public MySqlConnection OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open(); // Membuka koneksi jika belum terbuka
            }
            return connection;
        }

        // Menutup koneksi database
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close(); // Menutup koneksi jika terbuka
            }
        }

        // Fungsi untuk menambah obat ke keranjang
        public void TambahKeKeranjang(int idUser, int idObat, int jumlah)
        {
            try
            {
                string query = "INSERT INTO keranjang (id_user, id_obat, jumlah) VALUES (@idUser, @idObat, @jumlah)";
                MySqlCommand cmd = new MySqlCommand(query, OpenConnection());
                cmd.Parameters.AddWithValue("@idUser", idUser); // Menambahkan parameter untuk idUser
                cmd.Parameters.AddWithValue("@idObat", idObat); // Menambahkan parameter untuk idObat
                cmd.Parameters.AddWithValue("@jumlah", jumlah); // Menambahkan parameter untuk jumlah

                cmd.ExecuteNonQuery(); // Eksekusi query (menambah ke keranjang)
                CloseConnection(); // Menutup koneksi setelah query dieksekusi
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message); // Menampilkan pesan error jika ada masalah
            }
        }

        // Fungsi untuk mengambil stok obat
        public DataTable GetStokObat()
        {
            DataTable dt = new DataTable(); // Membuat DataTable untuk menyimpan data obat
            try
            {
                string query = "SELECT id_obat, nama, harga, stok FROM obat"; // Query untuk mengambil data obat
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, OpenConnection()); // Membuat adapter untuk mengambil data
                adapter.Fill(dt); // Mengisi DataTable dengan data dari database
                CloseConnection(); // Menutup koneksi setelah query selesai
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message); // Menampilkan pesan error jika ada masalah
            }
            return dt; // Mengembalikan DataTable yang berisi data obat
        }

        public static Dictionary<string, object> GetObatById(int idObat)
        {
            Dictionary<string, object> dataObat = new Dictionary<string, object>();

            string connectionString = "server=localhost;port=3307;database=db_sigmafarma;uid=root;pwd=Password123!;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT nama_obat, harga, stok, foto FROM data_obat WHERE id_obat = @idObat";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idObat", idObat);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                dataObat["nama_obat"] = reader.GetString("nama_obat");
                                dataObat["harga"] = reader.GetDecimal("harga");
                                dataObat["stok"] = reader.GetInt32("stok");
                                dataObat["foto"] = reader["foto"]; // Foto disimpan dalam bentuk byte[]
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return dataObat;
        }

    }

}

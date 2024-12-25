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
        //public void TambahKeKeranjang(int idUser, int idObat, int jumlah)
        //{
        //    try
        //    {
        //        using (var connection = OpenConnection())
        //        {
        //            string query = "INSERT INTO keranjang (id_user, id_obat, jumlah) VALUES (@idUser, @idObat, @jumlah)";
        //            MySqlCommand cmd = new MySqlCommand(query, connection);
        //            cmd.Parameters.AddWithValue("@idUser", idUser);
        //            cmd.Parameters.AddWithValue("@idObat", idObat);
        //            cmd.Parameters.AddWithValue("@jumlah", jumlah);

        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //    }
        //}
        public void TambahKeKeranjang(int userId, int idObat, int jumlah)
        {
            try
            {
                using (var connection = OpenConnection())
                {
                    // Debugging: Cetak parameter untuk memastikan nilai yang benar
                    Console.WriteLine("idUser: " + userId);
                    Console.WriteLine("idObat: " + idObat);
                    Console.WriteLine("jumlah: " + jumlah);

                    // Verifikasi bahwa idUser ada di tabel users
                    string checkUserQuery = "SELECT COUNT(*) FROM users WHERE id_user = @idUser";
                    MySqlCommand checkUserCmd = new MySqlCommand(checkUserQuery, connection);
                    checkUserCmd.Parameters.AddWithValue("@idUser", userId);

                    int userCount = Convert.ToInt32(checkUserCmd.ExecuteScalar());
                    if (userCount == 0)
                    {
                        Console.WriteLine("User ID tidak ditemukan di tabel users.");
                        return; // Keluar dari metode jika idUser tidak ditemukan
                    }

                    string query = "INSERT INTO keranjang (id_user, id_obat, jumlah) VALUES (@idUser, @idObat, @jumlah)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@idUser", userId);
                    cmd.Parameters.AddWithValue("@idObat", idObat);
                    cmd.Parameters.AddWithValue("@jumlah", jumlah);

                    int result = cmd.ExecuteNonQuery(); // Eksekusi query

                    // Log hasil eksekusi kueri
                    Console.WriteLine("Rows affected: " + result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }



        // Fungsi untuk mengambil stok obat
        public DataTable GetStokObat()
        {
            DataTable dt = new DataTable(); // Membuat DataTable untuk menyimpan data obat
            try
            {
                string query = "SELECT id_obat, nama, harga, stok FROM data_obat"; // Query untuk mengambil data obat
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
                    string query = "SELECT nama_obat, harga, stok, foto_obat FROM data_obat WHERE id_obat = @idObat";
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
                                dataObat["foto_obat"] = reader["foto_obat"]; // Foto disimpan dalam bentuk byte[]
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

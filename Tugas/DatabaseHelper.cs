using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


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

        public List<string> GetFilteredObat(string jenisObat, string keyword)
        {
            List<string> listObat = new List<string>();
            MySqlConnection connection = null;

            try
            {
                connection = OpenConnection(); // Buka koneksi
                string query = "SELECT nama_obat, jenis_obat, stok, harga FROM data_obat WHERE 1=1";

                // Tambahkan filter jenis obat jika dipilih
                if (!string.IsNullOrEmpty(jenisObat) && jenisObat != "Semua")
                {
                    query += " AND jenis_obat = @jenisObat";
                }

                // Tambahkan filter keyword jika diisi
                if (!string.IsNullOrEmpty(keyword))
                {
                    query += " AND nama_obat LIKE @keyword";
                }

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(jenisObat) && jenisObat != "Semua")
                    {
                        cmd.Parameters.AddWithValue("@jenisObat", jenisObat);
                    }

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string displayText = $"{reader["nama_obat"]} | Jenis: {reader["jenis_obat"]} | Stok: {reader["stok"]} | Harga: {reader["harga"]}";
                            listObat.Add(displayText);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close(); // Tutup koneksi di blok finally
                }
            }

            return listObat;
        }



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
        public int GetStokObat(string namaObat)
        {
            int stok = 0;
            string connectionString = "server=localhost;port=3307;database=db_sigmafarma;uid=root;pwd=Password123!;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT stok FROM data_obat WHERE nama_obat = @namaObat";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@namaObat", namaObat);

                        var result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            stok = Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return stok;
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

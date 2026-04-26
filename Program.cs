using System;
using TP_MODUL9_103022400024;

namespace TP_MODUL9_103022400024 
{
    class Program
    {
        static void Main(string[] args)
        {
            CovidConfig covidConfig = new CovidConfig();

            // Sesi 1: Menjalankan program dengan konfigurasi awal
            JalankanPengecekan(covidConfig);

            Console.WriteLine("\n=============================================");

            // Langkah C.7: Memanggil method UbahSatuan
            covidConfig.UbahSatuan();

            Console.WriteLine("=============================================\n");

            // Sesi 2: Menjalankan program lagi setelah satuan diubah
            JalankanPengecekan(covidConfig);
        }

        static void JalankanPengecekan(CovidConfig covidConfig)
        {
            Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {covidConfig.config.satuan_suhu}: ");
            string inputSuhu = Console.ReadLine();
            // Mengganti koma menjadi titik untuk meminimalisir error parsing desimal bawaan OS
            double suhu = Convert.ToDouble(inputSuhu.Replace(',', '.'));

            Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman? ");
            int hari = Convert.ToInt32(Console.ReadLine());

            bool suhuValid = false;

            // Pengecekan kondisi C.5.a
            if (covidConfig.config.satuan_suhu == "celcius")
            {
                if (suhu >= 36.5 && suhu <= 37.5) suhuValid = true;
            }
            else if (covidConfig.config.satuan_suhu == "fahrenheit")
            {
                if (suhu >= 97.7 && suhu <= 99.5) suhuValid = true;
            }

            // Pengecekan kondisi C.5.b
            bool hariValid = hari < covidConfig.config.batas_hari_deman;

            // Output hasil
            if (suhuValid && hariValid)
            {
                Console.WriteLine(covidConfig.config.pesan_diterima);
            }
            else
            {
                Console.WriteLine(covidConfig.config.pesan_ditolak);
            }
        }
    }
}
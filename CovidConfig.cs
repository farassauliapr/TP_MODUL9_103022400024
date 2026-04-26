using System;
using System.IO;
using System.Text.Json;

namespace TP_MODUL9_103022400024 
{
    public class ConfigData
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_deman { get; set; } 
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }
    }

    public class CovidConfig
    {
        public ConfigData config { get; set; }
        public string filePath = "covid_config.json";

        public CovidConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception)
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }

        private void ReadConfigFile()
        {
            string configJsonData = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<ConfigData>(configJsonData);
        }

        private void SetDefault()
        {
            config = new ConfigData
            {
                satuan_suhu = "celcius",
                batas_hari_deman = 14,
                pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini",
                pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini"
            };
        }

        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions() { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
        }

        // Langkah C.6: Method UbahSatuan
        public void UbahSatuan()
        {
            if (config.satuan_suhu == "celcius")
            {
                config.satuan_suhu = "fahrenheit";
            }
            else if (config.satuan_suhu == "fahrenheit")
            {
                config.satuan_suhu = "celcius";
            }
            Console.WriteLine($"[Sistem] Satuan suhu telah diubah menjadi: {config.satuan_suhu}");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace UartDataLogger
{
    class AppSettings
    {
        string port;
        string baudRate;
        string timer;
        bool newLine;
        string outputTimeType;

        public AppSettings()
        {
            Port = "";
            BaudRate = "9600";
            Timer = "10";
            NewLine = true;
            OutputTimeType = "Millis";
        }

        public string Port { get => port; set => port = value; }
        public string BaudRate { get => baudRate; set => baudRate = value; }
        public string Timer { get => timer; set => timer = value; }
        public bool NewLine { get => newLine; set => newLine = value; }
        public string OutputTimeType { get => outputTimeType; set => outputTimeType = value; }

        public void loadSettings(ref AppSettings appSettings, String path)
        {
            if (File.Exists(path))
            {
                string jsonString = File.ReadAllText(path);
                appSettings = JsonConvert.DeserializeObject<AppSettings>(jsonString);
            }
        }

        public void saveSettings(string path)
        {
            string jsonString = JsonConvert.SerializeObject(this);
            FileInfo fileinfo = new FileInfo(path);
            if (!fileinfo.Directory.Exists)
            {
                Directory.CreateDirectory(fileinfo.Directory.FullName);
            }
            File.WriteAllText(path, jsonString);
        }

    }
}

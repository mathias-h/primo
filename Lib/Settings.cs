using Newtonsoft.Json;
using System;
using System.IO;

namespace Lib
{
    class SettingsData
    {
        public string BatchFolder { get; set; }
        public string FMCFolder { get; set; }
        public string GRPFolder { get; set; }
        public string ASCFolder { get; set; }
        public int EndPieceLength { get; set; }
    }

    public class Settings
    {   
        private static string SETTINGS_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Primo\settings.json";
        private static Settings instance;
        public static Settings Instance {
            get
            {
                if (instance == null) instance = new Settings();
                return instance;
            }
        }
        private SettingsData data;

        private Settings()
        {
            data = GetData();

            if (!Directory.Exists(data.BatchFolder))
            {
                throw new Exception("BatchFolder stien \"" + data.BatchFolder + "\" findes ikke");
            }

            if (!Directory.Exists(data.FMCFolder))
            {
                throw new Exception("FMCFolder stien \"" + data.FMCFolder + "\" findes ikke");
            }
            if (!Directory.Exists(data.GRPFolder))
            {
                throw new Exception("GRPFolderstien  \"" + data.GRPFolder + "\" findes ikke");
            }
            if (!Directory.Exists(data.ASCFolder))
            {
                throw new Exception("ASCFolder stien \"" + data.ASCFolder + "\" findes ikke");
            }
            if (data.EndPieceLength < 0)
            {
                throw new Exception("EndPieceLength \"" + data.EndPieceLength + "\" er ikke gyldig");
            }
        }

        public string BatchFolder
        {
            get { return data.BatchFolder; }
        }
        public string FMCFolder
        {
            get { return data.FMCFolder; }
        }
        public string GRPFolder
        {
            get { return data.GRPFolder; }
        }
        public string ASCFolder
        {
            get { return data.ASCFolder; }
        }
        public int EndPieceLength
        {
            get { return data.EndPieceLength; }
        }

        private SettingsData GetData()
        {
            if (!File.Exists(SETTINGS_PATH))
            {
                throw new Exception("kan ikke finde en settings.json fil" + Environment.NewLine +
                    "den skal placers i \"" + SETTINGS_PATH + "\"");
            }

            var str = File.ReadAllText(SETTINGS_PATH);

            try
            {
                return JsonConvert.DeserializeObject<SettingsData>(str);
            } catch
            {
                throw new Exception("setting.json er ikke i korrekt format");
            }
        }
    }
}

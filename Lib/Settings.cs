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
        public string GRPSmallFolder { get; set; }
        public string ASCFolder { get; set; }
        public int EndPieceLength { get; set; }
    }

    public class Settings
    {   
        private static readonly string SETTINGS_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Primo\settings.json";
        private static Settings instance;
        public static Settings Instance {
            get
            {
                if (instance == null) instance = new Settings();
                return instance;
            }
        }
        private SettingsData Data;

        private Settings()
        {
            Data = GetData();

            if (!Directory.Exists(Data.BatchFolder))
            {
                throw new Exception("BatchFolder stien \"" + Data.BatchFolder + "\" findes ikke");
            }

            if (!Directory.Exists(Data.FMCFolder))
            {
                throw new Exception("FMCFolder stien \"" + Data.FMCFolder + "\" findes ikke");
            }
            if (!Directory.Exists(Data.GRPFolder))
            {
                throw new Exception("GRPFolder stien  \"" + Data.GRPFolder + "\" findes ikke");
            }
            if (!Directory.Exists(Data.GRPSmallFolder))
            {
                throw new Exception("GRPSmallFolder stien  \"" + Data.GRPSmallFolder + "\" findes ikke");
            }
            if (!Directory.Exists(Data.ASCFolder))
            {
                throw new Exception("ASCFolder stien \"" + Data.ASCFolder + "\" findes ikke");
            }
            if (Data.EndPieceLength < 0)
            {
                throw new Exception("EndPieceLength \"" + Data.EndPieceLength + "\" er ikke gyldig");
            }
        }

        public string BatchFolder
        {
            get { return Data.BatchFolder; }
        }
        public string FMCFolder
        {
            get { return Data.FMCFolder; }
        }
        public string GRPFolder
        {
            get { return Data.GRPFolder; }
        }
        public string GRPSmallFolder
        {
            get { return Data.GRPSmallFolder; }
        }
        public string ASCFolder
        {
            get { return Data.ASCFolder; }
        }
        public int EndPieceLength
        {
            get { return Data.EndPieceLength; }
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

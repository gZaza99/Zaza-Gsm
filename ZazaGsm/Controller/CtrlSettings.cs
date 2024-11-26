using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZazaGsm.Model;
using ZazaGsm.Base;

namespace ZazaGsm.Controller
{
    public static class CtrlSettings
    {
        private static string SettingsFilePath => @"../../../../settings.ini";

        public static void LoadSettings()
        {
            FileStream? fileStream = null;
            try
            {
                fileStream = new FileStream(SettingsFilePath, FileMode.Open, FileAccess.Read);
            }
            catch (IOException)
            {
                fileStream?.Close();
                return;
            }
            string? line;
            string key, value;
            string[] tempArray;
            int indexOfSemicolon;
            StreamReader streamReader = new(fileStream);
            do
            {
                line = streamReader.ReadLine();
                if (line == null)
                    continue;
                else
                {
                    indexOfSemicolon = line.IndexOf(';');
                    if (indexOfSemicolon == -1)
                        throw new Exception("Hiányzik a pontosvessző!");
                    line = line[..indexOfSemicolon]; // Cuts everythig behing semicolon
                    tempArray = line.Split('=');
                    key = tempArray[0];
                    value = tempArray[1];

                    switch (key.ToLower())
                    {
                        case "address":
                        case "addr":
                        case "a":
                        case "server":
                        case "s":
                            ZazaGSMForm.AppSettings.SetProperty(Settings.DbAddressProperty, value);
                            break;
                        case "database":
                        case "db":
                            ZazaGSMForm.AppSettings.SetProperty(Settings.DbNameProperty, value);
                            break;
                        case "username":
                        case "user":
                        case "usr":
                        case "u":
                            ZazaGSMForm.AppSettings.SetProperty(Settings.UsrNameProperty, value);
                            break;
                        case "password":
                        case "pass":
                        case "pwd":
                        case "p":
                            ZazaGSMForm.AppSettings.SetProperty(Settings.UsrPasswordProperty, value);
                            break;
                    }
                }
            } while (!streamReader.EndOfStream);

            streamReader.Close();
            fileStream.Close();
        }

        public static void SaveSettings()
        {
            FileStream? fileStream = null;

            try
            {
                fileStream = new FileStream(SettingsFilePath, FileMode.Open, FileAccess.Write);
            }
            catch (IOException)
            {
                fileStream?.Close();
                return;
            }
            string content = $"address={ZazaGSMForm.AppSettings.DbAddress};\n";
            content += $"database={ZazaGSMForm.AppSettings.DbName};\n";
            content += $"username={ZazaGSMForm.AppSettings.UsrName};\n";
            content += $"password={ZazaGSMForm.AppSettings.UsrPassword};";

            StreamWriter streamWriter = new(fileStream);
            streamWriter.Write(content);
            fileStream.SetLength(content.Length);

            streamWriter.Close();
            fileStream.Close();
        }
    }
}

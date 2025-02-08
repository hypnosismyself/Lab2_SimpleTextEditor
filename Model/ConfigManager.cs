using System.Collections.Generic;
using System.IO;

namespace Lab2_SimpleTextEditor.Model
{
    internal class ConfigManager
    {
        // Класс для работы с конфигом

        // Константы для настройки конфига

        // Разделитель
        private const char _CONFIG_SPLIT_CHAR = '=';

        // Путь к конфигу
        private const string _CONFIG_PATH = "..\\config.ini";

        // Список ключей
        private readonly List<string> _CONFIG_KEYS = new List<string>()
        {
            "ФОН.ЦВЕТ",
            "ШРИФТ.СЕМЬЯ",
            "ШРИФТ.РАЗМЕР",
            "ШРИФТ.ЦВЕТ",
            "ШРИФТ.ЖИРНЫЙ",
            "ШРИФТ.НАКЛОННЫЙ",
            "ШРИФТ.ПОДЧЕРКНУТЫЙ",
            "ШРИФТ.ЗАЧЕРКНУТЫЙ"
        };

        // Базовые настройки шрифта
        private const string _DEFAULT_BACKGROUND_COLOR = "#FFFFFF";
        private const string _DEFAULT_FONT_COLOR = "#000000";
        private const string _DEFAULT_FONT_FAMILY = "Arial";
        private const string _DEFAULT_FONT_SIZE = "14";

        // Служебный метод чтения конфига
        private string[] Read()
        {
            // return: список всех строк конфига

            string[] config_lines = new string[_CONFIG_KEYS.Count];

            try
            {
                using (StreamReader sr = new StreamReader(_CONFIG_PATH))
                {
                    for (int i = 0; i < config_lines.Length; i++)
                    {
                        config_lines[i] = sr.ReadLine();
                    }
                }
            }
            catch { }

            return config_lines;
        }

        // Служебный метод получения индекса опции
        private int GetKeyID(string search_key)
        {
            // arg: search_key - ключ поиска
            // return: индекс настройки в конфиге

            string[] config_lines = Read();

            for (int i = 0; i < config_lines.Length; i++)
            {
                string key = config_lines[i].Split(_CONFIG_SPLIT_CHAR)[0];

                if (key == search_key)
                {
                    return i;
                }
            }

            return -1;
        }

        // Метод проверки существования конфига
        public bool Exists()
        {
            return File.Exists(_CONFIG_PATH);
        }

        // Метод записи стандартного конфига
        public void WriteDeafultConfig()
        {
            // Сырой конфиг
            List<string> DEFAULT_CONFIG = new List<string>()
            {
                $"{_CONFIG_KEYS[0]}{_CONFIG_SPLIT_CHAR}{_DEFAULT_BACKGROUND_COLOR}",
                $"{_CONFIG_KEYS[1]}{_CONFIG_SPLIT_CHAR}{_DEFAULT_FONT_FAMILY}",
                $"{_CONFIG_KEYS[2]}{_CONFIG_SPLIT_CHAR}{_DEFAULT_FONT_SIZE}",
                $"{_CONFIG_KEYS[3]}{_CONFIG_SPLIT_CHAR}{_DEFAULT_FONT_COLOR}",
                $"{_CONFIG_KEYS[4]}{_CONFIG_SPLIT_CHAR}{false}",
                $"{_CONFIG_KEYS[5]}{_CONFIG_SPLIT_CHAR}{false}",
                $"{_CONFIG_KEYS[6]}{_CONFIG_SPLIT_CHAR}{false}",
                $"{_CONFIG_KEYS[7]}{_CONFIG_SPLIT_CHAR}{false}"
            };

            try
            {
                using (StreamWriter sr = new StreamWriter(_CONFIG_PATH, false))
                {
                    foreach (string line in DEFAULT_CONFIG)
                    {
                        sr.WriteLine(line);
                    }
                }
            }
            catch { }
        }

        // Метод получения настройки по ключу
        public string GetOptionByKey(string search_key)
        {
            // arg: search_key - ключ поиска
            // return: настройка

            string[] config_lines = Read();

            for (int i = 0; i < config_lines.Length; i++)
            {
                string key = config_lines[i].Split(_CONFIG_SPLIT_CHAR)[0];
                string option = config_lines[i].Split(_CONFIG_SPLIT_CHAR)[1];

                if (key == search_key)
                {
                    return option;
                }
            }

            return "";
        }

        // Метод обновления значения в конфиге по ключу
        public void UpdateConfig(string key, string new_option)
        {
            // arg: key - ключ настройки
            // arg: new_option - новая настройка
            string[] config_lines = Read();

            config_lines[GetKeyID(key)] = $"{key}{_CONFIG_SPLIT_CHAR}{new_option}";

            try
            {
                using (StreamWriter sr = new StreamWriter(_CONFIG_PATH, false))
                {
                    foreach (string line in config_lines)
                    {
                        sr.WriteLine(line);
                    }
                }
            }
            catch { }
        }
    }
}

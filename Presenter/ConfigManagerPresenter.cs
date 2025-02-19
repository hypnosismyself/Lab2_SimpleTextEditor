using Lab2_SimpleTextEditor.Model;
using System;
using System.Drawing;

namespace Lab2_SimpleTextEditor
{
    internal class ConfigManagerPresenter
    {
        // Презентер | Менеджер конфига

        // Инициализация представления
        public EditorView EditorView { get => _editorView; set => _editorView = value; }
        private EditorView _editorView;

        // Инициализация модели
        public ConfigManager ConfigManager { get => _configManager; set => _configManager = value; }
        private ConfigManager _configManager;

        // Конструктор
        public ConfigManagerPresenter(ConfigManager model, EditorView view)
        {
            EditorView = view;
            ConfigManager = model;
        }

        // Презентер проверки существования фалйа на БЛ
        public bool CheckConfigExist()
        {
            // return: есть конфиг?

            return ConfigManager.Exists();
        }

        // Презентер записи стандартного конфига
        public void WriteDefaultConfig()
        {
            // зовем запись конфига на БЛ
            ConfigManager.WriteDeafultConfig();

            // перерисовываем представление по новому конфигу
            UpdateViewByConfig();
        }

        // Презентер перерисовки представления по конфигу
        public void UpdateViewByConfig()
        {
            // забираем из БЛ цвета и конвертируем в Color
            Color background_color = StringToColor(ConfigManager.GetOptionByKey("ФОН.ЦВЕТ"));
            Color font_color = StringToColor(ConfigManager.GetOptionByKey("ШРИФТ.ЦВЕТ"));

            // забираем из БЛ шрифт и конвертим
            Font font = new Font
            (
                ConfigManager.GetOptionByKey("ШРИФТ.СЕМЬЯ"),
                float.Parse(ConfigManager.GetOptionByKey("ШРИФТ.РАЗМЕР")),
                ParseFontStyle()
            );

            // записываем в представление новый конфиг
            EditorView.FontColor = font_color;
            EditorView.FontOptions = font;
            EditorView.BackgroundColor = background_color;

            // перерисовывем представление
            EditorView.UpdateTextField();
        }

        // Служебный метод парсинга стиля шрифта
        private FontStyle ParseFontStyle()
        {
            // return: стиль шрифта

            FontStyle style = FontStyle.Regular;

            if (Convert.ToBoolean(ConfigManager.GetOptionByKey("ШРИФТ.ЖИРНЫЙ")))
            {
                style |= FontStyle.Bold;
            }

            if (Convert.ToBoolean(ConfigManager.GetOptionByKey("ШРИФТ.НАКЛОННЫЙ")))
            {
                style |= FontStyle.Italic;
            }

            if (Convert.ToBoolean(ConfigManager.GetOptionByKey("ШРИФТ.ПОДЧЕРКНУТЫЙ")))
            {
                style |= FontStyle.Underline;
            }

            if (Convert.ToBoolean(ConfigManager.GetOptionByKey("ШРИФТ.ЗАЧЕРКНУТЫЙ")))
            {
                style |= FontStyle.Strikeout;
            }

            return style;
        }

        // Служебный метод конвертации цвета из Color в string (HEX)
        private static string ColorToString(Color color)
        {
            // arg: color - цвет Color
            // return: строковый цвет в формате HEX

            return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }

        // Служебный метод конвертации цвета из string (HEX) в Color
        private static Color StringToColor(string hexColor)
        {
            // arg: color - цвет string (HEX)
            // return: цвет Color

            int r = Convert.ToInt32(hexColor.Substring(1, 2), 16);
            int g = Convert.ToInt32(hexColor.Substring(3, 2), 16);
            int b = Convert.ToInt32(hexColor.Substring(5, 2), 16);

            return Color.FromArgb(255, r, g, b);
        }

        // Презентер обновления шрифта в конфиге
        public void UpdateFontConfig()
        {
            string[] font_options = EditorView._FONT_OPTIONS;

            string[] new_options = new string[]
            {
                EditorView.FontOptions.FontFamily.Name.ToString(),
                EditorView.FontOptions.Size.ToString(),
                EditorView.FontOptions.Bold.ToString(),
                EditorView.FontOptions.Italic.ToString(),
                EditorView.Font.Underline.ToString(),
                EditorView.FontOptions.Strikeout.ToString()
            };

            for (int i = 0; i < font_options.Length; i++)
                ConfigManager.UpdateConfig(font_options[i], new_options[i]);
        }

        // Презентер обновления цвета шрифта в конфиге
        public void UpdateFontColorConfig()
        {
            ConfigManager.UpdateConfig("ШРИФТ.ЦВЕТ", ColorToString(EditorView.FontColor));
        }

        // Презентер обновления цвета фона конфиге
        public void UpdateBackgroundColorConfig()
        {
            ConfigManager.UpdateConfig("ФОН.ЦВЕТ", ColorToString(EditorView.BackgroundColor));
        }
    }
}
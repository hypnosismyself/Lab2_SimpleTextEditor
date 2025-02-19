using Lab2_SimpleTextEditor.Model;
using Lab2_SimpleTextEditor.Presenter;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab2_SimpleTextEditor
{   
    public partial class EditorView : Form
    {
        // Представление | Форма текстового редактора

        // Свойства
        /*
         * FilePath: путь к файлу
         * FontColor: цвет шрифта
         * BackgroundColor: цвет фона
         * FontOptions: настройки шрифта
         */
        public string FilePath { get; set; }
        public Color FontColor { get; set; }
        public Color BackgroundColor { get; set; }
        public Font FontOptions { get; set; }

        // Поля
        /*
         * _isFileSaved: файл сохранен?
         * FilePresenter: презентер работы с файлами
         * ConfigPresenter: презентер работы с конфигом
         */
        private bool _isFileSaved;
        private FileManagerPresenter FilePresenter;
        private ConfigManagerPresenter ConfigPresenter;

        // Константы
        /*
         * _FONT_OPTIONS: поля настроек шрифта
         * _FILE_FILTER: фильтр для файловых диалогов
         */
        public readonly string[] _FONT_OPTIONS = new string[]
        {
            "ШРИФТ.СЕМЬЯ",
            "ШРИФТ.РАЗМЕР",
            "ШРИФТ.ЖИРНЫЙ",
            "ШРИФТ.НАКЛОННЫЙ",
            "ШРИФТ.ПОДЧЕРКНУТЫЙ",
            "ШРИФТ.ЗАЧЕРКНУТЫЙ"
        };
        private const string _FILE_FILTER = 
            "Тектовые файлы (*.txt)|*.txt|" +
            "Конфигурационные файлы (*.ini; *.toml)|*.ini;*.toml|" +
            "Логовые файлы (*.log)|*.log";

        public EditorView()
        {
            InitializeComponent();
        }

        /*
         * Обработчики событий формы
         */

        // При загрузке формы
        private void EditorView_Load(object sender, EventArgs e)
        {
            ConfigPresenter = new ConfigManagerPresenter(new ConfigManager(), this);

            // создаем пустой шаблон
            CreateNamelessTemplate();

            if (!ConfigExists())
            {
                // если конфига нет, то пишем дефолтный конфиг
                ConfigPresenter.WriteDefaultConfig();
            }
            else
            {
                // иначе читаем настройки из конфига
                ConfigPresenter.UpdateViewByConfig();
            }
        }

        // При клике "Создать"
        private void CreateFileOption_Click(object sender, EventArgs e)
        {
            if (_isFileSaved || IsEmptyTemplate())
            {
                // если файл сохранен или пустой безымянный файл
                // создаем пустой файл
                CreateNamelessTemplate();
            }
            else
            {
                // иначе поднимаем диалог сохранения
                SaveFileOption.PerformClick();
            }
        }

        // При клике "Открыть"
        private void OpenFileOption_Click(object sender, EventArgs e)
        {
            if (IsEmptyTemplate() || _isFileSaved)
            {
                // если безымянный и сохранен
                // открываем диалог открытия файла
                ShowOpenDialog();
            }
            else
            {
                // иначе показываем диалог отмены сохранения
                if (ShowSaveAcceptanceDialog() == DialogResult.Yes)
                {
                    // если отказываемся от сохранения
                    // открываем диалог открытия файла
                    ShowOpenDialog();
                }
            }
        }

        // При клике "Сохранить" / "Сохранить как..."
        private void SaveFileOption_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;

            // из текста итема меню забираем текст
            string command = toolStripMenuItem.Text;
            ShowSaveDialog(command);
        }

        // При клике "Выход"
        private void ExitOption_Click(object sender, EventArgs e)
        {
            if (IsEmptyTemplate() || _isFileSaved)
            {
                // если пустой безымянный или файл сохранен
                // закрываемся
                Application.Exit();
            }
            else
            {
                // иначе предлагаем сохранить файл
                if (ShowSaveAcceptanceDialog() == DialogResult.No)
                {
                    Application.Exit();
                }
                else
                {
                    SaveAsFileOption.PerformClick();
                }
            }
        }        

        // При клике "Шрифт"
        private void SetFontFamilyOption_Click(object sender, EventArgs e)
        {
            ConfigPresenter = new ConfigManagerPresenter(new ConfigManager(), this);

            using (FontDialog FontDialog = new FontDialog())
            {
                try
                {
                    if (FontDialog.ShowDialog() == DialogResult.OK)
                    {
                        // если шрифт применили
                        // меняем шрифт на интерфейсе
                        FontOptions = FontDialog.Font;
                        UpdateTextField();

                        // обновляем конфиг
                        ConfigPresenter.UpdateFontConfig();
                    }
                }
                catch { }
            }
        }

        // При клике "Цвет шрифта"
        private void SetFontColorOption_Click(object sender, EventArgs e)
        {
            ColorDialog ColorDialog = new ColorDialog();

            ConfigPresenter = new ConfigManagerPresenter(new ConfigManager(), this);

            using (FontDialog FontDialog = new FontDialog())
            {
                try
                {
                    if (ColorDialog.ShowDialog() == DialogResult.OK)
                    {
                        // если цвет применили
                        // меняем цвет шрифта на интерфейсе
                        FontColor = ColorDialog.Color;
                        UpdateTextField();

                        // обновляем конфиг
                        ConfigPresenter.UpdateFontColorConfig();
                    }
                }
                catch { }
            }
        }

        // При клике "Цвет фона"
        private void BackgroundColorOption_Click(object sender, EventArgs e)
        {
            ColorDialog ColorDialog = new ColorDialog();

            ConfigPresenter = new ConfigManagerPresenter(new ConfigManager(), this);

            using (FontDialog FontDialog = new FontDialog())
            {
                try
                {
                    if (ColorDialog.ShowDialog() == DialogResult.OK)
                    {
                        // если цвет применили
                        // меняем цвет фона на интерфейсе
                        BackgroundColor = ColorDialog.Color;
                        UpdateTextField();

                        // обновляем конфиг
                        ConfigPresenter.UpdateBackgroundColorConfig();
                    }
                }
                catch { }
            }
        }

        // При клике "О программе"
        private void AboutOption_Click(object sender, EventArgs e)
        {
            MessageBox.Show
            (
                "Простой блокнот | Автор Никольский В.А. ЗЦИС-27",
                "О программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // При вводе в текстовое поле
        private void TextField_TextChanged(object sender, EventArgs e)
        {
            string FormatName = Text;
            _isFileSaved = false;

            if (FormatName.Substring(FormatName.Length - 1) != "*")
            {
                // если уже есть *, то её не пишем
                Text += "*";
            }
        }

        /*
         * Публичные методы представления
         */

        // Метод перерисовки текстового поля
        public void UpdateTextField()
        {
            // свойства поля ввода берем из полей класса

            TextField.ForeColor = FontColor;
            TextField.BackColor = BackgroundColor;
            TextField.Font = FontOptions;
        }

        // Метод заполнения текстового поля
        public void SetText(string text)
        {
            // arg: text - текст, текстового поля

            TextField.Text = text;
        }

        /*
         * Служебные методы интефейса
         */

        // Служебный метод получения результата окна сохранения
        private DialogResult ShowSaveAcceptanceDialog()
        {
            // return: Сохранить файл?

            DialogResult result = MessageBox.Show
            (
                "Сохранить файл? При нажатии 'Нет' изменения будут безвозвратно утеряны",
                "Сообщение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            return result;
        }

        // Служебный метод создания пустого файла на интерфейсе
        private void CreateNamelessTemplate()
        {
            FilePath = null;
            _isFileSaved = false;
            TextField.Clear();
            RefreshFormName();
        }

        // Служебный метод проверки того, что файл Безымянный
        private bool IsTemplate()
        {
            // return: файл является шаблоном?

            return FilePath == null && _isFileSaved == false;
        }

        // Служебный метод проверки конфига на БЛ
        private bool ConfigExists()
        {
            // return: конфиг существует?

            ConfigPresenter = new ConfigManagerPresenter(new ConfigManager(), this);
            return ConfigPresenter.CheckConfigExist();
        }

        // Служебный метод проверки шаблона файла на пустоту
        private bool IsEmptyTemplate()
        {
            // return: текущий файл Безымянный и пустой?

            return IsTemplate() && TextField.Text == "";
        }

        // Служебный метод переименования формы
        private void RefreshFormName()
        {
            if (FilePath != null)
            {
                // если есть путь к файлу
                // показываем путь
                Text = FilePath;
            }
            else
            {
                // иначе файл Безымянный
                Text = "Безымянный";
            }
        }

        // Служебный метод проверки существования файла на БЛ
        private bool FileExists(string file_path)
        {
            // arg: FilePath - путь к файлу
            // return: Файл существует?

            FilePresenter = new FileManagerPresenter(new FileManager(), this);

            return FilePresenter.CheckFileExists(file_path);
        }

        // Метод обработки диалога открытия файла
        private void ShowOpenDialog()
        {
            FilePresenter = new FileManagerPresenter(new FileManager(), this);

            // инициализация диалога открытия
            OpenFileDialog OpenFileDialog = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = _FILE_FILTER,
                RestoreDirectory = false
            };

            using (OpenFileDialog)
            {
                if (OpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // если ок
                    // открываем файл
                    FilePath = OpenFileDialog.FileName;
                    FilePresenter.OpenFile();

                    // перерисовываем текст формы
                    RefreshFormName();
                    _isFileSaved = true;
                }
            }
        }

        // Метод вызова окна сохранения
        private void ShowSaveDialog(string command)
        {
            // arg: command - опция сохранения

            string temp_path;
            FilePresenter = new FileManagerPresenter(new FileManager(), this);

            // инициализация диалога сохранения файла
            SaveFileDialog SaveFileDialog = new SaveFileDialog
            {
                Title = command,
                InitialDirectory = "c:\\",
                Filter = _FILE_FILTER,
                RestoreDirectory = false,
                FileName = "Безымянный.txt",
                OverwritePrompt = true
            };

            if (FilePath != null && FileExists(FilePath))
            {
                // если есть путь к файлу и файл существует
                // сохраняем в него текст без вызова диалога
                FileSave(FilePath, TextField.Text);
            }
            else
            {
                using (SaveFileDialog)
                {
                    if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // если ок
                        // открываем диалог сохранения
                        temp_path = SaveFileDialog.FileName;

                        // сохраняем файл на БЛ
                        FileSave(temp_path, TextField.Text);
                    }
                }
            }
        }

        // Метод сохранения файла на БЛ
        private void FileSave(string file_path, string file_content)
        {
            // arg: FilePath - путь к файлу
            // arg: FileContent - содержимое файла

            FilePresenter = new FileManagerPresenter(new FileManager(), this);

            if (!FilePresenter.Save(file_path, file_content))
            {
                // если файл не смогли сохранить
                MessageBox.Show("Не удалось сохранить файл");
            }
            else
            {
                if (FileExists(file_path))
                {
                    // если файл на БЛ есть
                    // обновляем путь к файлу
                    this.FilePath = file_path;

                    // перерисовываем текст формы
                    RefreshFormName();
                    _isFileSaved = true;
                }
            }
        }
    }
}

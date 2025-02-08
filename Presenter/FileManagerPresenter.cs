using Lab2_SimpleTextEditor.Model;

namespace Lab2_SimpleTextEditor.Presenter
{
    internal class FileManagerPresenter
    {
        // Презентер | Менеджер файлов

        // Инициализация представления
        public EditorView View { get => _view; set => _view = value; }
        private EditorView _view;

        // Инициализация модели
        public FileManager FileManager { get => _file_manager; set => _file_manager = value; }
        private FileManager _file_manager;

        // Конструктор
        public FileManagerPresenter(FileManager model, EditorView view)
        {
            View = view;
            FileManager = model;
        }

        // Презентер открытия файла
        public void OpenFile()
        {
            FileManager.FilePath = View.FilePath;

            // перерисовываем представление пр тексту файла
            View.SetText(FileManager.GetContent());
        }

        // Презентер сохранения файла
        public bool Save(string file_path, string file_content)
        {
            // arg: file_path - путь к файлу
            // arg: file_content - содержимое файла
            // return: файл создан и сохранён?

            FileManager.FilePath = file_path;

            // сохраняем на БЛ
            FileManager.Save(file_content);

            // проверяем, что файл сохранён и существует
            return FileManager.IsSaved() && FileManager.Exist();
        }

        // Презентер проверки существования пути файла
        public bool CheckFileExists(string file_path)
        {
            // arg: file_path - путь к файлу
            // return: файл существует?

            FileManager.FilePath = file_path;

            return FileManager.Exist();
        }
    }
}

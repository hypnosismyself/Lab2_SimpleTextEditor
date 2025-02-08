using System;
using System.IO;

namespace Lab2_SimpleTextEditor.Model
{
    internal class FileManager
    {
        // Класс работы с файлом

        // Свойства
        public string FilePath { get; set; }

        // Поля
        private bool _isSaved;

        // Метод вычитки содержимого файла
        public string GetContent()
        {
            // return: содержимое файла

            try
            { 
                using (StreamReader StreamReader = new StreamReader(FilePath))
                {
                    return StreamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Метод сохранения файла
        public void Save(string file_content)
        {
            // arg: file_content - содержимое файла
            try
            {
                File.WriteAllText(FilePath, file_content);

                // если получмлось записать
                // то флаг СОХРАНЕН
                _isSaved = true;
            }
            catch
            {
                _isSaved = false;
            }
        }

        // Метод проверки существования файла
        public bool Exist()
        {
            // return: файл существует?

            return File.Exists(FilePath);
        }

        // Метод проверки сохранения файла
        public bool IsSaved()
        {
            // return: файл сохранен?

            return _isSaved;
        }
    }
}

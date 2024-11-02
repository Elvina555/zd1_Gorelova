using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop
{
     class PlayList
    {
        private List<Song> list;
        private int ind;

        // Конструктор
        public PlayList()
        {
            list = new List<Song>();
            ind = 0;
        }

        // Метод для получения текущей аудиозаписи
        public Song CurrentSong()
        {
            if (list.Count > 0)
                return list[ind];
            else
                throw new IndexOutOfRangeException("Невозможно получить текущую аудиозапись для пустого плейлиста!");
        }

        // Метод для добавления аудиозаписи
        public void AddSong(Song song)
        {
            list.Add(song);
        }

        // метод для создания нового объекта и добавления
        public void AddSong(string author, string title, string filename)
        {
            Song song = new Song(author, title, filename);
            list.Add(song);
        }
        //метод для перехода по индексу записи
        public void GoToStart()
        {
            ind = 0;
        }

        //метод для перехода к предыдущему плейлисту 
        public void Perexodone()
        {
            if (list.Count > 0)
            {
                ind = (ind - 1 + list.Count) % list.Count;
            }
        }
        //метод для перехода к следующему плейлисту 
        public void Perexodtwo()
        {
            if (list.Count > 0)
            {
                ind = (ind + 1) % list.Count;
            }
        }
        // метод для переход по индексу записи
        public void GoToSong(int index)
        {
            if (index >= 0 && index < list.Count)
            {
                ind = index;
            }
            else
            {
                throw new IndexOutOfRangeException("Индекс вне диапазона!");
            }
        }
        //метод для удаления по индексу
        public void Remove(int index)
        {
            if (index >= 0 && index < list.Count)
            {
                list.RemoveAt(index);
                if (ind >= list.Count) ind = list.Count - 1; 
            }
            else
            {
                throw new IndexOutOfRangeException("Индекс вне диапазона!");
            }
        }
        // метод для удаления по значению 
        public void Remove(Song song)
        {
            int index = list.IndexOf(song);
            if (index != -1)
            {
                Remove(index);
            }
        }
    }
}

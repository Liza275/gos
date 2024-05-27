using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD.Framework
{
    public class HashTableLineProbing
    {
        private const double LoadFactorThreshold = 0.7; // Порог заполнения, при достижении которого будет происходить рехэширование
        private int _size;
        private PersonModel[] _data;
        private int _step;
        private int _count;

        public HashTableLineProbing(int initialSize, int step)
        {
            _size = initialSize;
            _data = new PersonModel[_size];
            _step = step;
            _count = 0;
        }

        public void Print()
        {
            int i = 1;
            foreach (var element in _data)
            {
                if (element == null || element.IsDeleted)
                {
                    Console.WriteLine($"Элемент {i} - null");
                }
                else
                {
                    Console.WriteLine($"Элемент {i} - {element.Name} {element.Age}");
                }
                i++;
            }
        }

        public void Insert(PersonModel personModel)
        {
            if ((double)(_count + 1) / _size > LoadFactorThreshold)
            {
                Resize();
            }

            int index = GetIndex(personModel);

            if (_data[index] == null || _data[index].IsDeleted)
            {
                _data[index] = personModel;
                _count++;
                return;
            }

            for (int i = 1; index + i * _step < _size; i++)
            {
                if (_data[index + i * _step] == null || _data[index + i * _step].IsDeleted)
                {
                    _data[index + i * _step] = personModel;
                    _count++;
                    return;
                }
            }

            Console.WriteLine("Таблица переполнена");
        }

        public void Delete(PersonModel personModel)
        {
            int index = GetIndex(personModel);

            for (int i = 0; index + i * _step < _size; i++)
            {
                if (_data[index + i * _step] != null &&
                    _data[index + i * _step].Age == personModel.Age &&
                    _data[index + i * _step].Name == personModel.Name &&
                    !_data[index + i * _step].IsDeleted)
                {
                    _data[index + i * _step].IsDeleted = true;
                    _count--;
                    return;
                }
            }
        }

        public bool Find(PersonModel personModel)
        {
            int index = GetIndex(personModel);

            if (_data[index] == null)
            {
                return false;
            }
            else
            {
                for (int i = 0; index + i * _step < _size; i++)
                {
                    if (_data[index + i * _step] == null)
                    {
                        return false;
                    }
                    if (_data[index + i * _step].Age == personModel.Age &&
                        _data[index + i * _step].Name == personModel.Name &&
                        !_data[index + i * _step].IsDeleted)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        private void Resize()
        {
            Console.WriteLine("rehesh");
            int newSize = _size * 2; // Удваиваем размер таблицы при рехэшировании
            var newData = new PersonModel[newSize];

            foreach (var element in _data)
            {
                if (element != null && !element.IsDeleted)
                {
                    int newIndex = GetIndex(element, newSize); // Пересчитываем хэш для нового размера таблицы
                    int i = 0;
                    while (newData[newIndex + i * _step] != null)
                    {
                        i++;
                    }
                    newData[newIndex + i * _step] = element;
                }
            }

            _data = newData;
            _size = newSize;
        }

        private int GetIndex(PersonModel personModel, int size)
            => (personModel.Age * personModel.Age + personModel.Name.Length * personModel.Name.Length + personModel.Age * personModel.Name.Length) % size;

        private int GetIndex(PersonModel personModel)
            => GetIndex(personModel, _size);
    }
}
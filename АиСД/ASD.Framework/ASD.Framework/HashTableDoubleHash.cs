using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD.Framework
{
    public class HashTableDoubleHash
    {
        private int _size;
        private PersonModel[] _data;
        private int _count;

        public HashTableDoubleHash(int size)
        {
            _size = size;
            _data = new PersonModel[_size];
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
            if (_count >= _size * 0.7)
            {
                Rehash();
            }

            int index = GetIndex(personModel);

            if (_data[index] == null || _data[index].IsDeleted)
            {
                _data[index] = personModel;
                _count++;
                return;
            }

            for (int i = 0; i < _size; i++)
            {
                index = HelperHash(personModel, i);
                if (_data[index] == null || _data[index].IsDeleted)
                {
                    _data[index] = personModel;
                    _count++;
                    return;
                }
            }

            Console.WriteLine("Таблица переполнена");
        }

        public void Delete(PersonModel personModel)
        {
            for (int i = 0; i < _size; i++)
            {
                int index = HelperHash(personModel, i);
                if (_data[index] != null && _data[index].Age == personModel.Age && _data[index].Name == personModel.Name && !_data[index].IsDeleted)
                {
                    _data[index].IsDeleted = true;
                    _count--;
                    return;
                }
            }
        }

        public bool Find(PersonModel personModel)
        {
            for (int i = 0; i < _size; i++)
            {
                int index = HelperHash(personModel, i);
                if (_data[index] == null)
                {
                    return false;
                }
                if (_data[index].Age == personModel.Age && _data[index].Name == personModel.Name && !_data[index].IsDeleted)
                {
                    return true;
                }
            }

            return false;
        }

        private int GetIndex(PersonModel personModel)
            => (personModel.Age * personModel.Age + personModel.Name.Length * personModel.Name.Length + personModel.Age * personModel.Name.Length) % _size;

        private int HelperHash(PersonModel personModel, int step)
            => (GetIndex(personModel) + step * personModel.Age * personModel.Name.Length) % _size;

        private void Rehash()
        {
            int newSize = _size * 2;
            PersonModel[] newData = new PersonModel[newSize];

            foreach (var item in _data)
            {
                if (item != null && !item.IsDeleted)
                {
                    int index = (item.Age * item.Age + item.Name.Length * item.Name.Length + item.Age * item.Name.Length) % newSize;
                    if (newData[index] == null)
                    {
                        newData[index] = item;
                    }
                    else
                    {
                        for (int i = 0; i < newSize; i++)
                        {
                            index = (GetIndex(item) + i * item.Age * item.Name.Length) % newSize;
                            if (newData[index] == null)
                            {
                                newData[index] = item;
                                break;
                            }
                        }
                    }
                }
            }

            _size = newSize;
            _data = newData;
        }
    }
}
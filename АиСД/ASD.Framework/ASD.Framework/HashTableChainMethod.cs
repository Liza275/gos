using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD.Framework
{
    public class HashTableChainMethod
    {
        private int _size;
        private List<PersonModel>[] _data;
        private int _count;

        public HashTableChainMethod(int size)
        {
            _size = size;
            _data = new List<PersonModel>[_size];
            _count = 0;
        }

        public void Print()
        {
            int i = 1;
            foreach (var element in _data)
            {
                if (element == null)
                {
                    Console.WriteLine($"Элемент {i} - null");
                }
                else
                {
                    Console.Write($"Элемент {i} -");
                    foreach (var item in element)
                    {
                        Console.Write($"| {item.Name} {item.Age} |");
                    }
                    Console.WriteLine();
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

            if (_data[index] == null)
            {
                _data[index] = new List<PersonModel> { personModel };
            }
            else
            {
                _data[index].Add(personModel);
            }

            _count++;
        }

        public void Delete(PersonModel personModel)
        {
            int index = GetIndex(personModel);

            if (_data[index] != null)
            {
                var itemToRemove = _data[index].Find(item => item.Age == personModel.Age && item.Name == personModel.Name);
                if (itemToRemove != null)
                {
                    _data[index].Remove(itemToRemove);
                    if (_data[index].Count == 0)
                    {
                        _data[index] = null;
                    }
                    _count--;
                }
            }
        }

        public bool Find(PersonModel personModel)
        {
            int index = GetIndex(personModel);

            return _data[index] != null && _data[index].Any(item => item.Age == personModel.Age && item.Name == personModel.Name);
        }

        private int GetIndex(PersonModel personModel)
            => (personModel.Age * personModel.Age + personModel.Name.Length * personModel.Name.Length + personModel.Age * personModel.Name.Length) % _size;

        private void Rehash()
        {
            int newSize = _size * 2;
            var newData = new List<PersonModel>[newSize];

            foreach (var chain in _data)
            {
                if (chain != null)
                {
                    foreach (var person in chain)
                    {
                        int newIndex = GetIndex(person, newSize);
                        if (newData[newIndex] == null)
                        {
                            newData[newIndex] = new List<PersonModel>();
                        }
                        newData[newIndex].Add(person);
                    }
                }
            }

            _data = newData;
            _size = newSize;
        }

        private int GetIndex(PersonModel personModel, int size)
            => (personModel.Age * personModel.Age + personModel.Name.Length * personModel.Name.Length + personModel.Age * personModel.Name.Length) % size;
    }
}

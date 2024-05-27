using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD.Framework
{
    public class GrafList
    {
        // Список смежности, представляющий граф
        private Dictionary<User, List<User>> adjList;

        // Конструктор для инициализации графа
        public GrafList()
        {
            adjList = new Dictionary<User, List<User>>();
        }

        // Метод для добавления новой вершины в граф
        public void AddVertex(User user)
        {
            if (!adjList.ContainsKey(user)) // Проверка, существует ли уже вершина в графе
            {
                adjList[user] = new List<User>(); // Добавление новой вершины
            }
        }

        // Метод для добавления ребра между двумя вершинами
        public void AddEdge(User user1, User user2)
        {
            if (adjList.ContainsKey(user1) && adjList.ContainsKey(user2)) // Проверка, существуют ли обе вершины
            {
                adjList[user1].Add(user2); // Добавление user2 в список смежности user1
                adjList[user2].Add(user1); // Добавление user1 в список смежности user2
            }
        }

        // Метод для вывода матрицы смежности
        public void PrintAdjacencyMatrix()
        {
            //var users = new List<User>(adjList.Keys); // Получение всех вершин
            //int n = users.Count; // Количество вершин
            //int[,] matrix = new int[n, n]; // Инициализация матрицы смежности

            //// Заполнение матрицы смежности
            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < n; j++)
            //    {
            //        if (adjList[users[i]].Contains(users[j])) // Проверка, существует ли ребро между вершинами
            //        {
            //            matrix[i, j] = 1; // Установка 1, если существует ребро
            //        }
            //        else
            //        {
            //            matrix[i, j] = 0; // Установка 0, если ребра нет
            //        }
            //    }
            //}

            //// Вывод заголовка матрицы смежности
            //Console.Write("  ");
            //foreach (var user in users)
            //{
            //    Console.Write($"{user.Id} ");
            //}
            //Console.WriteLine();

            //// Вывод содержимого матрицы смежности
            //for (int i = 0; i < n; i++)
            //{
            //    Console.Write($"{users[i].Id} ");
            //    for (int j = 0; j < n; j++)
            //    {
            //        Console.Write($"{matrix[i, j]} ");
            //    }
            //    Console.WriteLine();
            //}

            foreach (var key in adjList.Keys)
            {
                Console.Write(key.Name + " -> ");
                Console.WriteLine(string.Join(",", adjList[key].Select(x => x.Name)));
            }
        }

        // Метод для обхода графа в ширину
        public void BFS(User start)
        {
            var visited = new HashSet<User>(); // Множество для отслеживания посещенных вершин
            var queue = new Queue<User>(); // Очередь для обхода в ширину

            visited.Add(start); // Помечаем стартовую вершину как посещенную
            queue.Enqueue(start); // Добавляем стартовую вершину в очередь

            while (queue.Count > 0) // Пока очередь не пуста
            {
                var user = queue.Dequeue(); // Извлекаем вершину из очереди
                Console.WriteLine(user.Name); // Выводим вершину

                foreach (var neighbor in adjList[user]) // Проходим по всем соседям текущей вершины
                {
                    if (!visited.Contains(neighbor)) // Если соседняя вершина не посещена
                    {
                        visited.Add(neighbor); // Помечаем ее как посещенную
                        queue.Enqueue(neighbor); // Добавляем в очередь
                    }
                }
            }
        }

        // Метод для обхода графа в глубину
        public void DFS(User start)
        {
            var visited = new HashSet<User>(); // Множество для отслеживания посещенных вершин
            var stack = new Stack<User>(); // Стек для обхода в глубину

            stack.Push(start); // Добавляем стартовую вершину в стек

            while (stack.Count > 0) // Пока стек не пуст
            {
                var user = stack.Pop(); // Извлекаем вершину из стека

                if (!visited.Contains(user)) // Если вершина не посещена
                {
                    visited.Add(user); // Помечаем ее как посещенную
                    Console.WriteLine(user.Name); // Выводим вершину

                    foreach (var neighbor in adjList[user]) // Проходим по всем соседям текущей вершины
                    {
                        if (!visited.Contains(neighbor)) // Если соседняя вершина не посещена
                        {
                            stack.Push(neighbor); // Добавляем в стек
                        }
                    }
                }
            }
        }
    }
}

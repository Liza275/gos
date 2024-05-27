using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD.Framework
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public User(int id, string name, bool status)
        {
            Id = id;
            Name = name;
            Status = status;
        }
    }

    public class GrafMatrix
    {
        private List<User> users;       // Список пользователей (вершин графа)
        private int[,] adjacencyMatrix; // Матрица смежности
        private int size;               // Максимальный размер графа

        // Конструктор для создания графа с заданным размером
        public GrafMatrix(int size)
        {
            this.size = size;                          // Устанавливаем максимальный размер
            users = new List<User>();                  // Инициализируем список пользователей
            adjacencyMatrix = new int[size, size];     // Инициализируем матрицу смежности
        }

        // Метод для добавления нового пользователя (вершины) в граф
        public void AddUser(User user)
        {
            // Проверяем, что граф не переполнен
            if (users.Count >= size)
            {
                Console.WriteLine("Graph is full. Cannot add more users.");
                return;
            }
            users.Add(user); // Добавляем пользователя в список
        }

        // Метод для добавления связи между двумя пользователями (ребра)
        public void AddEdge(int userId1, int userId2)
        {
            // Находим индексы пользователей в списке
            int index1 = users.FindIndex(u => u.Id == userId1);
            int index2 = users.FindIndex(u => u.Id == userId2);

            // Проверяем, что оба пользователя найдены
            if (index1 == -1 || index2 == -1)
            {
                Console.WriteLine("One or both users not found.");
                return;
            }

            // Устанавливаем связь в матрице смежности
            adjacencyMatrix[index1, index2] = 1;
            adjacencyMatrix[index2, index1] = 1; // Предполагаем неориентированный граф
        }

        // Метод для вывода матрицы смежности
        public void PrintAdjacencyMatrix()
        {
            for (int i = 0; i < users.Count; i++)
            {
                for (int j = 0; j < users.Count; j++)
                {
                    // Выводим значение текущей ячейки матрицы
                    Console.Write(adjacencyMatrix[i, j] + " ");
                }
                Console.WriteLine(); // Переход на новую строку
            }
        }

        // Алгоритм обхода графа в ширину (BFS)
        public void BFS(int startUserId)
        {
            // Находим индекс начального пользователя
            int startIndex = users.FindIndex(u => u.Id == startUserId);
            if (startIndex == -1)
            {
                Console.WriteLine("Start user not found.");
                return;
            }

            bool[] visited = new bool[size];    // Массив для отслеживания посещенных вершин
            Queue<int> queue = new Queue<int>(); // Очередь для BFS

            visited[startIndex] = true;         // Отмечаем начального пользователя как посещенного
            queue.Enqueue(startIndex);          // Добавляем начального пользователя в очередь

            while (queue.Count > 0)
            {
                int userIndex = queue.Dequeue(); // Извлекаем пользователя из очереди
                Console.WriteLine(users[userIndex].Name); // Выводим имя пользователя

                for (int i = 0; i < size; i++)
                {
                    // Если существует связь и вершина не посещена
                    if (adjacencyMatrix[userIndex, i] == 1 && !visited[i])
                    {
                        visited[i] = true;   // Отмечаем вершину как посещенную
                        queue.Enqueue(i);    // Добавляем вершину в очередь
                    }
                }
            }
        }

        // Алгоритм обхода графа в глубину (DFS)
        public void DFS(int startUserId)
        {
            // Находим индекс начального пользователя
            int startIndex = users.FindIndex(u => u.Id == startUserId);
            if (startIndex == -1)
            {
                Console.WriteLine("Start user not found.");
                return;
            }

            bool[] visited = new bool[size]; // Массив для отслеживания посещенных вершин
            Stack<int> stack = new Stack<int>(); // Стек для DFS

            stack.Push(startIndex); // Добавляем начального пользователя в стек

            while (stack.Count > 0)
            {
                int userIndex = stack.Pop(); // Извлекаем пользователя из стека

                if (!visited[userIndex]) // Если вершина еще не была посещена
                {
                    visited[userIndex] = true; // Отмечаем вершину как посещенную
                    Console.WriteLine(users[userIndex].Name); // Выводим имя пользователя

                    for (int i = 0; i < size; i++)
                    {
                        // Если существует связь и вершина не посещена
                        if (adjacencyMatrix[userIndex, i] == 1 && !visited[i])
                        {
                            stack.Push(i); // Добавляем вершину в стек
                        }
                    }
                }
            }
        }
    }
}

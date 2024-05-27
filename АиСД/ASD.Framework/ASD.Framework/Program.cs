using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD.Framework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Sorts

            //Sorts sorts = new Sorts();
            //var array = sorts.FillArray(20);
            //sorts.PrintArray(array);

            //sorts.QuickSort(array, 0,  array.Length-1);

            //sorts.PrintArray(array);

            #endregion

            #region HashTables

            //var hashTable = new HashTableLineProbing(10, 1);
            ////var hashTable = new HashTableChainMethod(10);
            //for (int i = 1; i < 10; i++)
            //{
            //    hashTable.Insert(new PersonModel { Age = i, Name = "Ян" });
            //}

            //hashTable.Delete(new PersonModel { Age = 3, Name = "Ян" });
            //hashTable.Insert(new PersonModel { Age = 55, Name = "Ян" });
            //hashTable.Print();


            //for (int i = 1; i < 20; i++)
            //{
            //    var model = new PersonModel { Age = i, Name = "Ян" };
            //    Console.WriteLine($"Поиск элемента {model.Name} - {model.Age} : {hashTable.Find(model)}");
            //}

            #endregion

            #region Trees

            //var tree = new BinaryTree();
            //var random = new Random();

            //for (int i = 0; i < 20; i++)
            //{
            //    tree.Add(random.Next(0, 100));
            //}

            //tree.Add(20);
            //tree.Remove(20);
            //tree.Remove(20);

            //tree.Print();

            #endregion

            #region DoubleLinked list

            //var list = new DoubleLinkedList();
            //var random = new Random();
            //for (int i = 0; i < 10; i++)
            //{
            //    list.Add(random.Next(0, 2));
            //}

            //list.Print();
            //list.Add(101);
            //list.Print();
            //list.Remove(1000);
            //list.Print();
            //list.Remove(1);
            //list.Print();

            #endregion

            #region Graf matrix

            //// Создаем граф с максимальным размером 5
            //GrafMatrix graph = new GrafMatrix(5);

            //// Создаем пользователей
            //User user1 = new User(1, "Alice", true);
            //User user2 = new User(2, "Bob", true);
            //User user3 = new User(3, "Charlie", true);
            //User user4 = new User(4, "David", true);
            //User user5 = new User(5, "Eve", true);

            //// Добавляем пользователей в граф
            //graph.AddUser(user1);
            //graph.AddUser(user2);
            //graph.AddUser(user3);
            //graph.AddUser(user4);
            //graph.AddUser(user5);

            //// Добавляем связи между пользователями
            //graph.AddEdge(1, 2);
            //graph.AddEdge(1, 3);
            //graph.AddEdge(2, 4);
            //graph.AddEdge(3, 5);

            //// Выводим матрицу смежности
            //Console.WriteLine("Adjacency Matrix:");
            //graph.PrintAdjacencyMatrix();

            //// Выполняем обход графа в ширину начиная с пользователя Alice
            //Console.WriteLine("BFS from Alice:");
            //graph.BFS(1);

            //// Выполняем обход графа в глубину начиная с пользователя Alice
            //Console.WriteLine("DFS from Alice:");
            //graph.DFS(1);

            #endregion

            #region Graf list

            //// Создаем пользователей
            var user1 = new User(1, "Alice", true);
            var user2 = new User(2, "Bob", true);
            var user3 = new User(3, "Charlie", false);
            var user4 = new User(4, "David", true);
            var user5 = new User(5, "Eve", true);
            var user6 = new User(6, "Frank", true);
            var user7 = new User(7, "Groove", true);
            var user8 = new User(8, "Hovarg", true);

            var graph = new GrafList(); // Создаем граф

            // Добавляем вершины в граф
            graph.AddVertex(user1);
            graph.AddVertex(user2);
            graph.AddVertex(user3);
            graph.AddVertex(user4);
            graph.AddVertex(user5);
            graph.AddVertex(user6);
            graph.AddVertex(user7);
            graph.AddVertex(user8);

            // Добавляем ребра между вершинами
            graph.AddEdge(user1, user2);
            graph.AddEdge(user1, user3);
            graph.AddEdge(user2, user4);
            graph.AddEdge(user2, user7);
            graph.AddEdge(user4, user6);
            graph.AddEdge(user4, user5);
            graph.AddEdge(user3, user8);

            // Вывод матрицы смежности
            Console.WriteLine("Adjacency Matrix:");
            graph.PrintAdjacencyMatrix();

            // Обход в ширину начиная с Alice
            Console.WriteLine("\nBFS starting from Alice:");
            graph.BFS(user1);

            // Обход в глубину начиная с Alice
            Console.WriteLine("\nDFS starting from Alice:");
            graph.DFS(user1);

            #endregion

            #region Circle list

            //CircleList list = new CircleList();

            //list.Add(new User(1, "Alice", true));
            //list.Add(new User(2, "Bob", false));
            //list.Add(new User(3, "Charlie", true));
            //list.Add(new User(4, "David", true));
            //list.Add(new User(5, "Eve", true));

            //Console.WriteLine("Initial list:");
            //list.PrintList();

            //Console.WriteLine("\nRemoving user with Id 2:");
            //list.Remove(2);
            //list.PrintList();

            //Console.WriteLine("\nRemoving user with Id 1:");
            //list.Remove(1);
            //list.PrintList();

            #endregion

            Console.ReadKey();
        }
    }
}

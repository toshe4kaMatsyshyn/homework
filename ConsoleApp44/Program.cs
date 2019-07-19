using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp44
{
    class Program
    {
        /// <summary>
        /// Массив содержит цену проезда между станциями
        /// </summary>
        static int[,] cost;
        /// <summary>
        /// Массив для восстановления пути
        /// </summary>
        static int[] way;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            CostData(n);
            Console.WriteLine(CheapestWay());
            Console.WriteLine(RestoreTheWay());
            Console.ReadKey();
        }
        /// <summary>
        /// Функция создает массив стоимостей
        /// </summary>
        /// <param name="n"></param>
        static void CostData(int n)
        {
            Random random = new Random();
            cost = new int[n+1, n + 1];
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (j >= i + 1)
                        cost[i, j] = random.Next(20);
                    else
                        cost[i, j] = int.MaxValue;
                }
            }
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if(cost[i,j]!=int.MaxValue)
                    Console.Write(cost?[i,j]+"\t");
                    else Console.Write("null\t");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Находим стоимость кратчайшего пути
        /// </summary>
        /// <returns></returns>
        static int CheapestWay()
        {
            way = new int[cost.GetLength(0)];

            int[] minCost = new int[cost.GetLength(0)];
            for(int i=0; i<minCost.Length; i++)
            {
                minCost[i] = int.MaxValue;
            }
            minCost[0] = 0;
            for(int i = 1; i<minCost.Length;i++)
            {
                  for(int j = 0; j<i;j++)
                  {
                    if(minCost[i]> minCost[j] + cost[j,i])
                    {
                        minCost[i] = minCost[j] + cost[j,i];
                        way[i] = j;
                    }
                  } 
            }
            return minCost[minCost.Length-1];
        }
        /// <summary>
        /// Восстанавливаем кратчайший путь
        /// </summary>
        /// <returns></returns>
        static string RestoreTheWay()
        {
            int i = way.Length - 1;
            List<string> finalway_ = new List<string>();
            finalway_.Add(i.ToString());
            while (i != 0)
            {
                i = way[i];
                finalway_.Add(i.ToString());
            }
            string finalWay = "";
            for (int j = finalway_.Count - 1; j >= 0; j--)
                finalWay += finalway_[j] + "\t";
            return finalWay;
        }
    }
}

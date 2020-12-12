using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] mapLines = File.ReadAllLines("map.txt");

            char[,] map = new char[mapLines[0].Length, mapLines.Length];
            CreateMap(mapLines, map);

            //int moveX = 3;
            //int moveY = 1;
            //int treeHits = 0;
            List<int> treeHits = new List<int>();
            int hitTrees = RunFlight(mapLines, map, 1, 1, treeHits);
            Console.WriteLine($"Antal trädträffar: {hitTrees}");

            hitTrees = RunFlight(mapLines, map, 3, 1, treeHits);
            Console.WriteLine($"Antal trädträffar: {hitTrees}");

            hitTrees = RunFlight(mapLines, map, 5, 1, treeHits);
            Console.WriteLine($"Antal trädträffar: {hitTrees}");

            hitTrees = RunFlight(mapLines, map, 7, 1, treeHits);
            Console.WriteLine($"Antal trädträffar: {hitTrees}");

            hitTrees = RunFlight(mapLines, map, 1, 2, treeHits);
            Console.WriteLine($"Antal trädträffar: {hitTrees}");

            long multiplyHits = 1;

            foreach (int hits in treeHits)
            {
                multiplyHits *= hits;
            }

            Console.WriteLine($"Svaret är {multiplyHits}");
        }

        private static void CreateMap(string[] mapLines, char[,] map)
        {
            for (int i = 0; i < mapLines.Length; i++)
            {
                char[] charsInLane = mapLines[i].ToCharArray();
                {
                    for (int j = 0; j < charsInLane.Length; j++)
                    {
                        map[j, i] = charsInLane[j];
                        //Console.Write(charsInLane[j]);
                    }
                    //Console.WriteLine();
                }
            }
        }

        private static int RunFlight(string[] mapLines, char[,] map, int moveX, int moveY, List<int> treeHits)
        {
            int xPos = 0;
            int yPos = 0;
            int hits = 0;
            while (yPos < mapLines.Length + 1 - moveY)
            {
                if (map[xPos, yPos] == '#')
                    hits++;
                
                xPos = MoveXPos(mapLines[0].Length, xPos, moveX);
                yPos = MoveYPos(yPos, moveY);
            }
            treeHits.Add(hits);
            return hits;
        }

        private static int MoveYPos(int yPos, int moveY)
        {
            return yPos + moveY;
        }

        private static int MoveXPos(int lineLength, int xPos, int moveX)
        {
            if (xPos < lineLength - moveX)
                xPos += moveX;
            else
                xPos = moveX - 1 - (lineLength - 1 - xPos);

            return xPos;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Feb2018ExamCsharpAdvanced
{
    class KeyRollOver
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            int[] bullets = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var locks = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int intelligenceValue = int.Parse(Console.ReadLine());

            Stack<int> bulletStack = new Stack<int>();
            Queue<int> lockQueue = new Queue<int>();

            FillStack(bullets, bulletStack);
            FillQueue(locks, lockQueue);
            int currentGunBarrel = gunBarrelSize;
            int usedBullets = 0;
            while (true)
            {
                if (currentGunBarrel == 0 && bulletStack.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    currentGunBarrel = gunBarrelSize;
                }
                if (bulletStack.Count == 0 || lockQueue.Count == 0)
                {
                    break;
                }
                int currentBullet = bulletStack.Pop();
                currentGunBarrel--;
                usedBullets++;
                int currentLock = lockQueue.Peek();
                if (currentBullet <= currentLock)
                {
                    lockQueue.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
            }
            if (lockQueue.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {lockQueue.Count}");
            }
            else
            {
                int earned = intelligenceValue - (usedBullets * bulletPrice);
                Console.WriteLine($"{bulletStack.Count} bullets left. Earned ${earned}");
            }

        }

        private static void FillQueue(List<int> locks, Queue<int> lockQueue)
        {
            foreach (var lo in locks)
            {
                lockQueue.Enqueue(lo);
            }
        }

        private static void FillStack(int[] bullets, Stack<int> bulletStack)
        {
            foreach (var bullet in bullets)
            {
                bulletStack.Push(bullet);
            }
        }
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics.Eventing.Reader;

class Program
{
    static void Main(string[] args)
    {
        string playerName;
        Console.WriteLine("Проснитесь! Как ваше имя?");
        playerName = Console.ReadLine();

        bool gotFirstArtifact = false;
        bool gotSecondArtifact = false;
        bool gotThirdArtifact = false;
        bool gotKey = false;
        bool gotLockpick = false;

        int ventAttempts = 0;

        while (true)
        {
            Console.WriteLine($"\n{playerName}, что вы хотите сделать?");
            Console.WriteLine("1. Открыть дверь");
            Console.WriteLine("2. Заглянуть под кровать");
            Console.WriteLine("3. Открыть ящик");
            Console.WriteLine("4. Открыть вентиляцию");
            Console.WriteLine("5. Взглянуть на тумбочку");
            Console.WriteLine("6. Взглянуть на статую");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    if (gotLockpick)
                    {
                        Console.WriteLine($"{playerName}, вы успешно использовали отмычку и открыли дверь. Побег удался!");
                    }
                    else
                    {
                        Console.WriteLine("Дверь заперта, нужно найти способ её открыть.");
                    }
                    break;

                case "2":
                    if (!gotFirstArtifact)
                    {
                        Console.WriteLine($"{playerName}, вы нашли первый артефакт под кроватью!");
                        gotFirstArtifact = true;
                    }
                    else
                    {
                        Console.WriteLine($"{playerName}, под кроватью больше ничего нет.");
                    }
                    break;

                case "3":
                    if (gotKey)
                    {
                        if (!gotLockpick)
                        {
                            Console.WriteLine($"{playerName}, вы открыли ящик и нашли отмычку!");
                            gotLockpick = true;
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, ящик уже пуст.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{playerName}, ящик заперт. Нужно найти ключ.");
                    }
                    break;

                case "4":
                    ventAttempts++;
                    if (ventAttempts >= 3)
                    {
                        if (!gotSecondArtifact)
                        {
                            Console.WriteLine($"{playerName}, после нескольких попыток вы открыли вентиляцию и нашли второй артефакт!");
                            gotSecondArtifact = true;
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, в вентиляции больше ничего нет.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{playerName}, вентиляция не открывается. Попробуйте ещё раз.");
                    }
                    break;

                case "5":
                    if (!gotThirdArtifact)
                    {
                        Console.WriteLine($"{playerName}, на тумбочке лежит третий артефакт.");
                        gotThirdArtifact = true;
                    }
                    else
                    {
                        Console.WriteLine($"{playerName}, на тумбочке больше ничего нет.");
                    }
                    break;

                case "6":
                    if (gotFirstArtifact && gotSecondArtifact && gotThirdArtifact)
                    {
                        if (!gotKey)
                        {
                            Console.WriteLine($"{playerName}, статуя активирована! Вы получили ключ от ящика.");
                            gotKey = true;
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, статуя уже активирована.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{playerName}, для активации статуи нужны три артефакта.");
                    }
                    break;

                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}
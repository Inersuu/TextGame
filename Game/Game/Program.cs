using System;
using System.Text;
using System.Threading;
using System;

class Program
{
    static void Main(string[] args)
    {
        bool game = false;
        Foodetc food = new Foodetc();
        Time time = new Time();
        Inventory inventory = new Inventory();
        Store store = new Store();
        Upgrade upgrade = new Upgrade();
        while (game == false)
        {
            Console.WriteLine("1 -- Начать игру");
            Console.WriteLine("2 -- Загрузить игру (в разработке)");
            Console.WriteLine("3 -- Выйти из игры");
            int input = Convert.ToInt32(Console.ReadLine());
            switch(input)
            {
                case 1:
                    game = true;
                    break;
                case 2:
                    Console.WriteLine("Ещё в разработке");
                    break;
                case 3:
                    Console.WriteLine("Вы вышли из игры.");
                    Environment.Exit(0);
                    Console.ReadKey();
                    break;
            }
        }
        
        

        Console.WriteLine("Игра началась!");

        while (true)
        {
            food.CheckStats();
            Console.WriteLine($"\nХП - {food.HP}  Голод - {food.Hunger}  Жажда - {food.Thirst}  Золото - {inventory.Gold}");
            Console.WriteLine("\nЧто вы хотите сделать?");
            Console.WriteLine("1 -- Осмотреться");
            Console.WriteLine("2 -- Поесть/Попить (в инвентаре)");
            Console.WriteLine("3 -- Магазин");
            Console.WriteLine("4 -- Показать инвентарь");
            Console.WriteLine("5 -- Улучшения");
            Console.WriteLine("6 -- Показать характеристики");
            Console.WriteLine("7 -- Спать");
            Console.WriteLine("8 -- Выйти из игры");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.Clear(); // Очищаем консоль

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Вы осмотрелись.");
                    time.AddHour();  // Добавляем 1 час

                    // Обновляем только при осмотре местности
                    food.UpdateStats();

                    // Шанс встречи с мобом
                    if (MobEncounter.TryEncounterMob())
                    {
                        Mob mob = MobEncounter.GenerateRandomMob();
                        Console.WriteLine($"Вы встретили {mob.Name} с {mob.HP} HP.");
                        
                        // Цикл боя с мобом
                        bool battleOver = false;
                        while (!battleOver)
                        {
                            Console.WriteLine("\nЧто вы хотите сделать?");
                            Console.WriteLine("1 -- Атаковать");
                            Console.WriteLine("2 -- Отхилиться (в будущем)");
                            Console.WriteLine("3 -- Убежать");

                            int mobChoice = Convert.ToInt32(Console.ReadLine());
                            Console.Clear(); // Очищаем консоль после выбора
                            switch (mobChoice)
                            {
                                case 1:
                                    Console.Clear(); // Очищаем консоль после выбора
                                    Console.WriteLine("Вы решили атаковать моба!");
                                    mob.Attack(food, inventory);
                                    Console.WriteLine("Вы атакуете моба!");
                                    mob.TakeDamage(inventory.GetWeaponDamage());  // Урон от игрока

                                    if (mob.HP <= 0)
                                    {
                                        Console.WriteLine($"{mob.Name} был побежден!");

                                        // Генерация награды за убийство моба
                                        int reward = new Random().Next(30, 101);
                                        int xpl = new Random().Next(20, 71);
                                        inventory.Gold += reward;
                                        inventory.XP += xpl;
                                        Console.WriteLine($"Вы получили {reward} золота.");
                                        Console.WriteLine($"Вы получили {xpl} опыта.");

                                        battleOver = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{mob.Name} все еще жив.");
                                    }
                                    break;

                                case 2:
                                    Console.WriteLine("Этот вариант пока недоступен.");
                                    break;

                                case 3:
                                    Console.WriteLine("Вы решили убежать!");
                                    if (new Random().Next(1, 101) <= 50) // Шанс убежать 50%
                                    {
                                        Console.WriteLine("Вам удалось сбежать!");
                                        battleOver = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Не удалось сбежать, моб атакует!");
                                        mob.Attack(food, inventory);
                                    }
                                    break;

                                default:
                                    Console.WriteLine("Неверный выбор. Моб атакует!");
                                    mob.Attack(food, inventory);
                                    break;
                            }

                            // Проверка, не умер ли игрок во время боя
                            if (food.HP <= 0)
                            {
                                Console.WriteLine("Ваш персонаж умер. Игра окончена.");
                                return;
                            }
                        }
                    }
                    break;

                case 2:
                    inventory.UseItem(food);  // Использование еды и воды из инвентаря
                    break;

                case 3:
                    store.DisplayItems(inventory);  // Магазин (теперь еда и вода не тратятся при покупках)
                    break;

                case 4:
                    inventory.ShowInventory();  // Показываем инвентарь
                    break;

                case 5:
                    upgrade.UpgradeArmor(inventory);  // Улучшения
                    break;

                case 6:
                    inventory.ShowEquipment();  // Показываем снаряжение
                    break;

                case 7:
                    time.NextDay();  // Завершить день и сбросить время до 8:00
                    Console.WriteLine("Вы заснули. Новый день начался.");
                    break;

                case 8:
                    Console.WriteLine("Вы вышли из игры.");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Неверный выбор, попробуйте снова.");
                    break;
            }
            // Проверяем, не закончилась ли игра
            if (food.HP <= 0)
            {
                Console.WriteLine("Ваш персонаж умер. Игра окончена.");
                break;
            }

            // Проверяем, если время достигло 0:00, автоматически переходит на следующий день
            if (time.IsMidnight())
            {
                Console.WriteLine("День завершен. Время сброшено до 8:00.");
                time.NextDay();  // Сбросить время до 8:00
            }
        }
    }
}
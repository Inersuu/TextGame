using System;

public class Store
{
    public void DisplayItems(Inventory inventory)
    {
        Console.WriteLine("Добро пожаловать в магазин! Вот что у нас есть:");
        Console.WriteLine("1. Вода - 10 золота");
        Console.WriteLine("2. Еда - 15 золота");
        Console.WriteLine("3. Целебное зелье - 20 золота");
        Console.WriteLine("4. Меч - 50 золота");
        Console.WriteLine("5. Броня - 75 золота");
        Console.WriteLine("6. Выйти из магазина");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                if (inventory.Gold >= 10)
                {
                    inventory.AddItem("Вода");
                    inventory.Gold -= 10;
                    Console.WriteLine("Вы купили Воду.");
                }
                else
                {
                    Console.WriteLine("Недостаточно золота.");
                }
                break;
            case 2:
                if (inventory.Gold >= 15)
                {
                    inventory.AddItem("Еда");
                    inventory.Gold -= 15;
                    Console.WriteLine("Вы купили Еду.");
                }
                else
                {
                    Console.WriteLine("Недостаточно золота.");
                }
                break;
            case 3:
                if (inventory.Gold >= 20)
                {
                    inventory.AddItem("Целебное зелье");
                    inventory.Gold -= 20;
                    Console.WriteLine("Вы купили Целебное зелье.");
                }
                else
                {
                    Console.WriteLine("Недостаточно золота.");
                }
                break;
            case 4:
                if (inventory.Gold >= 50)
                {
                    inventory.EquipWeapon("Ржавый Бронзовый Меч");
                    inventory.Gold -= 50;
                    Console.WriteLine("Вы купили Меч.");
                }
                else
                {
                    Console.WriteLine("Недостаточно золота.");
                }
                break;
            case 5:
                if (inventory.Gold >= 75)
                {
                    inventory.EquipArmor("Ржавая Медная Броня");
                    inventory.Gold -= 75;
                    Console.WriteLine("Вы купили Броню.");
                }
                else
                {
                    Console.WriteLine("Недостаточно золота.");
                }
                break;
            case 6:
                Console.WriteLine("Вы вышли из магазина.");
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                break;
        }
    }
}
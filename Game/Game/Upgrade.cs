using System;

public class Upgrade
{
    public void UpgradeArmor(Inventory inventory)
    {
        Console.WriteLine("1 -- Улучшить броню -- 75 золота\n2 -- Улучшить меч -- 50 золота");
        int choice = Convert.ToInt32(Console.ReadLine());
        

        switch (choice)
        {
            case 1:
                if (inventory.Gold >= 75 & inventory.EquippedArmor  == "Ржавая Медная Броня")
                {   
                    inventory.EquipArmor("Потрёпанная Медная Броня");
                    inventory.Gold -= 75;
                    Console.WriteLine("Вы Улучшили Броню.");
                    Console.ReadKey();
                    break;
                }
                else if (inventory.Gold >= 75 & inventory.EquippedArmor  == "Потрёпанная Медная Броня")
                {
                    inventory.EquipArmor("Целая Медная Броня");
                    inventory.Gold -= 75;
                    Console.WriteLine("Вы Улучшили Броню.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Недостаточно золота или нет прошлой брони");
                    Console.ReadKey();
                    break;
                }
            case 2:
                if (inventory.Gold >= 50 & inventory.EquippedWeapon == "Ржавый Бронзовый Меч")
                {   
                    inventory.EquipWeapon("Потрёпанный Бронзовый Меч");
                    inventory.Gold -= 50;
                    Console.WriteLine("Вы Улучшили Меч.");
                    Console.ReadKey();
                    break;
                }
                else if (inventory.Gold >= 50 & inventory.EquippedWeapon  == "Потрёпанный Бронзовый Меч")
                {
                    inventory.EquipWeapon("Целый Бронзовый Меч");
                    inventory.Gold -= 50;
                    Console.WriteLine("Вы Улучшили Меч.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Недостаточно золота или нет прошлого меча");
                    Console.ReadKey();
                    break;
                }
            default:
                Console.WriteLine("Неправильная цифра");
                Console.ReadKey();
                break;
        }
        
    }
}
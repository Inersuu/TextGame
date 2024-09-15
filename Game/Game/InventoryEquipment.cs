using System;
using System.Collections.Generic;

public class Inventory
{
    public int Gold { get; set; }
    public int XP { get; set; }
    public int XPLevel { get; set; }
    public List<string> Items { get; set; }
    public string EquippedWeapon { get; set; }
    public string EquippedArmor { get; set; }

    public Inventory()
    {
        Items = new List<string>();
        Gold = 100;  // Начальное количество золота
        XP = 0;
        XPLevel = 1;
    }
    public void check()
    {
        //Atributes atributes = new Atributes();
        if (XP >= 100) XPLevel += 1;
        //atributes.Strength++;
        if (XP >= 100)
        /*{
            int chance = new Random().Next(0, 2);
            if (chance == 1)
            {
                atributes.Strength++;
            }
            else
            {
                atributes.Agility++;
            }
        }*/
        if (XP >= 100) XP -= 100; 
    }

    // Добавить предмет в инвентарь
    public void AddItem(string item)
    {
        Items.Add(item);
    }

    // Вывод инвентаря
    public void ShowInventory()
    {
        Console.WriteLine("Ваш инвентарь:");
        if (Items.Count == 0)
        {
            Console.WriteLine("Инвентарь пуст.");
        }
        else
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Items[i]}");
            }
        }
        
        
    }

    // Использование предметов
    public void UseItem(Foodetc player)
    {
        ShowInventory();
        Console.WriteLine("Выберите предмет для использования:");

        int choice = Convert.ToInt32(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < Items.Count)
        {
            string item = Items[choice];
            if (item == "Вода")
            {
                player.Thirst += 25;
                Items.RemoveAt(choice);
                Console.WriteLine("Вы выпили воду, жажда уменьшена.");
                player.CheckStats();
            }
            else if (item == "Еда")
            {
                player.Hunger += 25;
                Items.RemoveAt(choice);
                Console.WriteLine("Вы съели еду, голод уменьшен.");
                player.CheckStats();
            }
            else if (item == "Целебное зелье")
            {
                player.HP += 40;
                Items.RemoveAt(choice);
                Console.WriteLine("Вы выпили зелье, здоровье увеличено.");
                player.CheckStats();
            }
        }
        else
        {
            Console.WriteLine("Неверный выбор.");
        }
    }

    // Экипировать оружие
    public void EquipWeapon(string weapon)
    {
        EquippedWeapon = weapon;
        Console.WriteLine($"Вы экипировали {weapon}.");
    }

    // Экипировать броню
    public void EquipArmor(string armor)
    {
        EquippedArmor = armor;
        Console.WriteLine($"Вы экипировали {armor}.");
    }

    // Показать текущее снаряжение
    public void ShowEquipment()
    {
        //Atributes atributes = new Atributes();
        //atributes.check();
        check();
        Console.WriteLine($"Текущее оружие: {EquippedWeapon ?? "Нет"}");
        Console.WriteLine($"Текущее урон: {GetWeaponDamage()}");
        Console.WriteLine($"Текущая броня: {EquippedArmor ?? "Нет"}");
        Console.WriteLine($"Текущее защита: {GetDamageReduction()}\n\n");
        Console.WriteLine($"Текущий уровень: {XPLevel}");
        Console.WriteLine($"Текущее количество опыта: {XP}");
        Console.WriteLine($"Опыта до следующего уровня: {100 - XP}\n\n");
        //Console.WriteLine($"Сила: {atributes.Strength}");
        //Console.WriteLine($"Изменение урона от силы: +{atributes.StrengthEff}");
        //Console.WriteLine($"Ловкость: {atributes.Agility}");
        //WriteLine($"Изменение защиты от ловкости: +{atributes.AgilityEff}");
        Console.ReadKey();
    }

    // Получить урон, учитывая броню
    public double GetDamageReduction()
    {
        //Atributes atributes = new Atributes();
        if (EquippedArmor == "Ржавая Медная Броня")
        {
            Console.WriteLine("Броня снижает урон.");
            return 4 /*+ atributes.AgilityEff*/; // Пример уменьшения урона на 4
        }
        if (EquippedArmor == "Потрёпанная Медная Броня")
        {
            Console.WriteLine("Броня снижает урон.");
            return 6 /*+ atributes.AgilityEff*/; // Пример уменьшения урона на 10
        }
        if (EquippedArmor == "Целая Медная Броня")
        {
            Console.WriteLine("Броня снижает урон.");
            return 8 /*+ atributes.AgilityEff*/; // Пример уменьшения урона на 10
        }
        return 0;
    }

    // Получить бонус к атаке
    public double GetWeaponDamage()
    {
        //Atributes atributes = new Atributes();
        if (EquippedWeapon == "Ржавый Бронзовый Меч")
        {
            Console.WriteLine("Меч увеличивает урон.");
            return 10 /*+ atributes.StrengthEff*/; // Пример увеличения урона
        }
        if (EquippedWeapon == "Потрёпанный Бронзовый Меч")
        {
            Console.WriteLine("Меч увеличивает урон.");
            return 15 /*+ atributes.StrengthEff*/; // Пример увеличения урона
        }
        if (EquippedWeapon == "Целый Бронзовый Меч")
        {
            Console.WriteLine("Меч увеличивает урон.");
            return 20 /*+ atributes.StrengthEff*/; // Пример увеличения урона
        }
        return 500; // Базовый урон
    }
}
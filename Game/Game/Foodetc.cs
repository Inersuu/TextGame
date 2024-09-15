using System;
using System.Dynamic;
using System.Text;
using System.Threading;
public class Foodetc
{
    public double HP { get;  set; }
    public int Hunger { get;  set; }
    public int Thirst { get;  set; }

    public Foodetc()
    {
        HP = 100;
        Hunger = 50;
        Thirst = 50;
    }

    // Метод для обновления голода и жажды только при осмотре или других активных действиях
    public void UpdateStats()
    {
        if (Hunger > 0)
        {
            Hunger -= 5;
        }
        
        
        if (Thirst > 0)
        {
            Thirst -= 5;
        }

        if (Hunger < 0) Hunger = 0;
        if (Thirst < 0) Thirst = 0;

        Console.WriteLine($"Голод: {Hunger}, Жажда: {Thirst}");
    }
    
    // Обновляем только HP в других случаях
    public void UpdateHP()
    {
        if (HP <= 0)
        {
            Console.WriteLine("Вы погибли. Игра окончена.");
            Console.ReadKey();
        }
    }

    // Метод для получения урона
    public void TakeDamage(double damage)
    {
        HP -= damage;
        Console.WriteLine($"Вы получили {damage} урона! Текущие HP: {HP}");
        if (HP <= 0)
        {
            Console.WriteLine("Вы погибли. Игра окончена.");
            Console.ReadKey();
        }
    }
    public void CheckStats()
    {
        if (Thirst > 100) Thirst = 100;
        if (HP > 100) HP = 100;
        if (Hunger > 100) Hunger = 100;
    }
}
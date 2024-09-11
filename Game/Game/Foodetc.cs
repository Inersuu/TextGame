using System;
using System.Dynamic;
using System.Text;
using System.Threading;
public class Foodetc
{
    public int HP { get; private set; }
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
            Hunger -= 10;
        }
        
        if (Thirst > 0)
        {
            Thirst -= 10;
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
        }
    }

    // Метод для получения урона
    public void TakeDamage(int damage)
    {
        HP -= damage;
        Console.WriteLine($"Вы получили {damage} урона! Текущие HP: {HP}");
        if (HP <= 0)
        {
            Console.WriteLine("Вы погибли. Игра окончена.");
        }
    }
}
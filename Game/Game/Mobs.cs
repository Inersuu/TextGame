using System;
using System.Dynamic;
using System.Text;
using System.Threading;
public class Mob
{
    public string Name { get; private set; }
    public int HP { get; private set; }
    public int AttackDamage { get; private set; }

    public Mob(string name, int hp, int damage)
    {
        Name = name;
        HP = hp;
        AttackDamage = damage;
    }

    // Метод атаки моба
    public void Attack(Foodetc player, Inventory inventory)
    {
        int reducedDamage = AttackDamage - inventory.GetDamageReduction();
        if (reducedDamage < 0) reducedDamage = 0;
        Console.WriteLine($"{Name} атакует вас и наносит {reducedDamage} урона!");
        player.TakeDamage(reducedDamage);
    }

    // Метод получения урона мобом
    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Console.WriteLine($"{Name} был побежден!");
        }
    }
}


public static class MobEncounter
{
    private static Random random = new Random();

    public static bool TryEncounterMob()
    {
        // Шанс 70% встретить моба
        int chance = random.Next(1, 101); // Случайное число от 1 до 100
        return chance <= 70;
    }

    public static Mob GenerateRandomMob()
    {
        string[] mobNames = { "Гоблин", "Скелет", "Огр", "Волк", "Демон" };
        int hp = random.Next(30, 100); // Случайное количество HP для моба
        int attack = random.Next(5, 20); // Случайный урон
        string name = mobNames[random.Next(mobNames.Length)];

        return new Mob(name, hp, attack);
    }
}


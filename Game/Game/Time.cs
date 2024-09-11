using System;

public class Time
{
    public int Hours { get; private set; }
    public int Days { get; private set; }

    // Конструктор для инициализации начального времени
    public Time()
    {
        Hours = 8;  // Начало игры в 8:00
        Days = 1;   // Первый день
    }

    // Метод, который возвращает текущее время в формате ЧЧ:00
    public string CurrentTime
    {
        get { return $"{Hours}:00"; }
    }

    // Метод для добавления 1 часа к текущему времени
    public void AddHour()
    {
        Hours++;
        if (Hours >= 24)  // Если время достигло или превысило 24:00
        {
            Hours = 0;
            Days++;
        }
    }

    // Метод для завершения дня и сброса времени на 8:00
    public void NextDay()
    {
        Hours = 8;  // Время сбрасывается на 8:00
        Days++;
    }

    // Проверка, наступила ли полночь
    public bool IsMidnight()
    {
        return Hours == 0;
    }
}
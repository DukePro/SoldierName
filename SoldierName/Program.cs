using System;
using static System.Console;

namespace SoldierNames
{
    class Programm
    {
        static void Main()
        {
            Menu menu = new Menu();
            menu.Run();
        }
    }

    class Menu
    {
        private const string ShowAllCommand = "1";
        private const string ShowNameRankCommand = "2";
        private const string Exit = "0";

        public void Run()
        {
            string userInput;
            bool isExit = false;

            Database database = new Database();
            database.CreateSoldiers();

            while (isExit == false)
            {
                WriteLine();
                WriteLine(ShowAllCommand + " - Показать всех");
                WriteLine(ShowNameRankCommand + " - Отобразить только имена и звания");
                WriteLine(Exit + " - Выход\n");

                userInput = ReadLine();

                switch (userInput)
                {
                    case ShowAllCommand:
                        database.ShowAllSoldiers();
                        break;

                    case ShowNameRankCommand:
                        database.ShowNameRank();
                        break;

                    case Exit:
                        isExit = true;
                        break;
                }
            }
        }
    }

    class Soldier
    {
        public Soldier(string name, string weapon, string rank, int experience)
        {
            Name = name;
            Weapon = weapon;
            Rank = rank;
            Experience = experience;
        }

        public string Name { get; private set; }
        public string Weapon { get; private set; }
        public string Rank { get; private set; }
        public int Experience { get; private set; }
    }

    class Database
    {
        private int _ammountOfRecords = 10;
        private List<Soldier> _soldiers = new List<Soldier>();

        public void ShowAllSoldiers()
        {
            foreach (var soldier in _soldiers)
            {
                WriteLine($"{soldier.Name}, Оружие - {soldier.Weapon}, Звание - {soldier.Rank}, Стаж - {soldier.Experience}");
            }
        }

        public void ShowNameRank()
        {
            WriteLine("Список солдат:");

            var soldiersNameRank = _soldiers.Select(soldier => new {soldier.Name, soldier.Rank}).ToList();

            foreach (var soldier in soldiersNameRank)
            {
                WriteLine($"{soldier.Name}, Звание {soldier.Rank}");
            }
        }

        public void CreateSoldiers()
        {
            for (int i = 0; i < _ammountOfRecords; i++)
            {
                _soldiers.Add(new Soldier(GetName(), GetWeapon(), GetRank(), GetExp()));
            }
        }

        private string GetName()
        {
            string[] soldierNames =
            [
        "Иван Зевс",
        "Николай Лес",
        "Александр Сова",
        "Пётр Зима",
        "Егор Ветер",
        "Дмитрий Огонь",
        "Анатолий Гром",
        "Сергей Молния",
        "Михаил Шторм",
        "Артем Вихрь",
        "Алексей Молот",
        "Игорь Гроза",
        "Владимир Луч",
        "Андрей Громада",
        "Степан Буря",
        "Максим Ветеран",
        "Олег Взрыв",
        "Григорий Тайфун",
        "Василий Ураган",
        "Артур Блиц"
            ];

            string name = soldierNames[Utils.GetRandomNumber(soldierNames.Length - 1)];
            return name;
        }

        private string GetWeapon()
        {
            string[] weaponNames =
            [
        "Автомат Калашникова",
        "Пистолет-пулемёт МР5",
        "Автомат М16",
        "Пистолет Glock 17",
        "Винтовка Мосина"
            ];

            string weapon = weaponNames[Utils.GetRandomNumber(weaponNames.Length - 1)];
            return weapon;
        }

        private string GetRank()
        {
            string[] rankNames =
            [
        "Солдат",
        "Рядовой",
        "Ефрейтор",
        "Младший сержант",
        "Сержант"
            ];

            string rank = rankNames[Utils.GetRandomNumber(rankNames.Length - 1)];
            return rank;
        }

        private int GetExp()
        {
            int minExp = 1;
            int maxExp = 20;

            return Utils.GetRandomNumber(minExp, maxExp);
        }
    }

    class Utils
    {
        private static Random s_random = new Random();

        public static int GetRandomNumber(int minValue, int maxValue)
        {
            return s_random.Next(minValue, maxValue);
        }

        public static int GetRandomNumber(int maxValue)
        {
            return s_random.Next(maxValue);
        }
    }
}

//Существует класс солдата. В нём есть поля: имя, вооружение, звание, срок службы(в месяцах).
//Написать запрос, при помощи которого получить набор данных состоящий из имени и звания.
//Вывести все полученные данные в консоль.
//(Не менее 5 записей) 
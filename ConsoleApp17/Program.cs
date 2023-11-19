using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ШалаевИльяАлексеевич_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Приведен пример работы на игре \"Ведьмак 3: Дикая охота\"");
            Console.WriteLine("");

            Warrior warrior = new Warrior("Геральт", 100, 20, 5, "Меч");
            warrior.Attack();

            Goblin goblin = new Goblin("Детлафф", 350, 10, 12);
            goblin.Attack();
            

            Wizard wizard = new Wizard("Ольгерд Фон Эверек", 200, 30, 20, "Огонь");
            wizard.Attack();

            Kaban kaban = new Kaban("Володимир", 10000, 2500, 100);
            kaban.Attack();
            Console.ReadKey();
        }


        class Person
        {
            
            protected string name;
            public int health;
            private int damage;
            internal int level;
            protected bool isAlive;

            // Конструктор класса
            public Person(string name, int health, int damage, int level)
            {
                this.name = name;
                this.health = health;
                this.damage = damage;
                this.level = level;
                this.isAlive = true;
            }

            // Метод для атаки
            public virtual void Attack()
            {
                Console.WriteLine($"{name} атакует противника!");
            }

            // Метод для получения урона
            public virtual void TakeDamage(int amount)
            {
                health -= amount;
                if (health <= 0)
                {
                    isAlive = false;
                    Console.WriteLine($"{name} был уничтожен!");
                }
            }
        }

        // Родительский класс "Враг"
        class Enemy : Person
        {
            // Поля с различными модификаторами доступа
            protected string enemyType;
            public string specialAbility;

            // Конструктор класса
            public Enemy(string name, int health, int damage, int level, string enemyType, string specialAbility)
                : base(name, health, damage, level)
            {
                this.enemyType = enemyType;
                this.specialAbility = specialAbility;
            }

            // Переопределенный метод для атаки
            public override void Attack()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{name} ({enemyType}) атакует главного героя!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("--------------");
            }
        }

        // Подклассы персонажей
        class Warrior : Person
        {
            public string weapon;

            public Warrior(string name, int health, int damage, int level, string weapon)
                : base(name, health, damage, level)
            {
                this.weapon = weapon;
            }

            // Переопределенный метод для атаки
            public override void Attack()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{name} (Ведьмак) атакует врага с помощью {weapon}!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("--------------");
            }
        }

        class Wizard : Person
        {
            public string magicType;

            public Wizard(string name, int health, int damage, int level, string magicType)
                : base(name, health, damage, level)
            {
                this.magicType = magicType;
            }

            // Переопределенный метод для атаки
            public override void Attack()
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{name} (Волшебник) использует заклинание типа {magicType}!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("--------------");
            }
        }

        // Подклассы врагов
        class Goblin : Enemy
        {
            public Goblin(string name, int health, int damage, int level)
                : base(name, health, damage, level, "Вампир", "Проклятие на бесмертие")
            {
            }
        }

        class Kaban : Enemy
            {
            public Kaban(string name, int health, int damage, int level)
                : base(name, health, damage, level, "Веселый кабанчек", "попрашайничество")
            {
            }
        }

    }
}

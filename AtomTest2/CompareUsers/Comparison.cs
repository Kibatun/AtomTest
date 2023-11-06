using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomTest.UserComparison
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите данные первого пользователя (ФИО через пробел):");

            User user1 = new User();
            string[] fullName1 = Console.ReadLine().Split(' ');
            if (fullName1.Length != 3)
            {
                Console.WriteLine("Неправильный формат ввода ФИО.");
                return;
            }

            user1.SurName = fullName1[0];
            user1.FirstName = fullName1[1];
            user1.Patronymic = fullName1[2];

            Console.Write("Введите серию и номер паспорта (10 цифр): ");

            string passportNumber1 = Console.ReadLine();
            if (passportNumber1.Length != 10 || !int.TryParse(passportNumber1, out _))
            {
                Console.WriteLine("Неверный формат номера паспорта.");
                return;
            }
            user1.PassportNumber = passportNumber1;

            Console.Write("Введите дату рождения (ДД ММ ГГГГ через пробел): ");
            string[] birthDateParts1 = Console.ReadLine().Split(' ');
            if (birthDateParts1.Length != 3 ||
                !int.TryParse(birthDateParts1[0], out int day) ||
                !int.TryParse(birthDateParts1[1], out int month) ||
                !int.TryParse(birthDateParts1[2], out int year))
            {
                Console.WriteLine("Неверный формат даты рождения.");
                return;
            }
            user1.DateOfBirth = new DateTime(year, month, day);

            Console.WriteLine("Введите данные второго пользователя (ФИО через пробел):");

            User user2 = new User();
            string[] fullName2 = Console.ReadLine().Split(' ');
            if (fullName2.Length != 3)
            {
                Console.WriteLine("Неправильный формат ввода ФИО.");
                return;
            }

            user2.SurName = fullName2[0];
            user2.FirstName = fullName2[1];
            user2.Patronymic = fullName2[2];

            Console.Write("Введите серию и номер паспорта (10 цифр): ");
            string passportNumber2 = Console.ReadLine();
            if (passportNumber2.Length != 10 || !int.TryParse(passportNumber2, out _))
            {
                Console.WriteLine("Неверный формат номера паспорта.");
                return;
            } 
            user2.PassportNumber = passportNumber2;

            Console.Write("Введите дату рождения (ДД ММ ГГГГ через пробел): ");
            string[] birthDateParts2 = Console.ReadLine().Split(' ');
            if (birthDateParts2.Length != 3 ||
                !int.TryParse(birthDateParts2[0], out day) ||
                !int.TryParse(birthDateParts2[1], out month) ||
                !int.TryParse(birthDateParts2[2], out year))
            {
                Console.WriteLine("Неверный формат даты рождения.");
                return;
            }
            user2.DateOfBirth = new DateTime(year, month, day);

            if (user1.IsIdentical(user2))
            {
                Console.WriteLine("Пользователи идентичны.");
            }
            else
            {
                Console.WriteLine("Пользователи не идентичны.");
            }
        }
    }
}

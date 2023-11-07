using System.Text.RegularExpressions;

namespace AtomTest.UserComparison
{
    public class ComparisonLogic
    {
        /// <summary>
        /// Метод для сравнения двух пользователей и вывода результата.
        /// </summary>
        /// <param name="args">Аргументы командной строки (не используются).</param>
        public static void Compare(string[] args)
        {
            User userOne = ReadUserInput("первого пользователя");
            User userTwo = ReadUserInput("второго пользователя");
             
            if (userOne.IsIdentical(userTwo))
            {
                Console.WriteLine("Пользователи идентичны.");
            }
            else
            {
                Console.WriteLine("Пользователи не идентичны.");
            }
        }

        /// <summary>
        /// Метод для ввода данных пользователя и валидации входных данных.
        /// </summary>
        /// <param name="userDescription">Описание пользователя (первого или второго).</param>
        /// <returns>Объект User с введенными данными.</returns>
        private static User ReadUserInput(string userDescription)
        {
            Console.WriteLine($"Введите данные {userDescription} (ФИО через пробел):");
            User user = new User();

            string fullName = ReadLineWithValidation("Неправильный формат ввода ФИО.", ValidateFullName);
            string[] fullNameParts = fullName.Split(' ');

            if (fullNameParts.Length != 3)
            {
                Console.WriteLine("Неправильный формат ввода ФИО.");
                Environment.Exit(1);
            }

            user.SurName = fullNameParts[0];
            user.FirstName = fullNameParts[1];
            user.Patronymic = fullNameParts[2];

            Console.Write("Введите серию и номер паспорта (10 цифр): ");
            user.PassportNumber = ReadLineWithValidation("Неверный формат номера паспорта.", s => s.Length == 10 && int.TryParse(s, out _));

            Console.Write("Введите дату рождения (ДД ММ ГГГГ через пробел): ");
            string birthDate = ReadLineWithValidation("Неверный формат даты рождения.", ValidateDate);

            string[] birthDateParts = birthDate.Split(' ');
            int day = int.Parse(birthDateParts[0]);
            int month = int.Parse(birthDateParts[1]);
            int year = int.Parse(birthDateParts[2]);
            user.DateOfBirth = new DateTime(year, month, day);

            return user;
        }

        /// <summary>
        /// Метод для ввода строки с валидацией, повторяющий ввод до ввода корректных данных.
        /// </summary>
        /// <param name="errorMessage">Сообщение об ошибке для вывода при некорректных данных.</param>
        /// <param name="validator">Функция валидации введенных данных.</param>
        /// <returns>Введенная и проверенная строка.</returns>
        private static string ReadLineWithValidation(string errorMessage, Func<string, bool> validator)
        {
            string input;
            do
            {
                input = Console.ReadLine();
                if (!validator(input))
                {
                    Console.WriteLine(errorMessage);
                }
            } while (!validator(input));
            return input;
        }

        /// <summary>
        /// Метод для валидации ФИО.
        /// </summary>
        /// <param name="input">Введенная строка для валидации.</param>
        /// <returns>True, если введенное значение соответствует формату ФИО, иначе False.</returns>
        private static bool ValidateFullName(string input)
        {
            return Regex.IsMatch(input, @"^\S+\s+\S+\s+\S+$");
        }

        /// <summary>
        /// Метод для валидации даты рождения.
        /// </summary>
        /// <param name="input">Введенная строка для валидации.</param>
        /// <returns>True, если введенное значение соответствует формату ДД ММ ГГГГ и является корректной датой, иначе False.</returns>
        private static bool ValidateDate(string input)
        {
            string[] parts = input.Split(' ');
            if (parts.Length != 3)
            {
                return false;
            }

            if (!int.TryParse(parts[0], out int day) ||
                !int.TryParse(parts[1], out int month) ||
                !int.TryParse(parts[2], out int year))
            {
                return false;
            }

            if (day < 1 || day > 31 || month < 1 || month > 12 || year < 1900 || year > DateTime.Now.Year)
            {
                return false;
            }

            return true;
        }
    }
}

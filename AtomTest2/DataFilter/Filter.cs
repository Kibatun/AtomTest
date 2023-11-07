class Filtration
{
    static void Main(string[] args)
    {
        List<User> users = new List<User>
        {
            new User { SurName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", PassportNumber = "1234567890", DateOfBirth = new DateTime(1985, 2, 1) },
            new User { SurName = "Петров", FirstName = "Петр", Patronymic = "Петрович", PassportNumber = "9876543210", DateOfBirth = new DateTime(1990, 4, 15) },
            // Добавьте других пользователей по вашему усмотрению
        };

        Console.WriteLine("Введите поле для фильтрации (Фамилия, Имя, Отчество, Серия и номер паспорта, ДД-ММ-ГГ):");
        string filterField = Console.ReadLine();
        string filterFieldNormalized = NormalizeFilterField(filterField); // Преобразуем ввод пользователя в стандартизированное поле

        if (filterFieldNormalized == "Ошибка")
        {
            Console.WriteLine("Неправильный формат поля для фильтрации.");
            return;
        }

        Console.WriteLine("Введите значение для фильтрации:");
        string filterValue = Console.ReadLine();

        IEnumerable<User> filteredUsers = FilterUsers(users, filterFieldNormalized, filterValue);

        Console.WriteLine("Результаты фильтрации:");
        foreach (var user in filteredUsers)
        {
            Console.WriteLine($"{user.SurName} {user.FirstName} {user.Patronymic}, {user.PassportNumber}, {user.DateOfBirth:dd-MM-yyyy}");
        }
    }

    static IEnumerable<User> FilterUsers(List<User> users, string filterField, string filterValue)
    {
        switch (filterField)
        {
            case "Фамилия":
                return users.Where(user => user.SurName == filterValue);
            case "Имя":
                return users.Where(user => user.FirstName == filterValue);
            case "Отчество":
                return users.Where(user => user.Patronymic == filterValue);
            case "Серия и номер паспорта":
                return users.Where(user => user.PassportNumber == filterValue);
            case "ДД-ММ-ГГ":
                if (DateTime.TryParseExact(filterValue, "dd-MM-yy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
                {
                    return users.Where(user => user.DateOfBirth == date);
                }
                else
                {
                    Console.WriteLine("Неверный формат даты.");
                    return Enumerable.Empty<User>();
                }
            default:
                Console.WriteLine("Неверное поле для фильтрации.");
                return Enumerable.Empty<User>();
        }
    }

    /// <summary>
    /// Нормализует ввод пользователя, приводя его к стандартному виду.
    /// </summary>
    /// <param name="input">Входная строка, которую необходимо нормализовать.</param>
    /// <returns>Стандартизированное значение поля для фильтрации или "Ошибка" в случае неправильного ввода.</returns>
    static string NormalizeFilterField(string input)
    {
        // Приведем ввод пользователя к стандартному виду
        string normalizedField = input.Trim().ToLower();
        if (normalizedField == "фамилия") return "Фамилия";
        if (normalizedField == "имя") return "Имя";
        if (normalizedField == "отчество") return "Отчество";
        if (normalizedField == "серия и номер паспорта") return "Серия и номер паспорта";
        if (normalizedField == "дд-мм-гг") return "ДД-ММ-ГГ";
        return "Ошибка"; // Вернем "Ошибка" в случае неправильного ввода
    }
}
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AtomTest.DataFilter.Tests
{
    [TestFixture]
    public class FiltrationTests
    {
        [Test]
        public void TestFilterUsers_FiltersBySurName()
        {
            // Arrange
            var users = new List<User>
            {
                new User { SurName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", PassportNumber = "1234567890", DateOfBirth = new DateTime(1985, 2, 1) },
                new User { SurName = "Петров", FirstName = "Петр", Patronymic = "Петрович", PassportNumber = "9876543210", DateOfBirth = new DateTime(1990, 4, 15) },
                new User { SurName = "Сидоров", FirstName = "Сидор", Patronymic = "Сидорович", PassportNumber = "5555555555", DateOfBirth = new DateTime(1970, 7, 10) }
            };

            string filterField = "Фамилия";
            string filterValue = "Иванов";

            // Act
            IEnumerable<User> filteredUsers = Filtration.FilterUsers(users, filterField, filterValue);

            // Assert
            CollectionAssert.AreEquivalent(new[] { users[0] }, filteredUsers);
        }

        [Test]
        public void TestFilterUsers_FiltersByFirstName()
        {
            // Arrange
            var users = new List<User>
            {
                new User { SurName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", PassportNumber = "1234567890", DateOfBirth = new DateTime(1985, 2, 1) },
                new User { SurName = "Петров", FirstName = "Петр", Patronymic = "Петрович", PassportNumber = "9876543210", DateOfBirth = new DateTime(1990, 4, 15) },
                new User { SurName = "Сидоров", FirstName = "Сидор", Patronymic = "Сидорович", PassportNumber = "5555555555", DateOfBirth = new DateTime(1970, 7, 10) }
            };

            string filterField = "Имя";
            string filterValue = "Петр";

            // Act
            IEnumerable<User> filteredUsers = Filtration.FilterUsers(users, filterField, filterValue);

            // Assert
            CollectionAssert.AreEquivalent(new[] { users[1] }, filteredUsers);
        }

        // По аналогии добавьте другие тесты для остальных полей фильтрации

        // Тесты для неправильных входных данных (например, неверный формат даты) тоже могут быть добавлены.
    }
}

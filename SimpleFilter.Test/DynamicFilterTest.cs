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
                new User { SurName = "������", FirstName = "����", Patronymic = "��������", PassportNumber = "1234567890", DateOfBirth = new DateTime(1985, 2, 1) },
                new User { SurName = "������", FirstName = "����", Patronymic = "��������", PassportNumber = "9876543210", DateOfBirth = new DateTime(1990, 4, 15) },
                new User { SurName = "�������", FirstName = "�����", Patronymic = "���������", PassportNumber = "5555555555", DateOfBirth = new DateTime(1970, 7, 10) }
            };

            string filterField = "�������";
            string filterValue = "������";

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
                new User { SurName = "������", FirstName = "����", Patronymic = "��������", PassportNumber = "1234567890", DateOfBirth = new DateTime(1985, 2, 1) },
                new User { SurName = "������", FirstName = "����", Patronymic = "��������", PassportNumber = "9876543210", DateOfBirth = new DateTime(1990, 4, 15) },
                new User { SurName = "�������", FirstName = "�����", Patronymic = "���������", PassportNumber = "5555555555", DateOfBirth = new DateTime(1970, 7, 10) }
            };

            string filterField = "���";
            string filterValue = "����";

            // Act
            IEnumerable<User> filteredUsers = Filtration.FilterUsers(users, filterField, filterValue);

            // Assert
            CollectionAssert.AreEquivalent(new[] { users[1] }, filteredUsers);
        }

        // �� �������� �������� ������ ����� ��� ��������� ����� ����������

        // ����� ��� ������������ ������� ������ (��������, �������� ������ ����) ���� ����� ���� ���������.
    }
}

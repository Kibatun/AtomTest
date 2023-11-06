using System;
using System.Globalization;

class User
{
    public string SurName { get; set; }
    public string FirstName { get; set; }
    public string Patronymic { get; set; }
    public string PassportNumber { get; set; }
    public DateTime DateOfBirth { get; set; }

    public bool IsIdentical(User otherUser)
    {
        return
            this.SurName == otherUser.SurName &&
            this.FirstName == otherUser.FirstName &&
            this.Patronymic == otherUser.Patronymic &&
            this.PassportNumber == otherUser.PassportNumber &&
            this.DateOfBirth == otherUser.DateOfBirth;
    }
}
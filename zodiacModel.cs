using System;

namespace _01Kolomeytsev
{
    internal class Model
    {
        private DateTime _birthday;
        internal bool IsValid { get; private set; }
        internal string Age { get; private set; }
        internal string Western { get; private set; }
        internal string Chinese { get; private set; }
        internal bool CanCalculate { get; set; }

        internal Model()
        {
            _birthday = DateTime.Today;
            CanCalculate = true;
        }


        internal DateTime Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                _birthday = value;
            }
        }

        internal void CalcZodiaсs()
        {
            DateTime today = DateTime.Today;
            int xYears = (today.Year - Birthday.Year) - (today.DayOfYear >= _birthday.DayOfYear ? 0 : 1);
            TimeSpan DateTimeB = today - Birthday;
            IsValid = DateTimeB.Days >= 0 && xYears <= 135;
            if (!IsValid)
            {
                Age = "Invalid age";
                Western = "Invalid age";
                Chinese = "Invalid age";
                return;
            }
            Age = xYears > 0 ? xYears + (xYears == 1 ? " year" : "years") : DateTimeB.Days + (DateTimeB.Days == 1 ? " day" : " days");
            Chinese = CalculateChinese();
            Western = CalculateWestern();
        }


        internal bool IsBirthday()
        {
            DateTime today = DateTime.Today;
            return today.Day == _birthday.Day && today.Month == _birthday.Month;
        }

        private string CalculateChinese()
        {
            switch (_birthday.Year % 12)
            {
                case 1:
                    return "Rooster";
                case 2:
                    return "Dog";
                case 3:
                    return "Pig";
                case 4:
                    return "Rat";
                case 5:
                    return "Ox";
                case 6:
                    return "Tiger";
                case 7:
                    return "Rabbit";
                case 8:
                    return "Dragon";
                case 9:
                    return "Snake";
                case 10:
                    return "Horse";
                case 11:
                    return "Goat";
                default:
                    return "Monkey";
            }
        }

        private string CalculateWestern()
        {
            if ((_birthday.Month == 3 && _birthday.Day >= 21) || (_birthday.Month == 4 && _birthday.Day <= 20))
                return "Aries";
            if ((_birthday.Month == 4 && _birthday.Day >= 21) || (_birthday.Month == 5 && _birthday.Day <= 20))
                return "Taurus";
            if ((_birthday.Month == 5 && _birthday.Day >= 21) || (_birthday.Month == 6 && _birthday.Day <= 21))
                return "Gemini";
            if ((_birthday.Month == 6 && _birthday.Day >= 22) || (_birthday.Month == 7 && _birthday.Day <= 22))
                return "Cancer";
            if ((_birthday.Month == 7 && _birthday.Day >= 23) || (_birthday.Month == 8 && _birthday.Day <= 23))
                return "Leo";
            if ((_birthday.Month == 8 && _birthday.Day >= 24) || (_birthday.Month == 9 && _birthday.Day <= 23))
                return "Virgo";
            if ((_birthday.Month == 9 && _birthday.Day >= 24) || (_birthday.Month == 10 && _birthday.Day <= 22))
                return "Libra";
            if ((_birthday.Month == 10 && _birthday.Day >= 23) || (_birthday.Month == 11 && _birthday.Day <= 22))
                return "Scorpio";
            if ((_birthday.Month == 11 && _birthday.Day >= 23) || (_birthday.Month == 12 && _birthday.Day <= 21))
                return "Sagittarius";
            if ((_birthday.Month == 12 && _birthday.Day >= 22) || (_birthday.Month == 1 && _birthday.Day <= 20))
                return "Capricorn";
            if ((_birthday.Month == 1 && _birthday.Day >= 21) || (_birthday.Month == 2 && _birthday.Day <= 19))
                return "Aquarius";
            return "Pisces";
        }
    }
}
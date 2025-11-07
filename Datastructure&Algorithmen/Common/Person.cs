namespace Common
{
    public class Person : IComparable<Person>
    {
        public int ID { get; set; }
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public int Age
        {
            get
            {
                int year = 0;
                if (BirthDate.HasValue)
                {
                    year = BirthDate.Value.Year;
                }
                return DateTime.Now.Year - year;
            }
        }
        public enum Genders
        {
            m = 0,
            w = 1,
            d = 2
        }
        public Genders? Gender { get; private set; }
        public Person(string? firstName, string? lastName, DateTime? birthdate, Genders? gender)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthdate;
            Gender = gender;
        }
        public Person(string? firstName = "Firstname", string? lastName = "Lastname")
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public Person()
        {
            FirstName = "Firstname";
            LastName = "Lastname";
        }
        public void ChangeFirstName(string firstName)
        {
            Common.Utilities.Validator.ValidateString(firstName, nameof(firstName));
            FirstName = firstName;
        }
        public void ChangeLastName(string lastName)
        {
            Common.Utilities.Validator.ValidateString(lastName, nameof(lastName));
            LastName = lastName;
        }
        public void ChangeBirthdate(DateTime birthdate)
        {
            ValidateBirthdate(birthdate);
            BirthDate = birthdate;
        }
        public void ChangeGender(Genders gender)
        {
            Common.Utilities.Validator.ValidateEnumValue(gender, nameof(gender));
            Gender = gender;
        }
        private void ValidateBirthdate(DateTime birthdate)
        {
            if (birthdate >= DateTime.Now)
            {
                throw new ArgumentOutOfRangeException(nameof(birthdate), $"{nameof(birthdate)} must be in the past and cannot be today.");
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj is not Person other) return false;
            else return ID == other.ID
                    && FirstName == other.FirstName
                    && LastName == other.LastName
                    && BirthDate == other.BirthDate
                    && Age == other.Age
                    && Gender == other.Gender;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(ID, FirstName, LastName, BirthDate, Age, Gender);
        }
        public int CompareTo(Person? other)
        {
            int result;
            if (other is null) return 1;
            result = string.Compare(LastName, other.LastName, StringComparison.OrdinalIgnoreCase);
            if (result != 0) return result;
            result = string.Compare(FirstName, other.FirstName, StringComparison.OrdinalIgnoreCase);
            if (result != 0) return result;
            result = Nullable.Compare(BirthDate, other.BirthDate);
            if (result != 0) return result;
            return ID.CompareTo(other.ID);
        }
    }
}
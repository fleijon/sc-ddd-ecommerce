namespace Sales.Domain.Customers
{
    public class Name
    {
        private Name()
        {
        }

        public string Firstname { get; }
        public string Surname { get; }

        internal Name(string firstname, string surname)
        {
            Firstname = firstname;
            Surname = surname;
        }

        public static Name Of(string firstname, string surname)
        {
            return new Name(firstname, surname);
        }

        internal static Name CreateNew(string firstname, string surname)
        {
            return new Name(firstname, surname);
        }
    }
}
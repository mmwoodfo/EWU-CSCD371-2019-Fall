namespace Assignment
{
    public interface IPerson
    {
        string FirstName { get; }
        string LastName { get; }
        string Email { get; }
        IAddress Address { get; }

        string EmailAddress { get; }
    }
}

namespace Application.Features.Users.Commands.Create
{
    public class CreateUserInput
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string NumberPhone { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }
}

﻿namespace Application.Features.Users.Commands.Update
{
    public class UpdateUserInput
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string NumberPhone { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }
}

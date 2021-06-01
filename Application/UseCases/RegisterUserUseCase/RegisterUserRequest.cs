using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Application.UseCases.RegisterUserUseCase
{
    public class RegisterUserRequest : IRequest<Unit>
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
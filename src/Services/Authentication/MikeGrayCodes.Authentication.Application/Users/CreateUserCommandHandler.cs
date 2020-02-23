using MediatR;
using MikeGrayCodes.Authentication.Application.Authentication;
using MikeGrayCodes.Authentication.Domain.Entities.ApplicationUser;
using MikeGrayCodes.BuildingBlocks.Application;
using System.Threading;
using System.Threading.Tasks;

namespace MikeGrayCodes.Authentication.Application.Users
{
    internal class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IApplicationUserRepository applicationUserRepository;
        private readonly IApplicationUserUniquenessChecker uniquenessChecker;

        public CreateUserCommandHandler(
            IApplicationUserRepository applicationUserRepository,
            IApplicationUserUniquenessChecker uniquenessChecker)
        {
            this.applicationUserRepository = applicationUserRepository ?? throw new System.ArgumentNullException(nameof(applicationUserRepository));
            this.uniquenessChecker = uniquenessChecker ?? throw new System.ArgumentNullException(nameof(uniquenessChecker));
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var password = PasswordManager.HashPassword(request.Password);

            var applicationUser = ApplicationUser.Create(request.Email, request.FirstName, uniquenessChecker);

            await applicationUserRepository.Add(applicationUser);

            return Unit.Value;
        }
    }
}

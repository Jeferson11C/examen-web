using si730pc2u20211c211.API.Hr.Domain.Model.Aggregates;
using si730pc2u20211c211.API.Hr.Domain.Model.Commands;
using si730pc2u20211c211.API.Hr.Domain.Repositories;
using si730pc2u20211c211.API.Hr.Domain.Services;
using si730pc2u20211c211.API.Shared.Domain.Repositories;

namespace si730pc2u20211c211.API.Hr.Application.Internal.CommandServices;

public class JoinRequestCommadService(IJoinRequestRepository joinRequestRepository, IUnitOfWork unitOfWork)
    : IJoinRequestCommandService
{
    public async Task<JoinRequest?> Handle(CreateJoinRequestCommand command)
    {
        async Task<bool> ValidateInsertion()
        {
            try
            {
                await joinRequestRepository.AddAsync(new JoinRequest(command));
                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
        }
        if (await ValidateInsertion()) return new JoinRequest(command);
        else return null;
    }
    
}
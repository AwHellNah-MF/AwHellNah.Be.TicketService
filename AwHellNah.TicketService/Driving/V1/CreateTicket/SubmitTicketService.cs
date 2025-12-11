using AwHellNah.TicketService.Domain.TicketAggregate.Services;
using AwHellNah.TicketService.Domain.TicketAggregate.ValueObjs;
using AwHellNah.TicketService.Driven.Persistence;
using AwHellNah.TicketService.Driving.Common.Authentication.Auth0JwtBearer.Services;
using Frametux.Shared.Core.Driving.Common.Responses;
using Frametux.Shared.Core.Driving.MinimalApi;
using Frametux.Shared.Core.Driving.MinimalApi.RequestValidation;
using Microsoft.AspNetCore.Mvc;

namespace AwHellNah.TicketService.Driving.V1.CreateTicket;

public class SubmitTicketService(PersistenceDbContext dbContext, ITicketsService ticketsService) : IMinimalApi
{
    private async Task<BaseResponse> ExecuteAsync(string creatorUserId, SubmitTicketRequest request, CancellationToken cancellationToken)
    {
        var newTicket = await ticketsService.CreateTicketAsync(
            request.Title,
            request.Description != null ? (TicketDescription) request.Description : null,
            creatorUserId,
            cancellationToken);
        
        await dbContext.SaveChangesAsync(cancellationToken);

        return new SubmitTicketResponse
        {
            Message = "Ticket submitted successfully.",
            Type = ResponseType.CreateSuccess,
            Data = new SubmitTicketData
            {
                Id = newTicket.Id
            }
        };
    }
    
    public static void RegisterRestfulApi(IEndpointRouteBuilder app)
        => app
            .MapPost(Endpoints.Restful.V1.Tickets, async (
                [FromBody] SubmitTicketRequest request,
                IAuth0JwtBearerAuthenticationService authenticationService,
                SubmitTicketService submitTicketService,
                CancellationToken cancellationToken
            ) =>
            {
                var userId = authenticationService.GetCurrentUserId()!;
                
                var response = await submitTicketService.ExecuteAsync(userId, request, cancellationToken);

                if (response.Type == ResponseType.CreateSuccess)
                    return Results.Created("", response);
                
                return Results.BadRequest(response);
            })
            .WithRequestValidation<SubmitTicketRequest>()
            .RequireAuthorization();
}
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Driver.API.Models;
using MediatR;

namespace Driver.API.Features.GetDriverChatById;

public record GetDriverChatByIdResponse(DriverChatBox driverChatBox);
public class GetDriverChatByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/driverchatbox/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetDriverChatByIdQuery(id));

            var response = result.Adapt<GetDriverChatByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetDriverChatById")
        .Produces<GetDriverChatByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Driver Chat By Id")
        .WithDescription("Get Driver Chat By Id");
    }
}

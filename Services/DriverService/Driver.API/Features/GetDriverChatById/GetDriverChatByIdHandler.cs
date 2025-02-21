// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using BuildingBlocks.CQRS;
using Driver.API.Models;

namespace Driver.API.Features.GetDriverChatById;

public record GetDriverChatByIdQuery(Guid Id) : IQuery<GetDriverChatByIdResult>;
public record GetDriverChatByIdResult(DriverChatBox DriverChatBox);

public class GetDriverChatByIdHandler : IQueryHandler<GetDriverChatByIdQuery, GetDriverChatByIdResult>
{
    public Task<GetDriverChatByIdResult> Handle(GetDriverChatByIdQuery request, CancellationToken cancellationToken)
    {
        //TODO: call the db context and  return the driver chat messages
        throw new NotImplementedException();
    }
}

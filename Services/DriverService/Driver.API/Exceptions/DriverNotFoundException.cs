// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Driver.API.Exceptions;

public class DriverNotFoundException : NotFoundException
{
    public DriverNotFoundException(int Id) : base("Driver", Id)
    {
    }
}

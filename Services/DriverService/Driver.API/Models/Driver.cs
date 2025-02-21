// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Driver.API.Models;

public class Driver
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
}

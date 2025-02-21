// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Driver.API.Models;

public class DriverChatBox : Driver
{
    public string? Content { get; set; }
    public bool IsRead { get; set; }
    public string? Username { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
}

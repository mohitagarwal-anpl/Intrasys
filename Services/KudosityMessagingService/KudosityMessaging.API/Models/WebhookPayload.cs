// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace KudosityMessaging.API.Models;

public class WebhookPayload
{
    public string From { get; set; }
    public string To { get; set; }
    public string Message { get; set; }
}

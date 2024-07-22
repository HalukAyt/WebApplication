using System;

namespace WebApp.User.Models
{
    public class ErrorViewModel
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string RequestId { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

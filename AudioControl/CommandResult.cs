using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioControl
{
    public class CommandResult
    {
        public bool IsSuccess { get; }
        public string? ErrorMessage { get; }
        public CommandResponse? Response { get; }

        private CommandResult(bool isSuccess, string? errorMessage, CommandResponse? response)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
            Response = response;
        }

        public static CommandResult Success(CommandResponse? response) =>
            new(true, null, response);

        public static CommandResult Failure(string error) =>
            new(false, error, null);
    }
}

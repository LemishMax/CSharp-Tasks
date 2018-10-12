namespace Task_3.Commands
{
    public class ResultOfCommand
    {
        public readonly bool IsSuccess;

        public readonly string Message;

        public ResultOfCommand(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}

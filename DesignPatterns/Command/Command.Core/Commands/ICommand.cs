namespace Command.Core.Commands
{
    public interface ICommand
    {
        void Execute();
        bool CanExecute();
    }
}
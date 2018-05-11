namespace LodeRunner.Services
{
    public interface ICommand
    {
        void Execute();

        bool IsContinious();
    }
}

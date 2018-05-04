namespace LodeRunner.Services
{
    public interface IUserInput
    {
        void Add(char key, ICommand command);

        //void Add(string word, ICommand command); // maybe later for cheats implementations

        void SetUserInput(char key);

        ICommand GetActiveCommand();
    }
}

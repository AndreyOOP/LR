using System.Collections.Generic;

namespace LodeRunner.Services
{
    public class Commands : IUserInput
    {
        private char activeCommandKey;
        private Dictionary<char, ICommand> dictionary = new Dictionary<char, ICommand>();

        public void Add(char key, ICommand command)
        {
            dictionary[key] = command;
        }

        public ICommand GetActiveCommand()
        {
            if (dictionary.ContainsKey(activeCommandKey))
            {
                return dictionary[activeCommandKey];
            }
            else
            {
                return dictionary['0'];
            }
        }

        public void SetUserInput(char key)
        {
            activeCommandKey = key;
        }
    }
}

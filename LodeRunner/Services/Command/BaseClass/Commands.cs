using LodeRunner.Services.Command;
using System.Collections.Generic;

namespace LodeRunner.Services
{
    using LodeRunner.Model;

    public class Commands : IUserInput
    {
        private char activeCommandKey;
        private Dictionary<char, ICommand> dictionary;

        public Commands(Model model)
        {
            dictionary = new Dictionary<char, ICommand>();
            dictionary['0'] = new CommandNull(model);
        }

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

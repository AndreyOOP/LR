using System.Collections.Generic;

namespace LodeRunner.Services
{
    public class Commands : IUserInput
    {
        private char activeCommandKey;
        private Dictionary<char, ICommand> dictionary = new Dictionary<char, ICommand>();

        public HashSet<char> AllowedChars { get; set; } = new HashSet<char>();

        public ICommand General { get; set; }

        public void Add(char key, ICommand command)
        {
            dictionary[key] = command;
        }

        public void ExecuteSelectedCommandAndDefault()
        {
            if (AllowedChars.Contains(activeCommandKey))
            {
                var command = dictionary[activeCommandKey];

                if (!command.IsContinious())
                {
                    activeCommandKey = ' ';
                }

                command.Execute();

                General.Execute();
            }
        }

        public void SetUserInput(char key)
        {
            activeCommandKey = key;
        }
    }
}
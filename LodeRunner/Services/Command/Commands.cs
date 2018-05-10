﻿using System.Collections.Generic;

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
            return dictionary.ContainsKey(activeCommandKey) ? dictionary[activeCommandKey] : null;
        }

        public void SetUserInput(char key)
        {
            if (dictionary.ContainsKey(key))
            {
                activeCommandKey = key;
            }
        }

        public char GetUserInput()
        {
            return activeCommandKey;
        }
    }
}

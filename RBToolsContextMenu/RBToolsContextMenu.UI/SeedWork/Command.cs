using System;
using System.Windows.Input;

namespace RBToolsContextMenu.UI.Framework
{
    public class Command : ICommand
    {
        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        public event EventHandler CanExecuteChanged;
    }
}
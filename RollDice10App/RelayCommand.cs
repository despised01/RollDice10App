using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RollDice10App
{
    // Класс для реализации команд
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        // Конструктор
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        // Возможность выполнения команды
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        // Выполнение команды
        public void Execute(object parameter)
        {
            _execute();
        }

        // Событие для изменения состояния команды
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}

using RollDice10App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RollDice10App.ViewModels
{
    // Класс для основной логики приложения
    public class MainViewModel : INotifyPropertyChanged
    {
        private int _numberOfDice;
        private ObservableCollection<DiceRoll> _rolls;

        // Конструктор
        public MainViewModel()
        {
            Rolls = new ObservableCollection<DiceRoll>();
            RollDiceCommand = new RelayCommand(RollDice);
        }

        // Свойство для количества кубиков
        public int NumberOfDice
        {
            get => _numberOfDice;
            set
            {
                _numberOfDice = value;
                OnPropertyChanged(nameof(NumberOfDice));
            }
        }

        // Свойство для списка бросков
        public ObservableCollection<DiceRoll> Rolls
        {
            get => _rolls;
            set
            {
                _rolls = value;
                OnPropertyChanged(nameof(Rolls));
            }
        }

        // Комманда для выполнения броска
        public ICommand RollDiceCommand { get; }

        // Метод для выполнения броска и обновления результатов
        private void RollDice()
        {
            var random = new Random();
            var results = new DiceRoll
            {
                Results = Enumerable.Range(0, NumberOfDice)
                .Select(_ => random.Next(0, 10))
                .OrderByDescending(x => x)
                .ToList()
            };
            // Вставляем новые результаты в начало списка
            Rolls.Insert(0, results);
        }

        // Реализация интерфейса INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

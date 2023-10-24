using GalaSoft.MvvmLight.Command;
using MvvmFirst.Models;
using MvvmFirst.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MvvmFirst.ViewModels
{
    public class MainViewModel
    {
        public Person PersonToAdd { get; set; } = new();

        public ObservableCollection<Person> People { get; set; } = new();

        public ButtonCommand AddCommand
        {
            get => new(
            () =>
            {
                var newPerson = new Person
                {
                    Name = PersonToAdd.Name,
                    Surname = PersonToAdd.Surname,
                    Age = PersonToAdd.Age
                };
                People.Add(newPerson);
            },
                () => InputValidation.ValidatePerson(PersonToAdd)
            );
        }
    }
}

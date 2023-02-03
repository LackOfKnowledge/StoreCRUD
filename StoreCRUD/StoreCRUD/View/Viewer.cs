using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using crudDemo2.Interfaces;
using FluentValidation.Results;

namespace crudDemo2.View
{
    public class Viewer : IViewer
    {
        public bool ShowItem(IItem item)
        {
            if(item is null) return false;
            if(item is Smartphone)
            {
                Smartphone smartphone = (Smartphone)item;
                ShowSmartphone(smartphone);
            }
            if(item is Notebook)
            {
                Notebook notebook = (Notebook)item;
                ShowNotebook(notebook);
            }
            return true;
        }

        private void ShowNotebook(Notebook notebook)
        {
            Console.WriteLine($"Manufacturer:\t{notebook.Manufacturer}");
            Console.WriteLine($"Model:\t{notebook.Model}");
            Console.ReadKey();
        }

        private void ShowSmartphone(Smartphone smartphone)
        {
            Console.WriteLine($"Manufacturer:\t{smartphone.Manufacturer}");
            Console.WriteLine($"Model:\t {smartphone.Model}");
            Console.ReadKey();
        }

        public void ExistingItemError()
        {
            Console.WriteLine("Podany obiekt już istnieje!");
        }

        public void NotFoundError()
        {
            Console.WriteLine("Nie znaleziono!");
        }

        public bool OutputMsg(List<ValidationFailure>? validationFailures)
        {
            if(validationFailures is null)
            {
                ShowAllDoneMessage();
                return true;
            }
            ShowErrors(validationFailures);
            return false;
        }

        private void ShowAllDoneMessage()
        {
            Console.WriteLine("Dodano pomyslnie");
        }

        private void ShowErrors(List<ValidationFailure> validationFailures)
        {
            Console.WriteLine("\n");
            Console.WriteLine(new String('-', 20));
            Console.WriteLine("Wprowadzono nieprawidłowe dane");
            Console.WriteLine(new String('-', 20));
            foreach(ValidationFailure failure in validationFailures)
            {
                Console.WriteLine(failure.ToString());
            }
            Console.ReadKey();
        }

        public void ValueError()
        {
            Console.WriteLine("Nieprawidłowa wartość");
        }
    }
}
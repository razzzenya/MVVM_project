using MVVM_project.Interfaces;
using MVVM_project.Services;
using MVVM_project.Models;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MVVM_project.ViewModels
{
    public class SecondTabViewModel : INotifyPropertyChanged
    {
        public ICommand LoadCommand { get; }
        private readonly IFileService fileService;
        private ObservableCollection<ModelClass> models;

        public ObservableCollection<ModelClass> Models
        {
            get { return models; } 
            set 
            {
                models = value;
                OnPropertyChanged(nameof(Models));
            }

        }
        public SecondTabViewModel(IFileService fileService)
        {
           LoadCommand = new DelegateCommand(Load);
           this.fileService = fileService;
           Models = new ObservableCollection<ModelClass>();
        }

        private void Load(object parameter)
        {
            string filePath = fileService.GetFilePath(false);
            if (!string.IsNullOrEmpty(filePath))
            {
                List<ModelClass> data = fileService.LoadData(filePath);
                if (data != null)
                {
                    Models.Clear();
                    foreach (ModelClass item in data)
                    {
                        Models.Add(item);
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MVVM_project.Models;
using MVVM_project.Interfaces;
using MVVM_project.Services;
using System.Windows.Input;

namespace MVVM_project.ViewModels
{
    public class FirstTabViewModel : INotifyPropertyChanged
    {
        private readonly IFileService fileService;
        public event EventHandler<string> ErrorOccurred;
        private ModelClass _model;

        public ModelClass Model
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        public string A
        {
            get { return Model.A.ToString(); }
            set {
                if (Model.A.ToString() != value)
                {
                    try
                    {
                        Model.A = StringToDouble.MakeDouble(value);
                        OnPropertyChanged(nameof(A));
                    }
                    catch (InvalidOperationException ex) 
                    {
                        OnErrorOccurred(ex.Message);
                    }
                }
            }
        }

        public string B
        {
            get { return Model.B.ToString(); }
            set 
            {
                if (Model.B.ToString() != value)
                {
                    try
                    {
                        Model.B = StringToDouble.MakeDouble(value);
                        OnPropertyChanged(nameof(B));
                    }
                    catch (InvalidOperationException ex)
                    {
                        OnErrorOccurred(ex.Message);
                    }
                }
            }
        }

        public string Result { get { return Model.Result.ToString(); } set { } }

        public DateTime Date { get { return Model.Date; } set { } }

        public ICommand CalculateCommand { get; }
        public ICommand SaveCommand { get; }

        public FirstTabViewModel(IFileService fileService)
        {
            this.fileService = fileService;
            Model = new ModelClass();
            CalculateCommand = new DelegateCommand(Calculate);
            SaveCommand = new DelegateCommand(Save);
        }
        private void Calculate(object parameter)
        {
            OnPropertyChanged(nameof(Model.Result));
        }

        private void Save(object parameter)
        {
            OnPropertyChanged(nameof(Model.Result));
            var filePath = fileService.GetFilePath(true);
            if (!string.IsNullOrEmpty(filePath))
            {
                fileService.SaveData(filePath, Model);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnErrorOccurred(string message)
        {
            ErrorOccurred?.Invoke(this, message);
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

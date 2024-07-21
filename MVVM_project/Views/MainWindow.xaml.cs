using MVVM_project.Services;
using MVVM_project.ViewModels;
using System.Windows;

namespace MVVM_project
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FileService fileService = new FileService();
            FirstTabViewModel firstViewMdl = new FirstTabViewModel(fileService);
            DataContext = firstViewMdl;
            SecondTabViewModel secondViewMdl = new SecondTabViewModel(fileService);
            SecondTab.DataContext = secondViewMdl;
            firstViewMdl.ErrorOccurred += ViewModel_ErrorOccurred;
        }

        private void ViewModel_ErrorOccurred(object sender, string e)
        {
            MessageBox.Show(e, "Неверный ввод", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

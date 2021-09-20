using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using static DashboardCreator.Utility.FileExtension;
using static DashboardCreator.Phases.InterfacePhase;
using DashboardCreator.Phases;
using DashboardCreator.Models;

namespace DashboardCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Models = new ObservableCollection<FoundClass>();

        }

        private void BrowseFileBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            using var dialog = new System.Windows.Forms.OpenFileDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            switch (button.Name)
            {
                case "BrowseModelBtn":
                    ModelAdd = dialog.FileName;
                    break;

            }
        }
        private void BrowseBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            using var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();


            switch (button.Name)
            {
                case "BrowseApiBtn":
                    apiAdd = dialog.SelectedPath;
                    break;
                case "BrowseUiBtn":
                    uiAdd = dialog.SelectedPath;
                    break; 
                case "ShareAddBtn":
                    ShareAdd = dialog.SelectedPath;
                    break;

            }

        }


        private void GoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (selectedModel is null)
                return;
        
            if (!string.IsNullOrEmpty(apiAdd))
                new BackEnd().LetsBurnIt(apiAdd, selectedModel);
            if (!string.IsNullOrEmpty(uiAdd))
                new FrontEnd().LetsBurnIt(uiAdd, selectedModel);
            //if (!string.IsNullOrEmpty(ShareAdd))
            //    new Share().LetsBurnIt(ShareAdd, Name);

        }

        private void CheckFillBtn_Click(object sender, RoutedEventArgs e)
        {
            Models.Clear();
            var files = ListAllFiles(ModelAdd);
            foreach (var item in files)
            {
                Models.Add(item);
            }
        }



        private string _apiAdd;
        public string apiAdd
        {
            get => _apiAdd; set
            {
                _apiAdd = value;
                OnPropertyChanged();
            }
        }





        private FoundClass _selectedModel;
        public FoundClass selectedModel
        {
            get => _selectedModel; set
            {
                _selectedModel = value;
                OnPropertyChanged();
            }
        }


        private string _uiAdd;
        public string uiAdd
        {
            get => _uiAdd; set
            {
                _uiAdd = value;
                OnPropertyChanged();
            }
        }






        private string modelAdd;
        public string ModelAdd
        {
            get => modelAdd; set
            {
                modelAdd = value;
                OnPropertyChanged();
            }
        }

        private string shareAdd;
        public string ShareAdd
        {
            get => shareAdd; set
            {
                shareAdd = value;
                OnPropertyChanged();
            }
        }




        private ObservableCollection<FoundClass> _Models;
        public ObservableCollection<FoundClass> Models
        {
            get => _Models;
            set
            {
                _Models = value;
                OnPropertyChanged();
            }
        }





        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

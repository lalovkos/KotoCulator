using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KotoCulator
{

    public class MainWindowViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<Material> Materials { get { return _materials; } set { _materials = value; OnPropertyChanged("Materials"); } }
        public ObservableCollection<Creation> Creations { get { return _creations; } set { _creations = value; OnPropertyChanged("Creations"); } }

        private ObservableCollection<Material> _materials;
        private ObservableCollection<Creation> _creations;

        public Material SelectedMaterial { get { return _selectedMaterial; } set { _selectedMaterial = value; OnPropertyChanged("SelectedMaterial"); } }
        public Creation SelectedCreation { get { return _selectedCreation; } set { _selectedCreation = value; OnPropertyChanged("SelectedCreation"); } }

        public Material _selectedMaterial;
        public Creation _selectedCreation;

        public MainWindowViewModel() 
        {
            _materials = new ObservableCollection<Material>();
            _materials.Add(new Material("Epics", 4000, 8000));
            _materials.Add(new Material("Eyes", 300, 900));
            _materials.Add(new Material("Dye", 300, 300));
            _creations = new ObservableCollection<Creation>();
            _creations.Add(new Creation("Kot1", new ObservableCollection<MaterialConsumption> { new MaterialConsumption(_materials[0], 22), new MaterialConsumption(_materials[1], 33) }));

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;
        }

        private void Creations_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            CreationSave response = new CreationSave(false);
            Creation unsaved_creation = _viewModel.SelectedCreation.Copy();
            var window = new CreationWindow(response, unsaved_creation, _viewModel.Materials);

            window.Owner = this;
            window.ShowDialog();

            if (response.Save) 
            {
                _viewModel.Creations[_viewModel.Creations.IndexOf(_viewModel.SelectedCreation)] = unsaved_creation;
            }
        }

        private void Add_Material_Button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Materials.Add(new Material("Name", 0, 1));
            _viewModel.OnPropertyChanged();
        }

        private void Delete_Material_Button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Materials.Remove(_viewModel.SelectedMaterial);
            _viewModel.OnPropertyChanged();
        }

        private void Add_Creation_Button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Creations.Add(new Creation("Kot1", new ObservableCollection<MaterialConsumption> { new MaterialConsumption(_viewModel.Materials[0], 22), new MaterialConsumption(_viewModel.Materials[1], 33) }));
            _viewModel.OnPropertyChanged();
        }

        private void Delete_Creation_Button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Creations.Remove(_viewModel.SelectedCreation);
            _viewModel.OnPropertyChanged();
        }
    }
}

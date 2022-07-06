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
using System.Windows.Shapes;

namespace KotoCulator
{
    public class CreationWindowViewModel : INotifyPropertyChanged
    {
        public Creation Creation { 
            get 
            { 
                return _creation; 
            } 
            set 
            { 
                _creation = value; 
                OnPropertyChanged("Creation"); 
            } 
        }
        private Creation _creation;

        public Material SelectedMaterial;

        public CreationWindowViewModel(Creation creation = null)
        {
            if (creation == null)
            {
                Creation = new Creation("Name", new ObservableCollection<MaterialConsumption>());
            }
            else 
            {
                Creation = creation;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public partial class CreationWindow : Window
    {
        private CreationWindowViewModel _creationViewModel;
        private CreationSave _save;


        public CreationWindow(CreationSave save, Creation creation, ObservableCollection<Material> materials)
        {
            _save = save;
            InitializeComponent();
            _creationViewModel = new CreationWindowViewModel(creation);

            ComboboxColumn.ItemsSource = materials;
            DataContext = _creationViewModel.Creation;

        }

        private void Ok_Button_Click(object sender, RoutedEventArgs e)
        {
            _save.Save = true;
            Close();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            _save.Save = false;
            Close();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            _creationViewModel.Creation.AddComposition(new MaterialConsumption(new Material("Name", 0, 1), 0));
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            _creationViewModel.Creation.RemoveComposition((MaterialConsumption)MaterialsDataGrid.SelectedItem);
        }

        private void MaterialsDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            _creationViewModel.Creation.ChangePrice();
        }
    }

    public class CreationSave
    {
        public bool Save = false;

        public CreationSave(bool save = false) 
        {
            Save = save;
        }
    }
}

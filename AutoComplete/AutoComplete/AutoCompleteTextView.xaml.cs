using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoComplete
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AutoCompleteTextView : ContentPage
    {
        ObservableCollection<string> data = new ObservableCollection<string>();

        ObservableCollection<string> fileResultVMs = new ObservableCollection<string>();
        public AutoCompleteTextView()
        {
            InitializeComponent();
            ListOfStore();
            BindingContext = this;
            //lstSuggest.ItemsSource = data;
        }
        //List<string> data = new List<string>();
        public async void ListOfStore() //List of Countries  
        {
            try
            {
                data.Add("Afghanistan");
                data.Add("Austria");
                data.Add("Australia");
                data.Add("Azerbaijan");
                data.Add("Bahrain");
                data.Add("Bangladesh");
                data.Add("Belgium");
                data.Add("Botswana");
                data.Add("China");
                data.Add("Colombia");
                data.Add("Denmark");
                data.Add("Kmart");
                data.Add("Nigeria");
                data.Add("Pakistan");
                data.Add("Zambia");
            }
            catch (Exception ex)
            {
                await DisplayAlert("", "" + ex, "Ok");
            }
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            countryListView.IsVisible = true;
            countryListView.BeginRefresh();

            try
            {
                var dataEmpty = data.Where(i => i.ToLower().Contains(e.NewTextValue.ToLower()));

                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                    countryListView.IsVisible = false;
                //else if (dataEmpty.Max().Length == 0)
                //    countryListView.IsVisible = false;
                else
                    countryListView.ItemsSource = data.Where(i => i.ToLower().Contains(e.NewTextValue.ToLower()));
            }
            catch (Exception ex)
            {
                countryListView.IsVisible = false;

            }
            countryListView.EndRefresh();

        }

        private void ListView_OnItemTapped(Object sender, ItemTappedEventArgs e)
        {
            //EmployeeListView.IsVisible = false;  

            FileResultVM listsd = e.Item as FileResultVM;
            String kk = e.Item as string;
            searchBar.Text = kk.ToString();
            fileResultVMs.Add(kk);
            listDocument.ItemsSource = fileResultVMs;
            //MyListView.ItemsSource = fileResultVMs;
            gridFrames.IsVisible = true;
            countryListView.IsVisible = false;
            searchBar.Text = "";

            //((ListView)sender).SelectedItem = null;
        }
        //ObservableCollection<string> FileName = new ObservableCollection<string>();
        //List<string> _fileResultOb = new List<string>();
        //ObservableCollection<string> _fileResult = new ObservableCollection<string>();
        private void BtnRemoveAttachment_Tapped(object sender, EventArgs e)
        {
            var item = (Image)sender;
            var selectedAttachement = item.BindingContext as string;
            if (selectedAttachement != null)
            {
                //_fileResultOb.Remove(selectedAttachement);
                fileResultVMs.Remove(selectedAttachement);
            }
        }

        //private void OnEntryChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (entryMain.Text != null && lstSuggest.ItemsSource != null)
        //    {
        //        if (data.Any(x => x.Contains(e.NewTextValue)) && entryMain.Text != string.Empty)
        //        {
        //            var items = new List<string>();

        //            foreach (var item in data.FindAll(x => x.Contains(e.NewTextValue)))
        //            {
        //                items.Add(item);
        //            }

        //            lstSuggest.ItemsSource = items;
        //            lstSuggest.IsVisible = true;
        //        }
        //        else
        //        {
        //            lstSuggest.IsVisible = false;
        //        }
        //    }
        //}

        //private void ItemSelected(object sender, EventArgs args)
        //{
        //    if (((ListView)sender).SelectedItem == null)
        //        return;

        //    entryMain.Text = lstSuggest.SelectedItem.ToString();
        //    ((ListView)sender).SelectedItem = null;
        //    lstSuggest.IsVisible = false;
        //}
    }
    public class ComposeMessageViewModel
    {
        public List<FileResultVM> _fileResultVMs { get; set; }
        
    }
    public class FileResultVM
    {
        public string FileName { get; set; }
    }
}
using LlamaMusicApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LlamaMusicApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        private ObservableCollection<Song> Songs;
        public BlankPage1()
        {
            this.InitializeComponent();
        }

        private void SongSaveButton_Click(object sender, RoutedEventArgs e)
        {
            //Input from the user

            string name = SongTitle_UserInput.Text;
            string artist = SongArtist_UserInput.Text;
           
            

        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using System.Collections.ObjectModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Security.Cryptography.Core;
using LlamaMusicApp.Model;
using Windows.Media.Playback;
using Windows.Media.Core;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.Storage;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Pickers;
using Windows.Storage.Provider;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LlamaMusicApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Song> Songs;
        // private ObservableCollection<Song> Artists;
        MediaPlayer player;
        bool playing;
        //private object imgMain;

        public MainPage()
        {

            this.InitializeComponent();
            Songs = new ObservableCollection<Song>();
            SongManager.GetAllMusic(Songs);
            player = new MediaPlayer();
            playing = false;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MenuSplitView.IsPaneOpen == false)
            {
                MenuSplitView.IsPaneOpen = true;
            }
            else if (MenuSplitView.IsPaneOpen == true)
            {
                MenuSplitView.IsPaneOpen = false;
            }
        }

        private void SongGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var song = (Song)e.ClickedItem;
            MyMediaElement.Source = new Uri(BaseUri, song.AudioFilePath);
        }

        private async void EditInfo_Click(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(BlankPage1));
            var myview = CoreApplication.CreateNewView();
            int newViewId = 0;
           await myview.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,() =>
           {
               Frame newFrame = new Frame();
               newFrame.Navigate(typeof(BlankPage1), null);
               Window.Current.Content = newFrame;
               Window.Current.Activate();
               newViewId = ApplicationView.GetForCurrentView().Id;

           });
            await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId, ViewSizePreference.UseMinimum);
           // await ApplicationViewSwitcher.TryShowAsViewModeAsync(newViewId, ApplicationViewMode.CompactOverlay);
        }



        private async void EditALbumCover_Click(object sender, RoutedEventArgs e)
        {

            var picker = new FileOpenPicker();


            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = PickerLocationId.MusicLibrary;

           
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");


         
            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                string filePath = file.Path;
            }
            else
            {
                //this.textBlock.Text = "Operation cancelled.";
            }
            

            /*var savepicker = new FileSavePicker();
            savepicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;

            //Filters the type of files acceptable to connect
            savepicker.FileTypeChoices.Add("jpg image", new List<string>() { ".jpg" });

            //Allows user to select the image
            StorageFile file = await savepicker.PickSaveFileAsync();

            if (file != null)
            {
               
                Windows.Storage.CachedFileManager.DeferUpdates(file);
                await Windows.Storage.FileIO.WriteTextAsync(file, file.Name);
                FileUpdateStatus status = await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);
                if (status== FileUpdateStatus.Complete)
                {
                   
                    
                }
              
            }
            else
            {
                //this.textBlock.Text = "Operation cancelled.";
            }*/

    }

        private  void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //await DeleteAsync(StorageDeleteOption.Default);


        }

        private  void PlayButton_Click(object sender, RoutedEventArgs e)
        {
           /* Windows.Storage.StorageFolder folder = await Package.Current.InstalledLocation.GetFoldersAsync();
            Windows.Storage.StorageFile file = await folder.GetFileAsync();

            player.AutoPlay = false;
            player.Source = MediaSource.CreateFromStorageFile(file);

            if (playing)
            {
                player.Source = null;
                playing = false;
            }
            else
            {
                player.Play();
                playing = true;

            }*/
        

    }

        private void SortByArtists_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void SortByAlbums_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void EditALbumCover_DragOver(object sender, DragEventArgs e)
        {
            //To specify which operations are allowed    
            e.AcceptedOperation = DataPackageOperation.Copy;
            // To display the data which is dragged    
            e.DragUIOverride.Caption = "drop here to view image";
            e.DragUIOverride.IsGlyphVisible = true;
            e.DragUIOverride.IsContentVisible = true;
            e.DragUIOverride.IsCaptionVisible = true;

        }

        private async void EditALbumCover_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var items = await e.DataView.GetStorageItemsAsync();
                if (items.Any())
                {
                    var storageFile = items[0] as StorageFile;
                    var contentType = storageFile.ContentType;
                    StorageFolder folder = ApplicationData.Current.LocalFolder;
                    if (contentType == "image/jpg" || contentType == "image/png" || contentType == "image/jpeg")
                    {
                        StorageFile newFile = await storageFile.CopyAsync(folder, storageFile.Name, NameCollisionOption.GenerateUniqueName);
                        var bitmapImg = new BitmapImage();
                        bitmapImg.SetSource(await storageFile.OpenAsync(FileAccessMode.Read));
                       // imgMain.Source = bitmapImg;
                        

                    }
                }
            }

        }

        private void searchauto_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {

        }

       
    }
}

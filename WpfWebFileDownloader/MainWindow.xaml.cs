using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
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

namespace WpfWebFileDownloader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DownloadManager downloadManager;
        public MainWindow()
        {
            InitializeComponent();
            downloadManager = new DownloadManager();
            InitialSetUp();
        }

        private void InitialSetUp()
        {
            //Download_Button.IsEnabled = false;
            Link_TextBox.Text = "https://download.sprutcam.com/links/SprutCAM_X.zip";
            SavePath_TextBox.Text = "D:\\test";
        }

        private void OnProgressChanged(object sender, AltoHttp.ProgressChangedEventArgs e)
        {
            Download_ProgressBar.Value = (int)e.Progress;
        }

        private void OnDownloadCompleted(object? sender, EventArgs e)
        {
            Download_Button.IsEnabled = true;
            MessageBox.Show("File Download Complete!");
        }

        private void Link_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            downloadManager.DownloadLink = Link_TextBox.Text;
        }

        private void SavePath_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            downloadManager.SavePath = SavePath_TextBox.Text;
        }

        private void Download_Button_Click(object sender, RoutedEventArgs e)
        {
            Download_Button.IsEnabled = false;
            ResetProgressBar();
            downloadManager.DownloadFile();
            downloadManager.client.DownloadCompleted += OnDownloadCompleted;
            downloadManager.client.ProgressChanged += OnProgressChanged;
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            downloadManager.CancelDownload();
            ResetProgressBar();
            Download_Button.IsEnabled = true;
        }

        private void ResetProgressBar()
        {
            Download_ProgressBar.Value = 0;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if ((downloadManager.client.State == AltoHttp.Status.Downloading)
                ||
                (downloadManager.client.State == AltoHttp.Status.SendingRequest))
            {
                MessageBox.Show("Stop the download before closing window!");
                e.Cancel = true;
            }
            else
            {
                downloadManager.client.StopReset();
            }
        }
    }
}

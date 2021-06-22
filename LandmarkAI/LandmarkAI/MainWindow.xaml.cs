using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;
using System.Net.Http;
using System.Collections.Generic;
using LandmarkAI.Classes;
using Newtonsoft.Json;

namespace LandmarkAI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new();

            dialog.Filter = " Image Files(*.jpg, *.png, *.tiff)|*.png;*.jpg;*.tiff|All Files (*.*)|*.*";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (dialog.ShowDialog() == true)
            {
                string fileName = dialog.FileName;
                selectedImage.Source = new BitmapImage(new Uri(fileName));

               MakePredictionAsync(fileName);
            }
        }

        private async void MakePredictionAsync(string fileName)
        {
            
            //Sets the Headers that are needed to interact with CustomVision API
            string predictionURL = "https://westus2.api.cognitive.microsoft.com/customvision/v3.0/Prediction/a838f1ca-a059-4efa-ab3f-81c48667e65c/classify/iterations/Iteration1/image";
            string predictionKey = "5f1e5a47184a4814b539efd72dfdbc3b";
            string contentType = "application/octet-stream";
            byte[] file = File.ReadAllBytes(fileName);

            //Set Http Client
            using HttpClient client = new();
            client.DefaultRequestHeaders.Add("Prediction-Key", predictionKey);

            using var content = new ByteArrayContent(file);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
            HttpResponseMessage response = await client.PostAsync(predictionURL, content);
            string responseString = await response.Content.ReadAsStringAsync();

            List<Prediction> predictions = JsonConvert.DeserializeObject<CustomVision>(responseString).Predictions;
            listForPredictions.ItemsSource = predictions;
        }
    }
}

using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace TileMapEditor.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string json;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new TileMap();
        }

        public void Import(string path)
        {
            JObject obj;
            JsonSerializer serializer = new JsonSerializer();
            if (File.Exists(path))
            {
                StreamReader streamReader = new StreamReader(path);
                JsonReader jsonReader = new JsonTextReader(streamReader);
                obj = serializer.Deserialize(jsonReader) as JObject;
                jsonReader.Close();
                streamReader.Close();
                DataContext = obj.ToObject<TileMap>();
            }
        }
        public void Export(object obj, string path)
        {
            JsonSerializer serializer = new JsonSerializer();

            if (File.Exists(path))
            {
                File.Delete(path);
            }
            StreamWriter streamWriter = new StreamWriter(path);
            JsonWriter jsonWriter = new JsonTextWriter(streamWriter);

            serializer.Serialize(jsonWriter, obj);

            jsonWriter.Close();
            streamWriter.Close();
        }

        private void Button_Export(object sender, RoutedEventArgs e)
        {
            Export(DataContext, "ExportedMap.json");
        }

        private void Button_Import(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Json files (*.json)|*.json|All Files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == true)
            {
                string file = openFileDialog.FileName;
                Import(file);
            }
        }
    }
}

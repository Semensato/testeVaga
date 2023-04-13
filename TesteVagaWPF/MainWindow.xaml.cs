using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Text.Json;
using System.IO;
using System.Windows.Forms;

namespace TesteVagaWPF
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        string filePathFolder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        string filePath = "\\ColetaDados.json";

        private FileSystemWatcher _watcher;

        public MainWindow()
        {
            InitializeComponent();

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            txtDiretorio.Text = filePathFolder;

            //instanciando um watcher que vai sempre monitorar o status do arquivo
            _watcher = new FileSystemWatcher(filePathFolder);

            _watcher.Filter = "ColetaDados.json";
            _watcher.EnableRaisingEvents = true;
            _watcher.NotifyFilter = NotifyFilters.FileName;
            _watcher.Created += OnCreated;
            _watcher.Deleted += OnDeleted;

            ExibirDados();
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                btnExibirDados.IsEnabled = true;
            });
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                btnExibirDados.IsEnabled = false;
                txtConteudoArquivo.Document = new FlowDocument(new Paragraph(new Run("")));
            });
            
        }

        private bool ArquivoExiste()
        {
            if (!File.Exists(filePathFolder + filePath))
                return false;

            return true;
        }

        private void ExibirDados()
        {
            if (ArquivoExiste())
            {
                btnExibirDados.IsEnabled = true;
            }
            else
            {
                btnExibirDados.IsEnabled = false;
                txtConteudoArquivo.Document = new FlowDocument(new Paragraph(new Run("")));
            }
        }

        private void btnColetarDados_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(filePathFolder + filePath))
            {

                ColetaDados cd = new ColetaDados();

                string jsonString = JsonSerializer.Serialize(cd);

                sw.Write(jsonString);
            }

            txtConteudoArquivo.Document = new FlowDocument(new Paragraph(new Run("")));
        }

        private void btnExibirDados_Click(object sender, RoutedEventArgs e)
        {
            txtConteudoArquivo.Document = new FlowDocument(new Paragraph(new Run("")));

            if (ArquivoExiste())
            {
                string jsonColetaDados = File.ReadAllText(filePathFolder + filePath);

                ColetaDados cd = JsonSerializer.Deserialize<ColetaDados>(jsonColetaDados);

                string coletaFormatada = $@"Operating System:
    Caption: {cd.OperatingSystem.Caption}
    Version: {cd.OperatingSystem.Version}
    OSArchitecture: {cd.OperatingSystem.OSArchitecture}
    CSName: {cd.OperatingSystem.CSName}

Processor:
    Name: {cd.Processor.Name}
    Description: {cd.Processor.Description}

.NET Framework:
    Version: {cd.DotNetFramework.Version}

Network Interfaces:";

                string networkInterfaces = "";

                foreach (NetworkInterface ni in cd.NetworkInterfaces)
                {
                    networkInterfaces += $@"

    Name: {ni.Name}
    MACAddress: {ni.MACAddress}
    IPAddress: {ni.IPAddress}";
                }

                coletaFormatada = coletaFormatada + networkInterfaces;

                txtConteudoArquivo.Document = new FlowDocument(new Paragraph(new Run(coletaFormatada)));
            }
        }

        private void btnSelDiretorio_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.SelectedPath = filePathFolder;

            if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePathFolder = folderDialog.SelectedPath;

                _watcher = new FileSystemWatcher(filePathFolder);

                _watcher.Filter = "ColetaDados.json";
                _watcher.EnableRaisingEvents = true;
                _watcher.NotifyFilter = NotifyFilters.FileName;
                _watcher.Created += OnCreated;
                _watcher.Deleted += OnDeleted;
            }


            ExibirDados();
        }
    }
}

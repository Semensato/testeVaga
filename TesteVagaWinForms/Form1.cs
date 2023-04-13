using Microsoft.Win32;
using System;
using System.IO;
using System.Management;
using System.Net;
using System.Text.Json;
using System.Windows.Forms;

namespace TesteVagaWinForms
{
    public partial class Form1 : Form
    {
        string filePathFolder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        string filePath = "\\ColetaDados.json";
        
        private FileSystemWatcher _watcher;

        public Form1()
        {
            InitializeComponent();

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
            btnExibirDados.Invoke(new Action(() => btnExibirDados.Enabled = true));
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            btnExibirDados.Invoke(new Action(() => btnExibirDados.Enabled = false));
            btnExibirDados.Invoke(new Action(() => txtConteudoArquivo.Text = ""));
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
                btnExibirDados.Enabled = true;
            }
            else
            {
                btnExibirDados.Enabled = false;
                txtConteudoArquivo.Text = "";
            }
                
        }

        private void btnColetarDados_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(filePathFolder + filePath)) {

                ColetaDados cd = new ColetaDados();

                string jsonString = JsonSerializer.Serialize(cd);
                
                sw.Write(jsonString);
            }

            txtConteudoArquivo.Text = "";
        }

        private void btnExibirDados_Click(object sender, EventArgs e)
        {
            txtConteudoArquivo.Text = "";

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

                foreach(NetworkInterface ni in cd.NetworkInterfaces)
                {
                    networkInterfaces += $@"

    Name: {ni.Name}
    MACAddress: {ni.MACAddress}
    IPAddress: {ni.IPAddress}";
                }

                coletaFormatada = coletaFormatada + networkInterfaces;

                txtConteudoArquivo.Text = coletaFormatada;
            }
                
        }

        private void btnSelDiretorio_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.SelectedPath = filePathFolder;

            if (folderDialog.ShowDialog() == DialogResult.OK)
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

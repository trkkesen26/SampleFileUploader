using SampleFileUploader.Models.Uploader;
using SuperSimpleTcp;
using System.Text;


namespace SampleFileUploader
{
    public partial class Form1 : Form
    {
        SimpleTcpClient? client = null;
        Uploader uploader = new Uploader();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClientConnect_Click(object sender, EventArgs e)
        {
            if (client == null)
            {
                string hostIp = String.Format("{0}.{1}.{2}.{3}:{4}", tbxHostIp01.Text, tbxHostIp02.Text, tbxHostIp03.Text, tbxHostIp04.Text, tbxHostPort.Text);
                client = new SimpleTcpClient(hostIp);
                client.Events.Connected += Connected;
                client.Events.Disconnected += Disconnected;
                client.Events.DataReceived += DataReceived;
                client.Connect();
                btnClientConnect.Text = "Disconnect";
                uploader.setClient(client);
            }
            else
            {
                if (client.IsConnected)
                {
                    client.Disconnect();
                }
                client = null;
                btnClientConnect.Text = "Connect";
                uploader.deleteClient();
            }
        }

        static void Connected(object sender, ConnectionEventArgs e)
        {
            MessageBox.Show("Connected to server!", "TCP Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        static void Disconnected(object sender, ConnectionEventArgs e)
        {
            MessageBox.Show("Disconnect from server!", "TCP Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        static void DataReceived(object sender, DataReceivedEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client != null)
            {
                if (client.IsConnected)
                {
                    client.Disconnect();
                }
            }
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            uploader.clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Yalnızca .bin dosyalarını göster
            openFileDialog.Filter = "Binary files (*.bin)|*.bin";

            // Dosya seçme penceresini göster
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen dosya yolunu al
                string filePath = openFileDialog.FileName;
                lblFilePath.Text = filePath;
                // Dosya içeriğini oku ve base64 formatına çevir
                byte[] fileBytes = File.ReadAllBytes(filePath);

                if (fileBytes.Length > 0)
                {
                    uploader.binFile = fileBytes;
                    btnStartUpload.Enabled = true;
                }
            }
        }

        private void btnStartUpload_Click(object sender, EventArgs e)
        {
            while(true)
            {
                uploader.sendNextPacked();
                while (uploader.waitResponseFlag());
                if (!uploader.keepSend) break;
            }
        }
    }
}

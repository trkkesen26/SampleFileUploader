using SampleFileUploader.Models.Uploader;
using SuperSimpleTcp;
using System.Text;
using Newtonsoft.Json;


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

        private void DataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e != null)
            {
                string str = System.Text.Encoding.Default.GetString(e.Data);
                ServerResponse? response = JsonConvert.DeserializeObject<ServerResponse>(str);
                if (response != null)
                    uploader.response = response.result;
            }
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
            openFileDialog.Filter = "Binary files (*.bin)|*.bin";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                lblFilePath.Text = filePath;

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
            while (true)
            {
                if (uploader.sendNextPacked())
                {
                    if (!uploader.waitResponseFlag())
                    {
                        MessageBox.Show("Timeout!!!", "TCP Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
                else
                {
                    MessageBox.Show("Upload Done!", "TCP Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
            }
            uploader.clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

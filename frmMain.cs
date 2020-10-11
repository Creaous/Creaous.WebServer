using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Creaous.WebServer
{
    public partial class frmMain : Form
    {
        // Create a HttpListener called 'HttpServ'.
        HttpListener HttpServ;
        // Create a string called 'PhpComplierPath'.
        string PhpCompilerPath;
        public frmMain()
        {
            InitializeComponent();
            
            if (Directory.Exists("PluginData\\Creaous.WebServer")) {
                // Set the 'PHP Complier' text box to where the complier is located.
                textBox1.Text = File.ReadAllText("PluginData\\Creaous.WebServer\\settings\\phpcomplierpath.txt");
                // Set the PHP Complier Path variable to the text box value.
                PhpCompilerPath = textBox1.Text;
            }

            // Create a new HttpListener.
            HttpServ = new HttpListener();
        }


        public string ProcessPhpPage(string phpCompilerPath, string pageFileName)
        {
            // Create a new process variable
            Process proc = new Process();
            // Set the file name to the PHP Complier path.
            proc.StartInfo.FileName = phpCompilerPath;
            // Add some arguments such as 'display errors'.
            proc.StartInfo.Arguments = "-d \"display_errors=1\" -d \"error_reporting=E_PARSE\" \"" + pageFileName + "\"";
            // Create no window.
            proc.StartInfo.CreateNoWindow = true;
            // Don't use the shell execute.
            proc.StartInfo.UseShellExecute = false;
            // Redirect the standard output.
            proc.StartInfo.RedirectStandardOutput = true;
            // Rediect the standard errors.
            proc.StartInfo.RedirectStandardError = true;
            // Start the process.
            proc.Start();
            // Create a string called 'res' to read output.
            string res = proc.StandardOutput.ReadToEnd();
            // If the string is not null,,
            if (string.IsNullOrEmpty(res))
            {
                // Read the standard error to end.
                res = proc.StandardError.ReadToEnd();
                // Display error details.
                res = "<h2 style=\"color:red;\">Error!</h2><hr/> <h4>Error Details :</h4> <pre>" + res + "</pre>";
                // Close the error.
                proc.StandardError.Close();
            }
            // If the 'res' variable starts with 'Parse',
            if (res.StartsWith("\nParse error: syntax error"))
                // Display error details.
                res = "<h2 style=\"color:red;\">Error!</h2><hr/> <h4>Error Details :</h4> <pre>" + res + "</pre>";

            // Close the output.
            proc.StandardOutput.Close();

            // Close the process.
            proc.Close();
            // Return 'res'.
            return res;
        }

        private async void btnStartHttpServ_Click(object sender, EventArgs e)
        {
            // If the HTTP server is online.
            if (HttpServ.IsListening)
            {
                try
                {
                    // Stop it.
                    HttpServ.Stop();
                    // HttpServ.Abort();
                }
                catch
                {
                    // Display the shutdown message.
                    txtHttpLog.Text += "Server has been Shutdown.\r\n";
                }
                // Set the button to 'Start Server'.
                btnStartHttpServ.Text = "Start Server";
            }
            else
            {
                // Else start the server.
                await StartServer();
            }
        }

        private async Task StartServer()
        {
            // Create a new HTTP Listener.
            HttpServ = new HttpListener();
            // Change the button text to stop/start the server.
            btnStartHttpServ.Text = "Stop Server";
            // Add the localhost url.
            HttpServ.Prefixes.Add("http://localhost:" + txtHttpPort.Value.ToString() + "/");
            // Start the server.
            HttpServ.Start();
            // Say on log.
            txtHttpLog.Text += "Start Listining on Port :" + txtHttpPort.Value + "\r\n";
            txtHttpLog.Text += "Server is Running...\r\n\r\n";
            while (true)
            {
                try
                {
                    // Get the context async.
                    var ctx = await HttpServ.GetContextAsync();

                    // Log the request.
                    txtHttpLog.Text += "Request: " + ctx.Request.Url.AbsoluteUri + "\r\n";
                    // Create a variable for the pages.
                    var page = @"PluginData/Creaous.WebServer/wwwroot" + ctx.Request.Url.LocalPath;
                    var errorpages = @"PluginData/Creaous.WebServer/wwwroot/error/";

                    // Write line the page (for testing).
                    Console.WriteLine(page);
                    // If the page exists,
                    if (File.Exists(page))
                    {
                        // Create a new string called 'file'.
                        string file;
                        // Get the extenstion.
                        var ext = new FileInfo(page);
                        if (ext.Extension == ".php")
                        {
                            // Edit the file variable to process php.
                            file = ProcessPhpPage(PhpCompilerPath, page);
                            // Send to log.
                            txtHttpLog.Text += "Processing php page...\r\n";
                        }
                        else
                        {
                            //file = File.ReadAllText(page);
                            // Setting the file to a string puts it on the page.
                            file = "Sorry, but currently HTML pages do not work.";
                        }

                        // Write the async.
                        await ctx.Response.OutputStream.WriteAsync(ASCIIEncoding.UTF8.GetBytes(file), 0, file.Length);
                        // Close the output stream.
                        ctx.Response.OutputStream.Close();
                        // Close the response.
                        ctx.Response.Close();
                        // Send the type of response to log.
                        txtHttpLog.Text += "Response: 200 OK\r\n\r\n";

                    }
                    else // If the page doesn't exist.
                    {
                        // Set the response status code to 404.
                        ctx.Response.StatusCode = 404;
                        // Process the php page for the 404.
                        var file = ProcessPhpPage(PhpCompilerPath, errorpages + "404.php");
                        // Write async to output stream.
                        await ctx.Response.OutputStream.WriteAsync(ASCIIEncoding.UTF8.GetBytes(file), 0, file.Length);
                        // Close the output stream.
                        ctx.Response.OutputStream.Close();

                        // Close the response.
                        ctx.Response.Close();
                        // Send the type of response to log.
                        txtHttpLog.Text += "Response: 404 Not Found\r\n\r\n";

                    }
                }
                catch (Exception ex)
                {
                    // Send 'Exception' to the log.
                    txtHttpLog.Text += "\r\nException: Server Stopped!!!\r\n\r\n";
                    // txtHttpLog.Text += "\r\nException: " + ex.Message + "\r\n\r\n";
                    break;
                }
                txtHttpLog.Select(0, 0);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Save the PHP Complier text box to a file.
            File.WriteAllText("PluginData\\Creaous.WebServer\\settings\\phpcomplierpath.txt", textBox1.Text);
            // Show a message box.
            MessageBox.Show("You must close this form to apply all the changes!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Hide this form.
            this.Hide();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            if (!File.Exists("PluginData\\Creaous.WebServer.zip"))
            {
                using (var client = new WebClient())
                {
                    Directory.CreateDirectory("PluginData");
                    client.DownloadFile("http://github.com/Creaous/Creaous.WebServer/raw/main/Other%20Stuff/PluginData.zip", "Creaous.WebServer.zip");
                }
            }
            ZipFile.ExtractToDirectory("Creaous.WebServer.zip", "PluginData");
            File.Delete("Creaous.WebServer.zip");
        }
    }
}

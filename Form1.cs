using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace DictionnaryGen
{
    public partial class Form1 : Form
    {
        private String inputFilePath;
        private String outputFilePath;
        private double permNumber;
        private double permDone;
        private double endFileSize;
        private List<String> permList = new List<string>();
        private bool inputPathSet = false;
        private bool outputPathSet = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void browseInputButton_Click(object sender, EventArgs e)
        {
            inputFilePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\temp\\";//Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.AutoUpgradeEnabled = true;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    inputFilePath = openFileDialog.FileName;
                    inputPathTextbox.Text = inputFilePath;
                }
            }
        }
        private void browseOutputButton_Click(object sender, EventArgs e)
        {
            outputFilePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\temp\\"; //Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
                openFileDialog.Filter = "Text files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 1;
                openFileDialog.CheckFileExists = false;
                openFileDialog.AutoUpgradeEnabled = true;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    outputFilePath = openFileDialog.FileName;
                    outputPathTextbox.Text = outputFilePath;
                }
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            try
            {
                var inputFileStream = File.OpenRead(inputFilePath);
                bool continueBigFIleAlert = true;

                if (!File.Exists(outputFilePath))
                {
                    StreamWriter outputSW = File.CreateText(outputFilePath);
                    outputSW.Dispose();
                    outputSW.Close();
                }
                else
                {
                    StreamWriter outputSW = new StreamWriter(outputFilePath);
                    outputSW.Write("");
                    outputSW.Dispose();
                    outputSW.Close();
                }

                using (StreamReader reader = new StreamReader(inputFileStream))
                {
                    toolStripStatusLabel1.Text = "Generating list";
                    permNumber = 0;
                    permDone = 0;
                    endFileSize = 0;
                    String line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        line = RemoveSpecialCharacters(line);
                        double permPossible = countPossibilities(line.Length);
                        if (line.Length <= 32 && line.Length>0)
                        {
                            permNumber += permPossible;
                            endFileSize += permPossible * (double)line.Length;
                        }
                    }

                    if (permNumber == 0) permNumber = 1;

                    if (endFileSize >= 1000000000)
                    {
                        DialogResult result = MessageBox.Show("Be careful, the resulting file will be bigger than 1 GB. Are you sure you want to continue ?\n"+ 
                            "Words longer than 32 characters will be skipped\n"+
                            "\nProjected filesize : " + endFileSize/1000000000 + " GB","Possible big resulting file",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                            continueBigFIleAlert = true;
                        else
                            continueBigFIleAlert = false;
                    }
                    if (continueBigFIleAlert == true)
                    {
                        inputFileStream.Position = 0;
                        reader.DiscardBufferedData();
                        while ((line = reader.ReadLine()) != null)
                        {
                            line = RemoveSpecialCharacters(line);
                            if (line.Length<=32)
                                permute(line);
                        }
                        flushPermutations();
                        openFileButton.Enabled = true;
                        toolStripStatusLabel1.Text = "Yataa !";
                    }
                    else
                        MessageBox.Show("Operation cancelled");
                }
                
            }
            catch (ArgumentNullException ArgNullEx)
            {
                //toolStripStatusLabel1.Text = "Incorrect file path";
                MessageBox.Show(ArgNullEx.Message);

            }
            catch (OutOfMemoryException OomEx)
            {
                System.Windows.Forms.MessageBox.Show("Not enough memory to perform the operation");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-ZÀ-Þà-þ]+", "", RegexOptions.Compiled);
        }

        private void permute(String input)
        {
            int n = input.Length;
            permDone = 0;
            // Number of permutations is 2^n 
            double max = Math.Pow(2,n);

            // Converting string 
            // to lower case 
            input = input.ToLower();

            // Using all subsequences  
            // and permuting them 
            for (int i = 0; i < max; i++)
            {
                char[] combination = input.ToCharArray();

                // If j-th bit is set, we  
                // convert it to upper case 
                for (int j = 0; j < n; j++)
                {
                    if (((i >> j) & 1) == 1)
                    {
                        combination[j] = (char)(combination[j] - 32);
                    }
                }
                // Printing current combination 
                storePermutation(combination);
                permDone++;
                toolStripProgressBar1.Value = 100 * (int)permDone / (int)permNumber;
            }
        }

        private void storePermutation(char[] combination)
        {
            permList.Add(new  String(combination));
            if(permList.Count == 1000)
            {
                flushPermutations();
            }
          
        }

        private void flushPermutations()
        {
            StreamWriter fs = File.AppendText(outputFilePath);
            foreach (String permutation in permList)
            {
                fs.WriteLine(permutation);
            }
            fs.Dispose();
            fs.Close();
            permList.Clear();
        }


        private double countPossibilities(int cLength)
        {
            return ((double)Math.Pow(2, cLength));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text File|*.txt";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                StreamWriter fs = new StreamWriter(saveFileDialog1.OpenFile());
                fs.Write(outputPathTextbox.Text);
                fs.Dispose();
                fs.Close();
            }
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(outputFilePath);
        }

        private void inputPathTextbox_TextChanged(object sender, EventArgs e)
        {
            this.inputFilePath = inputPathTextbox.Text;
            this.inputPathSet = !string.IsNullOrWhiteSpace(this.inputFilePath);
            this.generateButton.Enabled = (outputPathSet && inputPathSet);
        }
        private void outputPathTextbox_TextChanged(object sender, EventArgs e)
        {
            this.outputFilePath = outputPathTextbox.Text;
            this.outputPathSet = !string.IsNullOrWhiteSpace(this.outputFilePath);
            this.generateButton.Enabled = (outputPathSet & inputPathSet);
        }
    }
}
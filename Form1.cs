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
        public Form1()
        {
            InitializeComponent();
        }
        private String fileContent;
        private String filePath;
        private int permNumber;
        private int permDone;

        private void button1_Click(object sender, EventArgs e)
        {
            fileContent = string.Empty;
            filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    textBox2.Text = filePath;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var fileStream = File.OpenRead(filePath);
                toolStripProgressBar1.Enabled = true;
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    toolStripStatusLabel1.Text = "Loading file";
                    //fileContent = reader.ReadToEnd();
                    //fileContent = RemoveSpecialCharacters(fileContent);
                    permNumber = 0;
                    permDone = 0;
                    String line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        int permPossible = countPossibilities(line.Length);
                        permNumber += permPossible;
                    }
                    fileStream.Position = 0;
                    reader.DiscardBufferedData();
                    while ((line = reader.ReadLine()) != null)
                    {
                        permute(line);
                    }
                    toolStripStatusLabel1.Text = "File loaded !";
                }
            }
            catch(ArgumentNullException Ex)
            {
                toolStripStatusLabel1.Text = "Chemin de fichier incorrect";

            }
        }

        private static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9áàâäãåçéèêëíìîïñóòôöõúùûüýÿæœÁÀÂÄÃÅÇÉÈÊËÍÌÎÏÑÓÒÔÖÕÚÙÛÜÝŸÆŒ\n\r]+", "", RegexOptions.Compiled);
        }

        private void permute(String input)
        {
            int n = input.Length;

            // Number of permutations is 2^n 
            int max = 1 << n;

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
                textBox1.AppendText(new String(combination));
                textBox1.AppendText(Environment.NewLine);
                permDone++;
                toolStripProgressBar1.Value = (100 * permDone)/permNumber;
            }
        }

        private int countPossibilities(int cLength)
        {
            return((int)Math.Pow(2,(double) cLength));
        }
        private bool saveFile()
        {
            
            return true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

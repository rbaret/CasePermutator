namespace DictionnaryGen
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.browseInputButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.inputPathTextbox = new System.Windows.Forms.TextBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.outputPathTextbox = new System.Windows.Forms.TextBox();
            this.browseOutputButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 119);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(498, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 16);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // browseInputButton
            // 
            this.browseInputButton.Location = new System.Drawing.Point(412, 22);
            this.browseInputButton.Name = "browseInputButton";
            this.browseInputButton.Size = new System.Drawing.Size(67, 20);
            this.browseInputButton.TabIndex = 2;
            this.browseInputButton.Text = "Browse...";
            this.browseInputButton.UseVisualStyleBackColor = true;
            this.browseInputButton.Click += new System.EventHandler(this.browseInputButton_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.SelectedPath = "E:\\Donnees\\Richard\\Documents";
            // 
            // inputPathTextbox
            // 
            this.inputPathTextbox.Location = new System.Drawing.Point(83, 22);
            this.inputPathTextbox.Name = "inputPathTextbox";
            this.inputPathTextbox.Size = new System.Drawing.Size(323, 20);
            this.inputPathTextbox.TabIndex = 3;
            this.inputPathTextbox.TextChanged += new System.EventHandler(this.inputPathTextbox_TextChanged);
            // 
            // generateButton
            // 
            this.generateButton.Enabled = false;
            this.generateButton.Location = new System.Drawing.Point(20, 88);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 4;
            this.generateButton.Text = "Generate !";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // outputPathTextbox
            // 
            this.outputPathTextbox.Location = new System.Drawing.Point(83, 48);
            this.outputPathTextbox.Name = "outputPathTextbox";
            this.outputPathTextbox.Size = new System.Drawing.Size(323, 20);
            this.outputPathTextbox.TabIndex = 6;
            this.outputPathTextbox.TextChanged += new System.EventHandler(this.outputPathTextbox_TextChanged);
            // 
            // browseOutputButton
            // 
            this.browseOutputButton.Location = new System.Drawing.Point(412, 48);
            this.browseOutputButton.Name = "browseOutputButton";
            this.browseOutputButton.Size = new System.Drawing.Size(67, 20);
            this.browseOutputButton.TabIndex = 5;
            this.browseOutputButton.Text = "Browse...";
            this.browseOutputButton.UseVisualStyleBackColor = true;
            this.browseOutputButton.Click += new System.EventHandler(this.browseOutputButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Input file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Output file";
            // 
            // openFileButton
            // 
            this.openFileButton.Enabled = false;
            this.openFileButton.Location = new System.Drawing.Point(102, 88);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(75, 23);
            this.openFileButton.TabIndex = 9;
            this.openFileButton.Text = "Open file";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 141);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputPathTextbox);
            this.Controls.Add(this.browseOutputButton);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.inputPathTextbox);
            this.Controls.Add(this.browseInputButton);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "Case Permutator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button browseInputButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox inputPathTextbox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.TextBox outputPathTextbox;
        private System.Windows.Forms.Button browseOutputButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button openFileButton;
    }
}


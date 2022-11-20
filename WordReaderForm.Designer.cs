namespace WordCounter;

partial class WordCounterForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.btn_uploadFile = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.resultLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_uploadFile
            // 
            this.btn_uploadFile.Location = new System.Drawing.Point(12, 39);
            this.btn_uploadFile.Name = "btn_uploadFile";
            this.btn_uploadFile.Size = new System.Drawing.Size(238, 53);
            this.btn_uploadFile.TabIndex = 0;
            this.btn_uploadFile.Text = "Upload file";
            this.btn_uploadFile.UseVisualStyleBackColor = true;
            this.btn_uploadFile.Click += new System.EventHandler(this.uploadFileClick);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(256, 39);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(50, 53);
            this.btn_stop.TabIndex = 1;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // listView
            // 
            this.listView.Location = new System.Drawing.Point(12, 159);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(294, 279);
            this.listView.TabIndex = 2;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.sortColumn);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 95);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(291, 26);
            this.progressBar1.Step = 2;
            this.progressBar1.TabIndex = 3;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // resultLabel
            // 
            this.resultLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(114, 136);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(83, 20);
            this.resultLabel.TabIndex = 4;
            this.resultLabel.Text = "Upload file";
            this.resultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WordCounterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 450);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_uploadFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "WordCounterForm";
            this.Text = "WordCounter";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Button btn_uploadFile;
    private Button btn_stop;
    private ListView listView;
    private ProgressBar progressBar1;
    private Label resultLabel;
}

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WordCounter;

public partial class WordCounterForm : Form
{
    private int highestPercentageReached = 0;
    private ListViewColumnSorter lvwColumnSorter;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    public WordCounterForm()
    {
        InitializeComponent();
        InitializeBackgroundWorker();
        InitializeBackgroundWorker();
        InitListView();
    }

    private void InitializeBackgroundWorker()
    {
        backgroundWorker1.DoWork +=
            new DoWorkEventHandler(backgroundWorker1_DoWork);
        backgroundWorker1.RunWorkerCompleted +=
            new RunWorkerCompletedEventHandler(
        backgroundWorker1_RunWorkerCompleted);
        backgroundWorker1.ProgressChanged +=
            new ProgressChangedEventHandler(
        backgroundWorker1_ProgressChanged);
    }

    private void InitListView()
    {
        //Clear all
        listView.Items.Clear();
        listView.Columns.Clear();
        //Properties
        listView.View = View.Details;
        listView.GridLines = true;
        listView.FullRowSelect = true;
        //Add columns
        listView.Columns.Add("Word", 150);
        listView.Columns.Add("Occurences", 150);
        lvwColumnSorter = new ListViewColumnSorter();
        this.listView.ListViewItemSorter = lvwColumnSorter;
    }
    private void uploadFileClick(object sender, EventArgs e)
    {
        this.btn_uploadFile.Enabled = false;
        this.btn_stop.Enabled = true;

        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Text Documents (*.txt)|*.txt";
        String filePath = String.Empty;
        DialogResult result = openFileDialog.ShowDialog();
        if (result == DialogResult.OK)
        {
            filePath = openFileDialog.FileName;
            highestPercentageReached = 0;
            resultLabel.Text = "Parsing file";
            backgroundWorker1.RunWorkerAsync(filePath);
        }
        else if (result == DialogResult.Cancel)
        {
            this.btn_uploadFile.Enabled = true;
            this.btn_stop.Enabled = false;
        }

    }


    private void stopButton_Click(System.Object sender,
    System.EventArgs e)
    {
        this.backgroundWorker1.CancelAsync();
        btn_stop.Enabled = false;
    }
    private void backgroundWorker1_DoWork(object sender,
            DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
        e.Result = ParseText((string)e.Argument, worker, e);
    }

    private void backgroundWorker1_RunWorkerCompleted(
            object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            MessageBox.Show(e.Error.Message);
        }
        else if (e.Cancelled)
        {
            resultLabel.Text = "Canceled";
        }
        else
        {
            resultLabel.Text = "Generating list";
            List<WordCounter> words = e.Result as List<WordCounter>;
            InitListView();
            foreach (WordCounter word in words)
            {
                String[] row = new String[] { word.word, word.occurences.ToString() };
                listView.Items.Add(new ListViewItem(row));
            }
            resultLabel.Text = "Success";
        }
        btn_uploadFile.Enabled = true;
        btn_stop.Enabled = false;
    }

    private void backgroundWorker1_ProgressChanged(object sender,
            ProgressChangedEventArgs e)
    {
        this.progressBar1.Value = e.ProgressPercentage;
    }

    List<WordCounter> ParseText(string filePath, BackgroundWorker worker, DoWorkEventArgs e)
    {
        String result = String.Empty;
        String[] wordList = new string[] { };
        List<WordCounter> words = new List<WordCounter>();
        Boolean steamReaderRun = true;
        using (StreamReader sr = new StreamReader(filePath))
        {
            string line = string.Empty;
            Stream baseStream = sr.BaseStream;
            long length = baseStream.Length;

            while ((line = sr.ReadLine()) != null && steamReaderRun)
            {

                wordList = line.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in wordList)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        worker.ReportProgress(0);
                        resultLabel.Text = "Canceling";
                        steamReaderRun = false;
                        break;
                    }
                    else
                    {
                        WordCounter wordFound = words.Find(x => x.word == word);

                        if (wordFound == null)
                        {
                            words.Add(new WordCounter(word, 1));
                        }
                        else
                        {
                            wordFound.occurences++;
                        }
                    }
                }
                int percentComplete = Convert.ToInt32((double)baseStream.Position / length * 100);
                if (percentComplete > highestPercentageReached)
                {
                    highestPercentageReached = percentComplete;
                    worker.ReportProgress(percentComplete);
                }
            }
        }
        return words;
    }

    private void sortColumn(object sender, ColumnClickEventArgs e)
    {
        if (e.Column == this.lvwColumnSorter.SortColumn)
        {
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
            }
        }
        else
        {
            lvwColumnSorter.SortColumn = e.Column;
            lvwColumnSorter.Order = SortOrder.Descending;
        }
        this.listView.Sort();
    }
}

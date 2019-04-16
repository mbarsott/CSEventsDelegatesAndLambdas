﻿using System.Threading;
using System.Windows.Forms;

namespace ThreadsAndDelegates
{
    public partial class AsyncGood : Form
    {
        delegate void StartProcessDelegate(int val);

        delegate void ShowProgressDelegate(int val);

        public AsyncGood()
        {
            InitializeComponent();
        }

        public static void Main()
        {
            Application.Run(new AsyncGood());
        }

        private void StartButton_Click(object sender, System.EventArgs e)
        {
            StartProcessDelegate progDel = new StartProcessDelegate(StartProcess);
            progDel.BeginInvoke(100, null, null);
            MessageBox.Show("Done with operation!!");

        }

        //Called Asynchronously
        private void StartProcess(int max)
        {
            ShowProgress(0);
            for (int i = 0; i <= max; i++)
            {
                Thread.Sleep(10);
                ShowProgress(i);
            }
        }

        private void ShowProgress(int i)
        {
            // This is hit if a background thread calls ShowProgress()  
            if (lblOutput.InvokeRequired)
            {
                var del = new ShowProgressDelegate(ShowProgress);
                this.BeginInvoke(del, new object[] { i });
            }
            else
            {
                lblOutput.Text = i.ToString();
                pbStatus.Value = i;
            }
        }

    }
}

using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace FormTerminal
{
    public partial class Form1 : Form
    {
        enum mode {
            normal,
            locked,
            userinput
        }

        secretPhrases   phrases         = new secretPhrases("exit", "4 8 15 16 23 42");
        int             countdown       = 0;
        int             lockedSize      = 3;
        string          stringInit      = ">: ";
        int             lockCountdown   = 30;
        string          positionMarker  = "█";
        string          fileWinner      = "C:\\temp\\winner.txt";
        string          fileConfig      = "C:\\temp\\terminal.cfg";
        string          winner;
        mode            mMode;

        public Form1() {
            WindowState = FormWindowState.Maximized;
            Cursor.Hide();
            InitializeComponent();
        }

        private void wrongCodeFound() {
            text.Text           = "Wrong Code. Console is locked for " + lockCountdown + " seconds";
            text_cursor.Text    = text.Text;
            countdown           = lockCountdown;
            timer2.Enabled      = true;
            mMode               = mode.locked;
        }

        private void secretCodeFound() {
            timer2.Enabled      = false;
            text.Text           = "Input Correct. Type in your user-id: ";
            text_cursor.Text    = text.Text + positionMarker;
            lockedSize          = text.Text.Length;
            mMode               = mode.userinput;
        }

        private void userFinished() {
            System.IO.StreamWriter file = new System.IO.StreamWriter(fileWinner, true);
            file.WriteLine(DateTime.Now.ToString() + " | " + winner + "\n");
            file.Close();

            text.Text           = text_cursor.Text = "Input Correct. All praise for User " + winner;
            text_cursor.Visible = false;
            mMode               = mode.locked;
            timer1.Enabled      = false;
            timer2.Enabled      = false;
        }

        private void exitToExplorer() {
            Process P = new Process();
            P.StartInfo.FileName = "explorer.exe";
            P.Start();

            Close();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (mMode == mode.locked)
                return;

            string input = text.Text.Remove(0, lockedSize);

            if (e.KeyCode == Keys.Enter)
            {
                if (mMode == mode.normal)
                {
                    if (input.CompareTo(phrases.secretMessage) == 0)
                    {
                        secretCodeFound();
                        return;
                    }

                    else if (input.CompareTo(phrases.exitExplorer) == 0)
                        exitToExplorer();

                    else
                    {
                        wrongCodeFound();
                        return;
                    }
                }
                else if (mode.userinput == mMode)
                {
                    winner = input;
                    userFinished();
                }
            }

            // letters
            else if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
            {
                if (e.Shift)
                    text.Text += e.KeyCode.ToString().ToUpper();
                else
                    text.Text += e.KeyCode.ToString().ToLower();
            }

            // space key
            else if (e.KeyCode == Keys.Space)
            {
                text.Text += " ";
            }

            // numbers
            else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                text.Text += (int)(e.KeyCode - Keys.D0);
            }

            // numpad
            else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                text.Text += (int)(e.KeyCode - Keys.NumPad0);
            }

            // comma
            else if (e.KeyCode >= Keys.Decimal)
            {
                text.Text += " ";
            }

            // backspace
            else if (e.KeyCode == Keys.Back && text.Text.Length > lockedSize)
            {
                text.Text = text.Text.Remove(text.Text.Length - 1);
            }

            text_cursor.Text = text.Text + positionMarker;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (mMode != mode.locked)
                text_cursor.Visible = !text_cursor.Visible;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (countdown > 0)
            {
                countdown--;
                text.Text           = "Wrong Code. Console is locked for " + countdown + " seconds";
                text_cursor.Text    = text.Text;
            }
            else
            {
                text.Text           = stringInit;
                text_cursor.Text    = text.Text + "█";
                timer1.Enabled      = true;
                timer2.Enabled      = false;
                mMode               = mode.normal;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            phrases.loadFromFile(fileConfig);
        }
    }

    class secretPhrases
    {
        public string exitExplorer;
        public string secretMessage;

        public secretPhrases(string exitExplorer, string secretMessage)
        {
            this.exitExplorer = exitExplorer;
            this.secretMessage = secretMessage;
        }

        public void loadFromFile(string filename)
        {
            try
            {
                System.IO.StreamReader cfgFile = new System.IO.StreamReader(filename);
                while (!cfgFile.EndOfStream)
                {
                    string[] param = cfgFile.ReadLine().Split(':');
                    if (param.Length <= 1)
                    {
                        continue;
                    }

                    switch (param[0])
                    {
                        case "exitKey":
                            exitExplorer = param[1];
                            break;
                        case "secret":
                            secretMessage = param[1];
                            break;
                        default:
                            break;
                    }
                }

                cfgFile.Close();
            }
            catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }
    };
}

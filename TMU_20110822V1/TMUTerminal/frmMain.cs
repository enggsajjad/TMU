using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Drawing.Printing;
using System.IO.Ports;
using TMU_Terminal.Properties;
using System.Threading;

namespace TMU_Terminal
{
    public partial class frmMain : Form
    {
        int rxState = 0;
        String rtFileName = "";
        string user = "";
        string[] ExprDate = new string [100];
        int s = 0;
        
        
        byte[] cmd = new byte[3];
        string[] exprTime = new string[400];
        
        TextBox[] txtSignatures = new TextBox[5];
        CheckBox[] chkSignatures = new CheckBox[5];

        ExprSettings stng = ExprSettings.Default;
        public frmMain()
        {
            stng.Reload();
            
            InitializeComponent();
            // Set the Paper Size Settings Default to A4, Portrait
            PaperSize ps = new PaperSize();
            ps.RawKind = (int)PaperKind.A4;
            docPrint.DefaultPageSettings.PaperSize = ps;
            docPrint.DefaultPageSettings.Landscape = false;
            // Initialze the Component Values
            
            
            txtTestName.Text = stng.TestName;
            txtWeapon.Text = stng.WeaponNo;
            
            txtSig1.Text = stng.Sig1;
            txtSig2.Text = stng.Sig2;
            txtSig3.Text = stng.Sig3;
            txtSig4.Text = stng.Sig4;
            txtSig5.Text = stng.Sig5;
            chkSig1.Checked = stng.ChkSig1;
            chkSig2.Checked = stng.ChkSig2;
            chkSig3.Checked = stng.ChkSig3;
            chkSig4.Checked = stng.ChkSig4;
            chkSig5.Checked = stng.ChkSig5;
            user = stng.user;

            // Determain if the list of com port names has changed since last checked
            string selected = RefreshComPortList(cmbPortName.Items.Cast<string>(), cmbPortName.SelectedItem as string, comport.IsOpen);
            
            // If there was an update, then update the control showing the user the list of port names
            if (!String.IsNullOrEmpty(selected))
            {
                cmbPortName.Items.Clear();
                cmbPortName.Items.AddRange(OrderedPortNames());
                cmbPortName.SelectedItem = selected;
            }
            
            // If it is still avalible, select the last com port used
            if (cmbPortName.Items.Contains(stng.PortName)) cmbPortName.Text = stng.PortName;
            else if (cmbPortName.Items.Count > 0) cmbPortName.SelectedIndex = cmbPortName.Items.Count - 1;
            else
            {
                MessageBox.Show(this, "There are no COM Ports detected on this computer.\nPlease install a COM Port and restart this app.", "No COM Ports Installed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            // Make Array of Check Box and Text Boxes for Signatures
            txtSignatures[0] = txtSig1;
            txtSignatures[1] = txtSig2;
            txtSignatures[2] = txtSig3;
            txtSignatures[3] = txtSig4;
            txtSignatures[4] = txtSig5;
            chkSignatures[0] = chkSig1;
            chkSignatures[1] = chkSig2;
            chkSignatures[2] = chkSig3;
            chkSignatures[3] = chkSig4;
            chkSignatures[4] = chkSig5;
            // Set Log File Name
            String rtPath = @"C:\";
            rtPath = System.IO.Path.Combine(rtPath, "LogTMU");
            System.IO.Directory.CreateDirectory(rtPath);
            //System.DateTime dt = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            DateTime dt = DateTime.Now;
            
            rtFileName = System.IO.Path.Combine(rtPath,
                    dt.Year.ToString() + dt.Month.ToString("00") + dt.Day.ToString("00") +
                    dt.Hour.ToString("00") + dt.Minute.ToString("00") + dt.Second.ToString("00"));
            
            InputBoxResult test =  InputBox.Show ("Enter the User Name for the Experiment \n i.e. the title for the printing","User Name",user);
            if (test.ReturnCode == DialogResult.OK)
            {
                user = test.Text;
            }
        }
        private string[] OrderedPortNames()
        {
            // Just a placeholder for a successful parsing of a string to an integer
            int num;

            // Order the serial port names in numberic order (if possible)
            return SerialPort.GetPortNames().OrderBy(a => a.Length > 3 && int.TryParse(a.Substring(3), out num) ? num : 0).ToArray();
        }

        private string RefreshComPortList(IEnumerable<string> PreviousPortNames, string CurrentSelection, bool PortOpen)
        {
            // Create a new return report to populate
            string selected = null;

            // Retrieve the list of ports currently mounted by the operating system (sorted by name)
            string[] ports = SerialPort.GetPortNames();

            // First determain if there was a change (any additions or removals)
            bool updated = PreviousPortNames.Except(ports).Count() > 0 || ports.Except(PreviousPortNames).Count() > 0;

            // If there was a change, then select an appropriate default port
            if (updated)
            {
                // Use the correctly ordered set of port names
                ports = OrderedPortNames();

                // Find newest port if one or more were added
                string newest = SerialPort.GetPortNames().Except(PreviousPortNames).OrderBy(a => a).LastOrDefault();

                // If the port was already open... (see logic notes and reasoning in Notes.txt)
                if (PortOpen)
                {
                    if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                    else if (!String.IsNullOrEmpty(newest)) selected = newest;
                    else selected = ports.LastOrDefault();
                }
                else
                {
                    if (!String.IsNullOrEmpty(newest)) selected = newest;
                    else if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                    else selected = ports.LastOrDefault();
                }
            }

            // If there was a change to the port list, return the recommended default selection
            return selected;
        }
        private void RefreshComPortList()
        {
            // Determain if the list of com port names has changed since last checked
            string selected = RefreshComPortList(cmbPortName.Items.Cast<string>(), cmbPortName.SelectedItem as string, comport.IsOpen);

            // If there was an update, then update the control showing the user the list of port names
            if (!String.IsNullOrEmpty(selected))
            {
                cmbPortName.Items.Clear();
                cmbPortName.Items.AddRange(OrderedPortNames());
                cmbPortName.SelectedItem = selected;
            }
        }
        
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            dlgOpen.InitialDirectory = @"C:\Open TMU Files";

            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(this.dlgOpen.FileName,
                       FileMode.Open, FileAccess.Read, FileShare.Read);
                BinaryReader br = new BinaryReader(fs);

                
                
                txtTestName.Text  = br.ReadString ();
                                              
                txtSig1.Text  = br.ReadString ();
                txtSig2.Text  = br.ReadString ();
                txtSig3.Text = br.ReadString (); 
                txtSig4.Text  = br.ReadString ();
                txtSig5.Text  = br.ReadString ();
                chkSig1.Checked = br.ReadBoolean ();
                chkSig2.Checked = br.ReadBoolean ();
                chkSig3.Checked = br.ReadBoolean ();
                chkSig4.Checked = br.ReadBoolean ();
                chkSig5.Checked = br.ReadBoolean ();
                int sFromFile = br.ReadInt32 ();
                for (int i = 0; i < sFromFile; i++)
                    ExprDate[i] = br.ReadString();
                s = 0;
                for (int i = 0; i < (5 * sFromFile); i++)
                {
                    exprTime[i] = br.ReadString();
                    if(i%5 == 4)  UpdateResults ();
                }
                br.Close();
                fs.Close();
            }

        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            // Display the Save dialog box and find out if the user clicked OK
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                // Create a new file using the name of the Save dialog box
                FileStream fs = new FileStream(dlgSave.FileName,
                           FileMode.Create, FileAccess.Write, FileShare.Write);
                BinaryWriter br = new BinaryWriter(fs);

                // Write each value in the file
                
                
                br.Write(txtTestName.Text);
                
                br.Write(txtSig1.Text);
                br.Write(txtSig2.Text);
                br.Write(txtSig3.Text);
                br.Write(txtSig4.Text);
                br.Write(txtSig5.Text);
                br.Write(chkSig1.Checked);
                br.Write(chkSig2.Checked);
                br.Write(chkSig3.Checked);
                br.Write(chkSig4.Checked);
                br.Write(chkSig5.Checked);

                br.Write(s);

                for (int i = 0; i < s; i++)
                    br.Write(ExprDate[i]);

                for (int i = 0; i < (5 * s); i++)
                {
                    br.Write (exprTime [i]);
                }

                br.Close();
                fs.Close();
            }

        }
        private void PrintColumn(System.Drawing.Printing.PrintPageEventArgs ee,int Col)
        {
            // Print the Column Header
            System.Drawing.Font fnt = new Font("Verdana", 12, FontStyle.Regular);
            ee.Graphics.DrawString("Test", fnt, Brushes.Black, 35 , 27);
            ee.Graphics.DrawString("TMU-01 Results in ms", fnt, Brushes.Black, 70, 27);
            ee.Graphics.DrawString("Time", fnt, Brushes.Black, 35, 32);
            ee.Graphics.DrawString("Ch#1", fnt, Brushes.Black, 50, 32);//57 80 103 126
            ee.Graphics.DrawString("Ch#2", fnt, Brushes.Black, 70, 32);
            ee.Graphics.DrawString("Ch#3", fnt, Brushes.Black, 90, 32);
            ee.Graphics.DrawString("Ch#4", fnt, Brushes.Black, 110, 32);
            ee.Graphics.DrawString("Jitter", fnt, Brushes.Black, 128, 32);//128

            fnt = new Font("Courier New", 12, FontStyle.Regular);

            int rPos = 0;
            for (int i = 0; i < s; i++)
            {
                rPos = 50 + i * 14;
                ee.Graphics.DrawString(ExprDate[i], fnt, Brushes.Black, 33, rPos);
                ee.Graphics.DrawString(exprTime [i * 5 + 0], fnt, Brushes.Black, 50, rPos);
                ee.Graphics.DrawString(exprTime [i * 5 + 1], fnt, Brushes.Black, 70, rPos);
                ee.Graphics.DrawString(exprTime [i * 5 + 2], fnt, Brushes.Black, 90, rPos);
                ee.Graphics.DrawString(exprTime [i * 5 + 3], fnt, Brushes.Black, 110, rPos);
                ee.Graphics.DrawString(exprTime[i * 5 + 4], fnt, Brushes.Black, 130, rPos);
            }
            
         }
        private void OfficialUse(System.Drawing.Printing.PrintPageEventArgs ee)
        {
            System.Drawing.Font fnt = new Font("Times New Roman", 12, FontStyle.Regular);
            ee.Graphics.DrawString("Test:", fnt,Brushes.Black, 146, 40);
            ee.Graphics.DrawString("Weapon:", fnt, Brushes.Black, 146, 60);
            ee.Graphics.DrawString("Date:", fnt, Brushes.Black, 146, 80);

            fnt = new Font("Courier New", 12, FontStyle.Regular     );
            ee.Graphics.DrawString(txtTestName.Text, fnt, Brushes.Black, 180 - ee.Graphics.MeasureString(txtTestName.Text, fnt).Width/2, 40);//176
            ee.Graphics.DrawString(txtWeapon .Text , fnt, Brushes.Black, 180 - ee.Graphics.MeasureString(txtWeapon .Text , fnt).Width / 2, 60);
            ee.Graphics.DrawString(DateTime.Now.ToString("d-MMM-y"), fnt, Brushes.Black, 180 - ee.Graphics.MeasureString("01-FEB-11", fnt).Width / 2, 80);
            // draw horizontal line as underlines
            ee.Graphics.DrawLine(new Pen(Color.Black, 0.25f), 162, 44, 193, 44);//158
            ee.Graphics.DrawLine(new Pen(Color.Black, 0.25f), 162, 64, 193, 64);
            ee.Graphics.DrawLine(new Pen(Color.Black, 0.25f), 162, 84, 193, 84);
           
            // draw signature lines and text
            fnt = new Font("Times New Roman", 10, FontStyle.Italic   );
            for (int i=0;i<5;i++)
            {
                if(chkSignatures [i].Checked )
                {
                    ee.Graphics.DrawLine(new Pen(Color.Black, 0.25f), 154, 125+i*25, 184, 125+i*25);
                    ee.Graphics.DrawString(txtSignatures [i].Text ,fnt,Brushes.Black, 
                        169 - ee.Graphics.MeasureString (txtSignatures [i].Text,fnt).Width/2,
                        126+i*25);
                }
            }
        }
        private void PageSetup(System.Drawing.Printing.PrintPageEventArgs ee, int PageNo)
        {
            // Draw the table
            ee.Graphics.DrawRectangle(new Pen(Color.Black, 0.25f), 20, 25, 176, 250);
            // Draw the vertical lines
            ee.Graphics.DrawLine(new Pen(Color.Black, 0.25f), 30, 25, 30, 275);
            ee.Graphics.DrawLine(new Pen(Color.Black, 0.25f), 50, 25, 50, 275);
            ee.Graphics.DrawLine(new Pen(Color.Black, 0.25f), 144, 25, 144, 275);
            // draw horizontal line
            ee.Graphics.DrawLine(new Pen(Color.Black, 0.25f), 20, 38, 144, 38);
            // Draw the Heading
            System.Drawing.Font fnt = new Font("Verdana", 14, FontStyle.Bold  );
            //ee.Graphics.DrawString(user.ToUpper, fnt, Brushes.Black, 60, 15);
            
            ee.Graphics.DrawString(user.ToUpper (), fnt, Brushes.Black, 75-user.Length/2 , 15);
            // Draw the Serial No in Column 0
            fnt = new Font("Verdana", 12, FontStyle.Regular );
            ee.Graphics.DrawString("Sr", fnt, Brushes.Black, 22, 29);
            fnt = new Font("Courier New", 12, FontStyle.Regular);
            for (int i=0; i < s; i++)
            {
                ee.Graphics.DrawString((i+1).ToString ("00"), fnt, Brushes.Black, 22, 50 + i * 14);
            }
            // Draw the Page No
            fnt = new Font("Times New Roman", 8, FontStyle.Regular );
            //ee.Graphics.DrawString("Page" + (PageNo+1).ToString ()+"/"+ TotPages.ToString ()+ ": by Sajjad", fnt, Brushes.Black, 165, 286);
            ee.Graphics.DrawString("Page1/1: by Sajjad", fnt, Brushes.Black, 165, 286);
            ee.Graphics.DrawString("*"+txtComments .Text , fnt, Brushes.Black, 20, 276);
        }

        private void docPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;


            OfficialUse(e);
            PageSetup(e, 0);
            PrintColumn(e, 0);
   
        }

        private void mnuFilePrint_Click(object sender, EventArgs e)
        {
            if (dlgPrint.ShowDialog() == DialogResult.OK)
            {
                docPrint.Print();
            }

        }

        private void mnuFilePageSetup_Click(object sender, EventArgs e)
        {
            dlgPageSetup.ShowDialog();
        }


        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Evaluation_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save the Last Settings
            stng.PortName = cmbPortName.Text;
            
            
            stng.TestName = txtTestName.Text;
            stng.WeaponNo = txtWeapon.Text;
            stng.Sig1 = txtSig1.Text;
            stng.Sig2 = txtSig2.Text;
            stng.Sig3 = txtSig3.Text;
            stng.Sig4 = txtSig4.Text;
            stng.Sig5 = txtSig5.Text;
            stng.ChkSig1 = chkSig1.Checked;
            stng.ChkSig2 = chkSig2.Checked;
            stng.ChkSig3 = chkSig3.Checked;
            stng.ChkSig4 = chkSig4.Checked;
            stng.ChkSig5 = chkSig5.Checked;
            stng.user = user;
            stng.Save();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            bool error = false;
            
            if (s == 16)
            {
                MessageBox.Show("All Sessions Completed!", "Session");
                return;
            }

            // Clear Texts
            
            txtOnline.Text = "";
            //ExprDate = DateTime.Now.ToString("d-MMM-y");
            // Baudrate = 9600,8,N,2 Handshaking = HW Fixed
            // If the port is open, close it.
            if (comport.IsOpen) comport.Close();
            // Current Com Port
            comport.PortName = cmbPortName.Text;
            // and Open for next experiment
            try
            {
                rxState = 0;
                //lblStatus.Text = "Session#" + (s + 1).ToString() +" is Ready....";
                // Open the port
                comport.Open();
                btnOpen.Enabled = false;
            }
            catch (UnauthorizedAccessException) { error = true; }
            catch (IOException) { error = true; }
            catch (ArgumentException) { error = true; }

            if (error) MessageBox.Show(this, "Could not open the COM port.  Most likely it is already in use, has been removed, or is unavailable.", "COM Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        private void Find_Jitter()
        {
            float Maxi = 0.0f;
            float Mini = 999.9f;
            float val;

            for (int Ji = 0; Ji < 4; Ji++)
            {
                val = float.Parse(exprTime[s * 5 + Ji]);
                if (val < Mini) Mini = val;
                if (val > Maxi) Maxi = val;
                
            }
            exprTime[s * 5 + 4] = (Maxi - Mini).ToString("000.0");
        }
        private void UpdateResults()
        {
            btnOpen.Enabled = true;
            Find_Jitter();
            txtResult.Text += (s+1).ToString ()+  "  "+ ExprDate [s]+ "   "+ exprTime [s*5+0]+ "  "
                + exprTime [s*5 + 1] + "  "
                + exprTime [s*5 + 2] + "  "
                + exprTime [s*5 + 3] + "  "
                + exprTime [s*5 + 4] + "  "
                + "\r\n-------------------------------------------\r\n";
            
            

            using (StreamWriter bw = new StreamWriter(new FileStream(rtFileName + ".tmu", FileMode.Append)))
            {
                bw.WriteLine  (DateTime.Now.ToString());
                bw.WriteLine("Unit (TMU-01)");
                bw.WriteLine("====");
                bw.WriteLine("Ch#1: "+ exprTime [s*5+0]+" ms");
                bw.WriteLine("Ch#2: "+ exprTime [s*5+1]+" ms");
                bw.WriteLine("Ch#3: "+ exprTime [s*5+2]+" ms");
                bw.WriteLine("Ch#4: "+ exprTime [s*5+3]+" ms");
                bw.WriteLine("Jitter: " + exprTime[s*5+4]+" ms");
                bw.WriteLine("====");
                bw.WriteLine("");
                bw.WriteLine("");
                bw.Close();
            }
            //lblStatus.Text = "Session#" + (s + 1).ToString() + " has Finished...";
            s++;
        }
        delegate void ComportDelegate(int d);
        private void ComportDlgtCallback(int d)
        {
            txtOnline.Text += (char)d;
            txtOnline.SelectionStart = txtOnline.Text.Length;
            txtOnline.ScrollToCaret();
            switch (rxState)
            {
                case 0:
                    if (d == 61) rxState = 21;
                    break;
                case 21:
                    if (d == 61)  rxState = 22;
                    else rxState = 0;
                    break;
                case 22:
                    if (d == 13) rxState = 23;
                    
                    break;
                case 23:
                    if (d == 10) 
                    { 
                        rxState = 24; 
                        //lblStatus.Text = "Session#" + (s + 1).ToString() + " is Running....";
                        ExprDate[s] = DateTime.Now.ToString("HH:mm");
                    }
                    break;
                case 24:
                    if (d == 58) rxState = 25;
                    break;
                case 25:
                    if (d == 32) rxState = 26;
                    break;
                case 26:
                    if (d == 32)
                    {
                        rxState = 27;
                    }
                    else
                    {
                        exprTime[s * 5] += (char)d;
                    }
                    break;
                case 27:
                    if (d == 58) rxState = 28;
                    break;
                case 28:
                    if (d == 32) rxState = 29;
                    break;
                case 29:
                    if (d == 32)
                    {
                        rxState = 30;
                    }
                    else
                    {
                        exprTime[s * 5+1] += (char)d;
                    }
                    break;
                case 30:
                    if (d == 58) rxState = 31;
                    break;
                case 31:
                    if (d == 32) rxState = 32;
                    break;
                case 32:
                    if (d == 32)
                    {
                        rxState = 33;
                    }
                    else
                    {
                        exprTime[s *5 + 2] += (char)d;
                    }
                    break;
                case 33:
                    if (d == 58) rxState = 34;
                    break;
                case 34:
                    if (d == 32) rxState = 35;
                    break;
                case 35:
                    if (d == 32)
                    {
                        rxState = 36;
                    }
                    else
                    {
                        exprTime[s * 5 + 3] += (char)d;
                    }
                    break;
                case 36:
                    if (d == 0x0d)
                    {
                        rxState = 37;
                        UpdateResults();
                    }
                    break;
                case 37:
                    break;
                case 38:
                    timer1.Enabled = false;
                    MessageBox.Show("Connection Done!","COM Port", MessageBoxButtons.OK , MessageBoxIcon.Information  );
                    rxState = 37;
                    break;
                default:
                    break;
            }
        }

        private void comport_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int comm = comport.ReadByte ();
            this.Invoke(new ComportDelegate(ComportDlgtCallback), comm);
        }

        private void mnuNewFile_Click(object sender, EventArgs e)
        {
            s = 0;
            txtResult.Text = "";
            txtOnline.Text = "";
            rxState = 0;
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog(this);
        }

        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer1.Enabled = false;
            MessageBox.Show("Connection Failed!", "COM Port", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // If the port is open, close it.
            if (comport.IsOpen) comport.Close();
        }

    }
}

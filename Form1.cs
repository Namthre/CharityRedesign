using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contact_Donation_Page
{
    public partial class Form1 : Form
    {
        bool verified = false;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void monthlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void donateLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl.SelectedTab = DonateTab;

        }

        private void contactLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl.SelectedTab = ContactTab;
        }

      
        private void registryButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.amazon.com/wedding/bigger-vision-of-athens-2016-2017-season-athens-april-2017/registry/Z12VT8YP7C2U");

        }

        private void amazonPic_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://smile.amazon.com/gp/chpf/homepage/ref=smi_chpf_redirect?ie=UTF8&ein=20-8189437&ref_=smi_ext_ch_20-8189437_cl");
        }

        private void krogerPic_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.kroger.com/i/community/community-rewards");
        }

        private void donationLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl.SelectedTab = DonateTab;

        }                         

        private void questionType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.guidestar.org/profile/20-8189437");
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void adminDonateLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl.SelectedTab = DonateTab;
        }

        private void adminContactLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl.SelectedTab = ContactTab;
        }

     

       
        private void sendButton_Click(object sender, EventArgs e)
        {
            if (emailBox.Text.Length == 0 && phoneBox.Text.Length == 0 && nameBox.Text.Length == 0)
            {
                return;
            }
            else { 
                Contact c = new Contact(emailBox.Text, phoneBox.Text, nameBox.Text, messageBox.Text);
                string workingDirectory = Environment.CurrentDirectory;
                string path = Directory.GetParent(workingDirectory).Parent.FullName;
                StreamWriter sw = new StreamWriter(path + @"\CustomerInfo.txt", true);
                sw.WriteLine(c.getInfo());
                sw.Close();
            }
            
        }

       

        private void donateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (donationEmailBox.TextLength == 0)
                {
                    if (monthlyButton.Checked == true)
                    {
                        Donation d = new Donation(true, Convert.ToDouble(donateBox.Text));
                        string workingDirectory = Environment.CurrentDirectory;
                        string path = Directory.GetParent(workingDirectory).Parent.FullName;
                        StreamWriter sw = new StreamWriter(path + @"\CustomerInfo.txt", true);
                        sw.WriteLine(d.getInfo());
                        sw.Close();
                    }
                    else
                    {

                        Donation d = new Donation(false, Convert.ToDouble(donateBox.Text));
                        string workingDirectory = Environment.CurrentDirectory;
                        string path = Directory.GetParent(workingDirectory).Parent.FullName;
                        StreamWriter sw = new StreamWriter(path + @"\CustomerInfo.txt", true);
                        sw.WriteLine(d.getInfo());
                        sw.Close();
                    }


                }
                else
                {
                    if (monthlyButton.Checked == true)
                    {
                        Donation d = new Donation(true, Convert.ToDouble(donateBox.Text), donationEmailBox.Text);
                        string workingDirectory = Environment.CurrentDirectory;
                        string path = Directory.GetParent(workingDirectory).Parent.FullName;
                        StreamWriter sw = new StreamWriter(path + @"\CustomerInfo.txt", true);
                        sw.WriteLine(d.getInfo());
                        sw.Close();
                    }
                    else
                    {
                        Donation d = new Donation(false, Convert.ToDouble(donateBox.Text), donationEmailBox.Text);
                        string workingDirectory = Environment.CurrentDirectory;
                        string path = Directory.GetParent(workingDirectory).Parent.FullName;
                        StreamWriter sw = new StreamWriter(path + @"\CustomerInfo.txt", true);
                        sw.WriteLine(d.getInfo());
                        sw.Close();
                    }

                }
            }

            catch (System.FormatException) { 
                
            }

            //System.Diagnostics.Process.Start("https://www.paypal.com/donate?token=AwQymtL6L92w0MUXr74PNMmhaM6xvJ_Ugrm-v8yexxG4kKVbBQF7wQkybTFAcDdCAFeJkQdUuTkHsfz1");
        }

    

       
       

        public class Donation
        {
            private bool isMonthly;
            private double donationAmount;
            private string email;
            

            public Donation()
            {
                isMonthly = false;
                donationAmount = 0.00;
                email = "";
            }

            public Donation(bool monthly, double amount, string email)
            {
                isMonthly = monthly;
                donationAmount = amount;
                this.email = email;
            }

            public Donation(bool monthly, double amount)
            {
                isMonthly = monthly;
                donationAmount = amount;
            }

            public string getEmail()
            {
                return this.email;
            }

            public void setEmail(String email)
            {
                this.email = email;
            }

            public double getDonationAmount()
            {
                return this.donationAmount;

            }

            public void setDonationAmount(double donationAmount)
            {
                this.donationAmount = donationAmount;
            }

            public void addDonation(double donation)
            {
                this.donationAmount += donation;
            }

            public bool getMonthly()
            {
                return this.isMonthly;
            }

            public void setMonthly(bool monthly)
            {
                this.isMonthly = monthly;
            }

            public string getInfo() {
                return "Email: " + email + ", DonationAmount: " + donationAmount + ", isMonthly: " + isMonthly + " ";
            }    

            }
            public class Contact
            {
                private string email, phone, name, message;
                public Contact()
                {
                    email = "";
                    phone = "";
                    name = "";
                    message = "";
                }
                public Contact(string email, string phone, string name, string message)
                {
                    this.email = email;
                    this.phone = phone;
                    this.name = name;
                    this.message = message;
                }
                public string getName()
                {
                    return this.name;
                }

                public void setName(string name)
                {
                    this.name = name;
                }
                public string getEmail()
                {
                    return this.email;
                }

                public void setEmail(string email)
                {
                    this.email = email;
                }
                public string getPhoneNumber()
                {
                    return this.phone;
                }
                public void setPhoneNumber(string phoneNumber)
                {
                    this.phone = phoneNumber;
                }
            public string getMessage()
            {
                return this.message;
            }
            public void setMessage(string message)
            {
                this.message = message;
            }
            public string getInfo()
            {
                return "Name: " + name + ", Email: " + email + ", Phone: " + phone + ", Message: " + message + " ";
            }
        }

        private void paymentTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = paymenTypeBox.SelectedIndex;
           
           if (x == 0)
            {
                paymentInfoBox.Visible = true;
                paymentInfoBox.Text = "Using Paypal, you will be able to contribute as a one time donation, or as a monthly contribution to the Bed Sponsorship program.";
            }

            else {
                paymentInfoBox.Visible = true;
                paymentInfoBox.Text = "If you send a check that represents a monthly or annual gift, please indicate so in the memo line, so we can give you credit for a Bed Sponsorship. Either drop them off in-person at (95 North Ave. Athens, GA 30601) M-F between 9am-4pm, or mail them to (The Bigger Vision of Athens, Inc. P.O.Box 8022, Athens, GA 30603).";
            }
        }

        private void DonateTab_Click(object sender, EventArgs e)
        {

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            String box = adminBox.Text;
            string workingDirectory = Environment.CurrentDirectory;
            string path = Directory.GetParent(workingDirectory).Parent.FullName;
            StreamWriter sw = new StreamWriter(path + @"\CustomerInfo.txt");
            
            sw.Write(box);
            sw.Close();
        }

        private void dAdminButton_Click(object sender, EventArgs e)
        {
            if (verified == false)
            {
                LoginForm login = new LoginForm();
                DialogResult dialogResult = login.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {

                    string username = login.userNameBox.Text;
                    string password = login.passwordBox.Text;
                    string workingDirectory = Environment.CurrentDirectory;
                    string path = Directory.GetParent(workingDirectory).Parent.FullName;
                    StreamReader sr = new StreamReader(path + @"\validCredentials.txt");
                    string usernameLine = sr.ReadLine();
                    string passwordLine = sr.ReadLine();
                    Console.WriteLine("here");
                    Console.WriteLine(usernameLine);
                    Console.WriteLine(passwordLine);
                    while (usernameLine != null || passwordLine != null)
                    {

                        if (usernameLine.Equals(username) && passwordLine.Equals(password))
                        {

                            usernameLine = null;
                            passwordLine = null;
                            verified = true;
                        }

                        else
                        {

                            usernameLine = sr.ReadLine();
                            passwordLine = sr.ReadLine();
                        }

                    }
                    if (verified == false)
                    {
                        login.Dispose();
                        return;
                    }


                }

                else if (dialogResult == DialogResult.Cancel)
                {
                    login.Dispose();
                    return;
                }
            }


            try
            {
                tabControl.SelectedTab = AdminTab;
                String line;
                adminBox.Text = "";
                string workingDirectory = Environment.CurrentDirectory;
                string path = Directory.GetParent(workingDirectory).Parent.FullName;
                StreamReader sr = new StreamReader(path + @"\CustomerInfo.txt");
                line = sr.ReadLine();

                while (line != null)
                {
                    adminBox.Text += line + Environment.NewLine;
                    line = sr.ReadLine();
                }

                sr.Close();
            }

            catch (System.IO.FileNotFoundException)
            {

            }
        }

        private void cAdminButton_Click(object sender, EventArgs e)
        {

            if (verified == false)
            {
                LoginForm login = new LoginForm();
                DialogResult dialogResult = login.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {

                    string username = login.userNameBox.Text;
                    string password = login.passwordBox.Text;                 
                    string workingDirectory = Environment.CurrentDirectory;
                    string path = Directory.GetParent(workingDirectory).Parent.FullName;
                    StreamReader sr = new StreamReader(path + @"\validCredentials.txt");
                    string usernameLine = sr.ReadLine();
                    string passwordLine = sr.ReadLine();
                    Console.WriteLine("here");
                    Console.WriteLine(usernameLine);
                    Console.WriteLine(passwordLine);
                    while (usernameLine != null || passwordLine != null)
                    {

                        if (usernameLine.Equals(username) && passwordLine.Equals(password))
                        {

                            usernameLine = null;
                            passwordLine = null;
                            verified = true;
                        }

                        else
                        {

                            usernameLine = sr.ReadLine();
                            passwordLine = sr.ReadLine();
                        }
                        
                    }
                    if (verified == false) { 
                    login.Dispose();
                    return;
                    }
                    

                }

                else if (dialogResult == DialogResult.Cancel)
                {
                    login.Dispose();
                    return;
                }
            }
            
               
                try
                { tabControl.SelectedTab = AdminTab;
                String line;
                    adminBox.Text = "";
                    string workingDirectory = Environment.CurrentDirectory;
                    string path = Directory.GetParent(workingDirectory).Parent.FullName;
                    StreamReader sr = new StreamReader(path + @"\CustomerInfo.txt");
                    line = sr.ReadLine();

                    while (line != null)
                    {
                        adminBox.Text += line + Environment.NewLine;
                        line = sr.ReadLine();
                    }

                    sr.Close();
                }

                catch (System.IO.FileNotFoundException)
                {

                }
            
    }

        private void newsPicture_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://biggervisionofathens.org/newsletter");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/biggervisionofathens/");
        }
    }
}

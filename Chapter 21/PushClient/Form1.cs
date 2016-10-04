using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace PushClient
{
    public partial class Form1 : Form
    {
        ServiceReference1.PushServiceClient client = null;

        public Form1()
        {
            InitializeComponent();

            client = new ServiceReference1.PushServiceClient();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                client.Register(txtURI.Text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void btnUnregister_Click(object sender, EventArgs e)
        {
            try
            {
                client.Unregister(txtURI.Text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void btnSendToastNotification_Click(object sender, EventArgs e)
        {
            try
            {
                client.SendToastNotification(txtToastTitle.Text, txtToastSubtitle.Text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void btnSendTileNotification_Click(object sender, EventArgs e)
        {
            try
            {
                client.SendTileNotification(Int32.Parse(txtCount.Text),
                    txtTileTitle.Text, comBackground.Text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void btnSendRawNotification_Click(object sender, EventArgs e)
        {
            try
            {
                client.SendRawNotification(txtRawMessage.Text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }   
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //#region organizes code into collapsible regions
        #region UI Event Handlers

        private void getButton_Click(object sender, EventArgs e)
        {
            //New instance of RestClient class, setting rClient.Endpoint to whatever the client inputs into the textbox.
            RestClient rClient = new RestClient
            {
                EndPoint = apiURLTextbox.Text
            };

            //Initiating string to eventually hold the response
            string strResponse = string.Empty;

            strResponse = rClient.MakeRequest();

            DebugOutput(strResponse);
        }

        #endregion

        #region Debug Function

        private void DebugOutput(string strDebugText)
        {
            try
            {
                //Puts debug text to output window of VS
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
                //Writes out to the response textbox in the UI
                apiResponseTextbox.Text = apiResponseTextbox.Text + strDebugText + Environment.NewLine;
                apiResponseTextbox.SelectionStart = apiResponseTextbox.TextLength;
                //Will scroll down as it fills
                apiResponseTextbox.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message, ToString() + Environment.NewLine);
            }
        }

        #endregion
    }
}

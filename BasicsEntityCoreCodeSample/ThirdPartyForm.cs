using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeconstructCodeSamples.Classes;
using DeconstructCodeSamples.Extensions;
using DeconstructCodeSamples.Models;
using Newtonsoft.Json;
using SomeThirdPartyLibrary.Classes;

namespace DeconstructCodeSamples
{
    public partial class ThirdPartyForm : Form
    {
        public ThirdPartyForm()
        {
            InitializeComponent();
            Shown += OnShown;
        }

        private void OnShown(object sender, EventArgs e)
        {
            var customerItems = CustomerOperations.CustomerItems();
            string json = JsonConvert.SerializeObject(customerItems, Formatting.Indented);
            File.WriteAllText("CustomerItems.json", json);
            CustomerListBox.DataSource = customerItems;
            //CustomerListBox.DataSource = CustomerOperations.CustomerItems();
        }

        private int CurrentIdentifier() 
            => ((CustomerItem)CustomerListBox.SelectedItem).CustomerIdentifier;


        /// <summary>
        /// Get all properties
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedCustomerButton_Click(object sender, EventArgs e)
        {
            Customer customer = CustomerOperations.CustomerByIdentifier(CurrentIdentifier());
        }

        /// <summary>
        /// Take id, company name, contact identifier, country identifier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeconstructButton_Click(object sender, EventArgs e)
        {
            var (id, companyName, contactIdentifier, countryIdentifier) = 
                CustomerOperations.CustomerByIdentifier(CurrentIdentifier());

            Dialogs.Information(this, $"Company {companyName}\nContact id {contactIdentifier}\nCountry {countryIdentifier}");
        }

        /// <summary>
        /// Skip id and country id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void partialDeconstructButton_Click(object sender, EventArgs e)
        {
            var ( _ , companyName, contactIdentifier, _) = 
                CustomerOperations.CustomerByIdentifier(CurrentIdentifier());

            Dialogs.Information(this, $"Company {companyName}\nContact id {contactIdentifier}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsCodeSamples.Classes;
using WindowsFormsCodeSamples.Extensions;
using WindowsFormsCodeSamples.Models;
using WindowsFormsLibrary.Classes;

namespace WindowsFormsCodeSamples
{
    /// <summary>
    /// Code samples showing various (good and bad) ways to return information
    /// from a class method.
    /// </summary>
    public partial class Form1 : Form
    {

        private readonly BindingSource _bindingSource = new ();

        public Form1()
        {
            InitializeComponent();
            CustomersDataGridView.AutoGenerateColumns = false;
        }

        /// <summary>
        /// What a novice developer might do, ask for a DataTable then
        /// check row count knowing records are present and if not show
        /// an error message,
        ///
        /// Actually a novice would do synchronous coding, not in a class
        /// but directly in this click event as it's simple and novice coders
        /// like simple rather than figure out classes and asynchronous coding.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ReadCustomersDataTableOnlyButton_Click(object sender, EventArgs e)
        {
            CustomersDataGridView.DataSource = null;

            CancellationTokenSource cancellationTokenSource = new(2000);

            await Task.Run(async () =>
            {

                _bindingSource.DataSource = await 
                    DataOperations.ReadCustomersConventional(cancellationTokenSource.Token);

            }, cancellationTokenSource.Token);

            if (_bindingSource.Count > 0)
            {
                CustomersDataGridView.DataSource = _bindingSource;
                CustomersDataGridView.ExpandColumns();
                ActiveControl = CustomersDataGridView;
            }
            else
            {
                Dialogs.ErrorBox("Failed to read data");
            }

        }

        /// <summary>
        /// In this example we want the same data as in the above click event.
        ///
        /// Differences
        /// * Is asynchronous (sure the above is but usually not)
        /// * Uses Named ValueTuple for returning a DataTable and Exception object.
        ///   If the data was read w/o incident than the Exception is null while
        ///   when an exception is thrown, the DataTable comes back as null and
        ///   the Exception is live.
        ///
        ///   We assert if the DataTable is null, if so show a dialog while if
        ///   the DataTable is not null present data to the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ReadCustomersWithTupleButton_Click(object sender, EventArgs e)
        {
            CustomersDataGridView.DataSource = null;

            CancellationTokenSource cancellationTokenSource = new(2000);

            await Task.Run(async () =>
            {

                var (dataTable, exception) = 
                    await DataOperations.ReadCustomersWithTuple(cancellationTokenSource.Token);

                if (dataTable is not null)
                {
                    _bindingSource.DataSource = dataTable;

                    CustomersDataGridView.InvokeIfRequired(dataGridViewx =>
                    {
                        dataGridViewx.DataSource = _bindingSource;
                        dataGridViewx.ExpandColumns();
                    });

                }
                else
                {
                    Dialogs.ErrorBox(exception);
                }
                
            }, cancellationTokenSource.Token);


        }

        /// <summary>
        /// An example which
        /// * uses tuples to return a list and an exception
        ///     If no errors, ask for first item via a Deconstruct
        ///     If errors, present an error message
        /// </summary>
        /// <remarks>
        /// In this case there are no errors
        /// </remarks>
        private void ChunkWithTuplesButton_Click(object sender, EventArgs e)
        {
            var (persons, exception) = FileOperations.Read();
            if (exception is null)
            {
                var (firstName, lastName) = persons.FirstOrDefault();
                Dialogs.Information(this, $"First person: {firstName} {lastName}");
            }
            else
            {
                Dialogs.ErrorBox(exception);
            }
        }
    }
}

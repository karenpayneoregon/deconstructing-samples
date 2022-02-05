using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlogPostsFormsProject.Classes;
using BlogPostsFormsProject.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogPostsFormsProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void BlogSingleButton_Click(object sender, EventArgs e)
        {
            await Task.Run(async () => await Operations.Example1());
        }

        private async void BlogsListButton_Click(object sender, EventArgs e)
        {
            await Task.Run(async () => await Operations.Example2());
        }
    }
}

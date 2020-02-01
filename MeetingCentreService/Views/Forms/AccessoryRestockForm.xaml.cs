﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MeetingCentreService.Views.Forms
{
    /// <summary>
    /// Interakční logika pro RestockForm.xaml
    /// </summary>
    public partial class AccessoryRestockForm : Window
    {
        public Models.Entities.Accessory.AccessoryForm Accessory { get; }
        public string ReactiveWindowTitle { get; }
        public CloseAction ClosedWith { get; private set; } = CloseAction.None;
        public AccessoryRestockForm(Models.Entities.Accessory accessory)
        {
            this.Accessory = accessory.GetEditForm();
            this.DataContext = this;
            this.ReactiveWindowTitle = $"Restock {accessory.Name}";
            InitializeComponent();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (!this.FormCount.GetBindingExpression(TextBox.TextProperty).HasValidationError)
            {
                this.ClosedWith = CloseAction.Save;
                this.Close();
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

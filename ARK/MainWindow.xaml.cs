﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ARK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ARK.Administrationssystem.AdminSystem window = new ARK.Administrationssystem.AdminSystem();
            ShowWindow(window);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Protokolsystem.Protokolsystem window = new Protokolsystem.Protokolsystem();
            ShowWindow(window);
        }

        private void ShowWindow(Window window)
        {
            window.Show();
            this.Hide();

            window.Closing += (sender, e) => this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //ARK.Model.XML.XMLParser.LoadBoatsFromXml();
            //ARK.Model.XML.XMLParser.LoadMembersFromXml();
            ARK.Model.XML.XMLParser.LoadTripsFromXml();
        }
    }
}

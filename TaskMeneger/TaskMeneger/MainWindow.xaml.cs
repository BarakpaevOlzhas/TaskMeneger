using System;
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
using System.Net.Mail;
using System.Net;
using System.IO;

namespace TaskMeneger
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Controls.Primitives.Popup menu;

        bool IsExit = false;

        public MainWindow()
        {
            InitializeComponent();
            typeSelect.Items.Add("Почта");
            typeSelect.Items.Add("Скачать файл");
            typeSelect.Items.Add("Перенести каталог");

            System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon();
            ni.Icon = new System.Drawing.Icon("Icon.ico");
            ni.Visible = true;
            ni.Click += ClickNi;

            this.Closing += ThisClosing;

        }

        private void ClickNi(object sender, EventArgs e)
        {
            Visibility = Visibility.Visible;
        }

        private void ThisClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!IsExit)
            {
                e.Cancel = true;
                this.Visibility = Visibility.Collapsed;
            }
            else
                e.Cancel = false;
        }

        private void ButtonClickExit(object sender, RoutedEventArgs e)
        {
            IsExit = true;
            this.Close();
        }

        private void ComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}

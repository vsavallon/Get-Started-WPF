using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProcessMonitor
{
    /// <summary>
    /// Interaction logic for Monitor.xaml
    /// </summary>
    public partial class Monitor : Window
    {
        public Monitor()
        {
            InitializeComponent();
        }

        private void sortingCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetNewSortingOrder();
        }

        private void SetNewSortingOrder()
        {
            string sortTypeName = ((ComboBoxItem)sortingCombo.SelectedItem).Content.ToString();
            SortDescription sortDesp = new SortDescription(sortTypeName, ListSortDirection.Ascending);
            CollectionViewSource source = FindResource("processesView") as CollectionViewSource;
            source.SortDescriptions.Clear();
            source.SortDescriptions.Add(sortDesp);
        }

        private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            Process p = e.Item as Process;
            int mode = (priorityCombo != null) ? priorityCombo.SelectedIndex : 0;
            switch (mode)
            {
                case 1:
                    e.Accepted = (p.BasePriority < 8); 
                    break;
                case 2:
                    e.Accepted = (p.BasePriority > 12); 
                    break;
                case 3:
                    e.Accepted = (p.BasePriority >= 8 && p.BasePriority <= 12);
                    break;
                default:
                    e.Accepted = true;
                    break;
            }
        }

        private void priorityCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetNewSortingOrder();
        }
    }
}

using DrugsProject3._0.Tools;
using DrugsProject3._0.ViewModels;

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

namespace DrugsProject3._0.Controls
{
    /// <summary>
    /// Interaction logic for DoctorUC.xaml
    /// </summary>
    public partial class DoctorUC : UserControl
    {
         //private IEventAggregator eventAggregator;
        public DoctorUC()
        {    
            DoctorVM VM = new DoctorVM((App.Current as App).controlManage);
            DataContext = VM;
            InitializeComponent();
        }

    }
}

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
    /// Interaction logic for PatientUC.xaml
    /// </summary>
    public partial class PatientUC : UserControl
    {
        
        public PatientUC()
        {
            PatientVM VM = new PatientVM();
            DataContext = VM;
            InitializeComponent();
        }

      
    }
}

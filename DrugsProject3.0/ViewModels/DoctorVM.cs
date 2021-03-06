using BE;

using DrugsProject3._0.Commands;
using DrugsProject3._0.Models;
using DrugsProject3._0.Tools;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DrugsProject3._0.ViewModels
{
    class DoctorVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DoctorModel DoctorM;
        public DoctorCommand Command { get; set; }

        public IControlManage IControlManage { get; set; }
       
        public ObservableCollection<string> PatientsId { get; set; }
       // public int PatientSelected { get; set; }

        private string patientSelected;
        public string PatientSelected
        {
            get { return patientSelected; }
            set
            {
                patientSelected = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PatientSelected"));
            }
        }

        public DoctorVM(IControlManage controlManage)
        {
            IControlManage = controlManage;
            DoctorM = new DoctorModel();
            Command = new DoctorCommand(this);
            try
            {
                PatientsId = new ObservableCollection<string>(DoctorM.GetAllPatientsId());
            }
            catch (Exception e)
            {

                (App.Current as App).navigation.MainWindows.comments.Text = e.Message.ToString();
            }
           
           
        }
        
        public void CManage()
        {
            try
            {
                IControlManage.Patient = DoctorM.GetPatient(patientSelected);
                (App.Current as App).navigation.ShowControls("DoctorVisitUC");
            }
            catch (Exception e)
            {
                (App.Current as App).navigation.MainWindows.comments.Text = e.Message.ToString();
            }
            
        }
    }
}


















//  public int PatientSelected { get; set; }

///PatientsId.CollectionChanged += PatientsId_CollectionChanged;
//private IEventAggregator eventAggreegator;
/*IEventAggregator eventAggreegator*/
//this.eventAggreegator = eventAggreegator;

//public void EventMenage()
//{
//    Patient patient = DoctorM.GetPatient(PatientSelected);
//    this.eventAggreegator.GetEvent<PatientEvent>().Publish(patient);
//}
//public Patient Subscribe(Patient patient)
//{
//    return patient;
//}

//private void PatientsId_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
//{
//    if (e.Action == NotifyCollectionChangedAction.Add)
//    {
//        PatientV = e.NewItems[0] as Patient;
//    }
//}
//public void tt()
//{
//    MessageBox.Show(PatientSelected.ToString());

//}
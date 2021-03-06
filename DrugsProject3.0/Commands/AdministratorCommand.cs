using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DrugsProject3._0.ViewModels;

namespace DrugsProject3._0.Commands
{
    public  class AdministratorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public AdministratorVM CurrentVM { get; set; }
        public AdministratorCommand(AdministratorVM VM)
        {
            CurrentVM = VM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {

            if (parameter.ToString() == "MedicinInformationUC")
            {
                (App.Current as App).navigation.ShowControls("MedicinInformationUC");
            }
            if (parameter.ToString() == "PatientInformationUC")
            {
                (App.Current as App).navigation.ShowControls("PatientInformationUC");
            }
            if (parameter.ToString() == "UserInformationUC")
            {
                (App.Current as App).navigation.ShowControls("UserInformationUC");
            }
            if (parameter.ToString() == "AddUser")
            {
                (App.Current as App).navigation.ShowControls("AddUserUC");
            }
            if (parameter.ToString() == "PatientUC")
            {
                (App.Current as App).navigation.ShowControls("PatientUC");
            }
            if (parameter.ToString() == "AddMedicine")
            {
                (App.Current as App).navigation.ShowControls("MedicineUC");
            }
            if (parameter.ToString() == "Statistics")
            {
                (App.Current as App).navigation.ShowControls("StatisticsUC");
            }
            if (parameter.ToString() == "Chart")
            {
                (App.Current as App).navigation.ShowControls("ChartUC");
            }

            }
            catch (Exception e)
            {

                (App.Current as App).navigation.MainWindows.comments.Text = e.Message.ToString();
            }
        }
    
    }
}

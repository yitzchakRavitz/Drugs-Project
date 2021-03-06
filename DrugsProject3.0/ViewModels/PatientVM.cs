using BE;
using CareManagment.Tools;
using DrugsProject3._0.Commands;
using DrugsProject3._0.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugsProject3._0.ViewModels
{
    class PatientVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Patient PatientV;
        public PatientCommand Command { get; set; }


        public PatientModel PatientM { get; set; }


        private string fname;
        public string Fname
        {
            get { return fname; }
            set
            {
                if (!new VerifyInput().IsValidName(value))
                {
                    (App.Current as App).navigation.MainWindows.comments.Text = "שם פרטי צריך להכיל רק תווים בעברית";
                }
                else
                {
                    (App.Current as App).navigation.MainWindows.comments.Text = "";
                    fname = null;
                    fname = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Fname"));
                }
            }
        }

        private string lname;
        public string Lname
        {
            get { return lname; }
            set
            {
                if (!new VerifyInput().IsValidName(value))
                {
                    (App.Current as App).navigation.MainWindows.comments.Text = "שם משפחה צריך להכיל רק תווים בעברית";
                }
                else
                {
                    (App.Current as App).navigation.MainWindows.comments.Text = "";
                    lname = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Lname"));
                }
            }
        }
        private string id;
        public string Id
        {
            get { return id; }
            set
            {
                if (!new VerifyInput().IsValidPersonId(value))
                {
                    (App.Current as App).navigation.MainWindows.comments.Text = "מספר id לא תקין ";
                }
                else
                {
                    (App.Current as App).navigation.MainWindows.comments.Text = "";
                    id = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id"));
                }
            }
        }
        private DateTime dateOfBirth = DateTime.Now;
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
            
              //  dateOfBirth = DateTime.Now;
                dateOfBirth = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DateOfBirth"));
            }
        }
        private string phoneNum;
        public string PhoneNum
        {
            get { return phoneNum; }
            set
            {
                if (!new VerifyInput().IsValidPhoneNumber(value))
                {
                    (App.Current as App).navigation.MainWindows.comments.Text = "מספר טלפון לא תקין";
                }
                else
                {
                    (App.Current as App).navigation.MainWindows.comments.Text = "";
                    phoneNum = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PhoneNum"));
                }
            }
        }

        private string mailAddress;
        public string MailAddress
        {
            get { return mailAddress; }
            set
            {
                if (!new VerifyInput().IsValidMail(value))
                {
                    (App.Current as App).navigation.MainWindows.comments.Text = "כתובת אימייל לא תקינה";
                }
                else
                {
                    (App.Current as App).navigation.MainWindows.comments.Text = "";
                    mailAddress = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MailAddress"));
                }
            }
        }
        public ObservableCollection<string> PatientIds { get; set; }

        public string PatientSelected { get; set; }
        public PatientVM()
        {
            PatientM = new PatientModel();
            Command = new PatientCommand(this);
            try
            {
                PatientIds = new ObservableCollection<string>(PatientM.GetAllPatientsId());
            }
            catch (Exception e)
            {
                (App.Current as App).navigation.MainWindows.comments.Text = e.Message.ToString();
            }
        }

        public void AddPatient()
        {
            try
            {
                if (Id == null || Fname == null || Lname == null || PhoneNum == null || MailAddress == null)
                {
                    throw new ArgumentException("אתה צריך למלא את כל השדות");
                }
                else
                {
                    PatientV = new Patient(Id, Fname, Lname, PhoneNum, DateOfBirth,MailAddress);
                    PatientM.AddPatient(PatientV);
                    PatientM.SendMail(PatientV);
                    PatientIds.Add(PatientV.PatientId);
                    (App.Current as App).navigation.MainWindows.comments.Text = "המטופל נוסף בהצלחה";
                }
            }
            catch (Exception e)
            {
                (App.Current as App).navigation.MainWindows.comments.Text = e.Message.ToString();
            }
        }

        public void DeletePatient()
        {
            try
            {
                PatientV = PatientM.GetPatient(PatientSelected);
                PatientM.DeletePatient(PatientV);
                PatientIds.Remove(PatientV.PatientId);
                (App.Current as App).navigation.MainWindows.comments.Text = " המטופל הוסר בהצלחה מהמערכת";
            }
            catch (Exception e)
            {

                (App.Current as App).navigation.MainWindows.comments.Text = e.Message.ToString();
            }
            
        }

    }
}

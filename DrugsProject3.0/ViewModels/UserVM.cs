using BE;
using CareManagment.Tools;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using static BE.User;

namespace DrugsProject3._0.ViewModels
{

    public class UserVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public User User { get; set; }

        public UserCommand Command { get; set; }

        public UserModel AddUserM { get; set; }

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

        private string fname;
        public string Fname
        {
            get { return fname; }
            set
            {
                if (!new VerifyInput().IsValidName(value))
                {
                    (App.Current as App).navigation.MainWindows.comments.Text = "שם פרטי לא תקין";
                }
                else
                {
                    (App.Current as App).navigation.MainWindows.comments.Text = "";
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
                    (App.Current as App).navigation.MainWindows.comments.Text = "שם משפחה לא תקין";
                }
                else
                {
                    (App.Current as App).navigation.MainWindows.comments.Text = "";
                    lname = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Lname"));
                }
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
                    phoneNum = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PhoneNum"));
                }
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                if (!new VerifyInput().IsValidPassword(value))
                {
                    (App.Current as App).navigation.MainWindows.comments.Text = "הסיסמה צריכה לכלול 8 תווים ";
                }
                else
                {
                    (App.Current as App).navigation.MainWindows.comments.Text = "";
                    password = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Password"));
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

        public ObservableCollection<string> Type { get; set; }

        private String typeSelected;
        public String TypeSelected
        {
            get { return typeSelected; }
            set
            {
                typeSelected = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TypeSelected"));
            }
        }
        public ObservableCollection<string> UserIds { get; set; }

        public string UserSelected { get; set; }
        public UserVM()
        {
            AddUserM = new UserModel();
            Command = new UserCommand(this);
            Type = new ObservableCollection<string>(Enum.GetNames(typeof(UserType)));
            try
            {
                UserIds = new ObservableCollection<string>(AddUserM.GetAllUserId());
            }
            catch (Exception e)
            {

                (App.Current as App).navigation.MainWindows.comments.Text = e.Message.ToString();
            }
            
        }

        public void AddUser()
        {
            try
            {
                UserType userType = (UserType)Enum.Parse(typeof(UserType), TypeSelected);
                if (Id == null || Fname == null || Lname == null || PhoneNum == null || Password == null || MailAddress == null)
                {
                    throw new ArgumentException("אתה צריך למלא את כל השדות");
                }
                else
                {    
                    User = new User(Id, Fname, Lname, PhoneNum, userType, MailAddress, Password);
                    AddUserM.AddUser(User);
                    AddUserM.SendMail(User);
                    UserIds.Add(User.Id);
                    (App.Current as App).navigation.MainWindows.comments.Text = "משתמש נוסף בהצלחה";
                }
            }
            catch (Exception e)
            {
                (App.Current as App).navigation.MainWindows.comments.Text = e.Message.ToString();
            }
        }

        public void DeleteUser()
        {
            try
            {
                User = AddUserM.GetUser(UserSelected);
                AddUserM.DeleteUser(User);
                UserIds.Remove(User.Id);
                (App.Current as App).navigation.MainWindows.comments.Text = "משתמש הוסר בהצלחה";
            }
            catch (Exception e)
            {

                (App.Current as App).navigation.MainWindows.comments.Text = e.Message.ToString();
            }
        }

       
    }
}









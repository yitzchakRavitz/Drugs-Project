﻿using BE;
using DrugsProject3._0.Commands;
using DrugsProject3._0.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugsProject3._0.ViewModels
{
    class AddPatientVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Patient PatientV;
       

       
        private string fname;
        public string Fname
        {
            get { return fname; }
            set
            {
                fname = null;
                fname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Fname"));
            }
        }

        private string lname;
        public string Lname
        {
            get { return lname; }
            set
            {
                lname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Lname"));
            }
        }
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                
                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id"));
            }
        }
        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                dateOfBirth = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DateOfBirth"));
            }
        }
        private int phoneNum;
        public int PhoneNum
        {
            get { return phoneNum; }
            set
            {
                phoneNum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PhoneNum"));
            }
        }
        
        public AddPatientVM()
        {
            AddPatientM = new AddPatientModel();
            AddCommand = new AddPatientCommand(this);
           

        }
        

        public AddPatientCommand AddCommand { get; set; }
       

        public AddPatientModel AddPatientM { get; set; }

       
        public void AddPatient()
        {
            PatientV = new Patient(Id, Fname, Lname, PhoneNum, DateOfBirth);
            AddPatientM.AddPatient(PatientV);
        }

        
    }
}

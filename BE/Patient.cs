﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Patient
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
       // public int PhoneNumber { get; set; }
    //    public List<Medicine> Medicines { get; set; }
       // public string Address { get; set; }
      //  public List<DoctorVisit> MedicalRecord { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Patient(int id, string fname, string lname,/* int phoneNumber,*/ /*string address,*/ DateTime dateOfBirth)
        {
            Id = id;
            Fname = fname;
            Lname = lname;
            //  PhoneNumber = phoneNumber;
          //  Address = address;
            DateOfBirth = dateOfBirth;

        }
    }
}

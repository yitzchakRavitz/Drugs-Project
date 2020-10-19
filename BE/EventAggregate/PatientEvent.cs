﻿using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.EventAggregate
{
    public class PatientEvent : PubSubEvent<Patient>
    {
        public Patient Subscribe(Patient patient)
        {
            return patient;
        }
    }


}
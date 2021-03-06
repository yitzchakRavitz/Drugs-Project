using BE;
using BL;
using DrugsProject3._0.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DrugsProject3._0.Models
{
    public class AddDoctorVisitModel
    {
        public IBL Bl { get; set; }
        public AddDoctorVisitModel()
        {
            Bl = new BlObject();
        }
        public void createPDF(List<Recipe> r)
        {
            Bl.CreateDocument(r);
        }

        public void Print(List<Recipe> r)
        {
            Bl.print(r);
        }
        public Medicine GetMedicine(string id)
        {
            try
            {
                return Bl.GetMedicine(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public string AddRecipeId()
        {
            return Bl.getPrescriptionID();
        }

        public List<string> GetAllMedicinesNames()
        {
            try
            {
                return Bl.GetAllMedicinesNames();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public string GetMedicineId(string medicineName)
        {
            try
            {
                return Bl.GetMedicineId(medicineName);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public void AddRecipe(Recipe recipe)
        {
            try
            {
                Bl.AddRecipe(recipe);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public List<string> interactionDrugs(string drugName)
        {
            try
            {
                return Bl.interactionDrugs(drugName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Recipe> getPatientHistory(string patientId, bool flag = false)
        {
            try
            {
                return Bl.getPatientHistory(patientId, flag);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> GetMedicinesNamesFromRecipe(List<Recipe> prescriptionsGiven)
        {
            try
            {
                return Bl.GetMedicinesNamesFromRecipe(prescriptionsGiven);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteRecipe(Recipe recipe)
        {
            try
            {
                 Bl.DeleteRecipe(recipe);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SendMail(Patient patient,User user, List<Recipe> r = null)
        {
            try
            {
                Mail mail = new Mail();
                string mailTo = patient.MailAddress;
                string mailSubject = "סיום ביקור";
                string mailBody = "היי " + patient.Fname + "," + "\n\n" + "ביקורך אצל דר   ." + user.Fname + " " + user.Lname + " הסתיים בהצלחה " + "\n\n" + "מקווים שקיבלת את הטיפול הטוב ביותר , צוות ההנהלה.";
               
                Thread thread = new Thread(() => mail.SendMail(mailTo, mailSubject, mailBody, r));
                thread.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
//public void AddMedicineToDoctorVisit(List<Medicine> medicines)
//{

//}

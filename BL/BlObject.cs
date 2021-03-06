using BE;
using com.sun.xml.@internal.bind.v2.model.nav;
using DAL;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.XPath;

using Document = MigraDoc.DocumentObjectModel.Document;

using Image = MigraDoc.DocumentObjectModel.Shapes.Image;
using Style = MigraDoc.DocumentObjectModel.Style;
using VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment;
using System.Windows.Xps.Packaging;
using PdfSharp.Pdf.Annotations;
using System.Reflection;
using MigraDoc.Rendering;
using PdfSharp.Pdf.IO;

namespace BL
{

    public class BlObject : IBL
    {
        public IDalService IDalService { get; set; }
        public CheckInteraction CI { get; set; }
        public BlObject()
        {
            IDalService = new DalService();
            CI = new CheckInteraction();
        }

        private string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        #region add
        public void AddMedicine(Medicine medicine)
        {
            try
            {
                IDalService.AddMedicine(medicine);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void AddPatient(Patient patient)
        {
            try
            {
                IDalService.AddPatient(patient);
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
                IDalService.AddRecipe(recipe);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void AddUser(User user)
        {
            try
            {
                IDalService.AddUser(user);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion add

        #region update
        public void UpdateMedicine(Medicine medicine)
        {
            try
            {
                IDalService.UpdateMedicine(medicine);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void UpdatePatient(Patient patient)
        {
            try
            {
                IDalService.UpdatePatient(patient);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void UpdateRecipe(Recipe recipe)
        {
            try
            {
                IDalService.UpdateRecipe(recipe);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void UpdateUser(User user)
        {
            try
            {
                IDalService.UpdateUser(user);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion update

        #region delete
        public void DeleteMedicine(Medicine medicine)
        {
            try
            {
                IDalService.DeleteMedicine(medicine);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeletePatient(Patient patient)
        {
            try
            {
                IDalService.DeletePatient(patient);
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
                IDalService.DeleteRecipe(recipe);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void DeleteUser(User user)
        {
            try
            {
                IDalService.DeleteUser(user);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion delete

        #region get all/some
        public List<Medicine> GetAllMedicines(Func<Medicine, bool> predicate = null)
        {
            try
            {
                List<Medicine> res = IDalService.GetAllMedicines();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<Patient> GetAllPatients(Func<Patient, bool> predicate = null)
        {
            try
            {
                List<Patient> res = IDalService.GetAllPatients();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<Recipe> GetAllRecipes(Func<Recipe, bool> predicate = null)
        {
            try
            {
                List<Recipe> res = IDalService.GetAllRecipes();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<User> GetAllUsers(Func<User, bool> predicate = null)
        {
            try
            {
                List<User> res = IDalService.GetAllUsers();
                return res;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion get all/some

        #region get 
        public Medicine GetMedicine(string id)
        {
            try
            {
                return IDalService.GetMedicine(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Patient GetPatient(string id)
        {
            try
            {
                return IDalService.GetPatient(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Recipe GetRecipe(string recipeId)
        {
            try
            {
                return IDalService.GetRecipe(recipeId);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public User GetUser(string id)
        {
            try
            {
                return IDalService.GetUser(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion get 

        #region statistics

        public Dictionary<string, int> drugStatistics(DateTime start, DateTime finish, string drugID = null)
        {
            try
            {
                Dictionary<string, int> result = new Dictionary<string, int>();
                if (drugID != null)
                {
                    var prescriptionsOnTheAppropriateDate = (from item in IDalService.GetAllRecipes()
                                                             where (drugID == item.MedicineId && start <= item.Date && finish >= item.Date)
                                                             group item by item.Date.ToString("MM")).ToList();
                    var prescriptions = prescriptionsOnTheAppropriateDate.OrderBy(g => g.Key);
                    foreach (var g in prescriptions)
                    {
                        result.Add(g.Key, g.Count());
                    }
                }
                if (drugID == null)
                {
                    var prescriptionsOnTheAppropriateDate = (from item in IDalService.GetAllRecipes()
                                                             where (start <= item.Date && finish >= item.Date)
                                                             group item by item.Date.ToString("MM")).ToList();
                    var prescriptions = prescriptionsOnTheAppropriateDate.OrderBy(g => g.Key);
                    foreach (var g in prescriptions)
                    {
                        result.Add(g.Key, g.Count());
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<Recipe> getPatientHistoryByDrug(DateTime first, DateTime second, string patientId = null, string drugID = null)
        {
            try
            {
                List<Recipe> result = new List<Recipe>();
                if (patientId != null && drugID != null)
                {
                    result = (from item in getPatientHistory(patientId)
                              where drugID == item.MedicineId && item.Date <= second.AddDays(1) && item.Date.AddDays(item.PeriodOfUse) > first
                              select item).ToList();
                }
                if (patientId != null && drugID == null)
                {
                    result = (from item in getPatientHistory(patientId)
                              where item.Date <= second.AddDays(1) && item.Date.AddDays(item.PeriodOfUse) > first
                              select item).ToList();
                }
                if (patientId == null && drugID != null)
                {
                    result = (from item in IDalService.GetAllRecipes()
                              where drugID == item.MedicineId && item.Date <= second.AddDays(1) && item.Date.AddDays(item.PeriodOfUse) > first
                              select item).ToList();
                }
                if (patientId == null && drugID == null)
                {
                    result = (from item in IDalService.GetAllRecipes()
                              where item.Date <= second.AddDays(1) && item.Date.AddDays(item.PeriodOfUse) > first
                              select item).ToList();
                }
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Recipe> getPatientHistory(string patientId, bool now = false)
        {
            try
            {
                var patientPrescriptions = (from p in GetAllRecipes()
                                            where p.PatientId == patientId
                                            select p).ToList();
                if (now)
                {
                    var drugsRightOfToday = (from p in patientPrescriptions
                                             where p.Date.AddDays(p.PeriodOfUse) >= DateTime.Now
                                             select p).ToList();
                    return drugsRightOfToday;
                }
                else
                {
                    return patientPrescriptions.ToList();
                }
            }
            catch (Exception)
            {
                throw new Exception("לא נמצא חולה במערכת");
            }
        }

        #endregion

        #region PDF


        public void CreateDocument(List<Recipe> r)
        {
            for (int i = 0; i < r.Count; i++)
            {
                Patient pa = GetPatient(r[i].PatientId);
                User u = GetUser(r[i].DoctorId);
                Medicine m = GetMedicine(r[i].MedicineId);

                // Create a new MigraDoc document
                Document document = new Document();
                document.Info.Title = "Prescription";


                // Get the predefined style Normal.
                Style style = document.Styles["Normal"];
                style.Font.Name = "Verdana";
                style = document.Styles[StyleNames.Header];
                style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);
                style = document.Styles[StyleNames.Footer];
                style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);
                style = document.Styles.AddStyle("Table", "Normal");
                style.Font.Name = "Verdana";
                style.Font.Name = "Times New Roman";
                style.Font.Size = 9;
                style = document.Styles.AddStyle("Reference", "Normal");
                style.ParagraphFormat.SpaceBefore = "5mm";
                style.ParagraphFormat.SpaceAfter = "5mm";
                style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right);


                // Each MigraDoc document needs at least one section.
                Section section = document.AddSection();

                // Put a logo in the header
                Image image = section.Headers.Primary.AddImage("../../Images/bikurofelogo.png");
                image.Height = "2.5cm";
                image.LockAspectRatio = true;
                image.RelativeVertical = RelativeVertical.Line;
                image.RelativeHorizontal = RelativeHorizontal.Margin;
                image.Top = ShapePosition.Top;
                image.Left = ShapePosition.Right;
                image.WrapFormat.Style = WrapStyle.Through;


                Paragraph paragraph = section.Footers.Primary.AddParagraph();


                // Create the text frame for the address
                var addressFrame = section.AddTextFrame();
                addressFrame.Height = "3.0cm";
                //addressFrame.Width = "20cm";
                addressFrame.Left = ShapePosition.Center;
                addressFrame.RelativeHorizontal = RelativeHorizontal.Margin;
                addressFrame.Top = "5.0cm";
                addressFrame.RelativeVertical = RelativeVertical.Page;

                // Put sender in address frame
                paragraph = addressFrame.AddParagraph(Reverse("מרשם"));
                paragraph.Format.Font.Name = "Times New Roman";
                paragraph.Format.Font.Size = 24;
                paragraph.Format.SpaceAfter = 3;


                // Add the print date field
                paragraph = section.AddParagraph();
                paragraph.Format.SpaceBefore = "8cm";
                paragraph.Style = "Reference";
                //paragraph.AddFormattedText("אאאאאאאאאאא", TextFormat.Bold);
                paragraph.AddTab();
                paragraph.AddText("Prescription, ");
                paragraph.AddDateField("dd.MM.yyyy");


                // Create the item table

                Table table = section.AddTable();
                table.Style = "Table";
                //table.Borders.Color = TableBorder;
                table.Borders.Width = 0.25;
                table.Borders.Left.Width = 0.5;
                table.Borders.Right.Width = 0.5;
                table.Rows.LeftIndent = 0;


                // Before you can add a row, you must define the columns
                Column column = table.AddColumn("1cm");
                column.Format.Alignment = ParagraphAlignment.Center;
                column = table.AddColumn("2.0cm");
                column.Format.Alignment = ParagraphAlignment.Right;
                column = table.AddColumn("2cm");
                column.Format.Alignment = ParagraphAlignment.Right;
                column = table.AddColumn("2cm");
                column.Format.Alignment = ParagraphAlignment.Right;
                column = table.AddColumn("2cm");
                column.Format.Alignment = ParagraphAlignment.Center;
                column = table.AddColumn("2cm");
                column.Format.Alignment = ParagraphAlignment.Right;
                column = table.AddColumn("2cm");
                column.Format.Alignment = ParagraphAlignment.Right;
                column = table.AddColumn("2cm");
                column.Format.Alignment = ParagraphAlignment.Right;

                // Create the header of the table

                Row row = table.AddRow();
                row = table.AddRow();
                row.HeadingFormat = true;
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Format.Font.Bold = true;



                row.Cells[1].AddParagraph(Reverse("מספר פעמים ביום"));

                row.Cells[1].Format.Alignment = ParagraphAlignment.Right;

                row.Cells[2].AddParagraph(Reverse("משך זמן בימים"));

                row.Cells[2].Format.Alignment = ParagraphAlignment.Right;

                row.Cells[3].AddParagraph(Reverse("שם תרופה"));

                row.Cells[3].Format.Alignment = ParagraphAlignment.Right;

                row.Cells[4].AddParagraph(Reverse("מספר תרופה"));

                row.Cells[4].Format.Alignment = ParagraphAlignment.Right;

                row.Cells[5].AddParagraph(Reverse("שם רופא מטפל"));

                row.Cells[5].Format.Alignment = ParagraphAlignment.Right;

                row.Cells[6].AddParagraph(Reverse("מספר זהות"));

                row.Cells[6].Format.Alignment = ParagraphAlignment.Right;

                row.Cells[7].AddParagraph(Reverse("שם חולה"));

                row.Cells[7].Format.Alignment = ParagraphAlignment.Right;

                table.SetEdge(0, 0, 6, 2, Edge.Box, BorderStyle.Single, 0.75);

                Paragraph p = addressFrame.AddParagraph();

                p.AddLineBreak();

                p.AddLineBreak();

                // Each item fills two rows

                Row row1 = table.AddRow();
                row1.TopPadding = 1.5;
                row1.Cells[7].AddParagraph(Reverse(pa.Fname + " " + pa.Lname));
                row1.Cells[6].AddParagraph(pa.PatientId);
                row1.Cells[5].AddParagraph(Reverse(u.Fname + " " + u.Lname));
                row1.Cells[4].AddParagraph(m.Id);
                row1.Cells[3].AddParagraph(m.CommercialName);
                row1.Cells[2].AddParagraph(r[i].PeriodOfUse.ToString());
                row1.Cells[1].AddParagraph(r[i].QuantityPerDay.ToString());

                string pdfFilename = r[i].RecipeId + ".pdf";
                var pdf = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.None);
                pdf.Document = document;
                pdf.RenderDocument();
                pdf.Save(pdfFilename);
                Process.Start(pdfFilename);

            }
        }

        public void print(List<Recipe> r)
        {

            CreateDocument(r);
            for (int i = 0; i < r.Count; i++)
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.Verb = "print";
                info.FileName = r[i].RecipeId + ".pdf";
                info.CreateNoWindow = true;
                info.WindowStyle = ProcessWindowStyle.Hidden;

                Process p = new Process();
                p.StartInfo = info;
                p.Start();

                p.WaitForInputIdle();
                System.Threading.Thread.Sleep(3000);
                if (false == p.CloseMainWindow())
                    p.Kill();
            }

        }
        #endregion PDF  

        #region interaction
        public List<string> getDrugsNames()
        {
            return CI.getDrugsNames();
        }

        public List<string> interactionDrugs(string drugName)
        {
            return CI.interactionDrugs(this.GetMedicineId(drugName));
        }
        #endregion  interaction

        #region other
        public string getPrescriptionID()
        {
            int result;
            Random rnd = new Random();
            result = rnd.Next(100000000, 999999999);

            bool flag = false;
            while (!flag)
            {
                flag = true;
                result = rnd.Next(100000000, 999999999);
                foreach (var item in GetAllRecipes())
                {
                    if (result == int.Parse(item.RecipeId))
                    {
                        flag = false;
                        break;
                    }


                }
            }

            return result.ToString();
        }
        public List<string> GetAllPatientsId()
        {
            try
            {
                var ids = (from item in IDalService.GetAllPatients()
                           select item.PatientId).ToList();

                return ids;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public List<string> GetAllMedicineId()
        {
            try
            {
                var ids = (from item in IDalService.GetAllMedicines()
                           select item.Id).ToList();
                return ids;
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
                List<string> res = new List<string>();
                res = (from item in prescriptionsGiven
                       select item.MedicineName).ToList();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<string> GetAllMedicinesNames()
        {
            try
            {
                var names = (from item in IDalService.GetAllMedicines()
                             select item.CommercialName).ToList();
                return names;
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
                Medicine medicine = new Medicine();

                medicine = (from item in GetAllMedicines()
                            where item.CommercialName == medicineName
                            select item).FirstOrDefault();
                if (medicine == null)
                {
                    throw new Exception("אין כזו תרופה");
                }
                return medicine.Id;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public int ResolveRxcuiFromName(string name)
        {
            try
            {
                return CI.ResolveRxcuiFromName(name);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public List<string> GetAllUserId()
        {
            try
            {
                var res = (from item in GetAllUsers()
                           select item.Id).ToList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


        #endregion other

    }

}







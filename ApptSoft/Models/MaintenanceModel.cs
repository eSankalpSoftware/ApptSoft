using ApptSoft.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApptSoft.Models
{
    public class MaintenanceModel
    {


        public int Id { get; set; }
        public string FlatNo { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string PaymentMode { get; set; }
        public string TransactionNo { get; set; }
        public string PaidDate { get; set; }
        public string DueDate { get; set; }
        public string Receipt { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public string CreateDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public string UpdateDate { get; set; }

        public string SaveMaintenanceData(MaintenanceModel model)
        {
            string msg = "data successfully data ";
            ApptSoftEntities1 db = new ApptSoftEntities1();
            {
                if (model.Id == 0)
                {
                    var maintenanceData = new tblMaintenance()
                    {
                        // Id = model.Id,
                        FlatNo = model.FlatNo,
                        Month = model.Month,
                        Year = model.Year,
                        Amount = model.Amount,
                        PaymentMode = model.PaymentMode,
                        TransactionNo = model.TransactionNo,
                        PaidDate = Convert.ToDateTime(model.PaidDate),
                        DueDate = Convert.ToDateTime(model.DueDate),
                        Receipt = model.Receipt,
                        CreateBy = model.CreateBy,
                        CreateDate = Convert.ToDateTime(DateTime.Now),
                        UpdateBy = model.UpdateBy,
                        UpdateDate = Convert.ToDateTime(DateTime.Now)

                    };
                    db.tblMaintenances.Add(maintenanceData);
                    db.SaveChanges();
                    msg = "Data Saved";
                }
                else
                {
                    var maintenanceData = db.tblMaintenances.Where(p => p.Id == model.Id).FirstOrDefault();
                    if (maintenanceData != null)
                    {
                        maintenanceData.Id = model.Id;
                        maintenanceData.FlatNo = model.FlatNo;
                        maintenanceData.Month = model.Month;
                        maintenanceData.Year = model.Year;
                        maintenanceData.Amount = model.Amount;
                        maintenanceData.PaymentMode = model.PaymentMode;
                        maintenanceData.TransactionNo = model.TransactionNo;
                        maintenanceData.PaidDate = Convert.ToDateTime(model.PaidDate);
                        maintenanceData.DueDate = Convert.ToDateTime(model.DueDate);
                        maintenanceData.Receipt = model.Receipt;
                        maintenanceData.CreateDate = Convert.ToDateTime(model.CreateDate);
                        maintenanceData.CreateBy = model.CreateBy;
                        maintenanceData.UpdateDate = Convert.ToDateTime(model.CreateDate);
                        maintenanceData.UpdateBy = model.UpdateBy;

                    };
                    db.SaveChanges();
                    msg = "Updated Successfully";
                    //return msg;
                }
            }
            return msg;
        }
        public List<MaintenanceModel> GetMaintenanceData()
        {
            ApptSoftEntities1 db = new ApptSoftEntities1();
            List<MaintenanceModel> listob = new List<MaintenanceModel>();
            var maintenanceData = db.tblMaintenances.ToList();
            if (maintenanceData != null)
            {
                foreach (var model in maintenanceData)
                {
                    listob.Add(new MaintenanceModel()
                    {
                        Id = model.Id,
                        FlatNo = model.FlatNo,
                        Month = model.Month,
                        Year = model.Year,
                        Amount = model.Amount,
                        PaymentMode = model.PaymentMode,
                        TransactionNo = model.TransactionNo,
                        PaidDate = model.PaidDate.ToShortDateString(),
                        DueDate = model.DueDate.ToShortDateString(),
                        Receipt = model.Receipt,
                        CreateBy = model.CreateBy,
                        CreateDate = DateTime.Now.ToString("dd/MM/yyyy"),
                        UpdateBy = model.UpdateBy,
                        UpdateDate = DateTime.Now.ToString("dd/MM/yyyy")
                    });
                }
            }
            return listob;
        }
        public string DeleteMaintenanceData(int Id)
        {
            string msg = "";
            ApptSoftEntities1 db = new ApptSoftEntities1();
            var maintenanceData = db.tblMaintenances.Where(p => p.Id == Id).FirstOrDefault();
            if (maintenanceData != null)
            {
                db.tblMaintenances.Remove(maintenanceData);
            };
            db.SaveChanges();
            msg = "Record delete";


            return msg;
        }
        public MaintenanceModel GetMaintenanceData(int Id)
        {
            MaintenanceModel model = new MaintenanceModel();
            ApptSoftEntities1 db = new ApptSoftEntities1();
            var maintenanceData = db.tblMaintenances.Where(p => p.Id == Id).FirstOrDefault();
            if (maintenanceData != null)

            {
                model.Id = maintenanceData.Id;
                model.Month = maintenanceData.Month;
                model.Year = maintenanceData.Year;
                model.FlatNo = maintenanceData.FlatNo;
                model.Amount = maintenanceData.Amount;
                model.PaymentMode = maintenanceData.PaymentMode;
                model.TransactionNo = maintenanceData.TransactionNo;
                model.Receipt = maintenanceData.Receipt;
                model.PaidDate = maintenanceData.PaidDate.ToShortDateString();
                model.PaidDate = maintenanceData.PaidDate.ToShortDateString();
                model.CreateBy = maintenanceData.CreateBy;
                model.CreateDate = maintenanceData.CreateDate.ToString();
                model.UpdateBy = maintenanceData.UpdateBy;
                model.UpdateDate = maintenanceData.UpdateDate.ToString();

            };
            return model;
        }
        public List<MaintenanceModel> GetMaintenanceDataseacr(string Year = null, string month = null)
        {
            ApptSoftEntities db = new ApptSoftEntities();
            List<MaintenanceModel> listob = new List<MaintenanceModel>();
            var maintenanceData = db.tblMaintenances.ToList().Where(x => x.Year == Year && x.Month == month).ToList(); ;
            if (maintenanceData != null)
            {
                foreach (var model in maintenanceData)
                {
                    listob.Add(new MaintenanceModel()
                    {
                        Id = model.Id,
                        FlatNo = model.FlatNo,
                        Month = model.Month,
                        Year = model.Year,
                        Amount = model.Amount,
                        PaymentMode = model.PaymentMode,
                        TransactionNo = model.TransactionNo,
                        PaidDate = model.PaidDate.ToShortDateString(),
                        DueDate = model.DueDate.ToShortDateString(),
                        Receipt = model.Receipt,
                        CreateBy = model.CreateBy,
                        CreateDate = DateTime.Now.ToString("dd/MM/yyyy"),
                        UpdateBy = model.UpdateBy,
                        UpdateDate = DateTime.Now.ToString("dd/MM/yyyy")
                    });
                }
            }
            return listob;
        }


    }
}
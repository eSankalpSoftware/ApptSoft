using ApptSoft.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace ApptSoft.Models
{
    public class ResidentModel
    {

        public string FlatNo { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string Wing { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<bool>IsParking { get; set; }
        public string JoinDate { get; set; }
        public string Adharcard { get; set; }
        public string Photo { get; set; }
        public string FlatType { get; set; }
        public string Area { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public string CreateDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public string UpdateDate { get; set; }

        public string SaveResidentData(HttpPostedFileBase fb,ResidentModel model)
        {
            string msg = "Save";
            ApptSoftEntities db = new ApptSoftEntities();
            string filepath = "";
            string fileName = "";
            string sysFileName = "";
            if (fb != null && fb.ContentLength > 0)
            {
                filepath = HttpContext.Current.Server.MapPath("../Content/Img/");
                DirectoryInfo di = new DirectoryInfo(filepath);
                if (!di.Exists)
                {
                    di.Create();

                }
                fileName = fb.FileName;
                sysFileName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(fb.FileName);
                fb.SaveAs(filepath + "//" + sysFileName);
                if (!string.IsNullOrWhiteSpace(fb.FileName))
                {
                    string afileName = HttpContext.Current.Server.MapPath("../Content/Img") + "/" + sysFileName;
                }
            }
            if (model.Id == 0)
                {
                    var residentData = new tblResident()
                    {
                       
                        FlatNo = model.FlatNo,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        MobileNo = model.MobileNo,
                        Wing = model.Wing,
                        Email = model.Email,
                        Password = model.Password,
                        IsParking = model.IsParking,
                        JoinDate = Convert.ToDateTime(model.JoinDate),
                        Adharcard = model.Adharcard,
                        Photo = sysFileName,
                        FlatType = model.FlatType,
                        Area = model.Area,
                        CreateBy = model.CreateBy,
                        CreateDate = Convert.ToDateTime(DateTime.Now),
                        UpdateBy = model.UpdateBy,
                        UpdateDate = Convert.ToDateTime(DateTime.Now)

                    };
                    db.tblResidents.Add(residentData);
                    db.SaveChanges();
                    return msg;
                }
                else
                {
                    var residentData = db.tblResidents.Where(p => p.Id == model.Id).FirstOrDefault();
                    if (residentData != null)
                    {
                        residentData.Id = model.Id;
                        residentData.FlatNo = model.FlatNo;
                        residentData.FirstName = model.FirstName;
                        residentData.LastName = model.LastName;
                        residentData.MobileNo = model.MobileNo;
                        residentData.Wing = model.Wing;
                        residentData.Email = model.Email;
                        residentData.Password = model.Password;
                        residentData.IsParking = model.IsParking;
                        residentData.JoinDate = Convert.ToDateTime(model.JoinDate);
                        residentData.Adharcard = sysFileName;
                        residentData.Photo = sysFileName;
                        residentData.FlatType = model.FlatType;
                        residentData.Area = model.Area;
                        residentData.CreateBy = model.CreateBy;
                        residentData.CreateDate = Convert.ToDateTime(DateTime.Now);
                        residentData.UpdateBy = model.UpdateBy;
                        residentData.UpdateDate = Convert.ToDateTime(DateTime.Now);

                    };
                    db.SaveChanges();
                    msg = "Updated Successfully";
                }
               return msg;   
        }



        public List<ResidentModel> GetResidentData()
        {
            ApptSoftEntities db = new ApptSoftEntities();
            List<ResidentModel> listcon = new List<ResidentModel>();
            var residentData = db.tblResidents.ToList();
            if (residentData != null)
            {
                foreach (var model in residentData)
                {
                    listcon.Add(new ResidentModel()
                    {
                        Id = model.Id,
                        FlatNo = model.FlatNo,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        MobileNo = model.MobileNo,
                        Wing = model.Wing,
                        Email = model.Email,
                        JoinDate = model.JoinDate.ToShortDateString(),
                        Adharcard = model.Adharcard,
                        Photo = model.Photo,
                        FlatType = model.FlatType,
                        Area = model.Area,
                        CreateBy = model.CreateBy,
                        CreateDate = DateTime.Now.ToString("dd/MM/yyyy"),
                        UpdateBy = model.UpdateBy,
                        UpdateDate = DateTime.Now.ToString("dd/MM/yyyy"),
                        Password = model.Password,
                        IsParking = model.IsParking,

                    });
                }
            }
            return listcon;

        }

        public string DeleteResidentData(int Id)
        {
            string msg = "";
            ApptSoftEntities db = new ApptSoftEntities();
            var residentdata = db.tblResidents.Where(p => p.Id == Id).FirstOrDefault();
            if (residentdata != null)
            {
                db.tblResidents.Remove(residentdata);
            };
            db.SaveChanges();
            msg = "Record delete";
            return msg;
        }

        public ResidentModel EditResidentData(int Id)
        {

            ResidentModel model = new ResidentModel();
            ApptSoftEntities db = new ApptSoftEntities();
            var residentdata = db.tblResidents.Where(p => p.Id == Id).FirstOrDefault();
            if (residentdata != null)

            {
                model.Id = residentdata.Id;
                model.FlatNo = residentdata.FlatNo;
                model.FirstName = residentdata.FirstName;
                model.LastName = residentdata.LastName;
                model.MobileNo = residentdata.MobileNo;
                model.Wing = residentdata.Wing;
                model.Email = residentdata.Email;
                model.Password = residentdata.Password;
                model.IsParking = residentdata.IsParking;
                model.JoinDate = residentdata.JoinDate.ToShortDateString();
               // model.Adharcard = residentdata.Adharcard;
               // model.Photo = residentdata.Photo;
                model.FlatType= residentdata.FlatType;   
                model.Area= residentdata.Area;
                model.CreateBy = residentdata.CreateBy;
                model.CreateDate = residentdata.CreateDate.ToString();
                model.UpdateBy = residentdata.UpdateBy;
                model.UpdateDate = residentdata.UpdateDate.ToString();

            };

            return model;
        }

    }
}
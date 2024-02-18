using Desh_Exam.CrystalReports;
using Desh_Exam.Models;
using Desh_Exam.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Desh_Exam.Controllers
{
    public class ReportsController : Controller
    {
        private readonly BookDbContext db = new BookDbContext();
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ReportDTO dto)
        {
            var data = db.Books.AsEnumerable().Where(x => x.Date.Date >= dto.FromDate.Date && x.Date.Date <= dto.ToDate.Date).ToList();
            dto.Books = data;
            return View(dto);
            
        }
        public ActionResult GetPdf(DateTime from, DateTime to)
        {
            var data = db.Books.AsEnumerable().Where(x => x.Date.Date >= from.Date && x.Date.Date <= to.Date).ToList();
            RptOuBook rpt = new RptOuBook();
            rpt.Load();
            rpt.SetDataSource(data);
            Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(s, "application/pdf");
        }
        public ActionResult GetExcel(DateTime from, DateTime to)
        {
            var data = db.Books.AsEnumerable().Where(x => x.Date.Date >= from.Date && x.Date.Date <= to.Date).ToList();
            RptOuBook rpt = new RptOuBook();
            rpt.Load();
            rpt.SetDataSource(data);
            Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
            return File(s, "application/vnd.ms-excel");
        }
    }
}
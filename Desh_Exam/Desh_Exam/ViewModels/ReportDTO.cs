using Desh_Exam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Desh_Exam.ViewModels
{
    public class ReportDTO
    {
        [Required, DataType(DataType.Date), Display(Name ="From Date")] 
        public DateTime FromDate { get; set; }
        [Required, DataType(DataType.Date), Display(Name ="To Date")]
        public DateTime ToDate { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
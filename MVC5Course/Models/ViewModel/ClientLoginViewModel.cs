using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.ViewModel
{
    public class ClientLoginViewModel
    {
        [Required]
        //{0}-欄位名稱' {1}變數
        [StringLength(10, ErrorMessage = "{0}最大不可超過{1}個字")]
        [DisplayName("名")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "{0}最大不可超過{1}個字")]
        [DisplayName("中間名")]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "{0}最大不可超過{1}個字")]
        [DisplayName("姓")]
        public string LastName { get; set; }
        
        [DisplayName("生日")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateOfBirth { get; set; }
    }
}
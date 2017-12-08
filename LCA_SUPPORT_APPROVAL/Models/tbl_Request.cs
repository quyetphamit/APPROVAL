namespace LCA_SUPPORT_APPROVAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class tbl_Request
    {
        [Display(Name ="Mã")]
        public int id { get; set; }

        public int userId_Create { get; set; }

        public int userId_Approval { get; set; }

        public int? userId_Update { get; set; }

        public int customer_Id { get; set; }

        [Required(ErrorMessage = "Số lượng không được bỏ trống")]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng ngoài khoảng cho phép")]
        [Display(Name = "Số lượng")]
        public int quantity { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

        [Display(Name = "Ngày mong muốn")]
        [Required(ErrorMessage = "Ngày mong muốn không được bỏ trống")]
        public DateTime dealLine { get; set; }

        [Required(ErrorMessage ="Tiêu đề không được bỏ trống")]
        [StringLength(100,ErrorMessage ="Tiêu đề không được vượt quá 100 kí tự")]
        [Display(Name = "Tiêu đề")]

        public string content { get; set; }

        [Display(Name = "Tăng năng suất")]
        public bool increaseProductivity { get; set; }

        [Display(Name = "Model mới")]
        public bool newModel { get; set; }

        [Display(Name = "Tăng sản lượng")]
        public bool increaseProduction { get; set; }

        [Display(Name = "Cải tiến chất lượng")]
        public bool improve { get; set; }

        [Column("_5s")]
        [Display(Name = "5S")]
        public bool C_5s { get; set; }

        [Display(Name = "Jig bị mòn/NG")]
        public bool checkJig { get; set; }

        [Display(Name = "Cắt giảm người")]
        public int? reducePeple { get; set; }

        [StringLength(200)]
        [Display(Name = "Nội dung lỗi")]
        public string errorContent { get; set; }

        [StringLength(10)]
        [Display(Name = "Tỷ lệ lỗi hiện tại")]
        public string currentError { get; set; }

        [StringLength(10)]
        [Display(Name = "Hiệu quả cải tiến")]
        public string afterError { get; set; }

        [Display(Name = "Khác")]
        [StringLength(100)]
        public string other { get; set; }

        [StringLength(100)]
        [Display(Name = "Chi trả")]
        public string pay { get; set; }

        [StringLength(100)]
        [Display(Name = "Model")]
        public string model { get; set; }

        [StringLength(100)]
        [Display(Name = "PCB")]
        public string pcb { get; set; }

        [StringLength(20)]
        [Display(Name = "Điện thoại liên hệ")]
        public string phone { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Chi tiết")]
        [AllowHtml]
        public string contentDetail { get; set; }

        [Display(Name = "Chi phí")]
        public int? cost { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày yêu cầu")]
        public DateTime date_Create { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày cập nhật")]
        public DateTime? date_Update { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày nhận")]
        public DateTime? date_Received { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày trả")]
        public DateTime? date_Finish { get; set; }

        [StringLength(100)]
        [Display(Name = "Tệp tải lên")]
        public string file_upload { get; set; }

        public virtual tbl_Customer tbl_Customer { get; set; }

        public virtual tbl_User tbl_User { get; set; }
    }
}

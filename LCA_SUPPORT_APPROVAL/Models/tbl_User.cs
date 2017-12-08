namespace LCA_SUPPORT_APPROVAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_User()
        {
            tbl_Request = new HashSet<tbl_Request>();
        }

        [Key]
        public int user_Id { get; set; }

        public int? group_Id { get; set; }

        [Required(ErrorMessage ="Tên đăng nhập không được bỏ trống")]
        [StringLength(6)]
        public string username { get; set; }

        [Required(ErrorMessage ="Mật khẩu không được bỏ trống")]
        [StringLength(50)]
        public string pass { get; set; }

        [Required]
        [StringLength(100)]
        public string fullname { get; set; }

        [StringLength(20)]
        public string phone { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(100)]
        public string create_at { get; set; }

        public bool isAdmin { get; set; }

        public virtual tbl_Group tbl_Group { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Request> tbl_Request { get; set; }
    }
}

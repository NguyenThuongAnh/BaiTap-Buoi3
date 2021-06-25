namespace BaiTap_Buoi3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "ID không được để trống")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Tên sách không được để trống")]
        [Display(Name = "Title")]
        [StringLength(100, ErrorMessage = "Tên sách không được vượt quá 100 ký tự")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Tên tác giả không được để trống")]
        [Display(Name = "Author")]
        [StringLength(30, ErrorMessage = "Tên tác giả không được vượt quá 30 ký tự")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Mô tả không được để trống")]
        [Display(Name = "Descrription")]
        [StringLength(255)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Hình ảnh không được để trống")]
        [Display(Name = "Images")]
        [StringLength(255)]
        public string Images { get; set; }

        [Required(ErrorMessage = "Giá tiền không được để trống")]
        [Display(Name = "Price")]
        [Range(1000, 1000000, ErrorMessage = "Giá tiền phải trong khoảng từ 1000 VNĐ - 1.000.000 VNĐ")]
        public int Price { get; set; }
    }
}

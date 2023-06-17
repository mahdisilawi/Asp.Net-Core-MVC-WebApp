using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage ="وارد کردن عنوان اجباری است")]
        [DisplayName("عنوان")]
        public string Title { get; set; }

        [Required(ErrorMessage = "وارد کردن توضیحات اجباری است")]
        [DisplayName("توضیحات")]
        public string Description { get; set; }

        [Required(ErrorMessage = "وارد کردن توضیحات کوتاه اجباری است")]
        [DisplayName("توضیحات کوتاه")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "وارد کردن شابک اجباری است")]
        [DisplayName("شابک")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "وارد کردن نام نویسنده اجباری است")]
        [DisplayName("نام نویسنده")]
        public string Author { get; set; }

        [Required(ErrorMessage = "وارد کردن لیست قیمت ها اجباری است")]
        [DisplayName("لیست قیمت ها")]
        public double ListPrice { get; set; }

        [Required(ErrorMessage = "وارد کردن قیمت اجباری است")]
        [DisplayName("قیمت")]
        public double Price { get; set; }

        [Required(ErrorMessage = "وارد کردن قیمت 50 عدد اجباری است")]
        [DisplayName("قیمت 50 عدد")]
        public double Price50 { get; set; }

        [Required(ErrorMessage = "وارد کردن قیمت 100 عدد اجباری است")]
        [DisplayName("قیمت 100 عدد")]
        public double Price100 { get; set; }

        [Required(ErrorMessage = "وارد کردن تصویر محصول اجباری است")]
        [DisplayName(" تصویر محصول")]
        [ValidateNever]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "وارد کردن عنوان تصویر محصول اجباری است")]
        [DisplayName(" عنوان تصویر محصول")]
        public string ImageTitle { get; set; }

        [Required(ErrorMessage = "وارد کردن  نام جایگزین تصویر محصول اجباری است")]
        [DisplayName(" نام جایگزین تصویر محصول")]
        public string ImageAlt { get; set; }

        [Required(ErrorMessage = "وارد کردن دسته اجباری است")]
        [DisplayName("دسته")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [Required(ErrorMessage = "وارد کردن کاور تایپ اجباری است")]
        [DisplayName("کاور تایپ")]
        public int CoverTypeId { get; set; }

        [ForeignKey("CoverTypeId")]
        [ValidateNever]

        public CoverType CoverType { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}

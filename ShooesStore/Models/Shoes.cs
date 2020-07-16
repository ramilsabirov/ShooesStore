using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShooesStore.Models
{
    public class Shoes
    {
        [HiddenInput(DisplayValue=false)]
        [Display(Name = "ID")]
        public int ShoesId { get; set; }

        [Display (Name = "Название")]
        [Required(ErrorMessage = "Пожалуйста, введите название обуви")]
        public string NameShoes { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Пожалуйста, опишите товар")]
        public string Discription{ get; set; }

        
        [Display(Name = "Производитель")]
        [Required(ErrorMessage = "Пожалуйста, укажите производителя")]
        public string Manufacturer { get; set; }

        [Display(Name = "Тип")]
        [Required(ErrorMessage = "Пожалуйста, укажите тип")]
        public string ShoesType { get; set; }

        [Display(Name = "Цена (руб)")]
        [Required(ErrorMessage = "Пожалуйста, укажите цену")]
        public int Price { get; set; }

        public string ImgPath { get; set; }
    }
}
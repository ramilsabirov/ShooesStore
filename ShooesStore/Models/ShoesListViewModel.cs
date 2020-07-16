using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShooesStore.Models
{
    public class ShoesListViewModel
    {
        public IEnumerable<Shoes> Shoess { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentShoesType { get; set; }
    }
}
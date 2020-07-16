﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShooesStore.Models
{
    public class PagingInfo
    {
        public int TotalItems{ get; set; }
        public int ItemPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages 
            { get { return (int)Math.Ceiling((decimal)TotalItems / ItemPerPage); } }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class Reader
    {
        public int ReaderID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Book>Books { get; set; }

    }
}

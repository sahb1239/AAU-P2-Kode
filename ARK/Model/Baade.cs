﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARK.Model
{
    public class Baade : Search.Searchable<Baade>
    {
        public int ID { get; set; }
        public string Navn { get; set; }
        public int AntalPladser { get; set; }
        public bool Aktiv { get; set; }
        public int BådType { get; set; }
        public bool Roforbud { get; set; }
        public int SpecifikBådType { get; set; }
        public bool LangtursBåd { get; set; }

        public override Baade getTarget()
        {
            return this;
        }
    }
}
﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM2E1201910050106.model
{
    public class Modelo
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength(20)]
        public double latitud { get; set; }
        [MaxLength(20)]
        public double longitud { get; set; }
        [MaxLength(600)]
        public string descripcion { get; set; }
        [MaxLength(100)]
        public byte[] fotografia { get; set; }
    }
}
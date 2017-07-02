using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectDemo.Models
{
    public class VideoJuego
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string ImagenUrl { get; set; }
    }
}
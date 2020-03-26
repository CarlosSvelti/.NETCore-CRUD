using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDDemo.Models
{
    public class EmployeeInfo
    {
        public int ID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Genero { get; set; }
        [Required]
        public string Compañia { get; set; }
        [Required]
        public string Departamento { get; set; }
    }
}

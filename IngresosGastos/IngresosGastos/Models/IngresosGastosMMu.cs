using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IngresosGastos.Models
{
    public class IngresosGastosMMu
    {
        //Data Annotattions, propiedades a cada atributo
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Descripcion { get; set; }
        [Required]
        [Display(Name ="Tipo")] //Cambia el display o label en todos los lados donde se utiliza esta propiedad
        public bool EsIngreso { get; set; }
        [Required]
        public double Valor { get; set; }
        [Display(Name = "Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; }
    }
}
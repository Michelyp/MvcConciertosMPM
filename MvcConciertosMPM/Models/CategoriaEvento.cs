using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcConciertosMPM.Models
{
    public class CategoriaEvento
    {

        public int Idcategoria { get; set; }
        public string Nombre { get; set; }
    }
}

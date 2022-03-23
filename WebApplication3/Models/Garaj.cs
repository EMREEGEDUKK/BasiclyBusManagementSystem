using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Garaj
    {
        public int GarajID { get; set; }
        public string GarajAdres { get; set; }
        public int GarajKapasite { get; set; }

        [ForeignKey("Firma")]
        public int Firma_ID { get; set; }
        public Firma Firma { get; set; }


    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Otobus
    {
        public int OtobusID { get; set; }
        public string Plaka { get; set; }
        public string rota { get; set; }
        public int OtobusKapasite { get; set; }
        [ForeignKey("Firma")]
        public int Firma_ID { get; set; }
        public Firma Firma { get; set; }

    }
}

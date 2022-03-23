using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Yolcu
    {
        public int YolcuID { get; set; }
        public string YolcuAd { get; set; }
        public int YolcuTel { get; set; }
        [ForeignKey("Otobus")]
        public int Otobus_ID { get; set; }
        

    }
}

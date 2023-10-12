using System.ComponentModel.DataAnnotations;

namespace Stok.Ekstre.Models
{
    public class STI
    {
        [Key]
        public int Id { get; set; }
        public int IslemTur { get; set; }
        public string EvrakNo { get; set; }
        public int Tarih { get; set; }
        public string MalKodu { get; set; }
        public double Miktar { get; set; }
        public double? Fiyat { get; set; }
        public double? Tutar { get; set; }
        public string Birim { get; set; }
    }
}

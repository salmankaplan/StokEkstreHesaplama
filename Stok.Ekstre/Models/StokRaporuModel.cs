using Microsoft.EntityFrameworkCore;

namespace Stok.Ekstre.Models
{
    [Keyless]
    public class StokRaporuModel
    {
        public long SiraNo { get; set; }
        public string IslemTur { get; set; }
        public string EvrakNo { get; set; }
        public string Tarih { get; set; }
        public int GirisMiktar { get; set; }
        public int CikisMiktar { get; set; }
        public int? StokMiktar { get; set; }
    }
}

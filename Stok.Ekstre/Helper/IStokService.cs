using Stok.Ekstre.Models;

namespace Stok.Ekstre.Helper
{
    public interface IStokService
    {
        Task<List<StokRaporuModel>> GetStokRaporu(string malKodu, int baslangicTarih, int bitisTarih);
        Task<List<string>> GetMalKodu();
    }
}

using Microsoft.EntityFrameworkCore;
using Stok.Ekstre.AppDbContext;
using Stok.Ekstre.Models;

namespace Stok.Ekstre.Helper
{
    public class StokService : IStokService
    {
        private readonly DataContext dbcontext;

        public StokService(DataContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        //prosedürü çalıştırmak için hazırlanmış metod, stok miktarı burada hesaplanıyor.
        public async Task<List<StokRaporuModel>> GetStokRaporu(string malKodu, int baslangicTarih, int bitisTarih)
        {
            var rapor = await dbcontext.StokRaporuModels.FromSqlRaw("[dbo].[StokRaporu] @Malkodu={0} ,@BaslangicTarihi={1}, @BitisTarihi={2}", malKodu, baslangicTarih, bitisTarih)
                .AsAsyncEnumerable()
                .ToListAsync();

            var stok = 0;
            foreach (var item in rapor)
            {
                if (item.IslemTur == "Giriş")
                    stok += item.GirisMiktar;
                else
                    stok -= item.CikisMiktar;
                item.StokMiktar = stok;
            }

            return rapor;
        }

        //Mal koduna göre arama yapabilmek için hazırlanmış metod, listede tekrar eden kayıt bulunmaması için Distinct() metodundan yararlanıldı.
        public async Task<List<string>> GetMalKodu()
        {
            var result = await dbcontext.STI.Select(x => x.MalKodu).Distinct().ToListAsync();
            return result;
        }
    }
}

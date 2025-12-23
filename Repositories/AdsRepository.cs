using BulletinBoardApi.Models;
using System.Text;
using System.Text.Json;

namespace BulletinBoardApi.Repositories
{
    public class AdsRepository
    {
        private readonly string _jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "ads.json");

        public List<Ad> GetAllAds()
        {
            var json = File.ReadAllText(_jsonPath, Encoding.UTF8);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var ads = JsonSerializer.Deserialize<List<Ad>>(json, options);
            return ads;
        }

        public void Save(List<Ad> ads)
        {
            var json = JsonSerializer.Serialize(ads, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(_jsonPath, json);
        }
    }
}

using BulletinBoardApi.Models;
using BulletinBoardApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BulletinBoardApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdsController : ControllerBase
    {
        private readonly AdsRepository _repo = new();

        [HttpGet]
        public IActionResult GetAll()
            => Ok(_repo.GetAllAds());


        [HttpPost]
        public IActionResult Create(Ad ad)
        {
            var ads = _repo.GetAllAds();
            ad.Id = ads.Any() ? ads.Max(a => a.Id) + 1 : 1;
            ad.CreatedAt = DateTime.Now;

            ads.Add(ad);
            _repo.Save(ads);
            return Ok(ad);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Ad updatedAd)
        {
            var ads = _repo.GetAllAds();
            var ad = ads.FirstOrDefault(a => a.Id == id);
            if (ad == null) return NotFound();

            ad.Title = updatedAd.Title;
            ad.Description = updatedAd.Description;
            ad.Phone = updatedAd.Phone;
            ad.ContactName = updatedAd.ContactName;
            ad.Location = updatedAd.Location;
            ad.ImageBase64 = updatedAd.ImageBase64;

            _repo.Save(ads);
            return Ok(ad);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ads = _repo.GetAllAds();
            var ad = ads.FirstOrDefault(a => a.Id == id);
            if (ad == null) return NotFound();

            ads.Remove(ad);
            _repo.Save(ads);
            return NoContent();
        }
    }

}

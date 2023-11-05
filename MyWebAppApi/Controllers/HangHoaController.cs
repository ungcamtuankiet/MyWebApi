using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWebAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
       public static List<HangHoa> hangHoas = new List<HangHoa>();

        [HttpGet]
        //Trả về các method
        public IActionResult GetAll()
        {
            return Ok(hangHoas);
        }

        [HttpGet("{id}")]
        //Trả về các method
        public IActionResult GetById(string id)
        {
            try
            {
                //LINQ [Objec] Query
                //SingleOrDefault là nếu có thì nó trả về đơn còn không có thì trả về null
                var hanghoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    //Trả về 404
                    return NotFound();
                }
                else
                {
                    return Ok(hanghoa);
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        //Dùng để thêm mới các hàng hóa
        [HttpPost]
        public  IActionResult Create(HangHoaVM hangHoaVm)
        {
            var hanghoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVm.TenHangHoa,
                DonGia = hangHoaVm.DonGia
            };
            hangHoas.Add(hanghoa);
            return Ok(new
            {
                Success = true, Data = hanghoa
            });
        }

        //Dùng để sửa
        [HttpPut("{id}")]
        public IActionResult Edit(string id, HangHoa hangHoaEdit)
        {
            try
            {
                var hanghoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                if(id != hanghoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                //Update
                hanghoa.TenHangHoa = hangHoaEdit.TenHangHoa;
                hanghoa.DonGia = hangHoaEdit.DonGia; 
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(string id)
        {
            try
            {
                var hanghoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse (id));
                if(hanghoa == null)
                {
                    return NotFound();
                }
                else
                {
                    hangHoas.Remove(hanghoa);
                }
                return Ok();
            } 
            catch
            {
                return BadRequest();
            }
        }
    }
}

using MyWebAppApi.Models;
using System.Collections.Generic;

namespace MyWebAppApi.Service
{
    public interface ILoaiRepository
    {
        List<LoaiVM> GetAll();
        LoaiVM GetById(int id);
        LoaiVM Add(LoaiModel loai);
        void Update(LoaiVM loai);
        void Remove(int id);
    }
}

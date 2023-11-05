﻿using MyWebAppApi.Models;
using System.Collections.Generic;

namespace MyWebAppApi.Service
{
    public interface IHangHoaRepository
    {
        List<HangHoaModel> GetAll(string search, double? from, double? to, string sortBy, int page =1);
    }
}

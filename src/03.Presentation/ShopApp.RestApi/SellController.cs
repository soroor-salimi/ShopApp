﻿using Microsoft.AspNetCore.Mvc;
using ShopApp.Services.Sells.Contracts;
using ShopApp.Services.Sells.Contracts.Dto;

namespace ShopApp.RestApi
{
    [ApiController]
    [Route("sells")]
    public class SellController:Controller
    {
        private SellServices _services;
        public SellController(SellServices services)
        {
            _services = services;
        }
        [HttpPost]
        public void Add([FromBody]AddedSellDto dto)
        {
            _services.Add(dto);
        }
    }
}

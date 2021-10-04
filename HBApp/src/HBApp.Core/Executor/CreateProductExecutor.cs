﻿using HBApp.Core.Dto;
using HBApp.Core.Interfaces;
using HBApp.Core.ParseStrategy;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HBApp.Core.Services
{
    public class CreateProductExecutor : IExecutor
    {
        IProductService _productService;
        public CreateProductExecutor(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<BaseDto> Execute(BaseDto baseDto)
        {
            var dtoToExecute = (CreateProductDto)baseDto;
            await _productService.AddProductAsync(dtoToExecute);
            return null;
        }
    }
}

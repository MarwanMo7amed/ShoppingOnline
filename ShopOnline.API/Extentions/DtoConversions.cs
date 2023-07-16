﻿using WebApplication1.Entities;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Extentions
{
    public static class DtoConversions
    {
        public static IEnumerable<ProductDto> convertToDto(this IEnumerable<Product> products,
            IEnumerable<ProductCategory> productCategories)
        {
            return (from product in products
                    join productCategory in productCategories
                    on product.CategoryId equals productCategory.Id
                    select new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        ImageURL = product.ImageURL,
                        Price = product.Price,
                        Qty = product.Qty,
                        CategoryId=product.CategoryId,
                        CategoryName= productCategory.Name
                    }).ToList();
        }
        public static ProductDto convertToDto(this Product product,ProductCategory productCategory)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageURL = product.ImageURL,
                Price = product.Price,
                Qty = product.Qty,
                CategoryId = product.CategoryId,
                CategoryName = productCategory.Name
            };
        }
    }
}
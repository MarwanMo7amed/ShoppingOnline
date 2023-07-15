using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web2.Services.Contracts;

namespace ShopOnline.Web2.Pages
{
    public class ProductsBase:ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }
        public IEnumerable<ProductDto>  Products { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Products=await ProductService.GetItems();
        }
    }
}

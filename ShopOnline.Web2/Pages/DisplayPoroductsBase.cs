using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Web2.Pages
{
    public class DisplayPoroductsBase:ComponentBase
    {
        [Parameter]
        public IEnumerable<ProductDto>  Products { get; set; }
    }
}

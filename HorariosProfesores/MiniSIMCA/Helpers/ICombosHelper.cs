using Microsoft.AspNetCore.Mvc.Rendering;

namespace MiniSIMCA.Helpers
{
    public interface ICombosHelper
    {
        Task<IEnumerable<SelectListItem>> GetComboProgramasAsync();
    }
}

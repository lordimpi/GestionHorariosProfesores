using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MiniSIMCA.Helpers
{
    public interface ICombosHelper
    {
        Task<IEnumerable<SelectListItem>> GetComboProgramasAsync();
        Task<IEnumerable<SelectListItem>> GetComboProgramasAsync(IEnumerable<Programa> filter);
        IEnumerable<SelectListItem> GetComboTipoCompetencia();
        IEnumerable<SelectListItem> GetComboDiasSemana();
        IEnumerable<SelectListItem> GetComboTipoIdentificacion();
        IEnumerable<SelectListItem> GetComboTipoDocente();
        IEnumerable<SelectListItem> GetComboTipoContrato();
        IEnumerable<SelectListItem> GetComboArea();
        IEnumerable<SelectListItem> GetComboTipoAmbiente();
    }
}

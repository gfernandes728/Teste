using Microsoft.AspNetCore.Mvc.Rendering;
using Omu.ValueInjecter;
using Teste.Business.Interface;

namespace Teste.Business.Business
{
    public class UtilsBusiness : IUtilsBusiness
    {
        public T Inject<T, R>(T res, R item)
        {
            res.InjectFrom(item);
            return res;
        }

        public SelectListItem ObterSelectItem<T>(T valor, string texto, List<T> selecionados)
            => new SelectListItem()
            {
                Value = valor.ToString(),
                Text = texto,
                Selected = selecionados.Contains(valor)
            };

    }
}

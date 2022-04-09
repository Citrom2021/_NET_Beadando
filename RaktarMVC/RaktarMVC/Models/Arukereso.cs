using Microsoft.AspNetCore.Mvc.Rendering;

namespace RaktarMVC.Models
{
    public class Arukereso
    {
        public string megnevezesKereses { get; set; }
        public string tipusKereses { get; set; }
        public SelectList tipusLista { get; set; }
        public List<Adatmodel> Aru { get; set; }
    }
}

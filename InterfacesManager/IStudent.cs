using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JT.UniStuttgart.StudentLibrary.Views.InterfacesManager
{
    public interface IStudent

    {
        string IdText { get; set; }
        string NameText { get; set; }
        string AddressText { get; set; }
        string PhoneText { get; set; }

    }
}

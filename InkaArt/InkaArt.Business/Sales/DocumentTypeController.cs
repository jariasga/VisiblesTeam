using InkaArt.Data.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Business.Sales
{
    public class DocumentTypeController
    {
        private DocumentTypeData type_data;

        public DocumentTypeController()
        {
            type_data = new DocumentTypeData();
        }

        public DataTable GetDocumentTypes(int id = -1)
        {
            return type_data.GetDocumentTypes(id);
        }
    }
}

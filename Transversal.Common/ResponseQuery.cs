using System;
using System.Collections.Generic;
using System.Text;

namespace MuniBot_BackEnd.Transversal.Common
{
    public class ResponseQuery
    {
        public int id_identity { get; set; }
        public int error_number { get; set; }
        public string error_message { get; set; }
    }
}

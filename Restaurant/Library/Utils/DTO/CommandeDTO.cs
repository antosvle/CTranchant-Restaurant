using Library.Utils.Nomenclature;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Utils.DTO
{
    public class CommandeDTO
    {
        public CommandeEnum CommandeType { get; set; }
        public String Argument { get; set; }
    }
}

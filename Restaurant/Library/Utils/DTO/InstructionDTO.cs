using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Utils.DTO
{
    public class InstructionDTO
    {
        public IList<string> Utensils { get; set; } = new List<string>();

        public string Furniture { get; set; }

        public int Time { get; set; }
    }
}

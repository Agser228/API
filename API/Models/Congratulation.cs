using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Congratulation
    {
        public int CongratulationId { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public int ThematicId { get; set; }

    }
}

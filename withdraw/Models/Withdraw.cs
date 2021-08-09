using System;
using System.Collections.Generic;

namespace withdraw.Models
{
    public class Withdraw
    {
        public int accountBalance { get; set; }
        public int bankNote100 { get; set; }
        public int bankNote050 { get; set; }
        public int bankNote020 { get; set; }
        public int bankNote010 { get; set; }
        public string message { get; set; }
    }
}

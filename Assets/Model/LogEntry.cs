using System;
using System.Collections.Generic;

namespace Feedback.Model
{
    public partial class LogEntry
    {
        public int Id { get; set; }
        public string PlayerGuid { get; set; }
        public double RestartTime { get; set; }
        public int Lifes { get; set; }
        public int Coins { get; set; }
    }
}

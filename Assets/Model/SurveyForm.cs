using System;
using System.Collections.Generic;

namespace Feedback.Model
{
    public partial class SurveyForm
    {
        public int Id { get; set; }
        public string PlayerGuid { get; set; }
        public DateTime AddTime { get; set; }
        public int DeeplyConcentrated { get; set; }
        public int LostConnection { get; set; }
        public int WasGood { get; set; }
        public int Annoyed { get; set; }
        public int Frustrated { get; set; }
        public int PutEffort { get; set; }
    }
}

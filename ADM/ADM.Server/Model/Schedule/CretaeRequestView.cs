namespace ADM.Server.Model.Schedule
{
    public class CretaeRequestView
    {
        public string subject { get; set; }

        public DateTime? startDateTime { get; set; } = null;

        public DateTime? endDateTime { get; set; } = null; 

        public int repeatTime { get; set; } = 1;

        public bool isRepeat { get; set; } = false;
    }
}

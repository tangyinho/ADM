namespace ADM.Server.Model.Monitoring
{
    public class ViewEquipment
    {
        public int id { get; set; }

        public string name { get; set; }

        public string model { get; set; }

        public string status { get; set; }

        public TimeOnly normal_schedule_on { get; set; }

        public TimeOnly normal_schedule_off { get; set; }

        public DateTime last_updated_time { get; set; }

        public DateTime last_respond_time { get; set; }

        public DateTime last_schedule_updated_at { get; set; }
    }
}

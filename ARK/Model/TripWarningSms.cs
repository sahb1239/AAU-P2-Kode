using System;

namespace ARK.Model
{
    public class TripWarningSms
    {
        public int Id { get; set; }

        public DateTime? RecievedSms { get; set; }

        public DateTime? SentAdminSms { get; set; }

        public DateTime? SentSms { get; set; }

        public Trip Trip { get; set; }
    }
}
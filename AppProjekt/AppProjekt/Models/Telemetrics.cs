using System;

namespace AppProjekt.Models
{
    public class Telemetrics
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
    }
}
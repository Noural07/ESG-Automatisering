namespace Back_end.Models
{
    public class SensorData
    {
        // Properties
        public string SensorId { get; set; } // Unique identifier for the sensor
        public DateTime Timestamp { get; set; } // Time of the data collection
        public double RawValue { get; set; } // The raw value from the sensor
        public string Unit { get; set; } // Unit of the measurement (e.g., "W", "kWh")
        public double CalibratedValue { get; set; } // Calibrated value, if applicable
        public string DataFormat { get; set; } // Format of the data (e.g., "Analog", "Digital", "JSON", etc.)
        public string Metadata { get; set; } // Any additional metadata or contextual data
        public string MeasurementType { get; set; } // Type of measurement ("GHG Emission" or "Energy Consumption")

       
    }
}

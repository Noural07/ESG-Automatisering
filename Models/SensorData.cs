namespace Frond_end.Models
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

        // Constructor
        public SensorData() { }  // Parameterless constructor for ORM tools

        public SensorData(string sensorId, DateTime timestamp, double rawValue, string unit, string dataFormat, string measurementType, string metadata = "")
        {
            SensorId = sensorId;
            Timestamp = timestamp;
            RawValue = rawValue;
            Unit = unit;
            DataFormat = dataFormat;
            CalibratedValue = CalibrateValue(rawValue); // Apply calibration
            MeasurementType = measurementType;
            Metadata = metadata;
        }




        // Method to calibrate the raw value
        private double CalibrateValue(double rawValue)
        {
            const double calibrationFactor = 1.2; // Example factor
            const double calibrationOffset = 5.0; // Example offset

            return (rawValue * calibrationFactor) + calibrationOffset;
        }

        public override string ToString()
        {
            return $"Sensor ID: {SensorId}, Timestamp: {Timestamp}, Raw Value: {RawValue} {Unit}, " +
                   $"Calibrated Value: {CalibratedValue} {Unit}, Data Format: {DataFormat}, Measurement Type: {MeasurementType}, Metadata: {Metadata}";
        }
    }
}

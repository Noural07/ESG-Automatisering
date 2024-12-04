using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Back_end.Models;

namespace Back_end.Data.SensorDataRepository;

public class SensorDataRepository
{
    private readonly string connectionString;

    public SensorDataRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public List<Back_end.Models.SensorData> GetAllSensorData()
    {
        List<Back_end.Models.SensorData> sensorDataList = new List<Back_end.Models.SensorData>();
        string query = "SELECT SensorId, Timestamp, RawValue, Unit, CalibratedValue, DataFormat, Metadata, MeasurementType FROM SensorData";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    sensorDataList.Add(new Back_end.Models.SensorData
                    {
                        SensorId = reader["SensorId"].ToString(),
                        Timestamp = (DateTime)reader["Timestamp"],
                        RawValue = (double)reader["RawValue"],
                        Unit = reader["Unit"].ToString(),
                        CalibratedValue = (double)reader["CalibratedValue"],
                        DataFormat = reader["DataFormat"].ToString(),
                        Metadata = reader["Metadata"].ToString(),
                        MeasurementType = reader["MeasurementType"].ToString()
                    });
                }
            }
        }

        return sensorDataList;
    }

    public void AddSensorData(Back_end.Models.SensorData data)
    {
        string query = "INSERT INTO SensorData (SensorId, Timestamp, RawValue, Unit, CalibratedValue, DataFormat, Metadata, MeasurementType) " +
                       "VALUES (@SensorId, @Timestamp, @RawValue, @Unit, @CalibratedValue, @DataFormat, @Metadata, @MeasurementType)";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SensorId", data.SensorId);
            command.Parameters.AddWithValue("@Timestamp", data.Timestamp);
            command.Parameters.AddWithValue("@RawValue", data.RawValue);
            command.Parameters.AddWithValue("@Unit", data.Unit);
            command.Parameters.AddWithValue("@CalibratedValue", data.CalibratedValue);
            command.Parameters.AddWithValue("@DataFormat", data.DataFormat);
            command.Parameters.AddWithValue("@Metadata", data.Metadata);
            command.Parameters.AddWithValue("@MeasurementType", data.MeasurementType);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public void UpdateSensorData(Back_end.Models.SensorData data)
    {
        string query = "UPDATE SensorData SET RawValue = @RawValue, Unit = @Unit, CalibratedValue = @CalibratedValue, DataFormat = @DataFormat, " +
                       "Metadata = @Metadata, MeasurementType = @MeasurementType WHERE SensorId = @SensorId AND Timestamp = @Timestamp";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SensorId", data.SensorId);
            command.Parameters.AddWithValue("@Timestamp", data.Timestamp);
            command.Parameters.AddWithValue("@RawValue", data.RawValue);
            command.Parameters.AddWithValue("@Unit", data.Unit);
            command.Parameters.AddWithValue("@CalibratedValue", data.CalibratedValue);
            command.Parameters.AddWithValue("@DataFormat", data.DataFormat);
            command.Parameters.AddWithValue("@Metadata", data.Metadata);
            command.Parameters.AddWithValue("@MeasurementType", data.MeasurementType);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public void DeleteSensorData(string sensorId, DateTime timestamp)
    {
        string query = "DELETE FROM SensorData WHERE SensorId = @SensorId AND Timestamp = @Timestamp";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SensorId", sensorId);
            command.Parameters.AddWithValue("@Timestamp", timestamp);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}

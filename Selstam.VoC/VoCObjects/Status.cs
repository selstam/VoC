// ---------------------------------------------------------------------
// <copyright file="Status.cs" company="Amido Ab">
//     Copyright 2019 Amido AB.  All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

namespace Selstam.VoC.VoCObjects
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class Status
    {
        [JsonProperty("ERS")]
        public Ers Ers { get; set; }

        [JsonProperty("averageFuelConsumption")]
        public long AverageFuelConsumption { get; set; }

        [JsonProperty("averageFuelConsumptionTimestamp")]
        public string AverageFuelConsumptionTimestamp { get; set; }

        [JsonProperty("averageSpeed")]
        public long AverageSpeed { get; set; }

        [JsonProperty("averageSpeedTimestamp")]
        public string AverageSpeedTimestamp { get; set; }

        [JsonProperty("brakeFluid")]
        public string BrakeFluid { get; set; }

        [JsonProperty("brakeFluidTimestamp")]
        public string BrakeFluidTimestamp { get; set; }

        [JsonProperty("bulbFailures")]
        public List<object> BulbFailures { get; set; }

        [JsonProperty("bulbFailuresTimestamp")]
        public string BulbFailuresTimestamp { get; set; }

        [JsonProperty("carLocked")]
        public bool CarLocked { get; set; }

        [JsonProperty("carLockedTimestamp")]
        public string CarLockedTimestamp { get; set; }

        [JsonProperty("distanceToEmpty")]
        public long DistanceToEmpty { get; set; }

        [JsonProperty("distanceToEmptyTimestamp")]
        public string DistanceToEmptyTimestamp { get; set; }

        [JsonProperty("doors")]
        public Doors Doors { get; set; }

        [JsonProperty("engineRunning")]
        public bool EngineRunning { get; set; }

        [JsonProperty("engineRunningTimestamp")]
        public string EngineRunningTimestamp { get; set; }

        [JsonProperty("fuelAmount")]
        public long FuelAmount { get; set; }

        [JsonProperty("fuelAmountLevel")]
        public long FuelAmountLevel { get; set; }

        [JsonProperty("fuelAmountLevelTimestamp")]
        public string FuelAmountLevelTimestamp { get; set; }

        [JsonProperty("fuelAmountTimestamp")]
        public string FuelAmountTimestamp { get; set; }

        [JsonProperty("heater")]
        public Heater Heater { get; set; }

        [JsonProperty("odometer")]
        public long Odometer { get; set; }

        [JsonProperty("odometerTimestamp")]
        public string OdometerTimestamp { get; set; }

        [JsonProperty("parkedIndoor")]
        public object ParkedIndoor { get; set; }

        [JsonProperty("parkedIndoorTimestamp")]
        public object ParkedIndoorTimestamp { get; set; }

        [JsonProperty("remoteClimatizationStatus")]
        public object RemoteClimatizationStatus { get; set; }

        [JsonProperty("remoteClimatizationStatusTimestamp")]
        public object RemoteClimatizationStatusTimestamp { get; set; }

        [JsonProperty("serviceWarningStatus")]
        public string ServiceWarningStatus { get; set; }

        [JsonProperty("serviceWarningStatusTimestamp")]
        public string ServiceWarningStatusTimestamp { get; set; }

        [JsonProperty("theftAlarm")]
        public object TheftAlarm { get; set; }

        [JsonProperty("timeFullyAccessibleUntil")]
        public string TimeFullyAccessibleUntil { get; set; }

        [JsonProperty("timePartiallyAccessibleUntil")]
        public string TimePartiallyAccessibleUntil { get; set; }

        [JsonProperty("tripMeter1")]
        public long TripMeter1 { get; set; }

        [JsonProperty("tripMeter1Timestamp")]
        public string TripMeter1Timestamp { get; set; }

        [JsonProperty("tripMeter2")]
        public long TripMeter2 { get; set; }

        [JsonProperty("tripMeter2Timestamp")]
        public string TripMeter2Timestamp { get; set; }

        [JsonProperty("tyrePressure")]
        public TyrePressure TyrePressure { get; set; }

        [JsonProperty("washerFluidLevel")]
        public string WasherFluidLevel { get; set; }

        [JsonProperty("washerFluidLevelTimestamp")]
        public string WasherFluidLevelTimestamp { get; set; }

        [JsonProperty("windows")]
        public Windows Windows { get; set; }
    }

    public class Doors
    {
        [JsonProperty("tailgateOpen")]
        public bool TailgateOpen { get; set; }

        [JsonProperty("rearRightDoorOpen")]
        public bool RearRightDoorOpen { get; set; }

        [JsonProperty("rearLeftDoorOpen")]
        public bool RearLeftDoorOpen { get; set; }

        [JsonProperty("frontRightDoorOpen")]
        public bool FrontRightDoorOpen { get; set; }

        [JsonProperty("frontLeftDoorOpen")]
        public bool FrontLeftDoorOpen { get; set; }

        [JsonProperty("hoodOpen")]
        public bool HoodOpen { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }

    public class Ers
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("engineStartWarning")]
        public string EngineStartWarning { get; set; }

        [JsonProperty("engineStartWarningTimestamp")]
        public string EngineStartWarningTimestamp { get; set; }
    }

    public class Heater
    {
        [JsonProperty("seatSelection")]
        public SeatSelection SeatSelection { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("timer1")]
        public Timer Timer1 { get; set; }

        [JsonProperty("timer2")]
        public Timer Timer2 { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }

    public class SeatSelection
    {
        [JsonProperty("frontDriverSide")]
        public bool FrontDriverSide { get; set; }

        [JsonProperty("frontPassengerSide")]
        public bool FrontPassengerSide { get; set; }

        [JsonProperty("rearDriverSide")]
        public bool RearDriverSide { get; set; }

        [JsonProperty("rearPassengerSide")]
        public bool RearPassengerSide { get; set; }

        [JsonProperty("rearMid")]
        public bool RearMid { get; set; }
    }

    public class Timer
    {
        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("state")]
        public bool State { get; set; }
    }

    public class TyrePressure
    {
        [JsonProperty("frontLeftTyrePressure")]
        public string FrontLeftTyrePressure { get; set; }

        [JsonProperty("frontRightTyrePressure")]
        public string FrontRightTyrePressure { get; set; }

        [JsonProperty("rearLeftTyrePressure")]
        public string RearLeftTyrePressure { get; set; }

        [JsonProperty("rearRightTyrePressure")]
        public string RearRightTyrePressure { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }

    public class Windows
    {
        [JsonProperty("frontLeftWindowOpen")]
        public bool FrontLeftWindowOpen { get; set; }

        [JsonProperty("frontRightWindowOpen")]
        public bool FrontRightWindowOpen { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("rearLeftWindowOpen")]
        public bool RearLeftWindowOpen { get; set; }

        [JsonProperty("rearRightWindowOpen")]
        public bool RearRightWindowOpen { get; set; }
    }
}

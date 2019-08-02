// ---------------------------------------------------------------------
// <copyright file="CarAttributes.cs" company="Amido Ab">
//     Copyright 2019 Amido AB.  All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

namespace Selstam.VoC.VoCObjects
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class CarAttributes
    {
        [JsonProperty("engineCode")]
        public string EngineCode { get; set; }

        [JsonProperty("exteriorCode")]
        public string ExteriorCode { get; set; }

        [JsonProperty("interiorCode")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long InteriorCode { get; set; }

        [JsonProperty("tyreDimensionCode")]
        public string TyreDimensionCode { get; set; }

        [JsonProperty("tyreInflationPressureLightCode")]
        public string TyreInflationPressureLightCode { get; set; }

        [JsonProperty("tyreInflationPressureHeavyCode")]
        public string TyreInflationPressureHeavyCode { get; set; }

        [JsonProperty("gearboxCode")]
        public string GearboxCode { get; set; }

        [JsonProperty("fuelType")]
        public string FuelType { get; set; }

        [JsonProperty("fuelTankVolume")]
        public long FuelTankVolume { get; set; }

        [JsonProperty("grossWeight")]
        public long GrossWeight { get; set; }

        [JsonProperty("modelYear")]
        public long ModelYear { get; set; }

        [JsonProperty("vehicleType")]
        public string VehicleType { get; set; }

        [JsonProperty("vehicleTypeCode")]
        public string VehicleTypeCode { get; set; }

        [JsonProperty("numberOfDoors")]
        public long NumberOfDoors { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("registrationNumber")]
        public string RegistrationNumber { get; set; }

        [JsonProperty("carLocatorDistance")]
        public long CarLocatorDistance { get; set; }

        [JsonProperty("honkAndBlinkDistance")]
        public long HonkAndBlinkDistance { get; set; }

        [JsonProperty("bCallAssistanceNumber")]
        public string BCallAssistanceNumber { get; set; }

        [JsonProperty("carLocatorSupported")]
        public bool CarLocatorSupported { get; set; }

        [JsonProperty("honkAndBlinkSupported")]
        public bool HonkAndBlinkSupported { get; set; }

        [JsonProperty("honkAndBlinkVersionsSupported")]
        public List<string> HonkAndBlinkVersionsSupported { get; set; }

        [JsonProperty("remoteHeaterSupported")]
        public bool RemoteHeaterSupported { get; set; }

        [JsonProperty("unlockSupported")]
        public bool UnlockSupported { get; set; }

        [JsonProperty("lockSupported")]
        public bool LockSupported { get; set; }

        [JsonProperty("journalLogSupported")]
        public bool JournalLogSupported { get; set; }

        [JsonProperty("assistanceCallSupported")]
        public bool AssistanceCallSupported { get; set; }

        [JsonProperty("unlockTimeFrame")]
        public long UnlockTimeFrame { get; set; }

        [JsonProperty("verificationTimeFrame")]
        public long VerificationTimeFrame { get; set; }

        [JsonProperty("timeFullyAccessible")]
        public long TimeFullyAccessible { get; set; }

        [JsonProperty("timePartiallyAccessible")]
        public long TimePartiallyAccessible { get; set; }

        [JsonProperty("subscriptionType")]
        public string SubscriptionType { get; set; }

        [JsonProperty("subscriptionStartDate")]
        public string SubscriptionStartDate { get; set; }

        [JsonProperty("subscriptionEndDate")]
        public string SubscriptionEndDate { get; set; }

        [JsonProperty("serverVersion")]
        public string ServerVersion { get; set; }

        [JsonProperty("VIN")]
        public string Vin { get; set; }

        [JsonProperty("journalLogEnabled")]
        public bool JournalLogEnabled { get; set; }

        [JsonProperty("highVoltageBatterySupported")]
        public bool HighVoltageBatterySupported { get; set; }

        [JsonProperty("maxActiveDelayChargingLocations")]
        public object MaxActiveDelayChargingLocations { get; set; }

        [JsonProperty("preclimatizationSupported")]
        public bool PreclimatizationSupported { get; set; }

        [JsonProperty("sendPOIToVehicleVersionsSupported")]
        public List<object> SendPoiToVehicleVersionsSupported { get; set; }

        [JsonProperty("climatizationCalendarVersionsSupported")]
        public List<object> ClimatizationCalendarVersionsSupported { get; set; }

        [JsonProperty("climatizationCalendarMaxTimers")]
        public long ClimatizationCalendarMaxTimers { get; set; }

        [JsonProperty("vehiclePlatform")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long VehiclePlatform { get; set; }

        [JsonProperty("vin")]
        public string CarAttributesVin { get; set; }

        [JsonProperty("overrideDelayChargingSupported")]
        public bool OverrideDelayChargingSupported { get; set; }

        [JsonProperty("engineStartSupported")]
        public bool EngineStartSupported { get; set; }

        [JsonProperty("status.parkedIndoor.supported")]
        public bool StatusParkedIndoorSupported { get; set; }
    }

    public class Country
    {
        [JsonProperty("iso2")]
        public string Iso2 { get; set; }
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
        }
    }
}

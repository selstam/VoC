// ---------------------------------------------------------------------
// <copyright file="Trips.cs" company="Amido Ab">
//     Copyright 2019 Amido AB.  All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Selstam.VoC.VoCObjects
{
    public class Trips
    {
        public List<Trip> trips { get; set; }
    }

    public class StartPosition
    {
        public double longitude { get; set; }
        public double latitude { get; set; }
        public string streetAddress { get; set; }
        public string postalCode { get; set; }
        public string city { get; set; }
        public string ISO2CountryCode { get; set; }
        public string Region { get; set; }
    }

    public class EndPosition
    {
        public double longitude { get; set; }
        public double latitude { get; set; }
        public string streetAddress { get; set; }
        public string postalCode { get; set; }
        public string city { get; set; }
        public string ISO2CountryCode { get; set; }
        public string Region { get; set; }
    }

    public class TripDetail
    {
        public int fuelConsumption { get; set; }
        public int electricalConsumption { get; set; }
        public int electricalRegeneration { get; set; }
        public int distance { get; set; }
        public int startOdometer { get; set; }
        public DateTimeOffset startTime { get; set; }
        public StartPosition startPosition { get; set; }
        public int endOdometer { get; set; }
        public DateTimeOffset endTime { get; set; }
        public EndPosition endPosition { get; set; }
    }

    public class Trip
    {
        public int id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string userNotes { get; set; }
        public string trip { get; set; }
        public List<TripDetail> tripDetails { get; set; }
    }
}
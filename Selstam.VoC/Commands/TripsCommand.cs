// ---------------------------------------------------------------------
// <copyright file="StatusCommand.cs" company="Amido Ab">
//     Copyright 2019 Amido AB.  All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

namespace Selstam.VoC.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using McMaster.Extensions.CommandLineUtils;
    using Newtonsoft.Json;

    using Selstam.VoC.Helpers;
    using Selstam.VoC.Services.VoC.Dtos;
    using Selstam.VoC.Services.VoC.Interfaces;

    [Command(Description = "Gets car's driving journal.")]
    public class TripsCommand : VoCCommandBase
    {
        private readonly IVoCService _vocService;

        public TripsCommand(IVoCService vocService)
        {
            _vocService = vocService;
        }

        // You can use this pattern when the parent command may have options or methods you want to
        // use from sub-commands.
        // This will automatically be set before OnExecute is invoked
        private VolvoOnCallService Parent { get; set; }

        protected override int OnExecute(CommandLineApplication app)
        {
            var tripsResponse = _vocService.GetTrips(new TripsDto
            {
                Username = Parent.Username,
                Password = Parent.Password,
                Server = Parent.Server,
                Vin = Parent.Vin
            });

            if (Parent.BeautifyJson)
            {
                Console.WriteLine(JsonConvert.SerializeObject(tripsResponse, Formatting.Indented));
            }
            else if (!Parent.Table)
            {
                Console.WriteLine(JsonConvert.SerializeObject(tripsResponse, Formatting.None));
            }
            else if (Parent.Table)
            {
                var dt = new DataTable("Trips");
                dt.Columns.Add("Id", typeof(int)).AllowDBNull = false;
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Category", typeof(string));
                dt.Columns.Add("Start", typeof(DateTimeOffset));
                dt.Columns.Add("Start location", typeof(string));
                dt.Columns.Add("End", typeof(DateTimeOffset));
                dt.Columns.Add("End location", typeof(string));
                dt.Columns.Add("Time used", typeof(string));
                dt.Columns.Add("Distance (km)", typeof(decimal));
                dt.Columns.Add("Fuel use (l)", typeof(decimal));
                dt.Columns.Add("Avg Fuel (l/10km)", typeof(decimal));
                foreach (var trip in tripsResponse.trips)
                {
                    var details = trip.tripDetails.First();

                    var avgFuelUse =
                        Math.Round((decimal) details.fuelConsumption / 100 / ((decimal) details.distance / 10000), 2);

                    dt.Rows.Add(
                        trip.id,
                        trip.name,
                        trip.category,
                        details.startTime.ToLocalTime(),
                        details.startPosition.city,
                        details.endTime.ToLocalTime(),
                        details.endPosition.city,
                        (details.endTime - details.startTime).ToString(@"hh\:mm"),
                        Math.Round((decimal) details.distance / 1000, 2),
                        Math.Round((decimal) details.fuelConsumption / 100, 2),
                        avgFuelUse);
                }

                dt.Print();
            }

            return 0;
        }

        public override List<string> CreateArgs()
        {
            var args = Parent.CreateArgs();
            args.Add("trips");

            return args;
        }
    }
}
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

    [Command(Description = "Gets car's last reported status.")]
    public class StatusCommand : VoCCommandBase
    {
        private readonly IVoCService _vocService;

        public StatusCommand(IVoCService vocService)
        {
            _vocService = vocService;
        }

        [Argument(0, Description = "Filter separated by space.")]
        public string[] Filter { get; }

        private VolvoOnCallService Parent { get; set; }

        protected override int OnExecute(CommandLineApplication app)
        {
            var status = _vocService.GetStatus(new StatusDto
            {
                Username = Parent.Username,
                Password = Parent.Password,
                Server = Parent.Server,
                Vin = Parent.Vin
            });

            if (Filter != null && Filter.Any())
            {
                foreach (var attribute in Filter)
                {
                    if (!status.Data.ContainsKey(attribute))
                        continue;

                    Console.WriteLine(!Parent.OmitKey
                        ? $"{attribute}={status.Data[attribute]}"
                        : $"{status.Data[attribute]}");
                }

                return 0;
            }

            if (Parent.BeautifyJson)
            {
                Console.WriteLine(JsonConvert.SerializeObject(status, Formatting.Indented));
            }
            else if (!Parent.Table)
            {
                Console.WriteLine(JsonConvert.SerializeObject(status, Formatting.None));
            }
            else if (Parent.Table)
            {
                var dt = new DataTable("Status");
                dt.Columns.Add("Plate", typeof(string)).AllowDBNull = false;
                dt.Columns.Add("Model", typeof(string)).AllowDBNull = false;
                dt.Columns.Add("Year", typeof(long)).AllowDBNull = false;
                dt.Columns.Add("VIN", typeof(string)).AllowDBNull = false;
                dt.Columns.Add("Odometer", typeof(long)).AllowDBNull = false;
                dt.Columns.Add("Fuel tank (l)", typeof(long)).AllowDBNull = false;
                dt.Columns.Add("Fuel left (l)", typeof(long)).AllowDBNull = false;
                dt.Columns.Add("Range (km)", typeof(long)).AllowDBNull = false;
                dt.Columns.Add("Position (lat, long)", typeof(string)).AllowDBNull = false;
                dt.Columns.Add("Doors", typeof(string)).AllowDBNull = false;
                dt.Columns.Add("Locked", typeof(string)).AllowDBNull = false;
                dt.Columns.Add("Heater", typeof(string)).AllowDBNull = false;

                var range = Math.Round(
                    status.Status.FuelAmount / ((decimal) status.Status.AverageFuelConsumption / 100) * 10, 0);
                var doorStatus = status.Status.Doors.FrontLeftDoorOpen ||
                                 status.Status.Doors.FrontRightDoorOpen ||
                                 status.Status.Doors.RearLeftDoorOpen ||
                                 status.Status.Doors.RearRightDoorOpen;

                dt.Rows.Add(
                    status.Attributes.RegistrationNumber,
                    status.Attributes.VehicleType,
                    status.Attributes.ModelYear,
                    status.Attributes.Vin,
                    status.Status.Odometer,
                    status.Attributes.FuelTankVolume,
                    status.Status.FuelAmount,
                    range,
                    $"{status.Position.Position.Latitude}, {status.Position.Position.Longitude}",
                    doorStatus ? "Open" : "All closed",
                    status.Status.CarLocked,
                    status.Status.Heater.Status
                );

                dt.Print();
            }

            return 0;
        }

        public override List<string> CreateArgs()
        {
            var args = Parent.CreateArgs();
            args.Add("status");

            return args;
        }
    }
}
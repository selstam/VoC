// ---------------------------------------------------------------------
// <copyright file="VolvoOnCallService.cs" company="Amido Ab">
//     Copyright 2019 Amido AB.  All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using McMaster.Extensions.CommandLineUtils;

namespace Selstam.VoC.Commands
{
    using System;

    [Command("voc")]
    [VersionOptionFromMember("--version", MemberName = nameof(GetVersion))]
    [Subcommand(
        typeof(StatusCommand),
        typeof(TripsCommand),
        typeof(PositionCommand),
        typeof(AttributesCommand),
        typeof(UnlockCommand),
        typeof(LockCommand))]
    public class VolvoOnCallService : VoCCommandBase
    {
        [Option("-u|--username <username>", Description = "Volvo on Call Username (i.e. email address).")]
        [Required]
        public string Username { get; set; }

        [Option("-p|--password <password>", Description = "Volvo on Call Password.")]
        [Required]
        public string Password { get; set; }

        [Option("-i|--vin <number>", Description = "Your Volvo's VIN number.")]
        [Required]
        public string Vin { get; set; }

        [Option("--server <fqdn>", Description = "Volvo on Call service server.")]
        public string Server { get; set; } = "vocapi.wirelesscar.net";

        [Option("-b|--beautify", Description = "Beautify Json output.")]
        public bool BeautifyJson { get; set; }

        [Option("-t|--table", Description = "Output as table (not all data returned).")]
        public bool Table { get; set; }

        [Option("-o|--omit", Description = "Omit key when using filters.")]
        public bool OmitKey { get; set; }

        protected override int OnExecute(CommandLineApplication app)
        {
            // this shows help even if the --help option isn't specified
            app.ShowHelp(usePager: false);
            return 1;
        }

        public override List<string> CreateArgs()
        {
            var args = new List<string>();

            return args;
        }

        private static string GetVersion()
            => "Volvo on Call, voc, version " + typeof(VolvoOnCallService).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
    }
}
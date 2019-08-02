// ---------------------------------------------------------------------
// <copyright file="StatusCommand.cs" company="Amido Ab">
//     Copyright 2019 Amido AB.  All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

using System.Collections.Generic;
using McMaster.Extensions.CommandLineUtils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Selstam.VoC.Services.VoCApiClient;

namespace Selstam.VoC.Commands
{
    using System;

    using Selstam.VoC.Services.VoC.Dtos;
    using Selstam.VoC.Services.VoC.Interfaces;

    [Command(Description = "Gets car's last reported GPS position.")]
    public class PositionCommand : VoCCommandBase
    {
        private readonly IVoCService _vocService;

        public PositionCommand(IVoCService vocService)
        {
            _vocService = vocService;
        }

        private VolvoOnCallService Parent { get; set; }

        protected override int OnExecute(CommandLineApplication app)
        {
            var dto = new BaseServiceDto
            {
                Username = Parent.Username,
                Password = Parent.Password,
                Server = Parent.Server,
                Vin = Parent.Vin
            };
            var response = _vocService.GetPosition(dto);

            Console.WriteLine(Parent.BeautifyJson ? JsonConvert.SerializeObject(response.Position, Formatting.Indented) : response.RawResponse);

            return 0;
        }

        public override List<string> CreateArgs()
        {
            var args = Parent.CreateArgs();
            args.Add("position");

            return args;
        }
    }
}
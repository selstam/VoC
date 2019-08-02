// ---------------------------------------------------------------------
// <copyright file="StatusCommand.cs" company="Amido Ab">
//     Copyright 2019 Amido AB.  All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading;
using McMaster.Extensions.CommandLineUtils;
using Newtonsoft.Json;
using Selstam.VoC.Services.VoCApiClient;
using Selstam.VoC.VoCObjects;

namespace Selstam.VoC.Commands
{
    using System;

    using Selstam.VoC.Services.VoC.Dtos;
    using Selstam.VoC.Services.VoC.Interfaces;

    [Command(Name = "unlock", Description = "Unlock your car.")]
    public class UnlockCommand : VoCCommandBase
    {
        private readonly IVoCService _vocService;

        [Option("--timeout <seconds>", Description = "Timeout before failure (default 140 seconds).")]
        public int Timeout { get; } = 140;

        public UnlockCommand(IVoCService vocService)
        {
            _vocService = vocService;
        }

        private VolvoOnCallService Parent { get; set; }

        protected override int OnExecute(CommandLineApplication app)
        {
            var dto = new LockDto
            {
                Username = Parent.Username,
                Password = Parent.Password,
                Vin = Parent.Vin,
                Server = Parent.Server,
                Timeout = Timeout,
                NewState = LockState.Unlocked
            };

            var response = _vocService.SetLockState(dto);

            Console.WriteLine(JsonConvert.SerializeObject(response.Response, Parent.BeautifyJson ? Formatting.Indented : Formatting.None));

            return response.Status;
        }

        public override List<string> CreateArgs()
        {
            var args = Parent.CreateArgs();
            args.Add("unlock");

            return args;
        }
    }
}
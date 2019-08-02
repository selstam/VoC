// ---------------------------------------------------------------------
// <copyright file="StatusCommand.cs" company="Amido Ab">
//     Copyright 2019 Amido AB.  All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

namespace Selstam.VoC.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using McMaster.Extensions.CommandLineUtils;

    using Newtonsoft.Json;

    using Selstam.VoC.Services.VoC.Dtos;
    using Selstam.VoC.Services.VoC.Interfaces;

    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    [Command(Name = "lock", Description = "SetLockState your car.")]
    public class LockCommand : VoCCommandBase
    {
        private readonly IVoCService _vocService;

        public LockCommand(IVoCService vocService)
        {
            _vocService = vocService;
        }

        [Option("--timeout <seconds>", Description = "Timeout before failure (default 140 seconds).")]
        public int Timeout { get; } = 140;

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
                NewState = LockState.Locked
            };

            var response = _vocService.SetLockState(dto);

            Console.WriteLine(JsonConvert.SerializeObject(response.Response, Parent.BeautifyJson ? Formatting.Indented : Formatting.None));

            return response.Status;
        }

        public override List<string> CreateArgs()
        {
            var args = Parent.CreateArgs();
            args.Add("lock");

            return args;
        }
    }
}
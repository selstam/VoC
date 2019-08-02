// ---------------------------------------------------------------------
// <copyright file="VoCCommandBase.cs" company="Amido Ab">
//     Copyright 2019 Amido AB.  All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

using System.Collections.Generic;
using McMaster.Extensions.CommandLineUtils;

namespace Selstam.VoC.Commands
{
    using System;

    [HelpOption("--help")]
    public abstract class VoCCommandBase
    {
        /// <summary>
        /// This base type provides shared functionality.
        /// Also, declaring <see cref="HelpOptionAttribute"/> on this type means all types that inherit from it
        /// will automatically support '--help'
        /// </summary>
        public abstract List<string> CreateArgs();

        protected virtual int OnExecute(CommandLineApplication app)
        {
            var args = CreateArgs();

            Console.WriteLine("Result = voc " + ArgumentEscaper.EscapeAndConcatenate(args));
            return 0;
        }
    }
}
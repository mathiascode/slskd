﻿// <copyright file="OptionsController.cs" company="slskd Team">
//     Copyright (c) slskd Team. All rights reserved.
//
//     This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU Affero General Public License as published
//     by the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
//
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU Affero General Public License for more details.
//
//     You should have received a copy of the GNU Affero General Public License
//     along with this program.  If not, see https://www.gnu.org/licenses/.
// </copyright>

namespace slskd.Management.API
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     Options.
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("0")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class OptionsController : ControllerBase
    {
        public OptionsController(Microsoft.Extensions.Options.IOptionsMonitor<Options> optionsMonitor)
        {
            OptionsMonitor = optionsMonitor;
        }

        private Microsoft.Extensions.Options.IOptionsMonitor<Options> OptionsMonitor { get; }
        private Options Options => OptionsMonitor.CurrentValue;

        /// <summary>
        ///     Gets the current application options.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(Options), 200)]
        public IActionResult Get()
        {
            return Ok(Options);
        }
    }
}
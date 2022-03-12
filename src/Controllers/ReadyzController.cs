// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Imdb.Application.Controllers
{
    /// <summary>
    /// Handle the /readyz requests
    /// </summary>
    [Route("[controller]")]
    public class ReadyzController : Controller
    {
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadyzController"/> class.
        /// </summary>
        /// <param name="logger">logger</param>
        public ReadyzController(ILogger<HealthzController> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Returns a plain text ready status (ready)
        /// </summary>
        /// <returns>IActionResult</returns>
        [HttpGet]
        [Produces("text/plain")]
        [ProducesResponseType(typeof(string), 200)]
        public IActionResult ReadyzAsync()
        {
            // get list of genres as list of string
            logger.LogInformation(nameof(ReadyzAsync));

            return Ok("ready");
        }
    }
}

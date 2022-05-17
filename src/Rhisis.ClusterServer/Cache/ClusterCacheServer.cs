﻿using LiteNetwork;
using LiteNetwork.Server;
using Microsoft.Extensions.Logging;
using Rhisis.Abstractions.Server;
using Rhisis.ClusterServer.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rhisis.ClusterServer.Cache
{
    internal class ClusterCacheServer : LiteServer<ClusterCacheUser>, IClusterCacheServer
    {
        private readonly ILogger<ClusterCacheServer> _logger;

        public IEnumerable<WorldChannel> WorldChannels => Users.Cast<ClusterCacheUser>().Select(x => x.Channel);

        public ClusterCacheServer(LiteServerOptions options, ILogger<ClusterCacheServer> logger, IServiceProvider serviceProvider) 
            : base(options, serviceProvider)
        {
            _logger = logger;
        }

        protected override void OnAfterStart()
        {
            _logger.LogInformation($"Cluster cache server started and listening on port '{Options.Port}'.");
        }

        protected override void OnError(LiteConnection connection, Exception exception)
        {
            _logger.LogError(exception, $"An exception occured in {typeof(ClusterCacheServer).Name}.");
        }
    }
}
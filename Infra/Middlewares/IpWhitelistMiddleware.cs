using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;


namespace Infra.Middlewares
{
    public class IpWhitelistMiddleware
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<IpWhitelistMiddleware> _logger;
        private readonly RequestDelegate _next;
        private readonly HashSet<string> _allowedIps;
        // private readonly string[] _allowedIps = new string[] 

        public IpWhitelistMiddleware(RequestDelegate next, ILogger<IpWhitelistMiddleware> logger, IConfiguration configuration)
        {
            _next = next;
            _logger = logger;
            _configuration = configuration;
            _allowedIps = configuration.GetSection("IpWhitelist").Get<string[]>().ToHashSet();
        }

        public async Task Invoke(HttpContext context)
        {
            string serverIp = null;
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                serverIp = host.AddressList
                    .FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)?
                    .ToString();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter o IP do servidor.");
            }

            // Se não conseguiu obter o IP, nega acesso por segurança
            if (string.IsNullOrEmpty(serverIp) || !_allowedIps.Contains(serverIp))
            {
                _logger.LogWarning($"Request from {serverIp ?? "UNKNOWN"} rejected.");
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("You are not in Whitelist, access denied.");
                return;
            }

            await _next(context);
        }



    }
}

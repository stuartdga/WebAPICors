using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Cors;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Threading.Tasks;
using System.Net.Http;

namespace WebAPI2Cors
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class EnableCorsCustomAttribute : Attribute, ICorsPolicyProvider
    {
        private const string keyCorsAllowOrigin = "cors:allowOrigins";

        private CorsPolicy _policy;

        public EnableCorsCustomAttribute()
        {
            _policy = BuildPolicy(keyCorsAllowOrigin);
        }

        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request)
        {
            return Task.FromResult(_policy);
        }

        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            return GetCorsPolicyAsync(request);
        }

        public CorsPolicy BuildPolicy(string appSettingsKey)
        {
            _policy = new CorsPolicy();

            // ToDo:  replace this section with lookup from the database
            // loads the origins from AppSettings
            string originsString = ConfigurationManager.AppSettings[keyCorsAllowOrigin];
            if (!String.IsNullOrEmpty(originsString))
            {
                foreach (var origin in originsString.Split(','))
                {
                    _policy.Origins.Add(origin);
                }
            }
            else
                _policy.Origins.Add("*");

            _policy.Headers.Add("Accept");
            _policy.Headers.Add("Content-Type");
            _policy.Headers.Add("Origin");

            _policy.Methods.Add("GET");
            _policy.Methods.Add("PUT");
            _policy.Methods.Add("POST");
            _policy.Methods.Add("DELETE");
            _policy.Methods.Add("OPTIONS");

            return _policy;
        }

    }
}
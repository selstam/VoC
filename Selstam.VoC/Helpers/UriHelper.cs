namespace Selstam.VoC.Helpers
{
    using System;

    public static class UriHelper
    {
        public static Uri Create(string server, string vin, string call)
        {
            return new Uri($"https://{server}/customerapi/rest/v3.0/vehicles/{vin}/{call}");
        }

        public static Uri Create(string server, string call)
        {
            return new Uri($"https://{server}/customerapi/rest/v3.0/{call}");
        }
    }
}
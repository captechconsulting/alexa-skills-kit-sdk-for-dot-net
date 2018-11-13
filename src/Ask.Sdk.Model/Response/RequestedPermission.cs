using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Model.Response
{
    public static class RequestedPermission
    {
        public const string ReadHouseholdList = "read::alexa:household:list";
        public const string WriteHouseholdList = "write::alexa:household:list";
        public const string FullAddress = "read::alexa:device:all:address";
        public const string AddressCountryAndPostalCode = "read::alexa:device:all:address:country_and_postal_code";
    }
}

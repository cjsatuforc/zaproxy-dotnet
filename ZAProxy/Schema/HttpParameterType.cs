﻿using Newtonsoft.Json;
using ZAProxy.Schema.Converters;

namespace ZAProxy.Schema
{
    /// <summary>
    /// Describes the type of an http parameter.
    /// </summary>
    [JsonConverter(typeof(CapitalizedEnumConverter))]
    public enum HttpParameterType
    {
        /// <summary>
        /// Parameter is part of the cookies.
        /// </summary>
        Cookie,

        /// <summary>
        /// Parameter is part of the form values.
        /// </summary>
        Form,

        /// <summary>
        /// Parameter is part of the url query string.
        /// </summary>
        Url
    }
}

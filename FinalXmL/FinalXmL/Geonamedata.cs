﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var welcome = Welcome.FromJson(jsonString);



namespace QuickType1
{
    using System;
    using System.Collections.Generic;



    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;



    public partial class Geonamedata
    {
        [JsonProperty("country")]
        public string Country { get; set; }



        [JsonProperty("geonameid")]
        public long Geonameid { get; set; }



        [JsonProperty("name")]
        public string Name { get; set; }



        [JsonProperty("subcountry")]
        public string Subcountry { get; set; }


    }



    public partial class Geonamedata
    {
        public static Geonamedata[] FromJson(string json) => JsonConvert.DeserializeObject<Geonamedata[]>(json, QuickType.Converter.Settings);
    }



    public static class Serialize
    {
        public static string ToJson(this Geonamedata[] self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }



    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
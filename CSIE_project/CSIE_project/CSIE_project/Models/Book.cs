using CSIE_project.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
//check
namespace XamWebApiClient.Models
{
    public class Book
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        public string TextColor { get; set; } = Pick.color;

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("state1")]
        public string State { get; set; }

        [JsonPropertyName("state2")]
        public string State2 { get; set; }

        [JsonPropertyName("state3")]
        public string State3 { get; set; }
    }
}

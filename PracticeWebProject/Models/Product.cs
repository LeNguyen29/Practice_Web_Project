﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace PracticeWebProject.Models
{
    public class Product
    {
        public string ID { get; set; }
        
        public string Maker { get; set; }

        [JsonPropertyName("img")]
        public string Image { get; set; }

        public string Url { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int[] Ratings { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}

﻿namespace BlazorServerDemo.Net6.MovieRatings.Models.Configuration
{
    public class PathConfiguration
    {
        public const string SectionName = "PathConfiguration";
        public string? Api { get; set; }
        public string? Web { get; set; }
        public string? Identity { get; set; }
    }
}

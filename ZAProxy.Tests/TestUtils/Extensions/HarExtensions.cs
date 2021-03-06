﻿using System;
using System.Linq;

namespace HttpArchive
{
    public static class HarExtensions
    {
        private static Random _random = new Random();

        public static Har FixAutoGeneratedReferences(this Har har)
        {
            var pageIds = har.Log.Pages.Select(p => p.Id);
            foreach (var entry in har.Log.Entries)
                entry.PageRef = pageIds.ElementAt(_random.Next(pageIds.Count()));
            return har;
        }
    }
}

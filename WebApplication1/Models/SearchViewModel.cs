using System;
using System.Collections.Generic;
namespace kuranmealuygulaması.Models
{
    public class SearchViewModel
    {
        public string Keyword { get; set; }
        public string Meal { get; set; }
        public string Sure { get; set; }
        public string SearchOption { get; set; }
        public bool OrderByRevelation { get; set; }
    }
}

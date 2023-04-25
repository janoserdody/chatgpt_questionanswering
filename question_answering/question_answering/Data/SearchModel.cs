﻿using System.ComponentModel.DataAnnotations;

namespace question_answering.Data
{
    public class SearchModel
    {
        [Required]
        public string Prompt { get; set; } = "";

        [Required]
        public string SearchText { get; set; } = "";

        [Required]
        public int NoOfResults { get; set; } = 2;

        [Required]
        public int MaxTokens { get; set; } = 200;

        public string System { get; set; } = "";

        public string Assistant { get; set; } = "";
    }
}

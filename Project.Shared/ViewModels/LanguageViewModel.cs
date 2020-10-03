﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Shared.ViewModels
{
    public class LanguageViewModel
    {
        public LanguageViewModel() { }
        public LanguageViewModel(Language language)
        {
            Id = language.Id;
            Name = language.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}

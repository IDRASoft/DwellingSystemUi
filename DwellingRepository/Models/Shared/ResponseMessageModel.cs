﻿namespace DwellingRepository.Models.Shared
{
    public class ResponseMessageModel
    {
        public bool HasError { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public bool HasExceptionMessage { get; set; }

    }
}
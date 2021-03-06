﻿using System;
using System.Collections.Generic;
using Valenia.Domain.Visas;
using Valenia.Domain.Visas.Requirements;

namespace Valenia.Visas
{
    public static class VisaReadModels
    {
        public class Details
        {
            public Guid VisaId { get; set; }
            public string Goal { get; set; }
            public VisaType Type { get; set; }
            public int ExpectedProcessingTime { get; set; }
        }

        public class Goals
        {
            public Guid VisaId { get; set; }
            public string Goal { get; set; }
        }

        public class RequirementsDetails
        {
            public Guid VisaId { get; set; }
            public int ExpectedProcessingTime { get; set; }
            public List<Requirement> Requirements { get; set; }
        }
    }
}

﻿namespace DwellingRepository.Database
{
    public partial class DwellingRel
    {
        public DwellingApartment DwellingApartmentToUse { get; set; }
        public DwellingHouse DwellingHouseToUse { get; set; }
        public string CountryName { get; set; }

        public string StateName { get; set; }

        public string MunicipalityName { get; set; }

        public string LocationName { get; set; }

        public int StreetId { get; set; }

    }
}



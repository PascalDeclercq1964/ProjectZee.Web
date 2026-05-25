public class ShareHolder
{
        public int ShareHolderId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; } = DateTime.Today.AddYears(-30);
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        // Partner switch & gegevens
        public bool HasPartner { get; set; }
        public string? PartnerFirstName { get; set; }
        public string? PartnerLastName { get; set; }
        public DateTime? PartnerBirthDate { get; set; }

        // Financieel & Vastgoed
        public double TargetBudget { get; set; }
        public double MaxBudget { get; set; }
        public string PreferredRegion { get; set; } = string.Empty;
        public int PreferredBedrooms { get; set; } = 2;
        public int MaxDistanceToBeach { get; set; } = 100;
        public RequirementTypes SeaViewPreference { get; set; } = RequirementTypes.NiceToHave;

        // Persoonlijk
        public string Bio { get; set; } = string.Empty;

}
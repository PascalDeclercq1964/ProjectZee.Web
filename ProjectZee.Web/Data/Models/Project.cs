using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using ProjectZee.Web.Data;

public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string RegionOrCity { get; set; } = string.Empty;
        public string Status { get; set; } = "InAanvraag";
        public double TargetBudget { get; set; } = 500000;
        public int Bedrooms { get; set; } = 2;
        public int MinApartmentSize { get; set; } = 80;
        public int MaxDistanceToBeach { get; set; } = 100;
        public RequirementTypes SeaView { get; set; } = RequirementTypes.NiceToHave;
        public RequirementTypes TerrasRequirement { get; set; } = RequirementTypes.NiceToHave;
        public int MinTerrasSize { get; set; } = 10;
        public List<ApplicationUser> Followers { get; set; }
        public List<ShareHolder> Candidates { get; set; }
        public List<CustomAttributeValue> ExtraAttributes { get; set; } = new();
    }

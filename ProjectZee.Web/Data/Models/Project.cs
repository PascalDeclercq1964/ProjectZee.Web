using System.ComponentModel.DataAnnotations.Schema;
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
        public List<ProjectFollower> ProjectFollowers { get; set; }
        public List<ProjectShareholder> ProjectShareholders { get; set; }
        public List<CustomAttributeValue> ExtraAttributes { get; set; } = new();
        public ProjectStates ProjectState { get; set; }
        public string ImageUrl { get; set; }

    public string OtherInfo { get; set; }

        [NotMapped]
        public double PricePerShare { get {return Math.Round(TargetBudget/16,0);} }

        [NotMapped]
        public string StatusDisplay
        {
            get
            {
                if (ProjectShareholders.Count == 0) 
                    return "Nieuw!";

                if (ProjectShareholders.Count > 12) 
                    return "Populair";

                if (ProjectShareholders.Count >=16) 
                    return "Volgeboekt";

                return "Zoekt nog kandidaten!";    

            }
        }
    }

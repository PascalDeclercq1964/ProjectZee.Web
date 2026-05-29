public class ProjectShareholder
{
    public int ProjectShareholderId { get; set; }
    public int ShareholderId { get; set; }
    public ShareHolder ShareHolder { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    //public CustomAttributeValue CustomAttributeValue { get; set; }

    public int ShareCount { get; set; }

    public int ShareholderProjectStatusId { get; set; }

    public ProjectShareholdeStates ShareholderProjectStatus { get; set; }
}

public enum ShareholderProjectStatuses
{
    Candidate = 1,
    PremiumCandidate = 2, //Heeft voorschot gestort
    Active = 3, //Project is gestart
    ProjectEnded = 4, //Project is afgelopen
    Abandoned = 5, //Kandidatuur is stopgezet
    HasQuit = 6 //Tijdens de projectduur uitgestapt
}
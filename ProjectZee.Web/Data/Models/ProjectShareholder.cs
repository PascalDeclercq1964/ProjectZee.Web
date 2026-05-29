using ProjectZee.Web.Data;

public class ProjectShareholder
{
    public int ProjectShareholderId { get; set; }
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }

    public int ShareCount { get; set; }


    public ProjectShareholdeStates ShareholderProjectStatus { get; set; }
}


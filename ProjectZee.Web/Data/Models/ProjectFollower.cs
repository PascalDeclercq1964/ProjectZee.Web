using ProjectZee.Web.Data;
public class ProjectFollower
{
    public int ProjectId { get; set; }
    public Project Project { get; set; }

    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
}
public class CustomAttributeValue
{
    public int CustomAttributeValueId { get; set; }
    public int CustomAttributeId { get; set; }
    public int ProjectId { get; set; }
    public string Value { get; set; }

    public CustomAttribute CustomAttribute { get; set; }
}
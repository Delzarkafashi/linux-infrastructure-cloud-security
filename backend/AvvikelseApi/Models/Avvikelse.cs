namespace AvvikelseApi.Models;

public class Avvikelse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Created_By { get; set; }
    public DateTime Created_At { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace PGEFCoreIssue;

public class EFTest
{
    [Key] public int Id { get; set; }
    public int? IPAddress { get; set; }
    public string SearchableIPAddress { get; set; }
}

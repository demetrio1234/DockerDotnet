namespace Model.Models;
public class Employee : BaseEntity
{
    public string FamilyName { get; set; } = string.Empty;

    public int DepartmentId { get; set; }
}
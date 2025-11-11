namespace StudentMVC_ITI.Models.ViewModels
{
    public class AddDepartmentVM
    {
        public string? DeptName { get; set; }
        public string? DeptDesc { get; set; }
        public string? DeptLocation { get; set; }
        public int? DeptManager { get; set; }
        public DateOnly? ManagerHiredate { get; set; }
    }
}

namespace ExpensePilot.API.Models.DTO.Administration.UserManagement
{
    public class EditUserDto
    {
        public string Logon { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public int ManagerID { get; set; }
        public int DepartmentID { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}

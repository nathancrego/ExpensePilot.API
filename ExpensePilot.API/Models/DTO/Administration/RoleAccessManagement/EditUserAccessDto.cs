namespace ExpensePilot.API.Models.DTO.Administration.RoleAccessManagement
{
    public class EditUserAccessDto
    {
        public int UserID { get; set; }
        public int UserRoleID { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}

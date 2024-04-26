namespace TaskManagementSystem.Application.Users.Commands.Login
{
    public class LoginUserResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string DepartmentName { get; set; }
    }
}

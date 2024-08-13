namespace Blazor8ServerLab1
{
    /// <summary>
    /// User Persistance 實體定義
    /// </summary>
    public class UserInfo
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public string DepartmentID { get; set; }
        public string EMail { get; set; }
    }
}
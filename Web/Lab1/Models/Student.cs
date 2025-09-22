namespace Lab1.Models
{
    public class Student
    {
        public int Id { get; set; } //MaSV
        public string? Name { get; set; } //Ho ten
        public string? Email { get; set; }   //Email
        public string? Password { get; set; } //Mật Khẩu
        public Branch? Branch { get; set; } //Ngành học
        public Gender? Gender { get; set; } //Giới tính
        public bool IsRegular { get; set; } //Hệ True-Chính quy, False-Phi chính quy
        public string? Address { get; set; } //Địa chỉ
        public DateTime DateOfBirth { get; set; } //Ngày sinh
        public string? Avatar { get; set; }
    }
}
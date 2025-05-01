using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using DataLayer; // BusinessLayer có thể tham chiếu đến DataLayer
using TransferObject; // Để sử dụng Acccount
using System.Data.SqlClient; // Tạo SqlParameter để tránh Data injection
using System.Linq;
using System.Security.Principal; // Thêm dòng này vào đầu file


namespace BusinessLayer
{
    public class UserService
    {
        private DataProvider dataProvider;

        public UserService()
        {
            dataProvider = new DataProvider();
        }

        // Kiểm tra Login
        public bool IsUserLogin(Acccount account)
        {
            try
            {
                // Truy vấn SQL để kiểm tra thông tin đăng nhập
                string sql = "SELECT COUNT(*) FROM [User] WHERE Username = @Username AND Password = @Password";

                // Tạo tham số để tránh SQL injection
                var parameters = new[]
                {
                    new SqlParameter("@Username", account.Username),
                    new SqlParameter("@Password", account.Password)
                };

                // Sử dụng MyExcuteScalar để lấy số lượng bản ghi khớp
                object result = dataProvider.MyExcuteScalar(sql, System.Data.CommandType.Text, parameters);

                // Chuyển đổi kết quả thành int
                int count = Convert.ToInt32(result);
                return count > 0; // Trả về true nếu tìm thấy bản ghi khớp
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra đăng nhập: " + ex.Message);
            }
        }

        // Kiểm tra Login bằng Entity Framework
        public bool IsUserLogin_ORM(Acccount account)
        {
            try
            {
                // Sử dụng OucareModel thay vì SQL trực tiếp
                using (var context = new DataLayer.OUCareDBContext())
                {
                    // Kiểm tra đăng nhập bằng LINQ
                    return context.Users.Any(u =>
                    u.userName == account.Username &&
                    u.passWord == account.Password &&
                        u.isActive == 1);
                }
            }
            catch(SqlException ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }

        // View User, viết theo cách này sẽ trả về kiểu dữ liệu trong lớp data. Presen ko ref đến data nên sẽ gây lỗi
        // Hướng giải quyết: Trả về kiểu dữ liệu trong DTO
        //public List<User> GetAllUsers()
        //{
        //    using(var context = new DataLayer.OUCareDBContext())
        //    {
        //        return context.Users.ToList();
        //    }
        //}

        // Chức năng load bảng user lên khi nhấn vào view user
        public List<TransferObject.UsersDTO> GetAllUsers()
        {
            using (var context = new DataLayer.OUCareDBContext())
            {
                // Lấy dữ liệu từ DataLayer và chuyển đổi sang DTO
                return context.Users.Select(u => new TransferObject.UsersDTO
                {
                    ID = u.ID,
                    userName = u.userName,
                    name = u.name,
                    email = u.email,
                    roleID = u.roleID,
                    CreateDate = u.createDate,
                    IsActive = u.isActive
                }).ToList();
            }
        }

        // Chức năng tìm kiếm trong View User
        public List<TransferObject.UsersDTO> SearchUsers(string username)
        {
            using (var context = new DataLayer.OUCareDBContext())
            {
                return context.Users
                    .Where(u => u.userName.Contains(username))
                    .Select(u => new TransferObject.UsersDTO
                    {
                        ID = u.ID,
                        userName = u.userName,
                        name = u.name,
                        email = u.email,
                        roleID = u.roleID,
                        CreateDate = u.createDate,
                        IsActive = u.isActive
                    }).ToList();
            }
        }

        // Chức năng xóa người dùng trong View user
        public bool DeleteUser(int userID)
        {
            try
            {
                using (var context = new DataLayer.OUCareDBContext())
                {
                    var user = context.Users.Find(userID);
                    if (user != null)
                    {
                        context.Users.Remove(user);
                        return context.SaveChanges() > 0;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa người dùng: " + ex.Message);
            }
        }

        // === Chức năng xem Profile

        //// Tra ve user name
        //public string GetUsername(Acccount account)
        //{
        //    try
        //    {               
        //        using (var context = new DataLayer.OUCareDBContext())
        //        {
        //            var username = context.Users
        //                .Where(u => u.userName == account.Username)
        //                .Select(u => u.userName)
        //                .FirstOrDefault();
        //            return username;
        //        }
                
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new Exception("Lỗi" + ex.Message);
        //    }
        //}

        // 1. Lấy thông tin profile của người dùng theo username
        public UsersDTO GetUserProfile(string username)
        {
            try
            {
                using (var context = new DataLayer.OUCareDBContext())
                {
                    // Truy vấn thông tin người dùng dựa trên username
                    var user = context.Users
                        .Where(u => u.userName == username)
                        .Select(u => new UsersDTO
                        {
                            ID = u.ID,
                            userName = u.userName,
                            passWord = u.passWord,
                            name = u.name,
                            email = u.email,
                            roleID = u.roleID,
                            CreateDate = u.createDate,
                            IsActive = u.isActive
                        })
                        .FirstOrDefault();

                    return user; // Trả về thông tin người dùng hoặc null nếu không tìm thấy
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải thông tin profile: " + ex.Message);
            }
        }

        // 2. Hàm update thông tin người dùng
        // => trả về kiểu bool, đồng thời thay đổi thuộc tính truyền vào (nếu có)
        public bool UpdateProfile(string username, string name, string email, string oldPw, string newPw)
        {
            try
            {
                using (var context = new DataLayer.OUCareDBContext())
                {
                    var user = context.Users.FirstOrDefault(u => u.userName == username);
                    if (user == null)
                        throw new Exception("Không tìm thấy người dùng.");

                    bool isUpdated = false;

                    // Nếu có bất kỳ sự thay đổi nào so với dbcontext => return true
                    if (user.name != name)
                    {
                        user.name = name;
                        isUpdated = true;
                    }
                    if (user.email != email)
                    {
                        user.email = email;
                        isUpdated = true;
                    }
                    if (!string.IsNullOrEmpty(oldPw) && !string.IsNullOrEmpty(newPw))
                    {
                        if (user.passWord == oldPw)  
                        {
                            user.passWord = newPw;
                            isUpdated = true;
                        }
                        else
                        {
                            throw new Exception("Mật khẩu cũ không chính xác.");
                        }
                    }

                    if (isUpdated)
                    {
                        context.SaveChanges();
                    }

                    return isUpdated;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thay đổi thông tin: " + ex.Message);
            }
        }
        // === Chức năng Thêm Users
        // Tương tự, trả về kiểu bool, đồng thời thay đổi dbcontext
        public bool AddUser(string username, string name, string email, string password, int userRole)
        {
            try
            {
                using (var context = new DataLayer.OUCareDBContext())
                {
                    // Kiểm tra tồn tại tên Username 
                    var existingUser = context.Users.FirstOrDefault(u => u.userName == username);
                    if (existingUser != null)
                    {
                        return false; // Username đã tồn tại
                    }

                    var newUser = new DataLayer.User
                    {
                        userName = username,
                        name = name,
                        email = email,
                        passWord = password, // Cân nhắc hash pw
                        roleID = userRole,
                        createDate = DateTime.Now,
                        isActive = 1
                    };

                    context.Users.Add(newUser);
                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm người dùng: " + ex.Message);
            }
        }

    }
}
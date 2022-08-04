using Login.Models;
using Login.Repositorios.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Login.Repositorios.Repository
{
    public class UserRepository : IUserRepostiroy
    {
        private readonly LoginDbContext _db;
        private readonly ILogger<UserRepository> _logger;   
        public UserRepository(LoginDbContext db, ILogger<UserRepository> logger)
        {
            _db = db;
            _logger = logger;
        }
        /// <summary>
        /// Search user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<string> Login(string email, string password)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));
            if (user == null)
            {   
                // register user to database
                _logger.LogWarning("User try to log, doesn't exist");
                return "usuario_wrong";
            }

            if (user.Password == ConvertirSha256(password)) {
                return "ok";
            }
            else
            {
                _logger.LogWarning("Password incorrect");
                return "password_wrong";
            }
        }
        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="userDto"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<string> Register(UserDto userDto, string password)
        {           
            try
            { 
                if (await UserExiste(userDto.Email))
                {
                    _logger.LogWarning("Usuario intenta loguearse ya existe");
                    return "user_exist";
                }
                // convertir password a sha256
                userDto.Password = ConvertirSha256(userDto.Password);
                User user = new User();
                user.Email= userDto.Email;
                user.Password = userDto.Password;

                await _db.Users.AddAsync(user);
                await _db.SaveChangesAsync();
                return "ok";

            }
            catch (Exception ex) {
                _logger.LogCritical(ex, ex.Message);
                return "-500";
            }           

        }
        /// <summary>
        /// Validate User 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<bool> UserExiste(string email)
        {
            if (await _db.Users.AnyAsync(x => x.Email.ToLower().Equals(email.ToLower())))
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// Convert string to Sha256 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string ConvertirSha256(string password)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 sha256 = SHA256.Create())
            {
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] stream = null;
                
                stream = sha256.ComputeHash(encoding.GetBytes(password));
                for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
               
            }
            return sb.ToString();

        }
    }
}

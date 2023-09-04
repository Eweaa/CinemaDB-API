//using System.Security.Claims;
//using System.Security.Cryptography;
//using System.Text;
//using CinemaDB.Application.Common.Interfaces;
//using Microsoft.AspNetCore.Cryptography.KeyDerivation;

//namespace CinemaDB.Application.Users.Login;

//public record Login : IRequest<string>
//{
//    public string? UserName { get; set; }
//    public string? Password { get; set; }
//}

//public class LoginHandle : IRequestHandler<Login, string>
//{
//    private readonly IApplicationDbContext _context;
//    public LoginHandle(IApplicationDbContext context)
//    {
//        _context = context;
//    }
//    public async Task<string> Handle(Login request, CancellationToken cancellationToken)
//    {
//        var exist = _context.Users.Where(u => u.userName == request.UserName).Any();
//        if (exist)
//        {
//            var entity = _context.Users.Where(u => u.userName == request.UserName).FirstOrDefault();
//            if (entity != null)
//            {
//                var userName = entity?.userName;
//                var password = entity?.Password;
//                if (password != null && request.Password != null)
//                {
//                    string userHashedPassword = Hash(password);
//                    string incomingPassword = Hash(request.Password);
//                    if (userHashedPassword == incomingPassword)
//                    {
//                        try
//                        {
//                            return JWTTokenGenerator.Generate(userName, password);
//                        }
//                        catch (Exception)
//                        {
//                            return "Something Went Wrong While Creating the Token";
//                        }
//                    }
//                }
//                return "Either the Password you've Entered is Null or Something went wrong while retrieving yourr data";
//            }
//        }
//        else
//        {
//            return "User Does Not Exist";
//        }
        
//    }

//    public string Hash(string password)
//    {
//        byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
//        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
//        password: password!,
//        salt: salt,
//        prf: KeyDerivationPrf.HMACSHA256,
//        iterationCount: 100000,
//        numBytesRequested: 256 / 8));
//        return hashed;
//    }
//}

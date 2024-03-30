using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTop.Entities.Entitties.Users;
public class UserEntity
{
    public long Id { get; set; }
    public string UserName { get; set; }
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public string Telegram { get; set; }
}

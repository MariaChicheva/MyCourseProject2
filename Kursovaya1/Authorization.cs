using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya1
{
    internal class Authorization
    {

        public static string authorizationRole;
        public static string GetRole(string login, string password)
        {
            var account = DBKursovayaEntities.GetContext().Account.FirstOrDefault(a => a.Login_ == login && a.Password_ == password);
            if (account != null) return authorizationRole = account.Role_.NameRole;
            return null;
        }
    }
}

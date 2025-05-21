using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public static class SessionManager
    {
        public static string Username {  get; private set; }
        public static int RoleID { get; private set; }
        public static Image ImageUser { get; private set; }
        public static string NameRole { get; private set; } 
        public static void Initialize(string username, int roleID,string nameRole)
        {
            username = username.Trim(); 
            RoleID = roleID;
            NameRole = nameRole;


        }
        public static bool IsAdmin()
        {
            return RoleID == 1 || NameRole =="admin"; // Assuming 1 is the role ID for admin
        }
        public static bool IsUser()
        {
            return RoleID == 2 || NameRole == "user";
        }


        public static void Clear()
        {
            Username=null;
            RoleID=0;
            NameRole = null;    
            
        }
    }
}
 
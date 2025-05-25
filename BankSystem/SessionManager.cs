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
        public static void Initialize(string username)
        {
            Username = username.Trim(); 
            


        }
        public static bool IsAdmin()
        {
            return  Username == "2004007";
        }
        public static bool IsUser()
        {
            return Username != "2004007";
        }


        public static void Clear()
        {
            Username=null;
               
            
        }
    }
}
 
using System;

namespace Beauty.Admin.Models.Helpher
{
    public class SessionManager
    {
            public static int? UserId { get; set; }
            public static string? Title { get; set; }
            public static string? FirstName { get; set; }
            public static string? LastName { get; set; }
            public static string? MiddleName { get; set; }
            public static string? UserName { get; set; }
            public static string? Phone { get; set; }
            public static string? Email { get; set; }
            public static string? Image { get; set; }
           
    }
   
    public class SessionList
    {
        public  string? Category { get; set; }
        public  int? Count { get; set; }
    }
}

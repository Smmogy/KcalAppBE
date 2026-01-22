using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace KcalAppBE.Models
{
    public class User
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Email { get; set; }
        public string Password { get; set; }
        public String ProfessorSex  { get; set; }
        public String Age { get; set; }
        public int? Weight {  get; set; }
        public int? Hight { get; set; }
        public List<Days> DaysTime {  get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .Navigation(e => e.DaysTime)
                .AutoInclude();
        }
    }
}


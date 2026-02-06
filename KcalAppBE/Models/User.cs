using System.Reflection.Emit;
using KcalAppBE.DTOs;
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
        public DateTime DayDateTime { get; set; }
        public List<Consumables> ConsumablesUsed { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .Navigation(e => e.ConsumablesUsed)
                .AutoInclude();
        }

        public UserDTO GetDTO()
        {
            return new UserDTO()
            {
                Id = Id,
                Name = Name,
                Surname = Surname,
                Email = Email,
                ProfessorSex = ProfessorSex,
                Age = Age,
                Hight = Hight
            };
        }
    }
}


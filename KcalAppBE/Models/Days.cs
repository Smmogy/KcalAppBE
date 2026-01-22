using Microsoft.EntityFrameworkCore;

namespace KcalAppBE.Models
{
    public class Days
    {
        public int Id { get; set; }
        public DateTime dateTime { get; set; }
        public List<Consumables> ConsumablesDate { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Days>()
                .Navigation(e => e.ConsumablesDate)
                .AutoInclude();
        }
    }
}


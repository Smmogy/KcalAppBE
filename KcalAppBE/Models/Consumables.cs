namespace KcalAppBE.Models
{
    public class Consumables
    {
        public int Id { get; set; }
        public String ConsumablesName { get; set; }
        public int Kcal {  get; set; }
        public int? Protein { get; set; }
        public int? Carbs { get; set; }
    }
}
    
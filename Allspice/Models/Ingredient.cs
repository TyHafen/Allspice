namespace Allspice.Models
{

    public class Ingredient
    {
        public string name { get; set; }
        public string quantity { get; set; }
        public Recipe? id { get; set; }
    }

}
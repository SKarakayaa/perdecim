namespace UI.Models.Cart
{
    public class DemandType
    {
        public int DemandTypeId { get; set; }
        public int DemandId { get; set; }
        public decimal ChoosedDemandPrice { get; set; }
        public string ChoosedDemand { get; set; }
    }
}
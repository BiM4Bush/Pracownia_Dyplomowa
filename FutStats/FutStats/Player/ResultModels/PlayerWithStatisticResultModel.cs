namespace FutStats.Api.Player.ResultModels
{
    public class PlayerWithStatisticResultModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
    }
}

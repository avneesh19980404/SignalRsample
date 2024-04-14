namespace SignalRsample.Hubs.Store
{
    public static class SD
    {
        public static Dictionary<string, int> Votes = new Dictionary<string, int>();
        static SD()
        {
            Votes[Cloak] = 0;
            Votes[Stone] = 0;
            Votes[Wand] = 0;
        }
        public const string Cloak = "cloak";
        public const string Stone = "stone";
        public const string Wand = "wand";
    }
}

namespace RockPaperScissor.Core.Game
{

    public enum Decision : short
    {
        Rock         = 0b_10101_00001, // is 1 << 0, doesn't win vs 1 << 4 | 1 << 2 | self
        Paper        = 0b_10011_00010, // is 1 << 1, doesn't win vs 1 << 4 |  self  | 1 << 1, 
        Scissors     = 0b_10110_00100, // is 1 << 2, doesn't win vs 1 << 4 |  self  | 1 << 1, 
        Dynamite     = 0b_01111_01000, // is 1 << 3, doesn't win vs  self  | 1 << 2 | 1 << 1 | 1 << 0
        WaterBalloon = 0b_11000_10000, // is 1 << 4, doesn't win vs  self  | 1 << 3
    }
}
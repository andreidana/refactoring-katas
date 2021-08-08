namespace GildedRose.Console
{
    public class Elixir: Item
    {
        public override void UpdateQuality()
        {
            if (Quality > 0)
            {
                Quality--;
            }

            SellIn--;

            if (SellIn < 0 && Quality > 0)
            {
                Quality--;
            }
        }
    }
}
namespace GildedRose.Console
{
    public class AgedBrie: Item
    {
        public override void UpdateQuality()
        {
            if (Quality < 50 || SellIn < 0 && Quality < 50)
            {
                Quality++;
            }

            SellIn--;
        }
    }
}
namespace GildedRose.Console
{
    public class BackstagePass: Item
    {
        public override void UpdateQuality()
        {
            if (Quality < 50)
            {
                Quality++;

                if (SellIn < 11 && Quality < 50)
                {
                    Quality++;
                }
            }

            SellIn--;

            if (SellIn < 0)
            {
                Quality = 0;
            }
        }
    }
}
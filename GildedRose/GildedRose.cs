using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private const string AgedBrieName = "Aged Brie";

        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        private bool IsMaxQuality(Item item)
        {
            return item.Quality == 50;
        }

        private bool IsMinQuality(Item item)
        {
            return item.Quality == 0;
        }

        private bool IsAgedBrie(Item item)
        {
            return item.Name == AgedBrieName;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (!IsAgedBrie(Items[i]) && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (!IsMinQuality(Items[i]))
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            Items[i].Quality--;
                        }
                    }
                }
                else
                {
                    if (!IsMaxQuality(Items[i]))
                    {
                        Items[i].Quality++;

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (!IsMaxQuality(Items[i]))
                                {
                                    Items[i].Quality++;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (!IsMaxQuality(Items[i]))
                                {
                                    Items[i].Quality++;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (!IsAgedBrie(Items[i]))
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (!IsMinQuality(Items[i]))
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    Items[i].Quality--;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (!IsMaxQuality(Items[i]))
                        {
                            Items[i].Quality++;
                        }
                    }
                }
            }
        }
    }
}

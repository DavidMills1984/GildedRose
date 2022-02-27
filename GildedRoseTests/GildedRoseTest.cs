using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using System.Linq;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        private const string ExampleItemName = "foo";
        private const string LegendaryItemName = "Sulfuras, Hand of Ragnaros";
        private const int MaxQuality = 50;

        [Fact]
        public void Should_Maintain_Item_Name_Property_After_UpdateQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = ExampleItemName, SellIn = 0, Quality = 0 } };
            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.Equal(ExampleItemName, Items.First().Name);
        }

        [Fact]
        public void Quality_Of_An_Item_Is_Never_Negative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = ExampleItemName, SellIn = 0, Quality = 0 } };
            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items.First().Quality);
        }

        [Fact]
        public void Aged_Brie_Increases_In_Quality_With_Age()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 } };
            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.True(Items.First().Quality > 0);
        }

        [Fact]
        public void Quality_Never_Increases_Above_Max()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = MaxQuality } };
            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.Equal(50, Items.First().Quality);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(5, 0)]
        [InlineData(0, 5)]
        [InlineData(5, 5)]
        [InlineData(5, 80)]
        public void Legendary_Items_Never_Decrease_In_Quality_Or_Decrease_SellIn(int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = LegendaryItemName, SellIn = sellIn, Quality = quality } };
            GildedRose app = new(Items);
            app.UpdateQuality();
            Assert.Equal(quality, Items.First().Quality);
            Assert.Equal(sellIn, Items.First().SellIn);
        }
    }
}
using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using System.Linq;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        private const string ExampleItemName = "foo";

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
    }
}
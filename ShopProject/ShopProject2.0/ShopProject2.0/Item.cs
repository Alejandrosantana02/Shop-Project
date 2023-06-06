using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ShopProject2._0
{
    public abstract class Item
    {
        private string name;
        private string desc;
        private int price;
        private string artString;
        private Image art;
        public string Name { get => name; set => name = value; }
        public string Desc { get => desc; set => desc = value; }
        public int Price { get => price; set => price = value; }
        public string Artstring { get => artString; set => artString = value; }
        public Image Art { get => art; set => art = value; }

        public abstract void BuyItem();

        public bool loadImage()
        {
            bool error = false;
            try 
            { 
                Art = Image.FromFile("imagefolder\\" +artString); 
            }
            catch
            {
                error = true;
            }
            return error;
        }

    }
}

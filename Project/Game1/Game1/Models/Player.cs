using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoBlock.Models
{
    public class Player : Sprite
    {
        public Player(Texture2D texture, int num) : base(texture)
        {
            Color[] colordata = new Color[100 * 100];
            Color c = num == 1 ? Color.Red : Color.Green;
            int p = num == 1 ? 700 : -0;
            for (int i = 0; i < 10000; i++)
            {
                colordata[i] = c;
            }
            texture.SetData<Color>(colordata);
            Position.X += p;
        }

        public int HP { get; set; } = 100;
        public Texture2D Texture ;
        public Vector2 Position;

    }
}

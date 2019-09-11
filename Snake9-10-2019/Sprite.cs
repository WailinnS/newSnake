using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake9_10_2019
{
    public class Sprite
    {
        public Texture2D Image { set; get; }
        public Vector2 Position { set; get; }
        public float X
        {
            get => Position.X;
            set { Position = new Vector2(value, Position.Y); }
        }


        public Color Tint { set; get; }

        public Sprite(Texture2D image, Vector2 position, Color tint)
        {
            Image = image;
            Position = position;
            Tint = tint;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Image, Position, Tint);
        }
    }
}

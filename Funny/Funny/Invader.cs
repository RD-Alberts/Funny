using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Funny
{
    class Invader
    {
        Vector2 position;
        Vector2 velocity;
        Texture2D texture;
        Random random;

        public Invader()
        {
            Init();
        }

        public void Reset()
        {
            position.X = random.Next(100, Global.width - 100);
            position.Y = random.Next(0, Global.height - 300);

            velocity.X = 3;
            velocity.Y = 10;
        }

        public void Init()
        {
            texture = Global.content.Load<Texture2D>("red_invader");
            random = new Random();
            Reset();
        }

        public void Update()
        {
            position.X += velocity.X;

            if ((position.X > Global.width - texture.Width) || (position.X < 0)) {
                position.X -= velocity.X;
                velocity.X = -velocity.X;
                position.Y += velocity.Y;
            }
        }

        public void Draw()
        {
            Global.spriteBatch.Draw(texture, position, Color.White);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Funny.Enemy
{
    class Patrouille
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 velocity;
        public int hp = 2;
        public Rectangle hitTest;

        public Patrouille()
        {
            Init();
        }

        public void Reset()
        {
            position.X = Global.Random(100, Global.width - 100);
            position.Y = 10;

            velocity.X = 3;
            velocity.Y = 0;
        }

        public void Init()
        {
            texture = Global.content.Load<Texture2D>("enemy_ship");
            hitTest = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            Reset();
        }
        

        public void Update()
        {
            position.X += velocity.X;

            if ((position.X > Global.width - texture.Width) || (position.X < 0))
            {
                position.X -= velocity.X;
                velocity.X = -velocity.X;
            }
        }

        public void Draw()
        {
            Global.spriteBatch.Draw(texture, position, Color.White);
        }
    }
}

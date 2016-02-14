using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Funny
{
    class Bullet
    {
        public Boolean isFired = false;
        public Vector2 position;
        public Vector2 velocity;
        public Texture2D texture;
        public float speed;

        public Bullet()
        {
            Init();
        }

        public void Init()
        {
            texture = Global.content.Load<Texture2D>("bullet");
            speed = 3;
            Reset();
        }

        public void Update()
        {
            if(isFired)
            {
                if(position.Y < 0)
                {
                    Reset();
                }

                position.Y += velocity.Y;
            }
        }

        public void Reset()
        {
            isFired = false;
            position.X= - 1000;
            velocity.Y = 0;
        }
        

        public void Draw()
        {
            Global.spriteBatch.Draw(texture, position, Color.White);
        }

        public void Fire(Vector2 startPosition)
        {
            if(!isFired)
            {
                isFired = true;
                this.position.X = startPosition.X;
                this.position.Y = startPosition.Y;
                velocity.Y = -speed;
            }            
        }

       /*public Boolean OverlapsInvader(Invader anInvader)
        {

        }*/

    }
}

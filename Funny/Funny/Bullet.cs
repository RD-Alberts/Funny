using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Funny.Enemy;

namespace Funny
{
    class Bullet
    {
        public Boolean isFired = false;
        public Vector2 position;
        public Vector2 velocity;
        public Texture2D texture;
        public float speed;
        public int damage;

        public Bullet()
        {
            Init();
        }

        public void Init()
        {
            texture = Global.content.Load<Texture2D>("bullet");
            speed = 3;
            damage = 1;
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

       public Boolean OverlapsInvader(Invader anInvader)
        {
            int w0 = this.texture.Width,
            h0 = this.texture.Width,
            w1 = anInvader.texture.Width,
            h1 = anInvader.texture.Height;

            if (this.position.X > anInvader.position.X + w1 || this.position.X + w0 < anInvader.position.X ||
                this.position.Y > anInvader.position.Y + h1 || this.position.Y + h0 < anInvader.position.Y)
                return false;
            else
                return true;
        }

        public Boolean OverlapsPatrouille(Patrouille aPatrouille)
        {
            int w0 = this.texture.Width,
            h0 = this.texture.Width,
            w1 = aPatrouille.texture.Width,
            h1 = aPatrouille.texture.Height;

            if (this.position.X > aPatrouille.position.X + w1 || this.position.X + w0 < aPatrouille.position.X ||
                this.position.Y > aPatrouille.position.Y + h1 || this.position.Y + h0 < aPatrouille.position.Y)
                return false;
            else
                return true;
        }

    }
}

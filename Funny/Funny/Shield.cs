using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace Funny
{
    class Shield
    {

        public Texture2D texture;
        public Vector2 position;
        public Boolean isVisible;

        public Shield()
        {
            Init();
            position.X = 100;
            position.Y = 500;
        }

        public void Init()
        {
            texture = Global.content.Load<Texture2D>("shield");
            isVisible = true;
        }

        public void Update()
        {

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

        public Boolean OverlapsBullet(Bullet aBullet)
        {
            int w0 = this.texture.Width,
            h0 = this.texture.Width,
            w1 = aBullet.texture.Width,
            h1 = aBullet.texture.Height;

            if (this.position.X > aBullet.position.X + w1 || this.position.X + w0 < aBullet.position.X ||
                this.position.Y > aBullet.position.Y + h1 || this.position.Y + h0 < aBullet.position.Y)
                return false;
            else
                return true;
        }

        public void Draw()
        {
            Global.spriteBatch.Draw(texture, position, Color.White);
        }
    }
}

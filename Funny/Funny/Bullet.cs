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
        Player player;

        public Bullet()
        {
            texture = Global.content.Load<Texture2D>("bullet");
            Init();
        }

        public void Init()
        {
            player = new Player();
            position.X = player.position.X;
            position.Y = player.position.Y - texture.Height;
        }

        public void Update()
        {
        }

        public void Draw()
        {            
        }

        public void Fire(Vector2 startPosition)
        {            
        }

//        public Boolean OverlapsInvader(Invader anInvader)
//        {
//        }

    }
}

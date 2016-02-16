using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Funny.Enemy;

namespace Funny.Screens
{
    class GameScreen : Screen
    {
        Texture2D background, scanlines;
        int nInvaders = 16;
        List<Invader> invadersList = new List<Invader>();

        Player thePlayer;
        Bullet theBullet;
        Patrouille thePatrouille;

        public GameScreen()
        {
            Init();
        }

        public void Init()
        {
          //  theBullet = new Bullet();
         //   thePatrouille = new Patrouille();
          //  thePlayer = new Player();


            CallInvader();
        }

        public void CallInvader()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Global.screenRect, Color.White);
        }
    }
}


using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.GamerServices;
using Funny.Enemy;

namespace Funny
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background, scanlines;

        //invader variables
        int nInvaders = 16;
        List<Invader> invadersList = new List<Invader>();

        //shield variables
        List<Shield> shieldList = new List<Shield>();
        int nShield = 4;

        //class variables
        Player thePlayer;
        Bullet theBullet;
        Patrouille thePatrouille;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;

            Content.RootDirectory = "Content";
        }

        public void CallInvader()
        {
            for(int iInvader = 0; iInvader < nInvaders; iInvader++)
            {
                Invader newInvader = new Invader();
                newInvader.Init();
                invadersList.Add(newInvader);
            }
        }

        public void CallShield()
        {
            for(int iShield = 0; iShield < nShield; iShield ++)
            {
                Shield newShield = new Shield();
                newShield.Init();
                shieldList.Add(newShield);
            }

            shieldList[0].position.X = 100;
            shieldList[1].position.X = shieldList[0].position.X + 100 + shieldList[0].texture.Width;
            shieldList[2].position.X = shieldList[1].position.X + 100 + shieldList[1].texture.Width;
            shieldList[3].position.X = shieldList[2].position.X + 100 + shieldList[2].texture.Width;
        }

        protected override void Initialize()
        {
            // Pass often referenced variables to Global
            Global.GraphicsDevice = GraphicsDevice;
            Global.content = Content;

            // Create and Initialize game objects
            thePlayer = new Player();
            theBullet = new Bullet();
            thePatrouille = new Patrouille();

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Global.spriteBatch = spriteBatch;
            background = Content.Load<Texture2D>("background");
            scanlines = Content.Load<Texture2D>("scanlines");
            CallInvader();
            CallShield();

            base.Initialize();
        }
        
        protected override void Update(GameTime gameTime)
        {
            // Pass keyboard state to Global so we can use it everywhere
            Global.keys = Keyboard.GetState();
            if (Global.keys.IsKeyDown(Keys.Space)) theBullet.Fire(thePlayer.position);

            // Update the game objects
            thePlayer.Update();
            theBullet.Update();
            thePatrouille.Update();
            foreach (Invader invader in invadersList)
            {
                invader.Update();

                if(theBullet.OverlapsInvader(invader))
                {
                    theBullet.Reset();
                    invader.Reset();
                }
            }
            

            for (int i = 0; i < shieldList.Count; i++)
            {
                if (shieldList[i].OverlapsBullet(theBullet))
                {
                    shieldList[i].isVisible = false;
                    theBullet.Reset();
                    RemoveShield();
                }
            }

            if (theBullet.OverlapsPatrouille(thePatrouille))
            {
                theBullet.Reset();
                thePatrouille.hp -= theBullet.damage;
                if(thePatrouille.hp <= 0)
                    thePatrouille.Reset();
            }
            base.Update(gameTime);
        }

        public void RemoveShield()
        {
            //if any of the asteroids in the list are destroyed (or are invisible) then remove them from the list this is for enemy 1
            for (int i = 0; i < shieldList.Count; i++)
            {
                if (!shieldList[i].isVisible)
                {
                    shieldList.RemoveAt(i);
                    i--;
                }
            }
        }

        
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            // Draw the background (and clear the screen)
            spriteBatch.Draw(background, Global.screenRect, Color.White);

            // Draw the game objects
            thePlayer.Draw();
            theBullet.Draw();
            thePatrouille.Draw();
            foreach(Invader invader in invadersList)
            {
                invader.Draw();
                spriteBatch.Draw(scanlines, Global.screenRect, Color.White);
            }

            foreach(Shield shield in shieldList)
            {
                shield.Draw();
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}


using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.GamerServices;

namespace Funny
{
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background, scanlines;
        int nInvaders = 16;
        List<Invader> invadersList = new List<Invader>();

        Player thePlayer;
        Bullet theBullet;

        //TODO: Add multiple invaders here

        public Main()
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
        
        protected override void Initialize()
        {
            // Pass often referenced variables to Global
            Global.GraphicsDevice = GraphicsDevice;
            Global.content = Content;

            // Create and Initialize game objects
            thePlayer = new Player();
            theBullet = new Bullet();

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Global.spriteBatch = spriteBatch;
            background = Content.Load<Texture2D>("background");
            scanlines = Content.Load<Texture2D>("scanlines");
            CallInvader();
            
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
            foreach (Invader invader in invadersList)
            {
                invader.Update();
            }

            Console.WriteLine(invadersList.Count);
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            // Draw the background (and clear the screen)
            spriteBatch.Draw(background, Global.screenRect, Color.White);

            // Draw the game objects
            thePlayer.Draw();
            theBullet.Draw();

            foreach(Invader invader in invadersList)
            {
                invader.Draw();
                spriteBatch.Draw(scanlines, Global.screenRect, Color.White);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

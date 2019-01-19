/*
 * Young Geun, Kim(Andrew)
 * Ykim1059@conestogac.on.ca
 * Student ID: 7841059
 * Section: 3
 * Created: 11/3/2018
 * Last Edit: 12/10/2018
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Dodge
{
    public class Flight : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        private Vector2 speed;

        private Vector2 stage;
        public Flight(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position,
            Vector2 speed,
            Vector2 stage) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.speed = speed;
            this.stage = stage;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            //common mistake :
            //KeyboardState ks = new KeyboardState();

            if (ks.IsKeyDown(Keys.Left))
            {
                position.X -= speed.X;

                if (position.X < 0)
                {
                    position.X = 0;
                }
            }
            if (ks.IsKeyDown(Keys.Right))
            {
                position.X += speed.X;
                if (position.X + tex.Width > stage.X)
                {
                    position.X = stage.X - tex.Width;
                }
            }
            if (ks.IsKeyDown(Keys.Up))
            {
                position.Y -= speed.Y;

                if (position.Y < 0)
                {
                    position.Y = 0;
                }
            }
            if (ks.IsKeyDown(Keys.Down))
            {
                position.Y += speed.Y;
                if (position.Y + tex.Height > stage.Y)
                {
                    position.Y = stage.Y - tex.Height;
                }

            }

            base.Update(gameTime);
        }

        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }
    }
}

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
    public class Bullet : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        private Vector2 speed;
        private Vector2 stage;
        public Vector2 Speed { get => speed; set => speed = value; }
        private Random rnd = new Random();

        public Bullet(Game game,
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
            position += speed;

            //top wall
            if (position.Y < 0 - 50)
            {
                speed.Y = -speed.Y;
            }
            //right wall
            if (position.X + tex.Width > stage.X + 50)
            {
                speed.X = -speed.X;
            }
            //Left wall
            if (position.X < 0 - 50)
            {
                speed.X = -speed.X;
            }
            //bottom wall
            if (position.Y + tex.Height > stage.Y + 50)
            {
                speed.Y = -speed.Y;
            }
            base.Update(gameTime);
        }
        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }
    }
}

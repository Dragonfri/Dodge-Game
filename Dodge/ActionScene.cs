
/*
 * Young Geun, Kim(Andrew)
 * Ykim1059@conestogac.on.ca
 * Student ID: 7841059
 * Section: 3
 * Created: 11/3/2018
 * Last Edit: 12/10/2018
 */using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Dodge
{
    public class ActionScene : GameScene
    {

        private SpriteBatch spriteBatch;
        private Flight flight;
        private Bullet bullet;
        private Random rnd = new Random();
        private CollisionManager cm;
        private List<Bullet> lstBullet = new List<Bullet>(30);

        public ActionScene(Game game,
            SpriteBatch spriteBatch, GraphicsDeviceManager graphics) : base(game)
        {
            Texture2D flightTex = game.Content.Load<Texture2D>("Images/Flight");
            Vector2 stage = new Vector2(graphics.PreferredBackBufferWidth,
                graphics.PreferredBackBufferHeight);
            Vector2 ballInitPos = new Vector2(stage.X / 2 - flightTex.Width / 2,
                stage.Y / 2 - flightTex.Height / 2);
            Vector2 flightSpeed = new Vector2(5, 5);

            flight = new Flight(game, spriteBatch, flightTex, ballInitPos, flightSpeed,
                stage);

            this.Components.Add(flight);

            Texture2D bulletTex = game.Content.Load<Texture2D>("Images/Bullet");
            Vector2 bulletInitPos = new Vector2(rnd.Next(0, graphics.PreferredBackBufferWidth),
                rnd.Next(0, graphics.PreferredBackBufferHeight));
            Vector2 bulletSpeed = new Vector2();

            bullet = new Bullet(game, spriteBatch, bulletTex, bulletInitPos, bulletSpeed, stage);
            for (int i = 0; i < 30; i++)
            {
                //Not Create bullet on Center. Prevent Spawning Kill
                do
                {
                    bulletInitPos.X = rnd.Next(0, graphics.PreferredBackBufferWidth);
                    bulletInitPos.Y = rnd.Next(0, graphics.PreferredBackBufferHeight);
                } while (!(bulletInitPos.X < 100 ||
                    bulletInitPos.X > graphics.PreferredBackBufferWidth - 100) &&
                    !(bulletInitPos.Y < 100 ||
                    bulletInitPos.Y > graphics.PreferredBackBufferHeight - 100));

                bulletSpeed.X = rnd.Next(3, 6);
                bulletSpeed.Y = rnd.Next(3, 6);
                bullet = new Bullet(game, spriteBatch, bulletTex, bulletInitPos, bulletSpeed, stage);
                cm = new CollisionManager(game, flight, bullet, lstBullet);
                lstBullet.Add(bullet);
                this.Components.Add(bullet);
                this.Components.Add(cm);
            }
            
            
            this.spriteBatch = spriteBatch;
        }


        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }


    }
}

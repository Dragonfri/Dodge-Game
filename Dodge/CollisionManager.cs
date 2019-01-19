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
    class CollisionManager : GameComponent
    {
        private Flight flight;
        private Bullet bullet;
        private List<Bullet> lstBullet;

        public CollisionManager(Game game,
            Flight flight, Bullet bullet, List<Bullet> lstBullet) : base(game)
        {
            this.flight = flight;
            this.bullet = bullet;
            this.lstBullet = lstBullet;
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle flightRect = flight.getBounds();
            Rectangle bulletRect = bullet.getBounds();
            if (flightRect.Intersects(bulletRect))
            {
                foreach (var bullet in lstBullet)
                {
                    bullet.Speed = new Vector2(0, 0);
                }
            }
            base.Update(gameTime);
        }
    }
}

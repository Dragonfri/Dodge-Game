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
    public class StartScene : GameScene
    {
        public MenuComponent Menu { get; set; }

        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private string[] menuItems =
            {
            "Start Game",
            "Help",
            "High Score",
            "Credit",
            "Quit"
        };


        public StartScene(Game game,
            SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
            tex = game.Content.Load<Texture2D>("Images/Title");
            SpriteFont regularFont = game.Content.Load<SpriteFont>("Fonts/regularfont");
            SpriteFont hilightFont = game.Content.Load<SpriteFont>("Fonts/hilightfont");
            Menu = new MenuComponent(game, spriteBatch, regularFont, hilightFont, menuItems);
            this.Components.Add(Menu);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, GraphicsDevice.Viewport.Bounds, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}

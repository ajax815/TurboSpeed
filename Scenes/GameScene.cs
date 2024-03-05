using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboSpeed.Classes;

namespace TurboSpeed.Scenes
{
    public abstract class GameScene : DrawableGameComponent
    {
        public List<GameComponent> Components {  get; set; }
        public virtual void Hide()
        {
            this.Visible = false;
            this.Enabled = false;
        }
        public virtual void Show()
        {
            this.Visible = true;
            this.Enabled = true;
        }

        public GameScene(Game game) : base(game)
        {
            Components = new List<GameComponent>();
            Hide();
        }
        public override void Update(GameTime gameTime)
        {
            foreach (DrawableGameComponent component in Components)
            {
                if (component.Enabled)
                {
                    component.Update(gameTime);
                }
            }
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            foreach (DrawableGameComponent component in Components)
            {
                if (component.Visible)
                {
                    component.Draw(gameTime);
                }
            }
            base.Draw(gameTime);
        }
    }
}

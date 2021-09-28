﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.States
{
    
    public class GameOverState : State
    {
        private SpriteFont titleFont;
        private SpriteFont subtitleFont;
        
        private Label titleLabel;
        private Label resultLabel;
        private Button continueButton;
        
        private int winningPlayer;
        public GameOverState(PongGame game, ContentManager content, int winningPlayer) : base(game, content)
        {
            this.winningPlayer = winningPlayer;
            titleLabel = new Label(PongGame.screenSize / 2, Vector2.Zero, "GAME OVER", Renderer.titleColor);
            resultLabel = new Label(PongGame.screenSize / 2 + new Vector2(0, 120), Vector2.Zero, $"player {winningPlayer+1} wins!", Renderer.subtitleColor);
            continueButton = new Button(PongGame.screenSize / 2 + new Vector2(0, 184), new Vector2(200, 48), "CONTINUE");
        }

        public override void LoadContent()
        {
            titleFont = content.Load<SpriteFont>("titleFont");
            subtitleFont = content.Load<SpriteFont>("subtitleFont");
            titleLabel.font = titleFont;
            resultLabel.font = subtitleFont;
            continueButton.font = subtitleFont;

        }

        public override void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            continueButton.Update(dt);
            if(continueButton.IsPressed)
                game.SwitchState(new MenuState(game, content));
            
        }

        public override void Draw(GameTime gameTime)
        {
            titleLabel.Draw();
            resultLabel.Draw();
            continueButton.Draw();
        }
    }
}

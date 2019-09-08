using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoBlock.Models;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MonoBlock : Game
    {
        GraphicsDeviceManager graphics;
        Player player1;
        Player player2;
        SpriteBatch spriteBatch;
        Texture2D texture;
        Vector2 position = new Vector2(0, 0);

        public MonoBlock()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            player2 = new Player(GraphicsDevice, 1);
            player1 = new Player(GraphicsDevice, 2);
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                player1.Position.Y += 1;

            // TODO: Add your update logic here
            position.X += 1;
            if (position.X > this.GraphicsDevice.Viewport.Width)
            {
                position.X = 0;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            DrawPlayer(player1);
            DrawPlayer(player2);
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        private void DrawPlayer(Player p)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(p.Texture, p.Position);
            spriteBatch.End();
        }
    }
}

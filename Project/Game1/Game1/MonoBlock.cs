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
            var texture = new Texture2D(GraphicsDevice, 100, 100);
            player2 = new Player(texture, 1);
            player1 = new Player(texture, 2);
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
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                player1.Position.Y -= 1;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                player1.Position.X += 1;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                player1.Position.X -= 1;

            if (player1.Position.X > Window.ClientBounds.Width - player1.Texture.Width)
                player1.Position.X = Window.ClientBounds.Width - player1.Texture.Width;
            if (player1.Position.Y > Window.ClientBounds.Height - player1.Texture.Height)
                player1.Position.Y = Window.ClientBounds.Height - player1.Texture.Height;

            if (player1.Position.X < 0)
                player1.Position.X = 0;
            if (player1.Position.Y < 0)
                player1.Position.Y = 0;

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

        private void DrawPlayer(Sprite p)
        {
            spriteBatch.Begin();
            p.Draw(spriteBatch);
            spriteBatch.End();

        }
    }
}

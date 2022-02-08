using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        Texture2D Mariobild;
        Texture2D Kirbybild;
        Texture2D questionblockbild;
        Texture2D blockbild;

        Vector2 Mariopos = new Vector2(0, 150);
        Vector2 questionblockpos = new Vector2(127, 846);
        Vector2 blockpos = new Vector2(513, 846);
        Vector2 Kirbypos = new Vector2(0, 995);

        float Kirbyspeed = 15;

        KeyboardState tangentbordone = Keyboard.GetState();
        KeyboardState tangentbordtwo = Keyboard.GetState();

        int jumpheight = 23;
        bool jump = false;

        int windowHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        int windowWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {

            windowWidth = graphics.PreferredBackBufferWidth;
            windowHeight = graphics.PreferredBackBufferHeight;

            Fullscreen();

            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected void Fullscreen()
        {

            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
           
            graphics.IsFullScreen = true;

            windowHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            windowWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;

            graphics.ApplyChanges();

        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Mariobild = Content.Load<Texture2D>("Mariobak");
            Kirbybild = Content.Load<Texture2D>("Kirby 2.0");
            questionblockbild = Content.Load<Texture2D>("questionblock");
            blockbild = Content.Load<Texture2D>("Block");


            // TODO: use this.Content to load your game content here

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            tangentbordtwo = tangentbordone;
            tangentbordone = Keyboard.GetState();

            if (jump && jumpheight > 0)
            {
                Kirbypos.Y -= jumpheight;

                jumpheight--;
            }
            else if (jumpheight < 23)
            {
                jumpheight++;

                Kirbypos.Y += jumpheight;

                jump = false;
            }


            if ((tangentbordone.IsKeyDown(Keys.Left) || tangentbordone.IsKeyDown(Keys.A)) && Kirbypos.X > (0))
            {
                Kirbypos.X -= Kirbyspeed;
            }

            if ((tangentbordone.IsKeyDown(Keys.Right) || tangentbordone.IsKeyDown(Keys.D)) && Kirbypos.X < (windowWidth-126))
            {
                Kirbypos.X += Kirbyspeed;
            }

            if ((tangentbordone.IsKeyDown(Keys.Space)) && (tangentbordtwo.IsKeyUp(Keys.Space)))
            {
                jump = true;
            }

            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(Mariobild, Mariopos, Color.White);

            spriteBatch.Draw(questionblockbild, questionblockpos, Color.White);
            spriteBatch.Draw(blockbild, blockpos, Color.White);

            spriteBatch.Draw(Kirbybild, Kirbypos, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

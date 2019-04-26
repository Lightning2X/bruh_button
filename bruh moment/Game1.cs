using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

/// <summary>
/// This is the main type for your game.
/// </summary>
public class Game1 : Game
{
    SoundEffect bruh;
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    Point mousePos;
    Vector2 buttonPos;
    Rectangle bb;
    Texture2D buttonSprite;
    public Game1()
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
        // TODO: Add your initialization logic here
        base.Initialize();
    }

    /// <summary>
    /// LoadContent will be called once per game and is the place to load
    /// all of your content.
    /// </summary>
    protected override void LoadContent()
    {
        bruh = Content.Load<SoundEffect>("sfx");
        buttonSprite = Content.Load<Texture2D>("button");
        // Create a new SpriteBatch, which can be used to draw textures.
        spriteBatch = new SpriteBatch(GraphicsDevice);
        buttonPos = new Vector2((graphics.PreferredBackBufferWidth / 2) - buttonSprite.Width / 2, (graphics.PreferredBackBufferHeight / 2) - buttonSprite.Height / 2);
        bb = new Rectangle((int)buttonPos.X, (int)buttonPos.Y, buttonSprite.Width, buttonSprite.Height);
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
        mousePos = Mouse.GetState().Position;
        if (bb.Contains(mousePos) && Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            bruh.Play();
        }
        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    /// <summary>
    /// This is called when the game should draw itself.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Draw(GameTime gameTime)
    {

        spriteBatch.Begin();
        this.IsMouseVisible = true;
        Vector2 origin = new Vector2(buttonSprite.Width / 2, buttonSprite.Height / 2);
        spriteBatch.Draw(buttonSprite, buttonPos, Color.White);
        spriteBatch.End();
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }

}

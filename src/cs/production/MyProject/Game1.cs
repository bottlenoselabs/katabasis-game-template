using System.Numerics;
using bottlenoselabs.Katabasis;

namespace MyProject
{
	public class Game1 : Game
	{
		private KeyboardState _previousKeyboardState;
		private KeyboardState _currentKeyboardState;
		
		private SpriteBatch _spriteBatch = null!;
		private Vector2 _cursorPosition;

		public Game1()
		{
			Window.Title = "My Project";
			IsMouseVisible = false;
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch();

			Content.Load();
			
			Content.Sounds.Greeting.Play();

			MediaPlayer.IsRepeating = true;
			MediaPlayer.Play(Content.Music.DnaLoop8Bit);
		}

		protected override void Update(GameTime gameTime)
		{
			var mouseState = Mouse.GetState();
			_cursorPosition = new Vector2(mouseState.X, mouseState.Y);

			_previousKeyboardState = _currentKeyboardState;
			_currentKeyboardState = Keyboard.GetState();
			if (_currentKeyboardState.IsKeyDown(Keys.Space) && _previousKeyboardState.IsKeyUp(Keys.Space))
			{
				Content.Sounds.ConstructionComplete.Play();
			}
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			_spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, null, null);
			
			// Terran
			var centerScreenPosition = new Vector2(GraphicsDevice.Viewport.Width * 0.5f, GraphicsDevice.Viewport.Height * 0.5f);
			var origin = new Vector2(Content.Graphics.Terran.Width * 0.5f, Content.Graphics.Terran.Height * 0.5f);
			_spriteBatch.Draw(Content.Graphics.Terran, centerScreenPosition, null, Color.White, 0, origin, new Vector2(5), SpriteEffects.None, 0);
			
			// Cursor
			var cursorRed = MathF.Sin((float)gameTime.TotalGameTime.TotalSeconds);
			var cursorGreen = MathF.Cos((float)gameTime.TotalGameTime.TotalSeconds);
			var cursorColor = new Color(cursorRed, cursorGreen, 1);
			_spriteBatch.Draw(Content.Graphics.Pixel, _cursorPosition, null, cursorColor, 0, new Vector2(0.5f, 0.5f), new Vector2(10, 10), SpriteEffects.None, 0);

			_spriteBatch.End();
		}
	}
}

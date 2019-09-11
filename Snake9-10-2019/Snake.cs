using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake9_10_2019
{
    public class Snake
    {

        Texture2D SnakeHead;
        Texture2D SnakeBody;

        List<SnakePiece> snakePieces = new List<SnakePiece>();

        TimeSpan updateTargetTime = TimeSpan.FromMilliseconds(120);
        TimeSpan elpasedUpdateTime;

        public Snake(Texture2D snakeHead, Texture2D snakeBody, Vector2 position)
        {
            SnakeHead = snakeHead;
            SnakeBody = snakeBody;

            snakePieces.Add(new SnakePiece(SnakeHead, position, Color.White));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < snakePieces.Count; i++)
            {
                snakePieces[i].Draw(spriteBatch);
            }
        }

        public void Update(KeyboardState ks, GameTime gameTime)
        {
            elpasedUpdateTime += gameTime.ElapsedGameTime;

            //check direction of head
            if (ks.IsKeyDown(Keys.Down))
            {
                snakePieces[0].Direction = Directions.Down;
            }
            else if (ks.IsKeyDown(Keys.Up))
            {
                snakePieces[0].Direction = Directions.Up;
            }
            else if(ks.IsKeyDown(Keys.Left))
            {
                snakePieces[0].Direction = Directions.Left;
            }
            else if(ks.IsKeyDown(Keys.Right))
            {
                snakePieces[0].Direction = Directions.Right;
            }

            if (elpasedUpdateTime >= updateTargetTime)
            {
                elpasedUpdateTime = TimeSpan.Zero;

                for (int i = 0; i < snakePieces.Count; i++)
                {
                    switch (snakePieces[i].Direction)
                    {
                        case Directions.Up:
                            snakePieces[i].Position = new Vector2(snakePieces[i].Position.X, snakePieces[i].Position.Y - SnakeHead.Bounds.Height);
                            break;
                        case Directions.Down:
                            snakePieces[i].Position = new Vector2(snakePieces[i].Position.X, snakePieces[i].Position.Y + SnakeHead.Bounds.Height);
                            break;
                        case Directions.Left:
                           snakePieces[i].X -= snakePieces[i].Image.Width; //better way to do it.
                            break;
                        case Directions.Right:
                            snakePieces[i].Position = new Vector2(snakePieces[i].Position.X + SnakeHead.Width, snakePieces[i].Position.Y);
                            break;
                    }
                }

                for (int i = snakePieces.Count - 1; i > 0; i--)
                {
                    snakePieces[i].Direction = snakePieces[i - 1].Direction;
                }
            }
        }
    }
}

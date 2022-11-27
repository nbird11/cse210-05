using System;
using System.Collections.Generic;
using System.Data;
using CSE210_05.Game.Casting;
using CSE210_05.Game.Services;


namespace CSE210_05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the cycle 
    /// collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool _isGameOver = false;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            HandleSegmentCollisions(cast);
            HandleGameOver(cast);
        }

        /// <summary>
        /// Sets the game over flag if the cycle collides with one of the segments of the opponent.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Cycle cycle1 = (Cycle)cast.GetFirstActor("cycle1");
            Cycle cycle2 = (Cycle)cast.GetFirstActor("cycle2");
            Actor head = cycle1.GetHead();
            Actor head2 = cycle2.GetHead();
            List<Actor> body = cycle1.GetBody();
            List<Actor> body2 = cycle2.GetBody();

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head2.GetPosition()))
                {
                    _isGameOver = true;
                }
            }
            foreach (Actor segment in body2)
            {
                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    _isGameOver = true;
                }
            }
        }

        private void HandleGameOver(Cast cast)
        {
            if (_isGameOver == true)
            {
                Cycle cycle1 = (Cycle)cast.GetFirstActor("cycle1");
                Cycle cycle2 = (Cycle)cast.GetFirstActor("cycle2");
                List<Actor> segments1 = cycle1.GetSegments();
                List<Actor> segments2 = cycle2.GetSegments();

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                foreach (Actor segment in segments1)
                {
                    segment.SetColor(Constants.WHITE);
                }
                foreach (Actor segment in segments2)
                {
                    segment.SetColor(Constants.WHITE);
                }

                // Negate growing trail
                cycle1.GrowTrail(-1, Constants.WHITE);
                cycle2.GrowTrail(-1, Constants.WHITE);
            }
        }

    }
}
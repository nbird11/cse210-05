using System.Collections.Generic;
using CSE210_05.Game.Casting;
using CSE210_05.Game.Services;


namespace CSE210_05.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService _videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Cycle cycle = (Cycle)cast.GetFirstActor("cycle");
            List<Actor> segments = cycle.GetSegments();
            Cycle cycle2 = (Cycle)cast.GetFirstActor("cycle2");
            List<Actor> segments2 = cycle2.GetSegments();
            List<Actor> messages = cast.GetActors("messages");
            
            _videoService.ClearBuffer();
            _videoService.DrawActors(segments);
            _videoService.DrawActors(segments2);
            _videoService.DrawActors(messages);
            _videoService.FlushBuffer();
        }
    }
}
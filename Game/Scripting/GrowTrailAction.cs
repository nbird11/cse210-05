using System.Collections.Generic;
using CSE210_05.Game.Casting;
using CSE210_05.Game.Services;


namespace CSE210_05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that moves all the actors.</para>
    /// <para>
    /// The responsibility of GrowTrailAction is to grow the trail behind each cycle.
    /// </para>
    /// </summary>
    public class GrowTrailAction : Action
    {
        /// <summary>
        /// Constructs a new instance of GrowTrailAction.
        /// </summary>
        public GrowTrailAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Cycle cycle1 = (Cycle)cast.GetFirstActor("cycle1");
            cycle1.GrowTrail(1, Constants.GREEN);
            Cycle cycle2 = (Cycle)cast.GetFirstActor("cycle2");
            cycle2.GrowTrail(1, Constants.RED);
        }
    }
}
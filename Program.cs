using CSE210_05.Game.Casting;
using CSE210_05.Game.Directing;
using CSE210_05.Game.Scripting;
using CSE210_05.Game.Services;


namespace CSE210_05
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            Point start1 = new Point(Constants.MAX_X / 4, Constants.MAX_Y / 4);
            Point start2 = new Point(Constants.MAX_X / 4 + Constants.MAX_X / 2, Constants.MAX_Y / 4 + Constants.MAX_Y / 2);
            Color color = Constants.GREEN;
            Color color2 = Constants.RED;

            // create the cast
            Cast cast = new Cast();
            cast.AddActor("cycle", new Cycle(start1, color));
            cast.AddActor("cycle2", new Cycle(start2, color2));

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}
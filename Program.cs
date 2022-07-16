using Unit05.Game.Casting;
using Unit05.Game.Directing;
using Unit05.Game.Scripting;
using Unit05.Game.Services;
using System.Collections.Generic;
using Unit05.Game;


namespace Unit05
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
            // create the cast
            Cast cast = new Cast();
            Color color = Constants.BLUE;
            int x = 300;
            int y = 450;

            cast.AddActor("user", new Bike(x, y, color));
            color = Constants.RED;
            x = 600;
            y = 150;
            cast.AddActor("program", new Bike(x, y, color));

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", "CAA", new ControlActorsAction(keyboardService));
            script.AddAction("update", "MAA", new MoveActorsAction());
            script.AddAction("update", "HCA", new HandleCollisionsAction());
            script.AddAction("update", "GTA", new GrowTailAction());
            script.AddAction("output", "DAA", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}
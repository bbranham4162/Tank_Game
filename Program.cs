using Raylib_cs;

using genie;
using genie.cast;
using genie.script;
using genie.test;
using genie.services;
using genie.services.raylib;

using Tanks.cast;
using Tanks.script;



namespace Tanks
{
    public static class Program
    {
        public static void Test() {
            // MouseMap mouseMap = new MouseMap();
            // mouseMap.getRaylibMouse(-1);

            // CastScriptTest castScriptTest = new CastScriptTest();
            // castScriptTest.testCast();
            // castScriptTest.testScript();

            ServicesTest servicesTest = new ServicesTest();
            servicesTest.TestScreenService();

            // Director director = new Director();
            // director.DirectScene();
        }

        public static void Main(string[] args)
        {   
            // Some constants W_SIZE and, Screen_title and FPS are for our screen
            (int, int) W_SIZE = (1000, 800);
            (int, int) START_POSITION = (500, 700);
            int TANK_WIDTH = 40;
            int TANK_LENGTH = 50;
            string SCREEN_TITLE = "Tanks";
            int FPS = 120;
            //All the services initiated

            RaylibKeyboardService keyboardService = new RaylibKeyboardService();
            RaylibPhysicsService physicsService = new RaylibPhysicsService();
            RaylibScreenService screenService = new RaylibScreenService(W_SIZE, SCREEN_TITLE, FPS);
            RaylibAudioService audioservice = new RaylibAudioService();
            RaylibMouseService mouseService = new RaylibMouseService();

            // Creates Director

            Director director = new Director();

           
            //Lets construct the Tank and the Building 
            //Heres one of the players
            Tank tank1  = new Tank(null, 70, 50, W_SIZE.Item1/2, W_SIZE.Item2/10 *9, 0, 0, 45, 0);

            // Here's our second Player

            Tank tank2 = new Tank(null, 70, 50, W_SIZE.Item1/2, W_SIZE.Item2/10 *9, 0, 0, 0, 0);

            //Here's the start game button
            StartGameButton startGameButton = new StartGameButton(null, 305, 113, W_SIZE.Item1/2, W_SIZE.Item2/2);

            // Lets create the cast so we can add to it

            Cast cast = new Cast();

           
            // Lets add it to Our cast

            cast.AddActor("Tank1", tank1);
            
            cast.AddActor("Tank2", tank2);

            cast.AddActor("start_button", startGameButton);

           // Create Script

            Script script = new Script();

            // Add Actions to my script
            script.AddAction("input", new HandleQuitAction(1,screenService));

            // Add actions that must be added to the script when the game starts: (NOTE CLASSES THAT ARE
            // COMMENTED OUT ARE TEMPLATES FROM THE EXAMPLE CODE NOT NEEDED OR NOT YET NEEDED)
            Dictionary<string, List<genie.script.Action>> startGameActions = new Dictionary<string, List<genie.script.Action>>();
            startGameActions["input"] = new List<genie.script.Action>();
            startGameActions["update"] = new List<genie.script.Action>();
            startGameActions["output"] = new List<genie.script.Action>();

            startGameActions["input"].Add(new HandleTankMovementAction(2, keyboardService));
            startGameActions["input"].Add(new ShootingAction(2, keyboardService));
            // startGameActions["update"].Add(new SpawnAsteroidsAction(1, W_SIZE, (float)1.5));

            script.AddAction("input", new HandleStartGameAction(2, mouseService, physicsService, startGameActions));

            // // Add all update actions 
            script.AddAction("update", new MoveActorsAction(1, physicsService));
            // script.AddAction("update", new HandleOffscreenAction(1, W_SIZE));

            // // Add all output actions
            script.AddAction("output", new DrawActorsAction(1, screenService));
            script.AddAction("output", new UpdateScreenAction(2, screenService));

            

            

            // // Yo, director, do your thing!
            director.DirectScene(cast, script);

        }
    }
}
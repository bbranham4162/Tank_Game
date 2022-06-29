using Raylib_cs;

using genie;
using genie.cast;
using genie.script;
using genie.test;
using genie.services;
using genie.services.raylib;



namespace Tank
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
            // A few game constants
            (int, int) W_SIZE = (1000, 800);
            (int, int) START_POSITION1 = (500, 700);
            (int, int) START_POSITION2 = (400, 600);
//             int SHIP_WIDTH = 40;
//             int SHIP_LENGTH = 50;
            string SCREEN_TITLE = "Tank_Game";
            int FPS = 120;
            
//             // Initiate all services
//             RaylibKeyboardService keyboardService = new RaylibKeyboardService();
//             RaylibPhysicsService physicsService = new RaylibPhysicsService();
            RaylibScreenService screenService = new RaylibScreenService(W_SIZE, SCREEN_TITLE, FPS);
//             RaylibAudioService audioservice = new RaylibAudioService();
//             RaylibMouseService mouseService = new RaylibMouseService();

//             // Create the director
//             Director director = new Director();

//             // Create the cast
//             Cast cast = new Cast();

//             // Create the player
//             Ship ship = new Ship("./asteroid/assets/spaceship/spaceship_yellow.png", 70, 50, W_SIZE.Item1/2, W_SIZE.Item2/10 *9, 0, 0, 180);

//             // Create the Start Button
//             StartGameButton startGameButton = new StartGameButton("./asteroid/assets/others/start_button.png", 305, 113, W_SIZE.Item1/2, W_SIZE.Item2/2);

//             // Give actors to cast
//             cast.AddActor("ship", ship);
//             cast.AddActor("start_button", startGameButton);

//             // Create the script
//             Script script = new Script();

//             // Add all input actions
//             script.AddAction("input", new HandleQuitAction(1,screenService));
            
//             // Add actions that must be added to the script when the game starts:
//             Dictionary<string, List<genie.script.Action>> startGameActions = new Dictionary<string, List<genie.script.Action>>();
//             startGameActions["input"] = new List<genie.script.Action>();
//             startGameActions["update"] = new List<genie.script.Action>();
//             startGameActions["output"] = new List<genie.script.Action>();

//             startGameActions["input"].Add(new HandleShipMovementAction(2, keyboardService));
//             startGameActions["update"].Add(new SpawnAsteroidsAction(1, W_SIZE, (float)1.5));

//             script.AddAction("input", new HandleStartGameAction(2, mouseService, physicsService, startGameActions));

//             // Add all update actions
//             script.AddAction("update", new MoveActorsAction(1, physicsService));
//             script.AddAction("update", new HandleOffscreenAction(1, W_SIZE));

//             // Add all output actions
//             script.AddAction("output", new DrawActorsAction(1, screenService));
//             script.AddAction("output", new UpdateScreenAction(2, screenService));

//             // Yo, director, do your thing!
//             director.DirectScene(cast, script);
        }
    }
}
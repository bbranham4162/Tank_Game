using genie;
using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;

namespace Tanks.script
{

    class HandleTankWallCollision : genie.script.Action
    {
        private RaylibPhysicsService physicsService;

        // private RaylibKeyboardService keyboardService;
        private genie.cast.Actor? tank1;

        private genie.cast.Actor? tank2;

        
        // private List<int> keysOfInterest;
        // private int tankMovementVel;

        public HandleTankWallCollision(int priority, RaylibPhysicsService physicsService) : base(priority)
        {

            this.physicsService = physicsService;
            this.tank1 = null;
            this.tank2 = null;
            // this.keyboardService = keyboardService;
            // this.keysOfInterest = new List<int>();
            // this.keysOfInterest.Add(Keys.LEFT);
            // this.keysOfInterest.Add(Keys.RIGHT);
            // this.keysOfInterest.Add(Keys.DOWN);
            // this.keysOfInterest.Add(Keys.UP);

            // this.keysOfInterest.Add(Keys.W);
            // this.keysOfInterest.Add(Keys.A);
            // this.keysOfInterest.Add(Keys.S);
            // this.keysOfInterest.Add(Keys.D);
            



        }

        public override void execute(Cast cast, Script script, Clock clock, Callback callback)
        {
        // Get my tank actors so I can check their position

        this.tank1 = cast.GetFirstActor("Tank1");

        this.tank2 = cast.GetFirstActor("Tank2");

       

        


        

            // Only worry about collision if the ship actually exists
        if (this.tank1 != null) {
            foreach (Actor newWall in cast.GetActors("walls")) {
                if (this.physicsService.CheckCollision(this.tank1, newWall)) {

                    Console.WriteLine("I hit a wall!!");

                    
                    


            
        
        // Get Tank1 (T1) Tank 2 (T2) and newWall(WX) positions and compare them 

        // int positionT1X = (int) tank1.GetX();

        // int positionT1Y = (int) tank1.GetY();

        // int positionT2X = (int) tank2.GetX();

        // int positionT2Y = (int) tank2.GetY();

        // int positionWX = (int) newWall.GetX();

        // int positionWY = (int) newWall.GetY();

        // int DirectionTank = (int) tank1.GetRotation();

        // Dictionary<int, bool> keysState = keyboardService.GetKeysState(this.keysOfInterest);


        // if (this.tank2 != null) {

        // while ( ((positionT2X & positionT2Y) ) == (positionWX & positionWY) & keysState[Keys.A])
        // {
        //     this.tank2.SetRotation(0);
               
        // }

               
        }
        }
    }

        }
    }
}
// }
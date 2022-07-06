using Tanks.cast;
using genie;
using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;


namespace genie.script{


    


    class ShootingAction : genie.script.Action{

        private RaylibKeyboardService keyboardService;
        
        // private genie.cast.Actor? tank1;

        // private genie.cast.Actor? tank2;

        private int shootingVel;
        private List<int> keysOfInterest;

        public ShootingAction(int priority, RaylibKeyboardService keyboardService) : base(priority){

            this.keyboardService = keyboardService;
            
            this.shootingVel = 12;
            // this.barrelOffset = 
            this.keysOfInterest = new List<int>();
            this.keysOfInterest.Add(Keys.SPACE);
            this.keysOfInterest.Add(Keys.RETURN);

        }
        public override void execute(Cast cast, Script script, Clock clock, Callback callback) {
        
            Actor? tank1 = cast.GetFirstActor("Tank1");

            Actor? tank2 = cast.GetFirstActor("Tank2");

            
            
            


           
           // 1. Create if statement for both keys being pressed and released
            // 2. Create bullet when you presss the key and add it to the cast
            // 3. Remove bulletg

            Dictionary<int, bool> keysState = keyboardService.GetKeysState(this.keysOfInterest);

           if (tank2 != null) {
                
                // Get the keysState from the keyboardService
                
                
                // Change the velocity to the appropriate value and let MoveActorsAction handle the
                // actual movement
                if (keysState[Keys.SPACE]) {

                    Actor bullet2 = new Actor("Tanks/assets/Cannonball/cannon ball_1.png", 2, 5, tank2.GetX(), tank2.GetY(), tank2.GetVx() + (float) (shootingVel*Math.Cos(Math.PI * tank2.GetRotation()/180)), tank2.GetVy() +(float) (shootingVel*Math.Sin(Math.PI * tank2.GetRotation()/180)),  tank2.GetRotation(), 0);
                    bullet2.SetVx(this.shootingVel);
                    cast.AddActor("bullet2", bullet2);

                 }

           }
            else {
                Console.WriteLine("Ya dun messed up");
            }

            if (tank1 != null){
                
            
                if (keysState[Keys.RETURN]){
                    
                    Actor bullet1 = new Actor("Tanks/assets/Cannonball/cannon ball_1.png", 2, 5, tank1.GetX() , tank1.GetY(), tank1.GetVx() + (float) (shootingVel*Math.Cos(Math.PI * tank1.GetRotation()/180)), tank1.GetVy() + (float) (shootingVel*Math.Sin(Math.PI * tank1.GetRotation()/180)),  tank1.GetRotation(), 0);
                    bullet1.SetVx(this.shootingVel);
                    cast.AddActor("bullet1", bullet1);
                 }
            
            }
            else {
                Console.WriteLine("Ya dun messed up");
            }

        }
    }
}
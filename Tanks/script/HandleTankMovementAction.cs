using genie;
using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;

namespace Tanks.script {
    class HandleTankMovementAction : genie.script.Action {
        
        private RaylibKeyboardService keyboardService;
        private genie.cast.Actor? tank1;

        private genie.cast.Actor? tank2;
        
        private List<int> keysOfInterest;
        private int tankMovementVel;

        public HandleTankMovementAction(int priority, RaylibKeyboardService keyboardService) : base(priority) {
            this.keyboardService = keyboardService;
            this.tank1 = null;
            this.tank2 = null;
            this.tankMovementVel = 4;
            this.keysOfInterest = new List<int>();
            this.keysOfInterest.Add(Keys.LEFT);
            this.keysOfInterest.Add(Keys.RIGHT);
            this.keysOfInterest.Add(Keys.DOWN);
            this.keysOfInterest.Add(Keys.UP);

            this.keysOfInterest.Add(Keys.W);
            this.keysOfInterest.Add(Keys.A);
            this.keysOfInterest.Add(Keys.S);
            this.keysOfInterest.Add(Keys.D);
        }

        public override void execute(Cast cast, Script script, Clock clock, Callback callback) {
            
            // Grab the tank from the cast
            this.tank1 = cast.GetFirstActor("Tank1");
            this.tank2 = cast.GetFirstActor("Tank2");

            // Only move if tank is not null
            if (this.tank1 != null) {
                
                // Get the keysState from the keyboardService
                Dictionary<int, bool> keysState = keyboardService.GetKeysState(this.keysOfInterest);
                
                // Change the velocity to the appropriate value and let MoveActorsAction handle the
                // actual movement
                if (keysState[Keys.LEFT]) {
                    this.tank1.SetVx(-this.tankMovementVel);
                }
                if (keysState[Keys.RIGHT]) {
                    this.tank1.SetVx(this.tankMovementVel);
                }
                if (keysState[Keys.DOWN]) {
                    this.tank1.SetVy(this.tankMovementVel);
                }
                if (keysState[Keys.UP]) {
                    this.tank1.SetVy(-this.tankMovementVel);
                }

                // If none of the LEFT or RIGHT keys are down, x-velocity is 0
                if (!(keysState[Keys.LEFT] || keysState[Keys.RIGHT])) {
                    this.tank1.SetVx(0);
                }

                // If none of the UP or DOWN keys are down, y-velocity is 0
                if (!(keysState[Keys.UP] || keysState[Keys.DOWN])) {
                    this.tank1.SetVy(0);



                
                }


            
            }

             if (this.tank2 != null) {
                
                // Get the keysState from the keyboardService
                Dictionary<int, bool> keysState = keyboardService.GetKeysState(this.keysOfInterest);
                
                // Change the velocity to the appropriate value and let MoveActorsAction handle the
                // actual movement
                if (keysState[Keys.A]) {
                    this.tank2.SetVx(-this.tankMovementVel);
                    this.tank2.SetRotation(-this.tankMovementVel);
                }
                if (keysState[Keys.D]) {
                    this.tank2.SetVx(this.tankMovementVel);
                    this.tank2.SetRotation(this.tankMovementVel);
                }
                if (keysState[Keys.S]) {
                    this.tank2.SetVy(this.tankMovementVel);
                    this.tank2.SetRotation(this.tankMovementVel);
                }
                if (keysState[Keys.W]) {
                    this.tank2.SetVy(-this.tankMovementVel);
                    this.tank2.SetRotation(-this.tankMovementVel);
                }

                // If none of the LEFT or RIGHT keys are down, x-velocity is 0
                if (!(keysState[Keys.A] || keysState[Keys.D])) {
                    this.tank2.SetVx(0);
                }

                // If none of the UP or DOWN keys are down, y-velocity is 0
                if (!(keysState[Keys.W] || keysState[Keys.S])) {
                    this.tank2.SetVy(0);



                
                }


            
            }
        }
    }
}
using genie;
using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;

namespace Tanks.script {
    class HandleTankMovementAction : genie.script.Action {
        
        private RaylibKeyboardService keyboardService;
        private genie.cast.Actor? Tank;
        private List<int> keysOfInterest;
        private int tankMovementVel;

        public HandleTankMovementAction(int priority, RaylibKeyboardService keyboardService) : base(priority) {
            this.keyboardService = keyboardService;
            this.Tank = null;
            this.tankMovementVel = 4;
            this.keysOfInterest = new List<int>();
            this.keysOfInterest.Add(Keys.LEFT);
            this.keysOfInterest.Add(Keys.RIGHT);
            this.keysOfInterest.Add(Keys.DOWN);
            this.keysOfInterest.Add(Keys.UP);
           
        }

        public override void execute(Cast cast, Script script, Clock clock, Callback callback) {
            
            // Grab the tank from the cast
            this.Tank = cast.GetFirstActor("Tank1");

            // Only move if tank is not null
            if (this.Tank != null) {
                
                // Get the keysState from the keyboardService
                Dictionary<int, bool> keysState = keyboardService.GetKeysState(this.keysOfInterest);
                
                // Change the velocity to the appropriate value and let MoveActorsAction handle the
                // actual movement
                if (keysState[Keys.LEFT]) {
                    this.Tank.SetVx(-this.tankMovementVel);
                }
                if (keysState[Keys.RIGHT]) {
                    this.Tank.SetVx(this.tankMovementVel);
                }
                if (keysState[Keys.DOWN]) {
                    this.Tank.SetVy(this.tankMovementVel);
                }
                if (keysState[Keys.UP]) {
                    this.Tank.SetVy(-this.tankMovementVel);
                }

                // If none of the LEFT or RIGHT keys are down, x-velocity is 0
                if (!(keysState[Keys.LEFT] || keysState[Keys.RIGHT])) {
                    this.Tank.SetVx(0);
                }

                // If none of the UP or DOWN keys are down, y-velocity is 0
                if (!(keysState[Keys.UP] || keysState[Keys.DOWN])) {
                    this.Tank.SetVy(0);
                }
            }
        }
    }
}
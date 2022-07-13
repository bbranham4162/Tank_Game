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
                
                // Rotates the tank (changes tank rotation)
                if (keysState[Keys.LEFT]) {
                    this.tank1.SetRotationVel(-5);
                    float direction = this.tank1.GetRotation();
                }
                else if (keysState[Keys.RIGHT]) {
                    this.tank1.SetRotationVel(5);
                    float direction = this.tank1.GetRotation();
                }
                else{
                    this.tank1.SetRotationVel(0);
                }

                // Changes rotation to 0-360. Used to simplify computations
                if (tank1.GetRotation() == 360) {
                    tank1.SetRotation(0);
                }
                if (tank1.GetRotation() == -5) {
                    tank1.SetRotation(355);
                }

                // Moves tank forwards and backwards
                if (keysState[Keys.DOWN]) {
                    double radians = (tank1.GetRotation() * Math.PI) / 180;
                    this.tank1.SetVx(-(float)(tankMovementVel * Math.Sin(radians)));
                    this.tank1.SetVy((float)(tankMovementVel * Math.Cos(radians)));
                }
                if (keysState[Keys.UP]) {
                    double radians = (tank1.GetRotation() * Math.PI) / 180;
                    this.tank1.SetVy(-(float)(tankMovementVel * Math.Cos(radians)));
                    this.tank1.SetVx((float)(tankMovementVel * Math.Sin(radians)));
                }

                // If none of the UP or DOWN keys are down, y-velocity is 0
                if (!(keysState[Keys.UP] || keysState[Keys.DOWN])) {
                    this.tank1.SetVy(0);
                    this.tank1.SetVx(0);
                }
            }

             if (this.tank2 != null) {
                
                // Get the keysState from the keyboardService
                Dictionary<int, bool> keysState = keyboardService.GetKeysState(this.keysOfInterest);
                
                // Change the velocity to the appropriate value and let MoveActorsAction handle the
                // actual movement
                // Rotates the tank (changes tank rotation)
                if (keysState[Keys.A]) {
                    this.tank2.SetRotationVel(-5);
                    float direction = this.tank2.GetRotation();
                }
                else if (keysState[Keys.D]) {
                    this.tank2.SetRotationVel(5);
                    float direction = this.tank2.GetRotation();
                }
                else{
                    this.tank2.SetRotationVel(0);
                }

                // Changes rotation to 0-360. Used to simplify computations
                if (tank2.GetRotation() == 360) {
                    tank2.SetRotation(0);
                }
                if (tank2.GetRotation() == -5) {
                    tank2.SetRotation(355);
                }

                // Moves tank forwards and backwards
                if (keysState[Keys.S]) {
                    double radians = (tank2.GetRotation() * Math.PI) / 180;
                    this.tank2.SetVx(-(float)(tankMovementVel * Math.Sin(radians)));
                    this.tank2.SetVy((float)(tankMovementVel * Math.Cos(radians)));
                }
                if (keysState[Keys.W]) {
                    double radians = (tank2.GetRotation() * Math.PI) / 180;
                    this.tank2.SetVy(-(float)(tankMovementVel * Math.Cos(radians)));
                    this.tank2.SetVx((float)(tankMovementVel * Math.Sin(radians)));
                }

                // If none of the UP or DOWN keys are down, y-velocity is 0
                if (!(keysState[Keys.W] || keysState[Keys.S])) {
                    this.tank2.SetVy(0);
                    this.tank2.SetVx(0);
                }
            }
        }
    }
}
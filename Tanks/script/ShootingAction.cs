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
        private DateTime lastBulletSpawn;
        private float attackInterval;
        private (float vx, float vy) bulletVel;

        public ShootingAction(int priority, RaylibKeyboardService keyboardService) : base(priority){

            this.keyboardService = keyboardService;
            
            this.shootingVel = 10;
            // this.barrelOffset = 
            this.keysOfInterest = new List<int>();
            this.keysOfInterest.Add(Keys.SPACE);
            this.keysOfInterest.Add(Keys.RETURN);

            this.lastBulletSpawn = DateTime.Now;
            this.attackInterval = 1;
        }


        private void SpawnBullet(Clock clock, Cast cast, Actor tank) {

            TimeSpan timeSinceLastShot = DateTime.Now - this.lastBulletSpawn;
            if (timeSinceLastShot.TotalSeconds >= this.attackInterval) {
                // Bullet's starting position should be right on top of the ship
                float bulletX = tank.GetX();
                float bulletY = tank.GetY() - (tank.GetHeight()/2);

                // Create the bullet and put it in the cast
                float velocity = tank.GetRotation();
                bulletVel.vx = velocity;
                bulletVel.vy = velocity;

                Actor bullet = new Actor("Tanks/assets/Cannonball/cannon ball_1.png", 20, 20, bulletX, bulletY, bulletVel.vx, bulletVel.vy);
                cast.AddActor("bullets", bullet);

                // Reset lastBulletSpawn to Now
                this.lastBulletSpawn = DateTime.Now;
            }
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

                    this.SpawnBullet(clock, cast, tank2);
                }
            }

            else {
                Console.WriteLine("Ya dun messed up");
            }

            if (tank1 != null){
            
                if (keysState[Keys.RETURN]) {

                    this.SpawnBullet(clock, cast, tank1);
                }
            }

            else {
                Console.WriteLine("Ya dun messed up");
            }
        }
    }
}
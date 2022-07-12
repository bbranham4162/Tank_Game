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

        // Creates the bullet
        private void SpawnBullet(Clock clock, Cast cast, Actor tank) {

            TimeSpan timeSinceLastShot = DateTime.Now - this.lastBulletSpawn;
            if (timeSinceLastShot.TotalSeconds >= this.attackInterval) {
                // Bullet's starting position should be right on top of the ship
                float bulletX = tank.GetX();
                float bulletY = tank.GetY() - (tank.GetHeight()/2);

                //xVelocity^2 + yVelocity^2 = velocity^2

                // Create the bullet and put it in the cast
                float velocity = 10;

                // sets up x and y velocities for the next step
                double xVelocity = 0;
                double yVelocity = 0;

                

                //Chooses one of the four quadrants to fire the bullet into
                if(tank.GetRotation() == 0) {
                    xVelocity = 0;
                    yVelocity = -velocity;
                }
                else if (tank.GetRotation() > 0 && tank.GetRotation() < 90) {
                    // top right
                    xVelocity = velocity;
                    yVelocity = -velocity;
                }
                else if(tank.GetRotation() == 90) {
                    xVelocity = velocity;
                    yVelocity = 0;
                }
                else if (tank.GetRotation() > 90 && tank.GetRotation() < 180) {
                    //bottom right
                    xVelocity = velocity;
                    yVelocity = velocity;
                }
                else if(tank.GetRotation() == 180) {
                    xVelocity = 0;
                    yVelocity = velocity;
                }
                else if (tank.GetRotation() > 180 && tank.GetRotation() < 270) {
                    //bottom left
                    xVelocity = -velocity;
                    yVelocity = velocity;
                }
                else if(tank.GetRotation() == 270) {
                    xVelocity = -velocity;
                    yVelocity = 0;
                }
                else {
                    //top left
                    xVelocity = -velocity;
                    yVelocity = -velocity;
                }

                double radians = (tank.GetRotation() * Math.PI) / 180;
                double slopeDec = Math.Tan(radians);
                xVelocity = slopeDec * 10;
                yVelocity = (1 - slopeDec) * 10;

                bulletVel.vx = (float)xVelocity;
                bulletVel.vy = -(float)yVelocity;

                Actor bullet = new Actor("Tanks/assets/Cannonball/cannon ball_1.png", 20, 20, bulletX, bulletY, bulletVel.vx, bulletVel.vy);
                cast.AddActor("bullets", bullet);

                // Reset lastBulletSpawn to Now
                this.lastBulletSpawn = DateTime.Now;
            }
        }

        // Checks if the user is pressing a fire button, if they are, SpawnBullet() is called
        public override void execute(Cast cast, Script script, Clock clock, Callback callback) {
        
            Actor? tank1 = cast.GetFirstActor("Tank1");
            Actor? tank2 = cast.GetFirstActor("Tank2");

            Dictionary<int, bool> keysState = keyboardService.GetKeysState(this.keysOfInterest);

            if (tank2 != null) {
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
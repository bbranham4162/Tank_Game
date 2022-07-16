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
        private DateTime lastBulletSpawn1;
        private DateTime lastBulletSpawn2;
        private float attackInterval;
        private (float vx, float vy) bulletVel;

        private RaylibAudioService audioService;

        public ShootingAction(int priority, RaylibKeyboardService keyboardService, RaylibAudioService audioService) : base(priority){

            this.keyboardService = keyboardService;

            this.audioService = audioService;
            
            this.shootingVel = 6;
            // this.barrelOffset = 
            this.keysOfInterest = new List<int>();
            this.keysOfInterest.Add(Keys.SPACE);
            this.keysOfInterest.Add(Keys.RETURN);

            this.lastBulletSpawn1 = DateTime.Now;
            this.lastBulletSpawn2 = DateTime.Now;
            this.attackInterval = 1;
        }

        // Creates the bullet
        private void SpawnBullet(Clock clock, Cast cast, Actor tank, String tankNum) {

            if(tankNum == "1") {
                TimeSpan timeSinceLastShot = DateTime.Now - this.lastBulletSpawn1;
                if (timeSinceLastShot.TotalSeconds >= this.attackInterval) {
                    // Bullet's starting position should be right on top of the ship
                    float bulletX = tank.GetX();
                    float bulletY = tank.GetY();

                    double radians = (tank.GetRotation() * Math.PI) / 180;
                    this.bulletVel = (((float)(this.shootingVel * Math.Sin(radians))) , (-(float)(this.shootingVel * Math.Cos(radians))));

                    Bullet bullet = new Bullet("Tanks/assets/Cannonball/cannon ball_1.png", 20, 20, bulletX, bulletY, bulletVel.vx, bulletVel.vy);
                    cast.AddActor("bullets", bullet);

                    // Reset lastBulletSpawn to Now
                    this.lastBulletSpawn1 = DateTime.Now;
                    this.audioService.PlaySound("Tanks/assets/Sound/mixkit-hard-pop-click-2364.wav", 1);
                }
            }
            else {
                TimeSpan timeSinceLastShot = DateTime.Now - this.lastBulletSpawn2;
                if (timeSinceLastShot.TotalSeconds >= this.attackInterval) {

                    

                    // Bullet's starting position should be right on top of the ship
                    float bulletX = tank.GetX();
                    float bulletY = tank.GetY();

                    double radians = (tank.GetRotation() * Math.PI) / 180;
                    this.bulletVel = (((float)(this.shootingVel * Math.Sin(radians))) , (-(float)(this.shootingVel * Math.Cos(radians))));

                    Bullet bullet = new Bullet("Tanks/assets/Cannonball/cannon ball_1.png", 20, 20, bulletX, bulletY, bulletVel.vx, bulletVel.vy);
                    cast.AddActor("bullets", bullet);

                    // Reset lastBulletSpawn to Now
                    this.lastBulletSpawn2 = DateTime.Now;
                    this.audioService.PlaySound("Tanks/assets/Sound/mixkit-hard-pop-click-2364.wav", 1);
                } 
            }
        }

        // Checks if the user is pressing a fire button, if they are, SpawnBullet() is called
        public override void execute(Cast cast, Script script, Clock clock, Callback callback) {
        
            Actor? tank1 = cast.GetFirstActor("Tank1");
            Actor? tank2 = cast.GetFirstActor("Tank2");

            Dictionary<int, bool> keysState = keyboardService.GetKeysState(this.keysOfInterest);

            if (tank2 != null) {
                if (keysState[Keys.SPACE]) {
                    this.SpawnBullet(clock, cast, tank2, "2");
                }
            }

            if (tank1 != null){
            
                if (keysState[Keys.RETURN]) {
                    this.SpawnBullet(clock, cast, tank1, "1");
                    
                }
            }
        }
    }
}
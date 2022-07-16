using genie;
using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;

using Tanks.cast;


namespace Tanks.script
{

    class HandleBulletWallCollision : genie.script.Action 
    {
        private RaylibPhysicsService physicsService;
        private RaylibAudioService audioService;

        public HandleBulletWallCollision(int priority, RaylibPhysicsService physicsService, RaylibAudioService audioService) : base(priority)
        {
            this.physicsService = physicsService;
            this.audioService = audioService;
        }  

        public override void execute(Cast cast, Script script, Clock clock, Callback callback)
        {
            foreach (Actor Wall in cast.GetActors("walls"))
            {
                foreach ( Bullet Bullet in cast.GetActors("bullets"))
                {
                    if (this.physicsService.CheckCollision(Bullet, Wall))
                    {
                        // increase bullet bounce count by 1
                        Bullet.SetBounces(Bullet.GetBounces() + 1);

                        if (physicsService.IsAbove(Wall, Bullet ) || physicsService.IsBelow(Wall, Bullet))
                        {
                            Bullet.SetVy(-Bullet.GetVy());
                        }
                        if (physicsService.IsRightOf(Wall, Bullet ) || physicsService.IsLeftOf(Wall,Bullet))
                        {
                            Bullet.SetVx(-Bullet.GetVx());
                        }

                        // if bullet bounces >= 4, delete the bullet
                        if (Bullet.GetBounces() >= 6)
                        {
                            cast.RemoveActor("bullets", Bullet);
                        }

                        Random rnd = new Random();
                        int random = rnd.Next(1,6);

                        if(random == 1) {
                            this.audioService.PlaySound("Tanks/assets/Sound/sfx-pop.wav", 1);
                        }
                        else if(random == 2) {
                            this.audioService.PlaySound("Tanks/assets/Sound/sfx-pop3.wav", 1);
                        }
                        else if(random == 3) {
                            this.audioService.PlaySound("Tanks/assets/Sound/sfx-pop4.wav", 1);
                        }
                        else if(random == 4) {
                            this.audioService.PlaySound("Tanks/assets/Sound/sfx-pop5.wav", 1);
                        }
                        else {
                            this.audioService.PlaySound("Tanks/assets/Sound/sfx-pop6.wav", 1);
                        }
                    }
                }
            }
        }
    }
}

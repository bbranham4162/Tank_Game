using genie;
using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;

using Tanks.cast;

namespace Tanks.script {
    class HandleTankBulletCollisionAction : genie.script.Action {

        
        // Member Variables
        RaylibPhysicsService physicsService;
        // RaylibAudioService audioService;
        private genie.cast.Actor? tank1;

        private genie.cast.Actor? tank2;

        private RaylibAudioService audioService;


        // Constructor
        public HandleTankBulletCollisionAction(int priority, RaylibPhysicsService physicsService, RaylibAudioService audioService ) : base(priority) {
            this.tank1 = null;
            this.physicsService = physicsService;
            this.audioService = audioService;
            
            this.tank2 = null; 
        }

        public override void execute(Cast cast, Script script, Clock clock, Callback callback) {
            // Grab the tank from the cast
            this.tank1 = cast.GetFirstActor("Tank1");
            this.tank2 = cast.GetFirstActor("Tank2");

             // List for Tank explosion animation pictures

            List<string> pictures = new List<string>( );


            // pictures we're adding for the explosion animation

            for (int i = 0; i <2; i++)
            {

            
            pictures.Add($"Tanks/assets/Animations/test{i}.png");
           
            }

            // Have a for loop that iterates each item in that list 

            // Only worry about collision if the ship actually exists
            if (this.tank2 != null) {
                foreach (Actor bullet in cast.GetActors("bullets")) {
                    if ((this.physicsService.CheckCollision(this.tank2, bullet) & physicsService.IsAbove(tank2, bullet)) |(this.physicsService.CheckCollision(this.tank2, bullet) & physicsService.IsLeftOf(tank2, bullet)) |(this.physicsService.CheckCollision(this.tank2, bullet) & physicsService.IsRightOf(tank2, bullet)) |(this.physicsService.CheckCollision(this.tank2, bullet) & physicsService.IsBelow(tank2, bullet)) ) {
                        
                        Console.WriteLine("I hit a Tank!!!!!");

                        cast.RemoveActor("Tank2", tank2);
                        cast.RemoveActor("bullets", bullet);

                        AnimatedActor animatedExplosionT2 = new AnimatedActor(pictures, tank2.GetWidth(), tank2.GetHeight(), 5, 60, true, tank2.GetX(), tank2.GetY(), 0, 0, 0, 0, false );
                        
                        animatedExplosionT2.SetAnimating(true);
                        cast.AddActor("explode2", animatedExplosionT2);
                        
                        
                        
                        this.audioService.PlaySound("Tanks/assets/Sound/Victory.mp3", 1);
                        
                    }
                }
            }

             if (this.tank1 != null) {
                foreach (Actor bullet in cast.GetActors("bullets")) {
                    if ((this.physicsService.CheckCollision(this.tank1, bullet) & physicsService.IsAbove(tank1, bullet)) |(this.physicsService.CheckCollision(this.tank1, bullet) & physicsService.IsLeftOf(tank1, bullet)) |(this.physicsService.CheckCollision(this.tank1, bullet) & physicsService.IsRightOf(tank1, bullet)) |(this.physicsService.CheckCollision(this.tank1, bullet) & physicsService.IsBelow(tank1, bullet))) {
                        
                        Console.WriteLine("I hit a Tank!!!!!");

                        cast.RemoveActor("Tank1", tank1);
                        cast.RemoveActor("bullets", bullet);

                        

                        AnimatedActor animatedExplosionT1 = new AnimatedActor(pictures, tank1.GetWidth(), tank1.GetHeight(), 5, 60, true, tank1.GetX(), tank1.GetY(), 0, 0, 0, 0, false );
                        
                        animatedExplosionT1.SetAnimating(true);
                        
                        cast.AddActor("explode1",animatedExplosionT1);
                        // this.audioService.PlaySound("asteroid/assets/sound/explosion-01.wav", (float) 0.1);
                        
                    }
                }
             }
        }
    }
}
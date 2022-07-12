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


        // Constructor
        public HandleTankBulletCollisionAction(int priority, RaylibPhysicsService physicsService) : base(priority) {
            this.tank1 = null;
            this.physicsService = physicsService;
            
            this.tank2 = null; 
        }

        public override void execute(Cast cast, Script script, Clock clock, Callback callback) {
            // Grab the tank from the cast
            this.tank1 = cast.GetFirstActor("Tank1");
            this.tank2 = cast.GetFirstActor("Tank2");
            

            // Only worry about collision if the ship actually exists
            if (this.tank2 != null) {
                foreach (Actor bullet in cast.GetActors("bullets")) {
                    if ((this.physicsService.CheckCollision(this.tank2, bullet) & physicsService.IsAbove(tank2, bullet)) |(this.physicsService.CheckCollision(this.tank2, bullet) & physicsService.IsLeftOf(tank2, bullet)) |(this.physicsService.CheckCollision(this.tank2, bullet) & physicsService.IsRightOf(tank2, bullet)) |(this.physicsService.CheckCollision(this.tank2, bullet) & physicsService.IsBelow(tank2, bullet)) ) {
                        
                        Console.WriteLine("I hit a Tank!!!!!");

                        cast.RemoveActor("Tank2", tank2);
                        cast.RemoveActor("bullets", bullet);
                        // this.audioService.PlaySound("asteroid/assets/sound/explosion-01.wav", (float) 0.1);
                        
                    }
                }
            }

             if (this.tank1 != null) {
                foreach (Actor bullet in cast.GetActors("bullets")) {
                    if ((this.physicsService.CheckCollision(this.tank1, bullet) & physicsService.IsAbove(tank1, bullet)) |(this.physicsService.CheckCollision(this.tank1, bullet) & physicsService.IsLeftOf(tank1, bullet)) |(this.physicsService.CheckCollision(this.tank1, bullet) & physicsService.IsRightOf(tank1, bullet)) |(this.physicsService.CheckCollision(this.tank1, bullet) & physicsService.IsBelow(tank1, bullet))) {
                        
                        Console.WriteLine("I hit a Tank!!!!!");

                        cast.RemoveActor("Tank1", tank1);
                        cast.RemoveActor("bullets", bullet);
                        // this.audioService.PlaySound("asteroid/assets/sound/explosion-01.wav", (float) 0.1);
                        
                    }
                }
             }

            // if (this.tank != null) {
            //     foreach (Actor bullet in cast.GetActors("bullet2")) {
            //         if (this.physicsService.CheckCollision(this.tank, bullet)) {
            //             cast.RemoveActor("tank1", this.tank);
            //             cast.RemoveActor("bullet2", bullet);
            //             this.audioService.PlaySound("asteroid/assets/sound/explosion-01.wav", (float) 0.1);
            //             this.tank = null;
            //             break;
                    }
                }
            }
//         }
//     }
// }
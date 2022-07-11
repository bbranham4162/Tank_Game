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
            // Grab the ship from the cast
            this.tank1 = cast.GetFirstActor("tank1");
            this.tank2 = cast.GetFirstActor("tank2");

            // Only worry about collision if the ship actually exists
            if (this.tank2 != null) {
                foreach (Actor bullet1 in cast.GetActors("bullet1")) {
                    if (this.physicsService.CheckCollision(this.tank2, bullet1)) {
                        cast.RemoveActor("tank2", tank2);
                        cast.RemoveActor("bullet1", bullet1);
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
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
        RaylibAudioService audioService;
        private genie.cast.Actor? tank;


        // Constructor
        public HandleTankBulletCollisionAction(int priority, RaylibPhysicsService physicsService, RaylibAudioService audioService) : base(priority) {
            this.tank = null;
            this.physicsService = physicsService;
            this.audioService = audioService;
        }

        public override void execute(Cast cast, Script script, Clock clock, Callback callback) {
            // Grab the ship from the cast
            this.tank = cast.GetFirstActor("tank1");
            this.tank = cast.GetFirstActor("tank2");

            // Only worry about collision if the ship actually exists
            if (this.tank != null) {
                foreach (Actor bullet in cast.GetActors("bullet1")) {
                    if (this.physicsService.CheckCollision(this.tank, bullet)) {
                        cast.RemoveActor("tank2", this.tank);
                        cast.RemoveActor("bullet1", bullet);
                        this.audioService.PlaySound("asteroid/assets/sound/explosion-01.wav", (float) 0.1);
                        this.tank = null;
                        break;
                    }
                }
            }

            if (this.tank != null) {
                foreach (Actor bullet in cast.GetActors("bullet2")) {
                    if (this.physicsService.CheckCollision(this.tank, bullet)) {
                        cast.RemoveActor("tank1", this.tank);
                        cast.RemoveActor("bullet2", bullet);
                        this.audioService.PlaySound("asteroid/assets/sound/explosion-01.wav", (float) 0.1);
                        this.tank = null;
                        break;
                    }
                }
            }
        }
    }
}
using genie;
using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;

namespace Tanks.script {
    class MoveActorsAction : genie.script.Action {

        private RaylibPhysicsService physicsService;

        public MoveActorsAction(int priority, RaylibPhysicsService physicsService) : base(priority) {
            this.physicsService = physicsService;
        }

        public override void execute(Cast cast, Script script, Clock clock, Callback callback) {
            // Move and rotate all actors in the cast according to their velocities
            List<Actor> allActors = cast.GetAllActors();
            this.physicsService.MoveActors(allActors);
            this.physicsService.RotateActors(allActors);
        }
    }
}
using genie;
using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;

using Tanks.cast;

namespace Tanks.script {
    class DrawActorsAction : genie.script.Action {
        
        private RaylibScreenService screenService;

        public DrawActorsAction(int priority, RaylibScreenService screenService) : base(priority) {
            this.screenService = screenService;
        }

        public override void execute(Cast cast, Script script, Clock clock, Callback callback) {

            // First, fill the screen with white every frame, get ready to draw more stuff
            this.screenService.FillScreen(Color.WHITE);

            // Actor tank1 = cast.GetFirstActor("Tank1");
            

            


            // Draw all actors as rectangles for now.
            // foreach (Actor actor in cast.GetAllActors()) {

                
                
            //     Color actorColor = actor == tank1 ? Color.GREEN : Color.BLUE; 
                
                
            //     // Color actorColor = actor is Tank tank1 ? Color.GREEN : Color.BLACK;
            //     // this.screenService.DrawRectangle(actor.GetPosition(), actor.GetWidth(), actor.GetHeight(), actorColor, 5);
            // }
            
            this.screenService.DrawActors(cast.GetAllActors());
        }
    }
}
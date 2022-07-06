using genie;
using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;

namespace asteroid.script
{
    class HandleOffscreenAction : genie.script.Action
    {
        private (int x, int y) windowSize;
        private Actor? ship;

        public HandleOffscreenAction(int priority, (int,int) windowSize) : base(priority)
        {
            this.windowSize = windowSize;
            this.ship = null;
        }

        public override void execute(Cast cast, Script script, Clock clock, Callback callback)
        {
            this.ship = cast.GetFirstActor("ship");

            // Make sure the ship stays within the game window
            if (this.ship != null) {
                if (this.ship.GetTopRight().Item1 >= this.windowSize.x) {
                    this.ship.SetX((int)(this.windowSize.x - this.ship.GetWidth()/2));
                }
                if (this.ship.GetTopLeft().Item1 <= 0)
                {
                    this.ship.SetX((int)(this.ship.GetWidth() / 2));
                }
                if (this.ship.GetBottomLeft().Item2 >= this.windowSize.y) {
                    this.ship.SetY(this.windowSize.y - (int)(this.ship.GetHeight()/2));
                }
                if (this.ship.GetTopLeft().Item2 <= 0) {
                    this.ship.SetY((int) (this.ship.GetHeight()/2));
                }
            }
        }
    }
}
using genie;
using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;

namespace Tanks.script
{
    class HandleOffscreenAction : genie.script.Action
    {
        private (int x, int y) windowSize;
        private Actor? ship;

        public HandleOffscreenAction(int priority, (int,int) windowSize) : base(priority)
        {
            this.windowSize = windowSize;
        }

        public override void execute(Cast cast, Script script, Clock clock, Callback callback)
        {
            Actor? tank1 = cast.GetFirstActor("Tank1");
            Actor? tank2 = cast.GetFirstActor("Tank2");


            // Make sure the tank1 stays within the game window
            if (tank1 != null) {
                if (tank1.GetTopRight().Item1 >= this.windowSize.x) {
                    tank1.SetX((int)(this.windowSize.x - tank1.GetWidth()/2));
                }
                if (tank1.GetTopLeft().Item1 <= 0)
                {
                    tank1.SetX((int)(tank1.GetWidth() / 2));
                }
                if (tank1.GetBottomLeft().Item2 >= this.windowSize.y) {
                    tank1.SetY(this.windowSize.y - (int)(tank1.GetHeight()/2));
                }
                if (tank1.GetTopLeft().Item2 <= 0) {
                    tank1.SetY((int) (tank1.GetHeight()/2));
                }
            }

            // Make sure the tank2 stays within the game window
            if (tank2 != null) {
                if (tank2.GetTopRight().Item1 >= this.windowSize.x) {
                    tank2.SetX((int)(this.windowSize.x - tank2.GetWidth()/2));
                }
                if (tank2.GetTopLeft().Item1 <= 0)
                {
                    tank2.SetX((int)(tank2.GetWidth() / 2));
                }
                if (tank2.GetBottomLeft().Item2 >= this.windowSize.y) {
                    tank2.SetY(this.windowSize.y - (int)(tank2.GetHeight()/2));
                }
                if (tank2.GetTopLeft().Item2 <= 0) {
                    tank2.SetY((int) (tank2.GetHeight()/2));
                }
            }
        }
    }
}
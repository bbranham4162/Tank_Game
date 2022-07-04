using genie;
using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;

using System.Numerics;

/***************************************************************
* This action is jokingly called a "pregnant" action since it
* adds more actions to the script when it's triggerred by the startGameButton.
****************************************************************/
class HandleStartGameAction : genie.script.Action {

    private RaylibMouseService mouseService;
    private RaylibPhysicsService physicsService;
    private Dictionary<string, List<genie.script.Action>> actions;

    public HandleStartGameAction(int priority, RaylibMouseService mouseService, RaylibPhysicsService physicsService, Dictionary<string, List<genie.script.Action>> actions) :
    base(priority)
    {
        this.mouseService = mouseService;
        this.physicsService = physicsService;
        this.actions = actions;
    }

    public override void execute(Cast cast, Script script, Clock clock, Callback callback)
    {
        Actor? startGameButton = cast.GetFirstActor("start_button");
        Vector2 mousePosition = this.mouseService.GetCurrentCoordinates();

        // When the startGameButton is clicked, add a bunch of actions to the script
        // as determined by the whoever calls this class.  
        if (startGameButton != null
            && this.mouseService.IsButtonDown(Mouse.LEFT)
            && this.physicsService.CheckCollisionPoint(startGameButton, (mousePosition.X, mousePosition.Y))) {
                
                // Remove the startGame Button
                cast.RemoveActor("start_button", startGameButton);
                script.RemoveAction("input", this);
                
                // Add input actions
                foreach (genie.script.Action action in this.actions["input"]) {
                    script.AddAction("input", action);
                }
                
                // Add update actions
                foreach (genie.script.Action action in this.actions["update"])
                {
                    script.AddAction("update", action);
                }

                // Add output actions
                foreach (genie.script.Action action in this.actions["output"])
                {
                    script.AddAction("output", action);
                }
        }

    }
}
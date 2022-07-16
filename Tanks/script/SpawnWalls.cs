using genie;
using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;

using Tanks.cast;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tanks.script
{

    class SpawnWalls : genie.script.Action
    {
        private class Wall
        {
            public float x {get; set;}
            public float y {get; set;}
            public float width {get; set;}
            public float height {get; set;}
        }
        
        private int wallNumber = 3;

        private int wallXPosition = 300;

        private int wallYPosition = 50;

        private int wallsWidth = 10;
        private int wallsHeight = 300;

        private string wallPath;
    

        public SpawnWalls(int priority, string wallPath) : base(priority){

            this.wallNumber = 4;
            this.wallXPosition = 100;
            this.wallPath = wallPath;
        }

        public override void execute(Cast cast, Script script, Clock clock, Callback callback)
        {
            // Number of wall addresses
            int wallAddressNumber = 0;
                
            List<Wall> walls = new List<Wall>();

            // Read the json string from the file
            string jsonString = File.ReadAllText(wallPath);
            Console.WriteLine(jsonString);

            // Read the json into the walls list:
            walls = JsonSerializer.Deserialize<List<Wall>>(jsonString);

            // Once everything is put in the list, you can traverse it
            foreach (Wall wall in walls) {
                // Console.WriteLine($"{wall.x}, {wall.y}, {wall.width}, {wall.height}");
                
                // comment the following out if you want this code to run
                Actor newWall = new Actor("Tanks/assets/Walls/Stone Wall.png", (int) wall.width, (int) wall.height, wall.x, wall.y);
                cast.AddActor("walls", newWall);
            }

            // The action removes itself from the script
            // (comment the following out if you want this code to run)
            script.RemoveAction("input", this);

        }
    }   
}

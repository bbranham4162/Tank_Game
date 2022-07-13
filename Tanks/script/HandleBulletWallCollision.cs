using genie;
using genie.cast;
using genie.script;
using genie.services;
using genie.services.raylib;

using Tanks.cast;


namespace Tanks.script
{

    class HandleBulletWallCollision : genie.script.Action 
    {

        private RaylibPhysicsService physicsService;

      

    

      public HandleBulletWallCollision(int priority, RaylibPhysicsService physicsService) : base(priority)
      {
        this.physicsService = physicsService;
        
     

      }  


        public override void execute(Cast cast, Script script, Clock clock, Callback callback) {

        
       
        

        
        foreach (Actor Wall in cast.GetActors("walls")) {

            foreach ( Actor Bullet in cast.GetActors("bullets")) {

                if (this.physicsService.CheckCollision(Bullet, Wall))
                {
                    if (physicsService.IsAbove(Wall, Bullet ) || physicsService.IsBelow(Wall, Bullet))

                    {
                        Bullet.SetVy(-Bullet.GetVy());

                    }

                    
                    if (physicsService.IsRightOf(Wall, Bullet ) || physicsService.IsLeftOf(Wall,Bullet))

                    {
                        Bullet.SetVx(-Bullet.GetVx());

                    }

                    
                }

            }
        }
        }
        
        }
    }

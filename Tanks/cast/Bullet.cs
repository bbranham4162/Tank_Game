using genie.cast;
using genie.services;

namespace Tanks.cast{

    class Bullet : Actor
    {

        private int bounces;

        public Bullet(string path, int width, int height,
                    float x = 0, float y = 0,
                    float vx = 0, float vy = 0,
                    float rotation = 0, float rotationVel = 0,
                    int bounces = 0) : 
        base(path, width, height, x, y, vx, vy, rotation, rotationVel)
        {
            this.bounces = bounces;
        }   

        public int GetBounces()
        {
            return this.bounces;
        }

        public void SetBounces(int bounces)
        {
            this.bounces = bounces;
        }
    }
}
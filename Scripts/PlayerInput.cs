
namespace ProyectoSDL2.Engine.Scripts
{
    public class PlayerInput
    {
        private Transform transform;
        private int speed = 5;

        private float x = 200;
        

        public PlayerInput(Transform playertransform)
        {
            transform = playertransform;
        }

        public void Update() 
        {
            if (Engine.KeyPress(Engine.KEY_A)) 
            { 
                MoveLeft();
            }

            if (Engine.KeyPress(Engine.KEY_D))
            {
                MoveRight();
            }
        }

        private void MoveLeft()
        {
            transform.Translate(-speed,0);

            if(transform.PosX < 0)
            {
                transform.Translate(-transform.PosX, 0);
            }
        }

        private void MoveRight() 
        { 
        
           transform.Translate(speed,0);
           
            if(transform.PosX > 640 - 124)
            {
                transform.Translate((640 - 124) - transform.PosX, 0);
            }

        }
    }
}

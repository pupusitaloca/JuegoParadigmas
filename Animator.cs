using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KpopJumpPRY.Engine.Scripts;

namespace KpopJumpPRY.Engine.Scripts
{
  
    
        public class Animator
        {
            private string name;
            private List<Image> frames;
            private int currentFrameIndex = 0;
            private float speed = 0.5f;
            private float currentAnimationTime;
            private bool isLoopEnabled;

            public int FramesCount => frames.Count;
            public int CurrentFrameIndex => currentFrameIndex;
            public Image CurrentFrame => frames[currentFrameIndex];

            public Animator(string name, List<Image> frames, float speed, bool isLoopEnabled)
            {
                this.name = name;
                this.frames = frames;
                this.speed = speed;
                this.isLoopEnabled = isLoopEnabled;
            }

            public void Update()
            {
                currentAnimationTime += Program.DeltaTime;
                if (currentAnimationTime >= speed)
                {
                    currentFrameIndex++;
                    currentAnimationTime = 0;

                    if (currentFrameIndex >= frames.Count)
                    {
                        if (isLoopEnabled)
                        {
                            currentFrameIndex = 0;
                        }
                        else
                        {
                            currentFrameIndex = frames.Count - 1;
                        }
                    }
                }
            }
        }
    }


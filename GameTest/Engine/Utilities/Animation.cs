using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NextEngine
{
    class Animation
    {
        private Texture2D[] frames;
        private int currentFrameIndex;
        private float frameDuration;
        private float counter;
        private int numFrames;
        private bool isPlaying;
        private bool loop;

        public Texture2D CurrentTexture;

        public Animation(string texturePrefixKey, int numFrames, float fps)
        {
            this.numFrames = numFrames;

            frames = new Texture2D[numFrames];

            for (int i = 0; i < numFrames; i++)
            {
                frames[i] = TextureManager.GetTexure(texturePrefixKey + i);
            }

            currentFrameIndex = 0;
            CurrentTexture = frames[currentFrameIndex];

            if(fps <= 0)
            {
                fps = 1;
            }

            frameDuration = 1 / fps;

            isPlaying = true;
            loop = true;
        }

        public void Update()
        {
            if(isPlaying)
            {
                counter += Utils.DeltaTime;

                if(counter >= frameDuration)
                {
                    currentFrameIndex++;

                    if(currentFrameIndex >= numFrames)
                    {
                        if(loop)
                        {
                            currentFrameIndex = 0;
                        }
                        else
                        {
                            currentFrameIndex = numFrames - 1;
                            isPlaying = false;
                        }
                    }

                    counter = 0;
                    CurrentTexture = frames[currentFrameIndex];
                }
            }
        }

        public bool IsPlaying()
        {
            return isPlaying;
        }

        public void SetLoop(bool value)
        {
            loop = value;
        }

        public bool GetLoop()
        {
            return loop;
        }

        public void Play()
        {
            isPlaying = true;
        }

        public void Stop()
        {
            isPlaying = false;
            currentFrameIndex = 0;
            CurrentTexture = frames[currentFrameIndex];
        }

        public void Pause()
        {
            isPlaying = false;
        }
    }
}

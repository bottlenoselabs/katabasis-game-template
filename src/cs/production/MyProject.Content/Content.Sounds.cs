using bottlenoselabs.Katabasis;

namespace MyProject;

public static partial class Content
{
    public static class Sounds
    {
        public static SoundEffect Greeting;
        public static SoundEffect ConstructionComplete;

        internal static void LoadSounds()
        {
            Greeting = SoundEffect.FromFile("assets/sounds/greeting_6_alex.wav");
            ConstructionComplete = SoundEffect.FromFile("assets/sounds/completion_9_karen.wav");
        }
    }   
}

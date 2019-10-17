using System;

namespace Inheritance
{
    public static class ActorExtensions
    {
        public static string Speak(this Actor actor, string says)
        {
            return $"{actor.GetType().Name} : {says}";
        }
    }
}

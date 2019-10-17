using System;

namespace Inheritance
{
    public static class ActorExtensions
    {
        public static string Speak(this Actor actor)
        {
            switch (actor)
            {
                case Raj raj when raj.WomenArePresent:
                    return $"{actor.GetType().Name} : ";
                case Raj raj when !raj.WomenArePresent:
                    return $"{actor.GetType().Name} : {raj.Says}";
                case Penny penny:
                    return $"{actor.GetType().Name} : {penny.Says}";
                case Sheldon sheldon:
                    return $"{actor.GetType().Name} : {sheldon.Says}";
                default:
                    return "";
            }
        }
    }
}

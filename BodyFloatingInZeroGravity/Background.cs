using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using System.Linq;

namespace StorybrewScripts
{
    public class Background : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            //disable background
            var bg = GetLayer("").CreateSprite(Beatmap.BackgroundPath, OsbOrigin.Centre);
            bg.Fade(0, 0, 0, 0);
        }
    }
}

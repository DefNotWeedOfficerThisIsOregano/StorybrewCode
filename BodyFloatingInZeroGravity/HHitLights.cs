using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public class HHitLights : StoryboardObjectGenerator
    {
        internal StoryboardLayer layer;
        internal static int startTime = 187235, endTime = 198529;
        internal OsuHitObject[] hitobjects;
        internal Color4[] combocolors;
        
        public override void Generate()
        {
		    layer = GetLayer("HHitLights");
            hitobjects = Beatmap.HitObjects.ToArray();
            combocolors = Beatmap.ComboColors.ToArray();

            HitLight(187588);
            HitLight(187765);
            HitLight(187853);
            HitLight(188029);
            HitLight(188117);
        }
        internal void HitLight(int startTime)
        {
            
            foreach (var hitobject in hitobjects)
            {
                if ((hitobject.StartTime == startTime || hitobject.EndTime == startTime) || (hitobject.StartTime <= startTime && hitobject.EndTime >= startTime)){
                    OsbSprite highlight = layer.CreateSprite("sb/1px.png", OsbOrigin.Centre);
                    highlight.Fade(startTime, startTime + 500, 0.3, 0);
                    highlight.Move(startTime, hitobject.PositionAtTime(startTime));
                    highlight.ScaleVec(startTime, startTime + 500, 5, 1200, 0, 1200);
                    highlight.Color(startTime, hitobject.Color);
                    highlight.Rotate(startTime, Random(-20, 20)/1000d);

                    OsbSprite highlightCenter = layer.CreateSprite("sb/p2.png", OsbOrigin.Centre);
                    highlightCenter.Fade(startTime, startTime + 500, 0.3, 0);
                    highlightCenter.Move(startTime, hitobject.PositionAtTime(startTime));
                    highlightCenter.Scale(OsbEasing.OutQuart, startTime, startTime + 500, 0.9, 0.6);
                    highlightCenter.Color(startTime, hitobject.Color);
                }
            }
            
        }
    }
}

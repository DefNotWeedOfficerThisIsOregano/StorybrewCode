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
    public class J : StoryboardObjectGenerator
    {
        internal StoryboardLayer layer;
        internal Vector2 CENTER = new Vector2(320, 240);
        internal FontGenerator numFont;
        internal int startTime = 221117, endTime = 243706;
        public override void Generate()
        {
		    layer = GetLayer("J");
            numFont = LoadFont("sb/hitcircles/nums", new FontDescription()
            {
                FontPath = "num.ttf",
                FontSize = 52,
                FontStyle = System.Drawing.FontStyle.Regular,
                Padding = Vector2.One, 
                TrimTransparency = false,
                Color = Color4.White
            });
            




            bool sw = true;
            int stack = 0;
            Vector2 lastPosition = new Vector2(-100, -100);
            OsuHitObject[] hitobjects = Beatmap.HitObjects.ToArray();
            Log(hitobjects.Length);
            for (int p = hitobjects.Length - 1; p > 0; p -= 1)
            {
                
                if (hitobjects[p].StartTime >= startTime && hitobjects[p].StartTime <= endTime)
                {
                    if (hitobjects[p].PositionAtTime(hitobjects[p].StartTime) == lastPosition) stack += 1;
                    else stack = 0;

                    
                    
                    DrawCircle(hitobjects[p].PositionAtTime(hitobjects[p].StartTime), hitobjects[p].StartTime, sw, hitobjects[p].ComboIndex, stack, hitobjects[p].Color);
                    
                    if (hitobjects[p].NewCombo) sw = !sw;
                    lastPosition = hitobjects[p].PositionAtTime(hitobjects[p].StartTime);
                }
                
            }
        }


        internal void DrawCircle(Vector2 pos, double startTime, bool newCombo, int playNumber, int stackCount, Color4 combocolor)
        {
            int which = newCombo ? 1:2;
            pos = new Vector2(pos.X + -3*stackCount, pos.Y + -5*stackCount);

            double preempt = startTime - 750 * (Beatmap.ApproachRate - 5) / 5d, 
            fadeIn = startTime - 500 * (Beatmap.ApproachRate - 5) / 5d, 
            fadeOut = startTime + 500 * (Beatmap.ApproachRate - 5) / 5d,
            CircleSize = GetCircleSize(Beatmap.CircleSize);
            
            //hit highlight
            OsbSprite highlight = layer.CreateSprite("sb/p2.png", OsbOrigin.Centre, pos);
            highlight.Fade(startTime, fadeOut >= endTime ? endTime : fadeOut, 0.7, 0);
            highlight.Scale(OsbEasing.OutQuart, startTime, fadeOut, 0.5, 0.6);
            highlight.Color(startTime, combocolor);

            /*
            //hitcircle
            OsbSprite circle = layer.CreateSprite("sb/hitcircles/playcircle" + which.ToString() + ".png", OsbOrigin.Centre, pos);
            circle.Scale(preempt, preempt, 1, CircleSize/1000d);
            circle.Fade( preempt, fadeIn, 0, 1);
            circle.Fade(startTime, startTime, 1, 0);
            
            //number
            OsbSprite num = layer.CreateSprite(numFont.GetTexture(playNumber.ToString()).Path, OsbOrigin.Centre, pos);
            num.Fade(startTime, startTime, 1, 0);
            num.Scale(preempt, preempt, 1, 24/52d);
            num.Fade(preempt, fadeIn, 0, 1);
            
            //approach circle
            circle = layer.CreateSprite("sb/hitcircles/approachCircle.png", OsbOrigin.Centre, pos);
            circle.Scale( preempt, startTime, CircleSize/200d, CircleSize/1000d);
            circle.Fade( preempt, fadeIn, 0, 1);

            //hit fade
            circle = layer.CreateSprite("sb/hitcircles/hitcircle_fade.png", OsbOrigin.Centre, pos);
            circle.Fade(startTime, fadeOut >= endTime ? endTime : fadeOut, 1, 0);
            circle.Scale(startTime, CircleSize/1000d);
            */


            

        }
        internal double GetApproachRate(double ar)
        {
            switch (Beatmap.Name)
            {
                case "Extraterrestial":
                {
                    return 509;
                }
                case "mrforse's Insane":
                {
                    return 570;
                }
                default:
return 0;

            }
        }
        internal double GetCircleSize(double size)
        {
            return (4 * (54.4 - 4.48 * size));
        }
    }
}

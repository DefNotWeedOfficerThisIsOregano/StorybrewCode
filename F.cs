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
    public class F : StoryboardObjectGenerator
    {
        internal StoryboardLayer layer;
        internal Vector2 CENTER = new Vector2(320, 240);
        internal int startTime = 153353, endTime = 175941;
        public override void Generate()
        {
            layer = GetLayer("F");
		    OsbSprite bg = layer.CreateSprite("sb/spinbg.jpg", OsbOrigin.Centre, CENTER);
            bg.Fade(startTime, startTime, 0, 0.7);
            bg.Fade(endTime, endTime, 0.7, 0);
            bg.Rotate(startTime, endTime, 0.1*Math.PI, -0.1*Math.PI);
            bg.Scale(startTime, 0.65);
            

            OsbSprite v = layer.CreateSprite("sb/v2.png", OsbOrigin.Centre, CENTER);
            v.Fade(startTime, startTime, 0, 1);
            v.Fade(endTime, endTime, 1, 0);
            v.Color(startTime, Color4.DarkBlue);
            for (int s = 0; s < 80; s++)
            {
                OsbSprite particle = layer.CreateSprite("sb/p.png", OsbOrigin.Centre, new Vector2(Random(-157, 797), Random(0, 480)));
                particle.Fade(startTime, startTime, 0, 0.14);
                particle.Fade(endTime, endTime, 0.14, 0);
                particle.Scale(startTime, Random(10, 20)/2.5d);
                particle.Color(startTime, new Color4((byte)(Random(125, 255)), (byte)(Random(125, 255)), (byte)(Random(125, 255)), 100));
                particle.Move(startTime, endTime, particle.PositionAt(startTime), new Vector2(particle.PositionAt(startTime).X + Random(-30, 30), particle.PositionAt(startTime).Y + Random(-30, 30)));

            }
            for (int s = 0; s < 240; s++)
            {
                OsbSprite particle = layer.CreateSprite("sb/p.png", OsbOrigin.Centre, new Vector2(Random(-107, 747), Random(0, 480)));
                particle.Fade(startTime, startTime, 0, 1);
                particle.Fade(endTime, endTime, 1, 0);
                particle.Scale(startTime, 0.1 + Random(-5, 5)/100d);
                particle.Color(startTime, new Color4((byte)(Random(125, 255)), (byte)(Random(125, 255)), (byte)(Random(125, 255)), 100));
                particle.Move(startTime, endTime, particle.PositionAt(startTime), new Vector2(particle.PositionAt(startTime).X + Random(-30, 30), particle.PositionAt(startTime).Y + Random(-30, 30)));

            }

            OsbSprite p2 = layer.CreateSprite("sb/p2.png", OsbOrigin.Centre);
            p2.Fade(startTime, startTime, 0, 0.3);
            p2.Fade(endTime, endTime, 0.3, 0);
            p2.Move(startTime, endTime, new Vector2(320, 200), new Vector2(320, 280));
            p2.Color(startTime, Color4.DarkMagenta);
            p2.Scale(startTime, 1.9);
            OsbSprite astro = layer.CreateSprite("sb/astronaut.png", OsbOrigin.Centre);
            astro.Fade(startTime, startTime, 0, 1);
            astro.Fade(endTime, endTime, 1, 0);
            astro.Move(startTime, endTime, new Vector2(320, 200), new Vector2(320, 280));
            astro.Scale(startTime, 0.4);
            astro.StartLoopGroup(startTime, 9);
                astro.Rotate(OsbEasing.InOutSine, 0, (endTime - startTime) / 18d, 0.77*Math.PI, 0.79*Math.PI);
                astro.Rotate(OsbEasing.InOutSine, (endTime - startTime) / 18d, (endTime - startTime) / 8d, 0.79*Math.PI, 0.77*Math.PI);
            astro.EndGroup();
            
            
            v = layer.CreateSprite("sb/v2.png", OsbOrigin.Centre, CENTER);
            v.Fade(startTime, startTime, 0, 1);
            v.Fade(endTime, endTime, 1, 0);
            v.Color(startTime, Color4.DarkBlue);
            
            
        }
    }
}

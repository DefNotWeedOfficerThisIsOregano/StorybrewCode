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
    public class K : StoryboardObjectGenerator
    {
        internal StoryboardLayer layer;
        internal Vector2 CENTER = new Vector2(320, 240);
        internal int startTime = 243706, endTime = 255000;
        public override void Generate()
        {
		    layer = GetLayer("K");
            OsbSprite bg = layer.CreateSprite("sb/1px.png", OsbOrigin.Centre, CENTER);
            bg.Fade(startTime, startTime, 0, 1);
            bg.Fade(endTime, endTime, 1, 0);
            bg.ScaleVec(startTime, startTime, 1, 1, 854, 480);
            bg.Color(startTime, new Color4(5, 5, 10, 100));
		    Vector2 pos;
            Color4[] starPalette = {Color4.LightSkyBlue, Color4.IndianRed, Color4.White, Color4.LightYellow};
            for (int p = 0; p < 180; p++)
            {
                pos = new Vector2(320 + Random(-684/2, 684/2), 240 + Random(-250, 250));
                OsbSprite star = layer.CreateSprite("sb/p.png", OsbOrigin.Centre);
                star.Fade(startTime, startTime, 0, Random(10, 100)/100d);
                star.Fade(endTime, endTime, 1, 0);
                star.Scale(startTime, Random(10, 50)/500d);
                star.Color(startTime, starPalette[Random(0, starPalette.Length - 1)]);
                star.Move(startTime, endTime, pos, new Vector2(pos.X, pos.Y - Random(1, 2)));
            }
    
            OsbSprite lighting = layer.CreateSprite("sb/lighting.png", OsbOrigin.Centre, new Vector2(75, 175));
            lighting.Rotate(startTime, endTime, 0.1, 0.2);
            lighting.Fade(startTime, startTime, 0, 1);
            lighting.Fade(endTime, endTime, 1, 0);
            

            OsbSprite planet = layer.CreateSprite("sb/planet.png", OsbOrigin.Centre, new Vector2(500, 150));
            planet.Scale(startTime, endTime, 0.4, 0.35);
            
            planet.Fade(startTime, startTime, 0, 1);
            planet.Fade(endTime, endTime, 1, 0);
            planet.Rotate(startTime, endTime, 0, 0.05*Math.PI);
            
           

            planet = layer.CreateSprite("sb/planet2.png", OsbOrigin.Centre, new Vector2(75, 175));
            planet.Scale(startTime, endTime, 0.6, 0.5);
            planet.Fade(startTime, startTime, 0, 1);
            planet.Fade(endTime, endTime, 1, 0);
            planet.Rotate(startTime, endTime, 0.08*Math.PI, 0);

            
            OsbSprite ship = layer.CreateSprite("sb/explosion.png", OsbOrigin.Centre, CENTER);
            ship.Scale( startTime, endTime, 0.98, 0.9);
            

            OsbSprite astro = layer.CreateSprite("sb/astronaut2.png", OsbOrigin.Centre, CENTER);
            astro.Scale(startTime, endTime, 0.4, 0.38);
            astro.Rotate(startTime, endTime, 0.1, 0.01);
            OsbSprite window = layer.CreateSprite("sb/window.png", OsbOrigin.Centre, CENTER);
            window.Scale(startTime, endTime, 0.8,  0.74);
            window.Fade(startTime, startTime, 0, 1);
            
            window.Fade(endTime, endTime, 1, 0);
            
        }
    }
}

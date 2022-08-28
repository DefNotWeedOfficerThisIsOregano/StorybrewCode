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
    public class A : StoryboardObjectGenerator
    {
        internal int startTime = 40412, endTime = 63000;
        internal Vector2 CENTER = new Vector2(320, 240);
        internal StoryboardLayer layer;
        public override void Generate()
        {
            layer = GetLayer("A");
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
            lighting.Rotate(startTime, endTime, 0, 0.1);
            lighting.Fade(startTime, startTime, 0, 1);
            lighting.Fade(endTime, endTime, 1, 0);
            lighting.Scale(51706, 51706, 1, 0.8);
            lighting.Move(51706, new Vector2(125, 105));


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
            


            OsbSprite ship = layer.CreateSprite("sb/spaceship.png", OsbOrigin.Centre, CENTER);
            ship.Scale(startTime, 51706, 0.3, 0.25);
            
            ship.Fade(startTime, startTime, 0, 1);
            ship.Fade(51706, 51706, 1, 0);
            ship.Rotate(startTime, 51706, .2*Math.PI, .18*Math.PI);
            
            float colorValue;
            double end;
            Color4[] palette = {Color4.Gray, Color4.DimGray, Color4.DarkGray, Color4.GhostWhite};
            for (int p = 0; p < 60; p++)
            {
                end = 51706 + Random(1000, 6000);
                colorValue = Random(0, 120);
                Vector2 endPos = new Vector2(Random(-107, 747), Random(-50, 530));
                OsbSprite debris = layer.CreateSprite("sb/p.png", OsbOrigin.Centre);
                debris.Scale(51706, Random(10, 100)/100d);
                debris.Move(51706, end, CENTER, endPos);
                debris.Color(51706, 51706, Color4.White, palette[Random(0, palette.Length)]);
                debris.Fade(end - Random(0, 1000), end, 1, 0);
            }


            ship = layer.CreateSprite("sb/explosion.png", OsbOrigin.Centre, CENTER);
            ship.Scale(OsbEasing.Out, 51706, 52412, 0.7, 0.9);
            ship.Scale(52412, endTime, 0.9, 0.75);

            OsbSprite hue = layer.CreateSprite("sb/1px.png", OsbOrigin.Centre, CENTER);
            hue.Color(51706, Color4.OrangeRed);
            hue.Fade(51706, endTime, 0.04, 0.1);
            hue.ScaleVec(51706, 51706, 1, 1, 854, 480);
            OsbSprite window = layer.CreateSprite("sb/window.png", OsbOrigin.Centre, CENTER);
            window.Scale(startTime, 51706, 0.8,  0.77);
            window.Fade(startTime, startTime, 0, 1);
            window.Color(51706, endTime, Color4.White, Color4.Goldenrod);
            window.Fade(endTime, endTime, 1, 0);
            
        }
        
    }
}

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
    public class Start : StoryboardObjectGenerator
    {
        internal StoryboardLayer layer;
        internal Vector2 CENTER = new Vector2(320, 240);
        internal int startTime = 882, endTime = 6529;
        public override void Generate()
        {
            
            layer = GetLayer("Start");


            DrawStar();
            



            
        }
        internal void DrawStar()
        {
            OsbSprite starEnter = layer.CreateSprite("sb/p2.png", OsbOrigin.Centre);
            starEnter.Scale(startTime, 0.05);
            starEnter.MoveY(OsbEasing.InOutQuad, startTime, 4059, 500, 200);
            starEnter.StartLoopGroup(startTime - 397.125, 2);   //end in center
                starEnter.MoveX(OsbEasing.InOutSine, 0, 794.25, 300, 340);
                starEnter.MoveX(OsbEasing.InOutSine, 794.25, 794.25*2, 340, 300);
            starEnter.EndGroup();
            starEnter.MoveX(OsbEasing.InOutSine, 3706, 4235, 300, 320.5);
            starEnter.MoveX(OsbEasing.InOutSine, 4235, 4412, 320.5, 320);
            starEnter.Fade(startTime, startTime, 0, 1);
            starEnter.Fade(OsbEasing.InOutSine, 4059, 4765, 1, 0);
            starEnter.Scale(OsbEasing.InOutSine, 3706, 4765, 0.05, 0.1);
		    
            OsbSprite star = layer.CreateSprite("sb/star.png", OsbOrigin.Centre, new Vector2(320, 200));
            star.Fade(4059, 6176, 0, 1);
            star.Fade(6176, endTime, 1, 0);
            star.Additive(3706, endTime);
            star.Scale(3706, 6176, 0.4, 1.2);
            star.Color(4059, 5823, Color4.GhostWhite, new Color4(Color4.LightSkyBlue.R, Color4.LightSkyBlue.G, Color4.LightSkyBlue.B + 10, 100));
            star.Color(5823, endTime, new Color4(Color4.LightSkyBlue.R, Color4.LightSkyBlue.G, Color4.LightSkyBlue.B + 20, 100), Color4.GhostWhite);


            int start, rand;
            for (int p = 0; p < 180;  p++)
            {
                start = Random(4059, 6176);
                rand = Random(200, 700);
                OsbSprite spew = layer.CreateSprite("sb/p.png", OsbOrigin.Centre);
                spew.Fade(start, start+rand > 6176 ? 6176 : start + rand, 
                star.OpacityAt(start), star.OpacityAt(start+rand > 6176 ? 6176 : start + rand));
                spew.Move(start, start+rand > 6176 ? 6176 + 400: start + rand, new Vector2(320, 200), new Vector2(Random(255, 385), Random(135, 275)));
                spew.Scale(start, start+rand > 6176 ? 6176 + 400 : start + rand, Random(200, 300)/1000d, 0);
                if (start < 5823)
                {
                    spew.Color(start, 5823, star.ColorAt(start), Color4.LightSkyBlue);
                    spew.Color(5823, endTime, Color4.LightSkyBlue, Color4.GhostWhite);
                }
                if (start >= 5823)
                {
                    spew.Color(start, endTime, star.ColorAt(start), Color4.GhostWhite);
                }
            }
            
            star = layer.CreateSprite("sb/star.png", OsbOrigin.Centre, new Vector2(320, 200));
            star.Fade(4059, 6176, 0, 0.7);
            star.Rotate(OsbEasing.InOutSine, 4059, endTime, -0.02*Math.PI, 0.02*Math.PI);
            star.Fade(6176, endTime, 0.9, 0);
            star.Color(4059, 5823, Color4.GhostWhite, Color4.LightSkyBlue);
            star.Color(5823, endTime, Color4.LightSkyBlue, Color4.GhostWhite);
            

            double time = startTime, fade;
            for (int p = 0; p < 240; p++)
            {
                Vector2 startPos = new Vector2(Random(-107, 747), Random(-20, 500));
                star = layer.CreateSprite("sb/p.png", OsbOrigin.Centre, startPos);
                star.Scale(time, Random(1, 10)/100d);
                fade = Random(10, 35)/100d;
                time = startTime;
                while (time < 4412)
                {
                    if (starEnter.PositionAt(time).Y <= startPos.Y)
                    {
                        star.Fade(time, time + 150 + Random(0, 400), 0, fade);
                        time = 4412;
                    }
                    time+=1;
                }
                if (startPos.Y < starEnter.PositionAt(4412).Y)
                {
                    star.Fade(4059, 4412 + 150 + Random(0, 400), 0, fade);
                }
                star.Fade(6176, endTime, fade, 0);
            }
        }
        
        
    }
}

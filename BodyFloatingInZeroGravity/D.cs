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
    public class D : StoryboardObjectGenerator
    {
        internal StoryboardLayer layer;
        internal Vector2 CENTER = new Vector2(320, 240);
        internal int startTime = 96882, endTime = 119470;
        public override void Generate()
        {
		    layer = GetLayer("D");
            /*OsbSprite bg = layer.CreateSprite("sb/spinbg.jpg", OsbOrigin.Centre, CENTER);
            bg.Fade(startTime, startTime, 0, 1);
            bg.Fade(endTime, endTime, 1, 0);
            bg.Rotate(startTime, endTime, 0.03*Math.PI, -0.05*Math.PI);
            bg.Scale(startTime, 0.5);
            */
            OsbSprite bg = layer.CreateSprite("sb/1px.png", OsbOrigin.Centre, CENTER);
            bg.Fade(startTime, startTime, 0, 1);
            bg.Fade(endTime, endTime, 1, 0);
            bg.ScaleVec(startTime, startTime, 1, 1, 854, 480);
            bg.Color(startTime, new Color4(5, 5, 8, 100));


            for (int s = 0; s < 300; s++)
            {
                OsbSprite a = layer.CreateSprite("sb/p.png", OsbOrigin.Centre, new Vector2(Random(-107, 747), Random(-20, 500)));
                a.Color(startTime, startTime, Color4.White, new Color4((byte)(115 + Random(0, 45)), ((byte)(105 + Random(0, 145))), (byte)255, (byte)100));
                a.Scale(startTime, Random(10, 50)/100d);
                a.Move(startTime, endTime, a.PositionAt(startTime), new Vector2(a.PositionAt(startTime).X, a.PositionAt(startTime).Y - Random(15, 20)));
            }
            
            for(int i = 0; i < 9; i++)
            {
                OsbSprite star = layer.CreateSprite("sb/p108.png", OsbOrigin.BottomCentre, CENTER);
                star.Fade(startTime, startTime, 0, 0.2);
                star.Fade(endTime, endTime, 0.2, 0);
                star.Scale(startTime, 3.1);
                star.Color(startTime, Color4.LightSkyBlue);
                star.Rotate(startTime, endTime, 2*i/9d * Math.PI, -7*Math.PI + 2*i/9d * Math.PI);
            }
            for(int i = 0; i < 12; i++)
            {
                OsbSprite star = layer.CreateSprite("sb/p162.png", OsbOrigin.BottomCentre, CENTER);
                star.Fade(startTime, startTime, 0, 0.3);
                star.Fade(endTime, endTime, 0.3, 0);
                star.Scale(startTime, 3);
                star.Color(startTime, Color4.LightBlue);
                star.Rotate(startTime, endTime, 2*i/12d * Math.PI, 9*Math.PI + 2*i/12d * Math.PI);
            }
            


            OsbSprite cutout = layer.CreateSprite("sb/cutout.png", OsbOrigin.Centre, CENTER);
            cutout.Fade(startTime, startTime, 0, 1);
            cutout.Fade(endTime, endTime, 1, 0);
            cutout.Scale(startTime, 0.5);
            
            cutout.StartLoopGroup(startTime, 8);
                cutout.Rotate(OsbEasing.InOutSine, 0, (endTime - startTime)/16d, 0.01, -0.01);
                cutout.Rotate(OsbEasing.InOutSine, (endTime - startTime)/16d, (endTime - startTime)/8d, -0.01, 0.01);
            cutout.EndGroup();
            cutout.StartLoopGroup(startTime, 16);
                cutout.MoveX(OsbEasing.InOutSine, 0, (endTime - startTime)/32d, 321, 319);
                cutout.MoveX(OsbEasing.InOutSine, (endTime - startTime)/32d, (endTime - startTime)/16d, 319, 321);
            cutout.EndGroup();
            cutout.StartLoopGroup(startTime, 12);
                cutout.MoveY(OsbEasing.InOutSine, 0, (endTime - startTime)/24d, 239, 241);
                cutout.MoveY(OsbEasing.InOutSine, (endTime - startTime)/24d, (endTime - startTime)/12d,241,239);
            cutout.EndGroup();

            OsbSprite vignette = layer.CreateSprite("sb/v2.png", OsbOrigin.Centre, CENTER);
            vignette.Fade(startTime, startTime, 0, 0.8);
            vignette.Fade(endTime, endTime, 0.8, 0);
            vignette.Color(startTime, Color4.LightSkyBlue);
                
        }
    }
}

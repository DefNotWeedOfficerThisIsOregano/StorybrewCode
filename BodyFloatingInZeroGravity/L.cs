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
    public class L : StoryboardObjectGenerator
    {
        internal StoryboardLayer layer;
        internal int startTime = 255000, endTime = 266294;
        internal Vector2 CENTER = new Vector2(320, 240);
        /// <summary>
        /// trog
        /// </summary>
        public override void Generate()
        {
		    layer = GetLayer("L");
            OsbSprite bg = layer.CreateSprite("sb/dystopiaBLUR.jpg", OsbOrigin.Centre, CENTER);
            bg.Fade(startTime, endTime, 0.8, 0.2);
            bg.FlipH(startTime);
            bg.Scale(startTime, endTime, 0.6, 0.55);

            bg = layer.CreateSprite("sb/dystopia.jpg", OsbOrigin.Centre, CENTER);
            bg.FlipH(startTime);
            bg.Fade(startTime, endTime,0.2, 0.8);
            bg.Scale(startTime, endTime, 0.55, 0.6);
            
            
            

            double loopC;
            for (int p = 0; p < 360; p++)
            {
                loopC = Random(6, 10);
                OsbSprite particle = layer.CreateSprite("sb/p.png", OsbOrigin.Centre, new Vector2(Random(-157, 797), Random(-50, 530)));
                particle.StartLoopGroup(startTime - Random(0, (endTime - startTime)/loopC), (int)loopC + 1);
                    particle.Move(0, (endTime - startTime)/loopC, particle.PositionAt(startTime), CENTER);
                particle.EndGroup();
                particle.Scale(startTime, Random(1, 3)/10d);
                particle.Fade(startTime, startTime, 0, 1);
                particle.Fade(endTime, endTime, 1, 0);
                particle.Color(startTime, new Color4((byte)Random(200, 255), (byte)Random(200, 255), (byte)Random(200, 255), 100));
            }


            OsbSprite circ = layer.CreateSprite("sb/p2.png", OsbOrigin.Centre, CENTER);
            circ.Scale(startTime, 264882, 0.4, 0.6);
            circ.Fade(startTime, startTime, 0, 1);
            circ.Fade(endTime, endTime, 1, 0);
            circ.Color(startTime, Color4.AliceBlue);
            circ.Scale(OsbEasing.OutBack, 264882, endTime, 0.6, 1.3);
            for (int p = 1; p < 9; p++)
            {
                OsbSprite a = layer.CreateSprite("sb/p108.png", OsbOrigin.BottomCentre, CENTER);
                a.Scale(startTime, 260647, 0.5, 0.6);
                a.Fade(startTime, startTime, 0, 1);
                a.Fade(endTime, endTime, 1, 0);
                a.Rotate(startTime, endTime, (p+1)*0.785, (p+1)*0.785 + 5);
                a.Scale(OsbEasing.OutQuart, 260647, 262059, 0.6, 0.7);
                a.Scale(OsbEasing.OutQuart, 263470, 264882, 0.7, 1);
                a.Scale(OsbEasing.OutBack, 264882, endTime, 1, 2);
            }

            OsbSprite overlay = layer.CreateSprite("sb/grunge.jpg", OsbOrigin.Centre, CENTER);
            overlay.Fade(startTime, endTime, 0.3, 0.1);

            overlay.Scale(startTime, 0.71);
        }
    }
}

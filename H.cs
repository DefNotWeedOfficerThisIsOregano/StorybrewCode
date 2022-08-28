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
    public class H : StoryboardObjectGenerator
    {
        internal StoryboardLayer layer;
        internal Vector2 CENTER = new Vector2(320, 240);
        internal static int startTime = 187235, endTime = 198529;
        public override void Generate()
        {
		    layer = GetLayer("H");
            OsbSprite bg = layer.CreateSprite("sb/horizon.jpg", OsbOrigin.Centre, CENTER);
            bg.FlipV(startTime);
            bg.Fade(startTime, startTime, 0, 1);
            bg.Fade(endTime, endTime,1, 0);
            bg.Scale(startTime, endTime, 0.46, 0.5);
            bg.Additive(startTime, endTime);
            
            double[] timeArray = new double[300], time2Array = new double[300];
            //float x, y;
            float[] xArray = new float[300], yArray = new float[300], x2Array = new float[300], y2Array = new float[300];
            //double time, time2;
            OsbSprite particle;
            for (int p = 0; p < 240; p++)
            {
                
                timeArray[p] = Random(1500, 5000);
                time2Array[p] = startTime - Random(1200, 4000);
                xArray[p] = Random(-197, 837);
                yArray[p] = Random(-75, -40);
                x2Array[p] = xArray[p]  - Random(900, 1000)/10f;
                y2Array[p] = yArray[p] + Random(5550, 6000)/10f;
                
                
                
                particle = layer.CreateSprite("sb/p2.png", OsbOrigin.Centre);
                
                particle.Fade(startTime, startTime, 0, 1);
                particle.Fade(endTime, endTime, 1, 0);
                particle.Additive(startTime, endTime);
                particle.Color(startTime, Color4.White);
                particle.Color(197117, 197823, Color4.White, new Color4(255, 125, 80, 100));
                particle.Scale(startTime, 0.05 + Random(1, 10)/1000d);
                particle.StartLoopGroup(time2Array[p], (int)((endTime - startTime)/timeArray[p]) + 2);
                    particle.Move(0, timeArray[p], new Vector2(xArray[p] , yArray[p]), new Vector2(x2Array[p],  y2Array[p]));
                particle.EndGroup();

                particle = layer.CreateSprite("sb/p2.png", OsbOrigin.Centre);
                
                particle.Fade(startTime, startTime, 0, 1);
                particle.Fade(endTime, endTime, 1, 0);
                //particle.Additive(startTime, endTime);
                particle.Color(startTime, Color4.Black);
                
                particle.Scale(startTime, 0.01 + Random(1, 10)/1000d);
                particle.StartLoopGroup(time2Array[p], (int)((endTime - startTime)/timeArray[p]) + 2);
                    particle.Move(0, timeArray[p], new Vector2(xArray[p], yArray[p]), new Vector2(x2Array[p], y2Array[p]));
                particle.EndGroup();
            }

            OsbSprite vignette = layer.CreateSprite("sb/v2.png", OsbOrigin.Centre, CENTER);
            vignette.Scale(startTime, 480.0f/1080.0f);
            vignette.Fade(startTime, startTime, 0, 0.9);
            vignette.Fade(endTime, endTime, 0.9, 0);
            vignette.Color(startTime, Color4.Black);

            vignette = layer.CreateSprite("sb/v2.png", OsbOrigin.Centre, CENTER);
            vignette.Scale(startTime, 480.0f/1080.0f);
            vignette.Fade(startTime, startTime, 0, 0.9);
            vignette.Fade(endTime, endTime, 0.9, 0);
            vignette.Color(startTime, Color4.Black);
        }
    }
}

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
    public class B : StoryboardObjectGenerator
    {
        internal StoryboardLayer layer;
        internal int startTime = 63000, endTime = 74294;
        internal Vector2 CENTER = new Vector2(320, 240);
        public override void Generate()
        {
            //bg
		    layer = GetLayer("B");
            
            
            double[] timeArray = new double[300], time2Array = new double[300];
            //float x, y;
            float[] xArray = new float[300], yArray = new float[300], x2Array = new float[300], y2Array = new float[300];
            //double time, time2;
            OsbSprite particle;
            /*
            for (int p = 0; p < 300; p++)
            {
                timeArray[p] = Random(1500, 5000);
                time2Array[p] = startTime - Random(1200, 4000);
                xArray[p] = Random(-157, 797);
                yArray[p] = Random(520, 555);
                particle = layer.CreateSprite("sb/p2.png", OsbOrigin.Centre);
                
                particle.Fade(startTime, startTime, 0, 1);
                particle.Fade(endTime, endTime, 1, 0);
                //particle.Additive(startTime, endTime);
                particle.Color(startTime, Color4.Black);
                particle.Scale(startTime, 0.02 + Random(1, 10)/1000d);
                particle.StartLoopGroup(time2Array[p], (int)((endTime - startTime)/timeArray[p]) + 2);
                    particle.Move(0, timeArray[p], new Vector2(xArray[p], yArray[p]), new Vector2(xArray[p] + Random(400, 500)/10f, yArray[p] - Random(5550, 6000)/10f));
                particle.EndGroup();
            }
            */
            
            
            

            OsbSprite bg = layer.CreateSprite("sb/horizon.jpg", OsbOrigin.Centre, CENTER);
            bg.Fade(startTime, startTime, 0, 1);
            bg.Fade(endTime, endTime, 1, 0);
            bg.Scale(startTime, endTime, 480.0/1080.0, 480.0/1080.0 + 0.05);
            bg.Additive(startTime, endTime);
            

            for (int p = 0; p < 240; p++)
            {
                
                timeArray[p] = Random(1500, 5000);
                time2Array[p] = startTime - Random(1200, 4000);
                xArray[p] = Random(-197, 837);
                yArray[p] = Random(520, 555);
                x2Array[p] = xArray[p]  - Random(900, 1000)/10f;
                y2Array[p] = yArray[p] - Random(5550, 6000)/10f;
                
                
                
                particle = layer.CreateSprite("sb/p2.png", OsbOrigin.Centre);
                
                particle.Fade(startTime, startTime, 0, 1);
                particle.Fade(endTime, endTime, 1, 0);
                particle.Additive(startTime, endTime);
                particle.Color(startTime, Color4.White);
                particle.Color(72882, 73588, Color4.White, new Color4(255, 125, 80, 100));
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


            //foreground
            OsbSprite v = layer.CreateSprite("sb/v2.png", OsbOrigin.Centre, CENTER);
            v.Scale(startTime, 480.0/1080.0);
            v.Color(startTime, Color4.Black);
            v.Fade(startTime, startTime, 0, 1);
            v.Fade(endTime, endTime, 1, 0);



            OsbSprite redOverlay = layer.CreateSprite("sb/1px.png", OsbOrigin.Centre, CENTER);
            redOverlay.ScaleVec(startTime, startTime, 1, 1, 854, 480);
            redOverlay.Color(startTime, Color4.OrangeRed);
            redOverlay.Fade(startTime, startTime, 0, 0);
            redOverlay.Fade(65823, 66529, 0.3, 0);
            redOverlay.Fade(68647, 69353, 0.3, 0);
            redOverlay.Fade(69353, 70059, 0.3, 0);
            redOverlay.Fade(70059, 70765, 0.3, 0);
            redOverlay.Fade(70765, 71470, 0.3, 0);
            redOverlay.Fade(OsbEasing.Out, 71470, 72176, 0.3, 0);
            redOverlay.Fade( 72176, 73588, 0, 0.4);
            redOverlay.Fade(OsbEasing.Out, 73588, endTime, 0.4, 0);



            

            v = layer.CreateSprite("sb/v2.png", OsbOrigin.Centre, CENTER);
            v.Scale(startTime, 480.0/1080.0);
            v.Color(startTime, Color4.Black);
            v.Fade(startTime, startTime, 0, 1);
            v.Fade(endTime, endTime, 1, 0);
        }
    }
}

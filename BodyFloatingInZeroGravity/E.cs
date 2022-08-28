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
    public class E : StoryboardObjectGenerator
    {
        internal StoryboardLayer layer;
        internal Vector2 CENTER = new Vector2(320, 240);
        internal int startTime = 119470, endTime = 153353;
        internal FontGenerator font;
        internal OsbSprite cover;
        public override void Generate()
        {
		    layer = GetLayer("E");

            OsbSprite lighting = layer.CreateSprite("sb/lighting.png", OsbOrigin.Centre, CENTER);
            lighting.Fade(130765, 132176, 0, 0.1);
            lighting.Fade(147706, endTime, 0.1, 0.4);
            lighting.Fade(endTime, endTime, 0.4, 0);
            lighting.Rotate(130765, endTime, 0.3*Math.PI, 0*Math.PI);
            OsbSprite v = layer.CreateSprite("sb/v2.png", OsbOrigin.Centre, CENTER);
            v.Fade(startTime, startTime, 0, 0.2);
            v.Fade(endTime, endTime, 0.2, 0);
            v.Scale(startTime, 480.0f/1080.0f);

            v = layer.CreateSprite("sb/v2.png", OsbOrigin.BottomCentre, CENTER);
            v.Fade(startTime, startTime, 0, 0.2);
            v.ScaleVec(startTime, startTime, 1, 1, 854.0f/1920.0f, 240.0f/1080.0f);
            v.Color(startTime, Color4.LightGoldenrodYellow);
            v.Fade(endTime, endTime, 0.2, 0);
            v = layer.CreateSprite("sb/v2.png", OsbOrigin.TopCentre, CENTER);
            v.Fade(startTime, startTime, 0, 0.2);
            v.ScaleVec(startTime, startTime, 1, 1, 854.0f/1920.0f, 240.0f/1080.0f);
            v.Color(startTime, Color4.LightGoldenrodYellow);
            v.Fade(endTime, endTime, 0.2, 0);

            v = layer.CreateSprite("sb/grad.png", OsbOrigin.BottomCentre, CENTER);
            v.Rotate(startTime, Math.PI);
            v.Fade(startTime, startTime, 0, 0.2);
            v.ScaleVec(startTime, startTime, 1, 1, 854, 1);
            v.Color(startTime, Color4.LightGoldenrodYellow);
            v.Fade(endTime, endTime, 0.2, 0);
            v = layer.CreateSprite("sb/grad.png", OsbOrigin.BottomCentre, CENTER);
            v.Fade(startTime, startTime, 0, 0.2);
            v.ScaleVec(startTime, startTime, 1, 1, 854, 1);
            v.Color(startTime, Color4.LightGoldenrodYellow);
            v.Fade(endTime, endTime, 0.2, 0);


            int loopCount;
            for (int p = 0; p < 90; p++)
            {
                loopCount = Random(10, 20) * 2;
                OsbSprite particle = layer.CreateSprite("sb/p.png", OsbOrigin.Centre, new Vector2(Random(-107, 747), 240));
                particle.Fade(startTime, startTime, 0, 1);
                particle.Additive(startTime, endTime);
                particle.Scale(startTime, 0.5 + Random(-1, 1)/10);
                particle.StartLoopGroup(startTime - Random(500, 2500), loopCount + 4);
                    particle.Move(0, (endTime - startTime)/loopCount, particle.PositionAt(startTime), new Vector2(particle.PositionAt(startTime).X, particle.PositionAt(startTime).Y + (Random(-10, 10) < 0? -1:1) * Random(40, 50)));
                    particle.Color(0, (endTime - startTime)/(loopCount*2), Color4.Black, Color4.LightGoldenrodYellow);
                    particle.Color((endTime - startTime)/(loopCount*2), (endTime - startTime)/(loopCount), Color4.LightGoldenrodYellow, Color4.Black);
                particle.EndGroup();
                particle.Fade(endTime, endTime, 1, 0);
            }





            cover = layer.CreateSprite("sb/1px.png", OsbOrigin.Centre, CENTER);
            cover.Fade(125117, 125117, 0, 1);
            cover.Fade(endTime, endTime, 1, 0);
            cover.Color(125117, Color4.LightGoldenrodYellow);
            cover.ScaleVec(OsbEasing.OutQuart, 125117, 126529, 350, 0, 400, 110);
            cover.ScaleVec(OsbEasing.InOutExpo, 129353, 130765, 400, 110, 854, 60);
            cover.Move(OsbEasing.InOutExpo, 129353, 130765, CENTER, new Vector2(320, 30));
            cover.ScaleVec(OsbEasing.InOutExpo, 147706, endTime, 854, 60, 854, 0);
            cover.Move(OsbEasing.InOutExpo, 147706, endTime, new Vector2(320, 30), new Vector2(320, 00));

            cover = layer.CreateSprite("sb/1px.png", OsbOrigin.Centre, CENTER);
            cover.Fade(129353, 129353, 0, 1);
            cover.Fade(endTime, endTime, 1, 0);
            cover.Color(129353, Color4.LightGoldenrodYellow);
            cover.ScaleVec(OsbEasing.InOutExpo, 129353, 130765, 400, 110, 854, 60);
            cover.Move(OsbEasing.InOutExpo, 129353, 130765, CENTER, new Vector2(320, 480 - 30));
            cover.ScaleVec(OsbEasing.InOutExpo, 147706, endTime, 854, 60, 854, 0);
            cover.Move(OsbEasing.InOutExpo, 147706, endTime, new Vector2(320, 480 - 30), new Vector2(320, 480));


            KeySounds();
            OsbSprite f = layer.CreateSprite("sb/grad.png", OsbOrigin.BottomCentre, new Vector2(320, 420));
            f.Fade(130765, 130765 + Beatmap.GetTimingPointAt(startTime).BeatDuration*2, 0, 1);
            f.ScaleVec(130765, 130765, 1, 1, 854, 1);
            f.Fade(endTime, endTime, 1, 0);
            f.Color(130765, Color4.LightGoldenrodYellow);
            f.Move(OsbEasing.InOutExpo, 147706, endTime, new Vector2(320, 420), new Vector2(320, 480));
            f = layer.CreateSprite("sb/grad.png", OsbOrigin.BottomCentre, new Vector2(320, 60));
            f.Rotate(130765, Math.PI);
            f.Fade(130765, 130765 + Beatmap.GetTimingPointAt(startTime).BeatDuration*2, 0, 1);
            f.ScaleVec(130765, 130765, 1, 1, 854, 1);
            f.Fade(endTime, endTime, 1, 0);
            f.Color(130765, Color4.LightGoldenrodYellow);
            f.Move(OsbEasing.InOutExpo, 147706, endTime, new Vector2(320, 60), new Vector2(320, 0));
            



            

            /*
            CreateText("Mapper:", 130765, 500, 150);
            CreateText("Tachibana-", 133588, 500, 150);
            CreateText("Guest Diffs:", 136412, 200, 150);
            
            CreateText("mrforse & Orange-",139235, 600, 100);
            CreateText("Storyboarder:", 142059, 500, 120);
            CreateText("binarie", 144882, 500, 150);

            */
        }
        /*internal void CreateText(string text, int startTime, int waitTime, int spawnTime)
        {
            double spl = Beatmap.GetTimingPointAt(this.startTime).BeatDuration*0.5d;
            char[] t = text.ToCharArray();
            for(int p = 0; p < t.Length; p++)
            {
                if (t[p] != ' '){
                    FontTexture texture = font.GetTexture(t[p].ToString());
                OsbSprite letter = layer.CreateSprite(texture.Path, OsbOrigin.Centre, new Vector2(797, 30));
                //letter.Additive(startTime - spl + (spawnTime*p));
                letter.Move(OsbEasing.OutQuart, startTime - spl + (spawnTime*p), startTime + (spawnTime*p), new Vector2(797, 30), new Vector2(320 + ((p - t.Length*0.5f)*25), 30));
                letter.Move(OsbEasing.OutQuart, startTime + (spawnTime * t.Length) + (spawnTime*0.33d*p) + waitTime, startTime + spl + (spawnTime * t.Length) + (spawnTime*0.33d*p) + waitTime, new Vector2(320 + ((p - t.Length*0.5f)*25), 30), new Vector2(-157, 30));
                letter.Scale(startTime - spl + (spawnTime*p), startTime + (spawnTime*p), 0.7, 0.5);
                //letter.Fade(startTime - spl + (50*p), 0.3);
                letter.Color(startTime - spl + (spawnTime*p), startTime + (spawnTime*p), Color4.White, Color4.Goldenrod);

                letter.Scale(startTime + (spawnTime * t.Length) + (spawnTime*0.33d*p) + waitTime, startTime + spl + (spawnTime * t.Length) + (spawnTime*0.33d*p) + waitTime, 0.5, 0.7);
                letter.Color(startTime + (spawnTime * t.Length) + (spawnTime*0.33d*p) + waitTime, startTime + spl + (spawnTime * t.Length) + (spawnTime*0.33d*p) + waitTime, Color4.Goldenrod, Color4.White);
                }
            }
            */
            /*
            
            char[] split = text.ToCharArray();
            for(int p = 0; p < split.Length; p++)
            {
                var letter = layer.CreateSprite(font.GetTexture(split[p].ToString()));
                letter.Move(startTime, new Vector2(320 + ((p - t.Length*0.5f)*offset), 240))
                letter.Fade(startTime, startTime, 0, 1);
                letter.Fade(endTime, endTime, 1, 0);
            }
            */
        
        internal void KeySounds()
        {
            int endTime = 152912;
            int sampleSet, minimum = 100, iteration;
            double currentTime;
            List<int> count = new List<int>();
            for (currentTime = 130765; currentTime < endTime; currentTime += Beatmap.GetTimingPointAt(startTime).BeatDuration/2d)
            {
                sampleSet = Beatmap.GetControlPointAt((int)(currentTime)).CustomSampleSet;
                if (sampleSet < minimum) minimum = sampleSet;
                if (!count.Contains(sampleSet)) count.Add(sampleSet);
            }
            count.Sort();
            int[] sorted = count.ToArray();
            
            for (currentTime = 130765; currentTime < endTime; currentTime += Beatmap.GetTimingPointAt(startTime).BeatDuration/2d)
            {
                sampleSet = Beatmap.GetControlPointAt((int)(currentTime)).CustomSampleSet;
                for (iteration = 0; iteration < sorted.Length; iteration++)
                {
                    if (sampleSet == sorted[iteration])
                    {
                        OsbSprite pool = layer.CreateSprite("sb/grad.png", OsbOrigin.BottomCentre, new Vector2(-107 + 21.35f + (854.0f/(float)(sorted.Length))*iteration, 420 + (60 - (cover.ScaleAt(currentTime)).Y)));
                        //pool.Color(currentTime, Color4.LightGoldenrodYellow);


                        if ((cover.PositionAt(currentTime)) != (cover.PositionAt(currentTime + 1000))) pool.Move(currentTime, currentTime + 1000, 
                        new Vector2(-107 + 21.35f + (854.0f/(float)(sorted.Length))*iteration, cover.PositionAt(currentTime).Y - cover.ScaleAt(currentTime).Y*0.5), new Vector2(-107 + 21.35f + (854.0f/(float)(sorted.Length))*iteration, cover.PositionAt(currentTime + 1000).Y  - cover.ScaleAt(currentTime + 1000).Y*0.5f));

                        
                        pool.ScaleVec(OsbEasing.OutQuart, currentTime, currentTime + 1000, (854.0d/(double)(sorted.Length)), 1, (854.0d/(double)(sorted.Length)), 2);
                        pool.Fade(OsbEasing.OutQuart, currentTime, currentTime + 1000, 1, 0);
                    }
                }
            }
            
            
            
        }
    }
}

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
    
    public class Warning : StoryboardObjectGenerator
    {
        internal StoryboardLayer layer;
        internal Vector2 CENTER = new Vector2(320, 240);
        internal int startTime = 6529, endTime = 40412;
        internal double measure;
        internal OsbSprite redBG, bar;
        internal FontGenerator font;
        public override void Generate()
        {
		    layer = GetLayer("Warning");
            
            OsbSprite background = layer.CreateSprite("sb/1px.png", OsbOrigin.Centre, CENTER);
            background.ScaleVec(17823, 17823, 1, 1, 854, 480);
            background.Fade(17823, 18529, 0, 0.1);
            background.Fade(29118, 29823, 0.1, 0.2);
            background.Fade(endTime, endTime, 1, 0);
            background.Color(17823, Color4.DarkRed);

            measure = Beatmap.GetTimingPointAt(startTime).BeatDuration;
            redBG = layer.CreateSprite("sb/1px.png", OsbOrigin.Centre, CENTER);
            redBG.Color(startTime, Color4.DarkRed);
            redBG.ScaleVec(startTime, startTime, 1, 1, 854, 480);
            /*
            redFade(7147);
            redFade(9970);
            redFade(12794);
            redFade(15618);
            redFade(18353);
            redFade(21176);
            redFade(24000);
            redFade(26823);
            redFade(29647);
            */
            redBG.StartLoopGroup(7147, 12);
                redBG.Fade(0, 7323 - 7147, 0, 0.3);
                redBG.Fade(7323 - 7147, 7941 - 7147, 0.3, 0);
                redBG.Fade(9970 - 7147, 9970 - 7147, 0, 0);
            redBG.EndGroup();
            


           

            OsbSprite vignette = layer.CreateSprite("sb/v.png", OsbOrigin.Centre, CENTER);
            vignette.ScaleVec(startTime, startTime, 1, 1, 854/800d, 480/567d);
            vignette.Color(startTime, Color4.Black);
            vignette.Fade(startTime, startTime, 0, 1);
            vignette.Fade(endTime, endTime, 1, 0);

            font = LoadFont("sb/text", new FontDescription()
            {
                FontPath = "warningTxt.ttf",
                FontSize = 64,
                FontStyle = System.Drawing.FontStyle.Regular,
                TrimTransparency = false,
                Color = Color4.White,
                Padding = Vector2.One
            });
            bar = layer.CreateSprite(font.GetTexture("█").Path, OsbOrigin.CentreLeft);
            bar.StartLoopGroup(startTime, 150);
                bar.Fade(0, 0, 0, 1);
                bar.Fade(175, 175, 1, 0);
                bar.Fade(225.8866, 225.8866, 0, 1);
            bar.EndGroup();
            bar.Fade(endTime, endTime, 1, 0);
            bar.Fade(274765, 274765, 0, 1);
            bar.StartLoopGroup(274765, 47);
                bar.Fade(0, 0, 0, 1);
                bar.Fade(175, 175, 1, 0);
                bar.Fade(225.8866, 225.8866, 0, 1);
            bar.EndGroup();
            //Log(AudioDuration);
            //bar.Fade(AudioDuration, AudioDuration, 1, 0);
            bar.Scale(startTime, 0.2);
            bar.Color(startTime, Color4.SeaGreen);
            Vector2 lastPos;
            CreateText(0, startTime, endTime, measure * 0.125, 
            "System Protocol 941: Engine Management", 
            new Vector2(10, 40), out lastPos);
            CreateText(9000 - 8294, 8294, 17823, measure * 0.125, "", new Vector2(10, 70), out lastPos);
            CreateText(500, 9000, 17823, measure * 0.125, "Please sign in: ", new Vector2(10, 100), out lastPos);
            CreateText(500, 12176, 17823, measure * 0.4, "101111011001", lastPos, out lastPos);
            CreateText(500, 15000, 17823, measure * 0.125, "Please stand by.", new Vector2(10, 130), out lastPos);
            CreateText(250, 16412, 17823, measure * 0.125, ".", lastPos, out lastPos);
            CreateText(250, 17294, 17823, measure * 0.125, ".", lastPos, out lastPos);
            CreateText(0, 17823, 29118, measure * 0.125, "Combustion Chamber: ", new Vector2(10, 70), out lastPos);
            CreateText(500, 18706, 29118, measure * 0.125, "Online", lastPos, out lastPos);
            CreateText(0, 20647, 29118, measure * 0.125, "Oxidiser: ", new Vector2(10, 100), out lastPos);
            CreateText(500, 21882, 29118, measure * 0.125, "Online", lastPos, out lastPos);
            CreateText(0, 23470, 29118, measure * 0.125, "Fuel Percentage: ", new Vector2(10, 130), out lastPos);
            CreateText(500, 24706, 29118, measure * 0.125, "51", lastPos, out lastPos);
            CreateText(0, 26294, 29118, measure * 0.125, "What would you like to do: ", new Vector2(10, 160), out lastPos);
            CreateText(0, 27706, 29118, measure * 0.3, "REFUEL", lastPos, out lastPos);
            CreateText(0, 28412, 29118, measure * 0.125, "Starting...", new Vector2(10, 190), out lastPos);
            CreateText(0, 29118, 34765, measure * 0.125, "CRITICAL WARNING: ENVIRONMENT SHUTDOWN", new Vector2(10, 70), out lastPos);
            CreateText(0, 31941, 34765, measure * 0.125, "CAUSE: ", new Vector2(10, 100), out lastPos);
            CreateText(250, 33176, 34765, measure * 0.125, "UNKNOWN", lastPos, out lastPos);
            CreateText(0, 34765, endTime, measure * 0.125, "MESSAGE FROM System Protocol 949: Security", new Vector2(10, 70), out lastPos);
            CreateText(0, 37588, endTime, measure * 0.11, "WARNING: CARBON MONOXIDE LEAK", new Vector2(10, 100), out lastPos);
            CreateText(0, 38823, endTime, measure * 0.11, "PLEASE GET TO EVAC SHUTTLE AND LEAVE IMMEDIATELY", new Vector2(10, 130), out lastPos);


            
            CreateText(1000, 274765, AudioDuration, measure * 0.125, "Storyboard by binarie", new Vector2(10, 40), out lastPos);
            CreateText(1000, 277588, AudioDuration, measure * 0.125, "Thanks for playing!", new Vector2(10, 70), out lastPos);
            
            
            OsbSprite fog = layer.CreateSprite("sb/fog.png", OsbOrigin.BottomCentre, new Vector2(320, 480));
            fog.Fade(OsbEasing.In, 34765, endTime, 0, 0.1);
            fog = layer.CreateSprite("sb/fog2.png", OsbOrigin.TopCentre, new Vector2(320, 500));
            fog.Fade(OsbEasing.In, 34765, endTime, 0, 0.3);
            fog.Rotate(34765, 34765, 0, 0.02*Math.PI);
            fog.ScaleVec(OsbEasing.In, 34765, endTime, 854d/1299d, 500.0d/615d, 1, 1);
            fog.Move(34765, endTime, new Vector2(320, 0), new Vector2(320, 20));

            double loopCount, scale;
            int start;
            for (int i = 0; i < 240; i++)
            {
                scale = Random(100, 500)/1000d;
                Vector2 startPos = new Vector2(Random(-227, 867), Random(500, 600));
                loopCount = Random(5, 10);
                start = Random(29118, 38294);
                OsbSprite particle = layer.CreateSprite("sb/p.png", OsbOrigin.Centre);
                particle.Fade(start, start, 0, 0.2);
                particle.Scale(start, scale);
                particle.StartLoopGroup(start + Random(-50, 200), (int)loopCount);
                    particle.Move(0, ((double)(endTime - start))/loopCount + Random(-200, 200), 
                    startPos, new Vector2(startPos.X + 140 + Random(-30, 30), Random(-100, -50)));
                particle.EndGroup();
                particle.Scale(OsbEasing.InSine, 39000, endTime, scale, scale + 1 + Random(10, 20)/100d);
                particle.Fade(endTime, endTime, 0.2, 0);

                
                
            }
            KeySounds();

            
            
        }
        internal void CreateText(double delay, 
        double start, double end, 
        double charDelay, string text, 
        Vector2 CentreLeft, out Vector2 LastPosition)
        {
            bar.Move(start, CentreLeft);
            start = start + delay;
            FontTexture texture;
            float xPos = CentreLeft.X, lastPos;
            char[] t = text.ToCharArray();
            for (int u = 0; u < t.Length; u++)
            {

                if (t[u] != ' '){
                    texture = font.GetTexture(t[u].ToString());
                    
                    if (start + charDelay * u < end){
                    
                        OsbSprite letter = layer.CreateSprite(
                            texture.Path, 
                            OsbOrigin.CentreLeft, 
                            new Vector2(xPos, CentreLeft.Y));
                        letter.Color(start + charDelay * (u), start + charDelay * (u), Color4.White, Color4.SeaGreen);
                        letter.Scale(start + charDelay * (u), 0.2);
                        letter.Fade(start + charDelay * (u), startTime + charDelay * (u), 0, 1);
                        letter.Fade(end, end, 1, 0);
                        
                    }
                    lastPos = xPos;
                    xPos += texture.BaseWidth*0.23f;
                } else 
                {
                    lastPos = xPos;
                    xPos += 10;
                }
                if (start + charDelay * u < end){
                    bar.Move(start + charDelay * (u), start + charDelay * (u), 
                    new Vector2(lastPos, CentreLeft.Y), 
                    new Vector2(xPos, CentreLeft.Y));
                }
            }
            LastPosition = new Vector2(xPos, CentreLeft.Y);
            
        }
        internal void KeySounds()
        {
            int endTime = 39970;
            int sampleSet, minimum = 100, iteration;
            double currentTime;
            List<int> count = new List<int>();
            for (currentTime = 17823; currentTime < endTime; currentTime += Beatmap.GetTimingPointAt(startTime).BeatDuration/2d)
            {
                sampleSet = Beatmap.GetControlPointAt((int)(currentTime)).CustomSampleSet;
                if (sampleSet < minimum) minimum = sampleSet;
                if (!count.Contains(sampleSet)) count.Add(sampleSet);
            }
            count.Sort();
            int[] sorted = count.ToArray();
            
            for (currentTime = 17823; currentTime < endTime; currentTime += Beatmap.GetTimingPointAt(startTime).BeatDuration/2d)
            {
                sampleSet = Beatmap.GetControlPointAt((int)(currentTime)).CustomSampleSet;
                for (iteration = 0; iteration < sorted.Length; iteration++)
                {
                    if (sampleSet == sorted[iteration])
                    {
                        OsbSprite pool = layer.CreateSprite("sb/grad.png", OsbOrigin.BottomCentre, new Vector2(-107 + 21.35f + (854.0f/(float)(sorted.Length))*iteration, 480));
                        pool.Color(currentTime, new Color4(255, 200, 200, 100));
                        if (currentTime >= 37588) pool.ScaleVec(OsbEasing.OutQuart, currentTime, currentTime + 1000, (854.0d/(double)(sorted.Length)), 1, (854.0d/(double)(sorted.Length)), 2 + ((currentTime - endTime)/currentTime)*5);
                        else pool.ScaleVec(OsbEasing.OutQuart, currentTime, currentTime + 1000, (854.0d/(double)(sorted.Length)), 1, (854.0d/(double)(sorted.Length)), 2);
                        pool.Fade(OsbEasing.OutQuart, currentTime, currentTime + 1000, 0.7, 0);
                    }
                }
            }
            Log((854.0f/(float)(sorted.Length))/2);
            OsbSprite p = layer.CreateSprite("sb/grad.png", OsbOrigin.BottomCentre, new Vector2(320, 480));
            p.ScaleVec(OsbEasing.OutQuart, 40059, 40412, 854.0d, 0, 854.0d, 1);
            p.Fade(OsbEasing.OutQuart, 40059, 40412, 0, 0.5);
            
            
        }
    }
}

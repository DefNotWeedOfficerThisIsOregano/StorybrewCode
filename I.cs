using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Animations;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public class I : StoryboardObjectGenerator
    {
        internal StoryboardLayer layer;
        internal Vector2 CENTER = new Vector2(320, 240);
        internal int startTime = 198529, endTime = 221117;
        public override void Generate()
        {
		    layer = GetLayer("I");
            OsbSprite bg = layer.CreateSprite("sb/dystopia.jpg", OsbOrigin.Centre);
            bg.StartLoopGroup(startTime, (endTime - startTime) / 2400);
                bg.Move(OsbEasing.InOutSine, 0, 1200, new Vector2(320, 238), new Vector2(320, 242));
                bg.Move(OsbEasing.InOutSine, 1200, 2400, new Vector2(320, 242), new Vector2(320, 238));
            bg.EndGroup();
            bg.Scale(startTime, 0.5);
            bg.Fade(startTime, startTime, 0, 0.2);
            bg.Fade(endTime, endTime,0.2 ,0);

            DrawSpectrum();



            for (int p = 0; p < 120; p++)
            {
                Vector2 startPos = new Vector2(Random(-107, 747), Random(0, 480)), endPos = new Vector2(startPos.X + Random(-25, 25), startPos.Y + Random(-25, 25));
                OsbSprite particle = layer.CreateSprite("sb/p.png", OsbOrigin.Centre);
                particle.StartLoopGroup(startTime, 8);
                    particle.Move(OsbEasing.InOutCirc, 0, (endTime - startTime)/16d, startPos, endPos);
                    particle.Move(OsbEasing.InOutCirc, (endTime - startTime)/16d, (endTime - startTime)/8d, endPos, startPos);
                particle.EndGroup();
                particle.Fade(startTime, startTime, 0, 0.2);
                particle.Fade(endTime, endTime, 0.2, 0);
                particle.Scale(startTime, Random(10, 30)/100d);

            }
            
            OsbSprite astro = layer.CreateSprite("sb/cutout.png", OsbOrigin.Centre, CENTER);
            astro.Scale(startTime, 0.46);
            astro.StartLoopGroup(startTime, 9);
                astro.Rotate(OsbEasing.InOutSine, 0, (endTime - startTime)/18d, -0.005, 0.005);
                astro.Rotate(OsbEasing.InOutSine, (endTime - startTime)/18d, (endTime - startTime)/9d, 0.005, -0.005);
            astro.EndGroup();
            astro.Fade(startTime, startTime, 0, 0.8);
            astro.Fade(endTime, endTime, 0.8, 0);
            astro.Color(startTime, Color4.White);
            astro.Color(213941, 214059, Color4.LightPink, Color4.White);
            astro.Color(214176, 214294, Color4.LightPink, Color4.White);
            astro.Color(214412, 214765, Color4.LightPink, Color4.White);

            int lC;
            float RandY, change;
            for (int p = 0; p < 120; p++)
            {
                RandY = Random(0, 480);
                change = Random(40, 90);
                lC = Random(10, 20);
                OsbSprite part = layer.CreateSprite("sb/p.png", OsbOrigin.Centre);
                part.StartLoopGroup(startTime - Random(0, (endTime - startTime)/lC), lC);
                    part.MoveX(0, (endTime - startTime)/lC, -157, 797);
                    part.MoveY(OsbEasing.InOutSine, 0, (endTime - startTime)/lC*2, RandY - change, RandY + change);
                    part.MoveY(OsbEasing.InOutSine, (endTime - startTime)/lC*2, (endTime - startTime)/lC, RandY + change, RandY - change);
                part.EndGroup();
                part.Fade(startTime, startTime, 0, 0.5);
                part.Fade(endTime, endTime, 0.5, 0);
                part.Scale(startTime, Random(30, 50)/100d);
                part.Color(startTime, new Color4((byte)Random(200, 245), (byte)Random(200, 245), (byte)Random(200, 245), 100));


            }

            OsbSprite vignette = layer.CreateSprite("sb/v2.png", OsbOrigin.Centre, CENTER);
            vignette.Fade(startTime, startTime, 0, 1);
            vignette.Fade(endTime, endTime, 1, 0);
            vignette.Color(startTime, Color4.Black);
            vignette.Scale(startTime, 480.0/1080.0);
            vignette.Fade(215470, 215735, 0.5, 1);
            vignette.Color(215470, 215735, Color4.DimGray, Color4.Black);
            vignette.Fade( 215735, 216000, 0.5, 1);
            vignette.Color( 215735, 216000, Color4.DimGray, Color4.Black);
            vignette.Fade(216000, 216265, 0.5, 1);
            vignette.Color(216000, 216265, Color4.DimGray, Color4.Black);
            vignette.Fade(216265, 216529, 0.5, 1);
            vignette.Color(216265, 216529, Color4.DimGray, Color4.Black);

            vignette.Fade(216882, 217147, 0.5, 1);
            vignette.Color(216882, 217147, Color4.DimGray, Color4.Black);
            vignette.Fade( 217147, 217412, 0.5, 1);
            vignette.Color( 217147, 217412, Color4.DimGray, Color4.Black);
            vignette.Fade(217412, 217676, 0.5, 1);
            vignette.Color(217412, 217676, Color4.DimGray, Color4.Black);
            vignette.Fade(217676, 217941, 0.5, 1);
            vignette.Color(217676, 217941, Color4.DimGray, Color4.Black);
            vignette.Fade(218294, 219000, 0.5, 1);
            vignette.Color(218294, 219000, Color4.DimGray, Color4.Black);
            vignette.Fade(219000, 219706, 0.5, 1);
            vignette.Color(219000, 219706, Color4.DimGray, Color4.Black);

            vignette.Fade(219706, endTime, 0.5, 1);
            vignette.Color(219706, endTime, Color4.DimGray, Color4.Black);

            vignette = layer.CreateSprite("sb/v2.png", OsbOrigin.Centre, CENTER);
            vignette.Fade(219706, endTime, 1, 0);
            vignette.Color(219706, Color4.Black);
            vignette.Scale(219706, 480.0/1080.0);


            int transitionTime = 220765;
            double spl = (transitionTime - 219706)/60d;
            Log(spl);
            for(int p = 0; p < 61; p++)
            {
                OsbSprite transition = layer.CreateSprite("sb/1px.png", OsbOrigin.Centre, new Vector2(-107 + (854.0f/60.0f)*(p),240));
                transition.ScaleVec(219706, transitionTime, 0, 480, 854.0d/60d, 480);
                transition.Color(219706, transitionTime, Color4.White, Color4.Black);
                transition.Fade(219706, 219706, 0, 0.8);
                transition.Fade(endTime, endTime, 0.8, 0);
                transition.Color(220765, 220941, Color4.DimGray, Color4.Black);
                transition.Color(220941, 221117, Color4.DimGray, Color4.Black);
            }
        }
        internal void DrawSpectrum()
    {
        string SpritePath = "sb/grad.png";
        int BarCount = 40;
        int StartTime = startTime, EndTime = 219706;
        int BeatDivisor = 4;
        OsbEasing FftEasing = OsbEasing.InOutQuart;
        int FrequencyCutOff = 22000;
        int LogScale = 200;
        Vector2 Scale = new Vector2(1, 100);
        float MinimalHeight = 0;
        double Width = 854.0d;
        double Tolerance = 0.15;
        OsbOrigin SpriteOrigin = OsbOrigin.BottomCentre;
        
        int CommandDecimals = 0;
        var bitmap = GetMapsetBitmap(SpritePath);

            var heightKeyframes = new KeyframedValue<float>[BarCount];
            for (var i = 0; i < BarCount; i++)
                heightKeyframes[i] = new KeyframedValue<float>(null);

            var fftTimeStep = Beatmap.GetTimingPointAt(StartTime).BeatDuration / BeatDivisor;
            var fftOffset = fftTimeStep * 0.2;
            for (var time = (double)StartTime; time < EndTime; time += fftTimeStep)
            {
                var fft = GetFft(time + fftOffset, BarCount, null, FftEasing, FrequencyCutOff);
                for (var i = 0; i < BarCount; i++)
                {
                    var height = (float)Math.Log10(1 + fft[i] * LogScale) * Scale.Y / bitmap.Height;
                    if (height < MinimalHeight) height = MinimalHeight;

                    heightKeyframes[i].Add(time, height);
                }
            }

            var barWidth = Width / BarCount;
            Vector2 Position = new Vector2(-107 + (float)barWidth/2f, 240);
            for (var i = 0; i < BarCount; i++)
            {
                var keyframes = heightKeyframes[i];
                keyframes.Simplify1dKeyframes(Tolerance, h => h);

                var bar = layer.CreateSprite(SpritePath, SpriteOrigin, new Vector2(Position.X + i * (float)barWidth, Position.Y));
                bar.Fade(startTime, startTime, 0, 0.05*BarCount/(i+1) > 1 ? 1 : 0.05*BarCount/(i+1));
                bar.Fade(219706, 220412, 0.05*BarCount/(i+1) > 1 ? 1 : 0.05*BarCount/(i+1), 0);
                bar.CommandSplitThreshold = 300;
                //bar.ColorHsb(StartTime, (i * 360.0 / BarCount) + Random(-10.0, 10.0), 0.6 + Random(0.4), 1);
                //bar.Additive(StartTime, EndTime);

                var scaleX = Scale.X * barWidth / bitmap.Width;
                scaleX = (float)Math.Floor(scaleX * 10) / 10.0f;

                var hasScale = false;
                keyframes.ForEachPair(
                    (start, end) =>
                    {
                        hasScale = true;
                        bar.ScaleVec(start.Time, end.Time,
                            scaleX, start.Value,
                            scaleX, end.Value);
                    },
                    MinimalHeight,
                    s => (float)Math.Round(s, CommandDecimals)
                );
                if (!hasScale) bar.ScaleVec(StartTime, scaleX, MinimalHeight);
                bar.ScaleVec(OsbEasing.Out, 219706, 220412, bar.ScaleAt(219706).X, bar.ScaleAt(219706).Y, bar.ScaleAt(219706).X, 0);
                bar = layer.CreateSprite(SpritePath, SpriteOrigin, new Vector2(Position.X + i * (float)barWidth, Position.Y));
                bar.Rotate(startTime, Math.PI);
                bar.Fade(startTime, startTime, 0, 0.05*BarCount/(i+1) > 1 ? 1 : 0.05*BarCount/(i+1));
                bar.Fade(219706, 220412, 0.05*BarCount/(i+1) > 1 ? 1 : 0.05*BarCount/(i+1), 0);
                bar.CommandSplitThreshold = 300;
                //bar.ColorHsb(StartTime, (i * 360.0 / BarCount) + Random(-10.0, 10.0), 0.6 + Random(0.4), 1);
                //bar.Additive(StartTime, EndTime);

                
                scaleX = (float)Math.Floor(scaleX * 10) / 10.0f;

                hasScale = false;
                keyframes.ForEachPair(
                    (start, end) =>
                    {
                        hasScale = true;
                        bar.ScaleVec(start.Time, end.Time,
                            scaleX, start.Value,
                            scaleX, end.Value);
                    },
                    MinimalHeight,
                    s => (float)Math.Round(s, CommandDecimals)
                );
                if (!hasScale) bar.ScaleVec(StartTime, scaleX, MinimalHeight);
                bar.ScaleVec(OsbEasing.Out, 219706, 220412, bar.ScaleAt(219706).X, bar.ScaleAt(219706).Y, bar.ScaleAt(219706).X, 0);
            }
    }
    }
}

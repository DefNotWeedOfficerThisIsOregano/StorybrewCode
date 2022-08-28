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
using StorybrewCommon.Animations;

namespace StorybrewScripts
{
    public class C : StoryboardObjectGenerator
    {
        internal FontGenerator font;
        internal StoryboardLayer layer;
        internal Vector2 CENTER = new Vector2(320, 240);
        internal int startTime = 74294, endTime = 96882;
        public override void Generate()
        {
		    layer = GetLayer("C");
            font = LoadFont("sb/text2", new FontDescription()
            {
                FontPath = "txt1.ttf",
                FontSize = 128,
                FontStyle = System.Drawing.FontStyle.Regular,
                Padding = Vector2.One,
                Color = Color4.White,
                TrimTransparency = true
            });
            OsbSprite bg = layer.CreateSprite("sb/dystopia.jpg", OsbOrigin.Centre);
            bg.StartLoopGroup(startTime, (endTime - startTime) / 2400);
                bg.Move(OsbEasing.InOutSine, 0, 1200, new Vector2(320, 238), new Vector2(320, 242));
                bg.Move(OsbEasing.InOutSine, 1200, 2400, new Vector2(320, 242), new Vector2(320, 238));
            bg.EndGroup();
            bg.Scale(startTime, 0.5);
            bg.Fade(startTime, startTime, 0, 0.2);
            bg.Fade(endTime, endTime,0.2 ,0);
            
            
            DrawSpectrum();
            
            Vector2 pos, pos2;
            for (int p = 0; p < 60; p++)
            {
                pos = new Vector2(Random(-107, 747), Random(-20, 500));
                pos2 = new Vector2(pos.X + Random(-5, 5), pos.Y + Random(-5, 5));
                OsbSprite particle = layer.CreateSprite("sb/p.png", OsbOrigin.Centre, pos);
                particle.Fade(startTime, startTime, 0, 1);
                particle.Fade(endTime, endTime,1 ,0);
                particle.Scale(startTime, 0.1 + Random(5, 20)/100d);
                particle.StartLoopGroup(startTime, 9);
                particle.Move( OsbEasing.InOutCirc, 0, (endTime - startTime)/16d, pos, pos2);
                particle.Move(OsbEasing.InOutCirc, (endTime - startTime)/16d, (endTime - startTime)/8d, pos2, pos);
                particle.EndGroup();
            }

            



            OsbSprite fadeOut = layer.CreateSprite("sb/1px.png", OsbOrigin.Centre, CENTER);
            fadeOut.ScaleVec(94059,94059, 1, 1, 854, 480);
            fadeOut.Fade(OsbEasing.None, 94059, 95117, 0, 0.5);
            fadeOut.Fade(OsbEasing.Out, 95117, 96176, 0.5, 0.7);
            fadeOut.Color(94059, Color4.Black);
            fadeOut.Fade(endTime, endTime, 1, 0);

            OsbSprite v = layer.CreateSprite("sb/v2.png", OsbOrigin.Centre, CENTER);
            v.Scale(startTime, 480.0/1080.0);
            v.Fade(startTime, startTime, 0, 0.3);
            v.Color(startTime, Color4.DimGray);
            v.Fade(endTime, endTime, 0.3, 0);
            
            OsbSprite box = layer.CreateSprite("sb/1px.png", OsbOrigin.CentreLeft, new Vector2(-107, 80));
            box.Fade(94059, 94059, 0, 0.5);
            box.Fade(OsbEasing.OutQuart, 96529, endTime, 0.5, 0.1);
            box.Additive(96529, endTime);
            box.Fade(endTime, endTime, 0.1 , 0);
            box.Color(94059, Color4.DimGray);
            box.ScaleVec(OsbEasing.None, 94059, 95117, 0, 50, 700, 50);
            box.ScaleVec(OsbEasing.Out, 95117, 96176, 700, 50, 854, 50);
            
            FontTexture txt = font.GetTexture("Don't ");
            OsbSprite dont = layer.CreateSprite(txt.Path, OsbOrigin.CentreRight, new Vector2(300, 77));
            dont.Scale(96176, 40/128d);
            dont.Color(96176, endTime, Color4.IndianRed, Color4.OrangeRed);
            txt = font.GetTexture(" Break");
            OsbSprite br = layer.CreateSprite(txt.Path, OsbOrigin.CentreLeft, new Vector2(340, 80));
            br.Scale(96529, 40/128d);
            br.Color(96529, endTime, dont.ColorAt(96529), Color4.OrangeRed);

            CreateCard();
        }
    internal void CreateText(string text, Vector2 CentreLeft, int pT)
    {
        float xPos = CentreLeft.X;
        OsbSprite letter;
        
        char[] spl = text.ToCharArray();
        for (int p = 0; p < spl.Length; p++)
        {
            if (spl[p] != ' '){
                FontTexture texture = font.GetTexture(spl[p].ToString());
                letter = layer.CreateSprite(texture.Path, OsbOrigin.CentreLeft, new Vector2(xPos, CentreLeft.Y));
                letter.Scale(startTime, pT/128d);
                
                letter.Fade(startTime, startTime, 0, 1);
                letter.Fade(endTime, endTime, 1, 0);
                xPos += texture.BaseWidth * pT/128f  + 1;
            } else
            {
                xPos += 12;
            }
        }
    }
    internal void CreateCard()
    {
        OsbSprite insideBox = layer.CreateSprite("sb/1px.png", OsbOrigin.CentreLeft, new Vector2(310, 240));
            insideBox.Fade(startTime, startTime, 0, 0.4);
            insideBox.Fade(endTime, endTime, 0.4 , 0);
            insideBox.ScaleVec(startTime,startTime, 1, 1, 350, 80);
            insideBox.Color(startTime, new Color4(10, 10, 10, 100));
        CreateText("Body F10ating in", new Vector2(340, 220), 32);
        CreateText("the Zero Gravity Space", new Vector2(340, 260), 32);

            
        OsbSprite box = layer.CreateSprite("sb/1px.png", OsbOrigin.CentreLeft, new Vector2(310, 200));
            box.ScaleVec(startTime, startTime, 1, 1, 350, 2);
            box.Fade(startTime, startTime, 0, 1);
            box.Fade(endTime, endTime,1 ,0);
        box = layer.CreateSprite("sb/1px.png", OsbOrigin.CentreLeft, new Vector2(310, 280));
            box.ScaleVec(startTime, startTime,1, 1, 350, 2);
            box.Fade(startTime, startTime, 0, 1);
            box.Fade(endTime, endTime,1 ,0);
        box = layer.CreateSprite("sb/1px.png", OsbOrigin.BottomCentre, new Vector2(311, 280));
            box.ScaleVec(startTime, startTime,1, 1, 2, 80);
            box.Fade(startTime, startTime, 0, 1);
            box.Fade(endTime, endTime,1 ,0);
        box = layer.CreateSprite("sb/1px.png", OsbOrigin.BottomCentre, new Vector2(659, 280));
            box.ScaleVec(startTime, startTime,1, 1, 2, 80);
            box.Fade(startTime, startTime, 0, 1);
            box.Fade(endTime, endTime,1 ,0);

        OsbSprite card = layer.CreateSprite("sb/card.png", OsbOrigin.Centre, new Vector2(160, 240));
        card.Scale(startTime, 0.3);
        card.Fade(startTime, startTime, 0, 0.8);
        card.Fade(endTime, endTime,0.8 ,0);
        box = layer.CreateSprite("sb/1px.png", OsbOrigin.CentreLeft, new Vector2(70, 150));
        box.ScaleVec(startTime, startTime, 1, 1, 600*0.3, 2);
        box.Fade(startTime, startTime, 0, 1);
        box.Fade(endTime, endTime,1 ,0);
        box = layer.CreateSprite("sb/1px.png", OsbOrigin.CentreLeft, new Vector2(70, 330));
        box.ScaleVec(startTime, startTime, 1, 1, 600*0.3, 2);
        box.Fade(startTime, startTime, 0, 1);
        box.Fade(endTime, endTime,1 ,0);
        box = layer.CreateSprite("sb/1px.png", OsbOrigin.Centre, new Vector2(71, 240));
        box.ScaleVec(startTime, startTime, 1, 1, 2, 600*0.3);
        box.Fade(startTime, startTime, 0, 1);
        box.Fade(endTime, endTime,1 ,0);
        box = layer.CreateSprite("sb/1px.png", OsbOrigin.Centre, new Vector2(249, 240));
        box.ScaleVec(startTime, startTime, 1, 1, 2, 600*0.3);
        box.Fade(startTime, startTime, 0, 1);
        box.Fade(endTime, endTime,1 ,0);
    }
    internal void DrawSpectrum()
    {
        string SpritePath = "sb/grad.png";
        int BarCount = 40;
        int StartTime = startTime, EndTime = 96176;
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
                bar.Fade(96529, 96882, 0.05*BarCount/(i+1) > 1 ? 1 : 0.05*BarCount/(i+1), 0);
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
                bar.ScaleVec(OsbEasing.Out, 96176, 96882, bar.ScaleAt(96176).X, bar.ScaleAt(96176).Y, bar.ScaleAt(96176).X, 0);
                bar = layer.CreateSprite(SpritePath, SpriteOrigin, new Vector2(Position.X + i * (float)barWidth, Position.Y));
                bar.Rotate(startTime, Math.PI);
                bar.Fade(startTime, startTime, 0, 0.05*BarCount/(i+1) > 1 ? 1 : 0.05*BarCount/(i+1));
                bar.Fade(96529, 96882, 0.05*BarCount/(i+1) > 1 ? 1 : 0.05*BarCount/(i+1), 0);
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
                bar.ScaleVec(OsbEasing.Out, 96176, 96882, bar.ScaleAt(96176).X, bar.ScaleAt(96176).Y, bar.ScaleAt(96176).X, 0);
            }
    }
    }
    
}

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
    public class G : StoryboardObjectGenerator
    {
        internal StoryboardLayer layer;
        internal FontGenerator font;
        internal Vector2 CENTER = new Vector2(320, 240);
        internal int startTime = 175941, endTime = 187235;
        public override void Generate()
        {
            font = LoadFont("sb/txt3", new FontDescription()
            {
               FontPath = "sfd.otf",
               FontSize = 128,
               FontStyle = System.Drawing.FontStyle.Regular,
               TrimTransparency = false,
               Color = Color4.White,
               Padding = Vector2.One
            });

		    layer = GetLayer("G");
            OsbSprite bg = layer.CreateSprite("sb/dystopiaBLUR.jpg", OsbOrigin.Centre);
            
            bg.StartLoopGroup(startTime, (endTime - startTime) / 4800);
                bg.Move(OsbEasing.InOutSine, 0, 2400, new Vector2(320, 238), new Vector2(320, 242));
                bg.Move(OsbEasing.InOutSine, 2400, 4800, new Vector2(320, 242), new Vector2(320, 238));
            bg.EndGroup();
            bg.StartLoopGroup(startTime, (endTime - startTime) / 9600);
                bg.Rotate(OsbEasing.InOutSine, 0, 4800, -0.01, 0.01);
                bg.Rotate(OsbEasing.InOutSine, 4800, 9600, 0.01, -0.01);
            bg.EndGroup();
            bg.Scale(startTime, 0.5);
            bg.Fade(startTime, startTime, 0, 0.2);
            bg.Fade(184412, endTime, 0.2, 0.4);
            bg.Fade(endTime, endTime,0.2 ,0);
            for (double glitch = 185823; glitch < endTime;)
            {
                bg.Color(glitch, glitch, Color4.White, new Color4((byte)Random(230, 255), (byte)Random(120, 150), (byte)Random(60, 90), 100));
                glitch += Random(50, 100);
            }
            
            double time, newTime;
            float x, y, x2, y2;
            for (int p = 0; p < 240; p++)
            {
                OsbSprite particle = layer.CreateSprite("sb/p.png", OsbOrigin.Centre);
                particle.Fade(startTime, startTime, 0, Random(1, 5)/10d);
                particle.Fade(endTime, endTime, 1, 0);
                particle.Scale(startTime, Random(10, 30)/100d);
                particle.Color(startTime, new Color4((byte)(Random(180, 255)),(byte)(Random(200, 255)), (byte)(Random(100, 155)), 100 ));
                x = Random(-107, 747);
                y = Random(0, 480);
                for (time = startTime; time < endTime;)
                {
                    x2 = x + Random(-30, 30);
                    y2 = y + Random(-30, 30);
                    newTime = time + Random(1400, 4000);

                    particle.Move(OsbEasing.InOutSine, time, newTime, x, y, x2, y2);
                    x = x2;
                    y = y2;
                    time = newTime;
                }
            }

            
            OsbSprite cover = layer.CreateSprite("sb/1px.png", OsbOrigin.CentreLeft, new Vector2(-107, 70));
            cover.ScaleVec(OsbEasing.OutQuart, 180176, 181588, 0, 90, 854, 90);
            cover.Color(180176, Color4.LightGray);
            cover.Fade(180176, 180176, 0, 0.2);
            cover.Fade(endTime, endTime, 0.2, 0);

            CreateText("Mapper: Tachibana_",181588, 70);
            CreateText("Guests: mrforse & Orange_", 181588, 100);
            OsbSprite vignette = layer.CreateSprite("sb/v2.png", OsbOrigin.Centre, CENTER);
            vignette.Fade(startTime, startTime, 0, 1);
            vignette.Fade(endTime, endTime, 1, 0);
            vignette.Color(startTime, new Color4((byte)5, (byte)5, (byte)5, 100));
        }

        internal void CreateText(string text, int startTime, float y)
        {
            char[] spl = text.ToCharArray();
            for (int i = 0; i < spl.Length; i++)
            {
                if (spl[i] != ' '){
                    Vector2 pos = new Vector2(320 + (i - spl.Length*0.5f) * 21, y);
                    OsbSprite letter = layer.CreateSprite(font.GetTexture(spl[i].ToString()).Path, OsbOrigin.Centre);
                    letter.Scale(startTime + 100*i, 0.4);
                    letter.Fade(startTime + 100*i, startTime + 100*(i + 5), 0, 1);
                    letter.Fade(endTime, endTime, 1, 0);
                    letter.Move(startTime + 100*i, pos);
                }
            }
        }
    }
}

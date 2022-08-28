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
    public class J2 : StoryboardObjectGenerator
    {
        internal StoryboardLayer layer;
        internal Vector2 CENTER = new Vector2(320, 240);
        internal int startTime = 221117, endTime = 243706;
        public override void Generate()
        {
            layer = GetLayer("J2");

            OsbSprite grunge = layer.CreateSprite("sb/grunge.jpg", OsbOrigin.Centre, CENTER);
            grunge.Fade(startTime, startTime, 0,0.2);
            grunge.Fade(endTime, endTime, 0.2, 0);
            grunge.Scale(startTime, 0.7);
            OsbSprite bg = layer.CreateSprite("sb/utopia.png", OsbOrigin.Centre);
            //bg.Fade(startTime, startTime, 0, 0.8);
            bg.Scale(startTime, 0.5);
            //bg.Fade(endTime, endTime, 0.8, 0);
            bg.StartLoopGroup(startTime, 2);
                bg.Fade(0, Beatmap.GetTimingPointAt(startTime).BeatDuration*2, 1, 0.5);
                bg.Move(OsbEasing.InOutSine, 0, Beatmap.GetTimingPointAt(startTime).BeatDuration*4, new Vector2(320, 245), new Vector2(320, 235));
                bg.Move(OsbEasing.InOutSine, Beatmap.GetTimingPointAt(startTime).BeatDuration*4, Beatmap.GetTimingPointAt(startTime).BeatDuration*8, new Vector2(320, 235), new Vector2(320, 245));
                bg.Fade(Beatmap.GetTimingPointAt(startTime).BeatDuration*8, Beatmap.GetTimingPointAt(startTime).BeatDuration*9, 0.5, 0);
                bg.Fade(Beatmap.GetTimingPointAt(startTime).BeatDuration*16, Beatmap.GetTimingPointAt(startTime).BeatDuration*16, 0, 0.5);
            bg.EndGroup();
            bg.Fade(232412, 232412 + Beatmap.GetTimingPointAt(startTime).BeatDuration*2, 1,0.5);
            bg.Fade(238059, 238059 + Beatmap.GetTimingPointAt(startTime).BeatDuration, 1, 0.7);
            bg.Fade(OsbEasing.OutQuart, 240882, endTime, 0.2, 0.7);
            bg.StartLoopGroup(232412, 4);
                bg.Move(OsbEasing.InOutSine, 0, Beatmap.GetTimingPointAt(startTime).BeatDuration*4, new Vector2(320, 245), new Vector2(320, 235));
                bg.Move(OsbEasing.InOutSine, Beatmap.GetTimingPointAt(startTime).BeatDuration*4, Beatmap.GetTimingPointAt(startTime).BeatDuration*8, new Vector2(320, 235), new Vector2(320, 245));
            bg.EndGroup();

            bg = layer.CreateSprite("sb/utopiaBLUR.png", OsbOrigin.Centre,new Vector2(320, 245));
            bg.Scale(startTime, 0.5);
            bg.StartLoopGroup(startTime, 2);
                bg.Fade(0, 0, 0.2, 0);
                bg.Fade(Beatmap.GetTimingPointAt(startTime).BeatDuration*8, Beatmap.GetTimingPointAt(startTime).BeatDuration*9, 0, 0.2);
                bg.Fade(Beatmap.GetTimingPointAt(startTime).BeatDuration*16, Beatmap.GetTimingPointAt(startTime).BeatDuration*16, 0.2, 0);
            bg.EndGroup();

            double time;
            Vector2 pos;
            for (int p = 0; p < 240; p++)
            {   time = Random(2000, 4000);
                OsbSprite particle = layer.CreateSprite("sb/p.png", OsbOrigin.Centre, new Vector2(Random(-107, 747), Random(0, 480)));
                pos = new Vector2(particle.PositionAt(startTime).X + Random(-5, 5), particle.PositionAt(startTime).Y + Random(-5, 5));
                particle.Fade(startTime, startTime, 0, Random(1, 7)/10d);
                particle.Fade(endTime, endTime, 1, 0);
                particle.StartLoopGroup(startTime, (int)((endTime - startTime)/time));
                
                    particle.Move(OsbEasing.InOutSine, 0, time*0.5, particle.PositionAt(startTime), pos);
                    particle.Move(OsbEasing.InOutSine,time*0.5, time, pos, particle.PositionAt(startTime));
                particle.EndGroup();

                particle.Scale(startTime, Random(10, 30)/52d);
                particle.Color(startTime, new Color4((byte)Random(120, 155), (byte)Random(50, 70), (byte)Random(190, 255), 100));
            }

            
            OsbSprite vignette = layer.CreateSprite("sb/v2.png", OsbOrigin.Centre, CENTER);
            vignette.Fade(startTime, startTime, 0, 0.5);
            vignette.Color(startTime, Color4.MidnightBlue);
            vignette.Fade(endTime, endTime, 1, 0);
            vignette.Scale(startTime, 480.0d/1080.0d);

        }
    }
}

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
    public class M : StoryboardObjectGenerator
    {
        internal StoryboardLayer layer;
        internal Vector2 CENTER = new Vector2(320, 240);
        
        internal int startTime = 266294, endTime = 280412;
        public override void Generate()
        {
		    layer = GetLayer("M");
            
            OsbSprite vignette = layer.CreateSprite("sb/v2.png", OsbOrigin.Centre, CENTER);
            vignette.Fade(startTime, 274765, 0, 1);
            vignette.Fade(274765, 277588, 1, 0);
            vignette.Scale(startTime, 480.0/1080.0);
            vignette.Color(startTime, Color4.Black);

            OsbSprite star = layer.CreateSprite("sb/star.png", OsbOrigin.Centre, CENTER);
            star.Scale(271941, 0.8);
            star.Fade(271941, 273353, 1, 0);
            star.Rotate(OsbEasing.OutQuart, 271941, 273353, 0.4, 0.3);
            
            OsbSprite logo = layer.CreateSprite("sb/tera.png", OsbOrigin.Centre, new Vector2(200, 425));
            logo.Fade(startTime, 274765, 0, 1);
            logo.Fade(274765, 277588, 1, 0);
            logo.Scale(startTime, 0.3);


            logo = layer.CreateSprite("sb/terabottomtxt.png", OsbOrigin.Centre, new Vector2(440, 410));
            logo.Fade(startTime, 274765, 0, 1);
            logo.Fade(274765, 277588, 1, 0);
            logo.Scale(startTime, 0.7);
        }
        
        
    }
}

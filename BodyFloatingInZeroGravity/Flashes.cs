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
    public class Flashes : StoryboardObjectGenerator
    {
        internal Vector2 CENTER = new Vector2(320, 240);
        internal StoryboardLayer layer;
        internal OsbSprite flash;
        public override void Generate()
        {
            layer = GetLayer("");
            flash = layer.CreateSprite("sb/1px.png", OsbOrigin.Centre, CENTER);
            flash.ScaleVec(40412, 40412, 1, 1, 854, 480);
            Flash(40412, 40765, 1);
            /*Flash(41823, 42176, 0.2);
            Flash(43235, 43765, 0.1);
            Flash(43765, 44294, 0.2);
            Flash(44294, 45706, 0.5);
            Flash(46059, 46765, 0.9);
            Flash(47470, 47823, 0.1);
            Flash(48882, 49412, 0.1);
            Flash(49412, 49941, 0.2);
            Flash(49941, 50647, 0.5);
            Flash(50647, 51000, 0.05);
            Flash( 51000, 51353, 0.05);
            Flash( 51353, 51706, 0.05);
            Flash( 51706, 52412, 1);
		    */
            Flash( 51706, 52412, 1);
            Flash( 63000, 63706, 1);
            Flash(74294, 75000, 1);
            Flash(79941, 80647, 0.2);
            
            flash.Color(90529, 90529, Color4.White, Color4.Red);
            Flash(90529, 91235, 0.2);
            flash.Color(91235,91235,Color4.Red, Color4.White);
            Flash(85588, 86294, 0.5);

            Flash(96882, 97588, 1);
            Flash(102529, 103235, 0.2);
            Flash(108176, 108882, 0.2);
            Flash(113823, 114529, 0.2);
            Flash(119470, 125117, 1);
            Flash(116647, 119470, -0.8);
            Flash(153353, 154059, 1);
            Flash(154765, 155117, 0.2);
            Flash(156176, 156706, 0.1);
            Flash(156706, 157235, 0.1);
            Flash(157235, 157941, 0.1);
            Flash(159000, 159353, 0.2);
            Flash(160412, 160765, 0.2);
            Flash(161823, 162353, 0.1);
            Flash(162353, 162882, 0.1);
            Flash(162882, 163588, 0.2);
            Flash(164647, 165706, 0.5);
            Flash(166059, 166412, 0.2);
            Flash(167470, 168000, 0.1);
            Flash(168000, 168529, 0.1);
            Flash(168529, 169235, 0.2);
            Flash(169588, 169941, 0.05);
            Flash(170294, 170647, 0.2);
            Flash(171706, 172059, 0.2);
            Flash(173117, 173823, 0.3);
            Flash(174529, 175941, -0.7);
            Flash(175941, 180176, 1);
            flash.Color(185823, 185823, Color4.White, Color4.Orange);
            Flash(185823, 186529, 0.1);
            flash.Color(186529, 186529, Color4.Orange, Color4.White);
            Flash(187235, 187941, 1);

            flash.Color(192882, 192882, Color4.White, Color4.Red);
            Flash(192882, 193588, 0.2);
            Flash(193588, 194294, 0.2);
            Flash(194294, 195000, 0.2);
            Flash(195000, 195706, 0.2);
            Flash(195706, 196412, 0.2);
            Flash(196412,197823, -0.4);
            Flash(197823,198529, 0.4);
            flash.Color(198529, 198529, Color4.Red, Color4.White);
            Flash(198529,199235, 1);
            Flash(204176, 204882, 0.3);
            Flash(209823, 210529, 0.5);
            flash.Color(214765, 214765, Color4.White, Color4.Red);
            Flash(214765, 215470, 0.1);
            flash.Color(215470, 215470, Color4.Red, Color4.White);
            Flash(221117, 221823, 1);
            Flash(226765, 227470, 0.2);
            Flash(232412, 232588, 0.05);
            Flash(232588, 232765, 0.05);
            Flash( 232765, 233823, 0.4);
            Flash(238059, 240882, -0.1);
            Flash(240882, 243706, -0.6);
            Flash(243706, 244412, 1);
            Flash(255000, 256412, 1);
            Flash(266294, 277588, 1);
            Flash(264882, 266294, -0.8);
            
        }

        internal void Flash(double starttime, double endtime, double opacity)
        {
            if (opacity < 0) flash.Fade(starttime, endtime, 0, -opacity);
            else
            flash.Fade(starttime, endtime, opacity, 0);
        }
    }
}

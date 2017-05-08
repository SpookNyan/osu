﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Primitives;
using osu.Game.Graphics;
using osu.Game.Graphics.Sprites;
using System;

namespace osu.Game.Screens.Play
{
    public class SongProgressInfo : Container
    {
        private OsuSpriteText timeCurrent;
        private OsuSpriteText timeLeft;
        private OsuSpriteText progress;

        private double currentTime;
        private double songLenght;

        private const int margin = 10;

        public double SongLenght { set { songLenght = value; } }
        public double CurrentTime
        {
            set
            {
                currentTime = value;
                if (value > 0)
                {
                    timeCurrent.Text = TimeSpan.FromMilliseconds(value).ToString(@"m\:ss");
                    timeLeft.Text = @"-" + TimeSpan.FromMilliseconds(songLenght - value).ToString(@"m\:ss");
                }
            }
        }
        public float Progress
        {
            set
            {
                if (currentTime > 0)
                    progress.Text = value.ToString("P0");
            }
        }

        [BackgroundDependencyLoader]
        private void load(OsuColour colours)
        {
            Children = new Drawable[]
            {
                timeCurrent = new OsuSpriteText
                {
                    Origin = Anchor.BottomLeft,
                    Anchor = Anchor.BottomLeft,
                    Colour = colours.BlueLighter,
                    Font = @"Venera",
                    Margin = new MarginPadding
                    {
                        Left = margin,
                    },
                    Text = @"0:00",
                },
                progress = new OsuSpriteText
                {
                    Origin = Anchor.BottomCentre,
                    Anchor = Anchor.BottomCentre,
                    Colour = colours.BlueLighter,
                    Font = @"Venera",
                    Text = @"0%",
                },
                timeLeft = new OsuSpriteText
                {
                    Origin = Anchor.BottomRight,
                    Anchor = Anchor.BottomRight,
                    Colour = colours.BlueLighter,
                    Font = @"Venera",
                    Margin = new MarginPadding
                    {
                        Right = margin,
                    },
                    Text = @"-" + TimeSpan.FromMilliseconds(songLenght).ToString(@"m\:ss"),
                }
            };
        }
    }
}

﻿//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Game.Modes.Objects.Drawables;
using osu.Game.Modes.UI;
using OpenTK;
using OpenTK.Graphics;

namespace osu.Game.Modes.Osu.UI
{
    public class OsuPlayfield : Playfield
    {
        protected override Container<Drawable> Content => hitObjectContainer;

        private Container hitObjectContainer;

        public override Vector2 Size
        {
            get
            {
                var parentSize = Parent.DrawSize;
                var aspectSize = parentSize.X * 0.75f < parentSize.Y ? new Vector2(parentSize.X, parentSize.X * 0.75f) : new Vector2(parentSize.Y * 4f / 3f, parentSize.Y);

                return new Vector2(aspectSize.X / parentSize.X, aspectSize.Y / parentSize.Y) * base.Size;
            }
        }

        public OsuPlayfield()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            RelativeSizeAxes = Axes.Both;
            Size = new Vector2(0.75f);

            AddInternal(new Box
            {
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Colour = Color4.Black,
                Alpha = 0.5f,
            });

            AddInternal(hitObjectContainer = new HitObjectContainer
            {
                RelativeSizeAxes = Axes.Both,
            });
        }

        class HitObjectContainer : Container
        {
            protected override Vector2 DrawScale => new Vector2(DrawSize.X / 512);
        }
    }
}
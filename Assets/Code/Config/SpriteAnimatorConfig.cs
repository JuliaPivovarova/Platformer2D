﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Config
{
    [CreateAssetMenu(fileName = "SpriteAnimatorCfg", menuName = "Configs / Animation Cfg", order = 1)]
    public class SpriteAnimatorConfig: ScriptableObject
    {
        [Serializable]
        public sealed class SpriteSequence
        {
            public AnimState Track;
            public List<Sprite> Sprites = new List<Sprite>();
        }

        public List<SpriteSequence> Sequences = new List<SpriteSequence>();
    }
}
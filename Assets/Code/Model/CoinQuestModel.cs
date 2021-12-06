﻿using Code.Interfaces;
using UnityEngine;

namespace Code.Model
{
    public class CoinQuestModel : IQuestModel
    {
        private const string TargetTag = "Player";
        public bool TryComplete(GameObject activator)
        {
            return activator.CompareTag(TargetTag);
        }
    }
}
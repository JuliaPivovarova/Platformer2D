using System;
using System.Collections.Generic;
using Code.Interfaces;
using UnityEngine;

namespace Code
{
    public class ProtectedZone
    {
        private readonly List<IProtector> _protectors;
        private readonly LevelObjectTrigger _viewTrigger;

        public ProtectedZone(LevelObjectTrigger viewTrigger, List<IProtector> protectors)
        {
            _viewTrigger = viewTrigger != null ? viewTrigger : throw new ArgumentNullException(nameof(viewTrigger));
            _protectors = protectors != null ? protectors : throw new ArgumentNullException(nameof(protectors));
        }

        public void Init()
        {
            _viewTrigger.TriggerEnter += OnContact;
            _viewTrigger.TriggerExit += OnExit;
        }

        public void DeInit()
        {
            _viewTrigger.TriggerEnter -= OnContact;
            _viewTrigger.TriggerExit -= OnExit;
        }

        private void OnContact(object sender, GameObject gameObject)
        {
            foreach (var protector in _protectors)
            {
                protector.StartProtection(gameObject);
            }
        }

        private void OnExit(object sender, GameObject gameObject)
        {
            foreach (var protector in _protectors)
            {
                protector.FinishProtection(gameObject);
            }
        }
    }
}
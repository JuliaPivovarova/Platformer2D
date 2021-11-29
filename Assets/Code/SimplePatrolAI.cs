using System;
using Code.View;
using UnityEngine;

namespace Code
{
    public class SimplePatrolAI
    {
        private readonly LevelObjectsView _view;
        private readonly SimplePatrolAIModel _model;

        public SimplePatrolAI(LevelObjectsView view, SimplePatrolAIModel model)
        {
            _view = view != null ? view : throw new ArgumentNullException(nameof(view));
            _model = model != null ? model : throw new ArgumentNullException(nameof(model));
        }

        public void FixedUpdate()
        {
            var newVelocity = _model.CalculateVelocity(_view.transform.position) * Time.fixedDeltaTime;
            _view.rigidbody.velocity = newVelocity;
        }
    }
}
using System;
using System.Collections.Generic;
using Code.Interfaces;
using Code.Model;
using Code.View;
using Pathfinding;
using UnityEngine;

namespace Code
{
    public class EnemiesConfigurator : MonoBehaviour
    {
        [Header("Simple AI")] 
        [SerializeField] private AIConfig simplePatrolAIConfig;
        [SerializeField] private LevelObjectsView simplePatrolAIView;

        [Header("Stalker AI")] 
        [SerializeField] private LevelObjectsView stalkerAIView;
        [SerializeField] private AIConfig stalkerAIConfig;
        [SerializeField] private Seeker stalkerAISeeker;
        [SerializeField] private Transform stalkerAITarget;

        [Header("Protector AI")] 
        [SerializeField] private LevelObjectsView protectorAIView;
        [SerializeField] private AIDestinationSetter protectorAIDestinationSetter;
        [SerializeField] private AIPatrolPath protectorAIPatrolPath;
        [SerializeField] private LevelObjectTrigger protectedZoneTrigger;
        [SerializeField] private Transform[] protectorWayPoint;

        private SimplePatrolAI _simplePatrolAI;
        private StalkerAI _stalkerAI;
        private ProtectorAI _protectorAI;
        private ProtectedZone _protectedZone;

        private void Start()
        {
            _simplePatrolAI = new SimplePatrolAI(simplePatrolAIView, new SimplePatrolAIModel(simplePatrolAIConfig));
            _stalkerAI = new StalkerAI(stalkerAIView, new StalkerAIModel(stalkerAIConfig), stalkerAISeeker,
                stalkerAITarget);
            InvokeRepeating(nameof(RecalculateAIPath), 0.0f, 1.0f);

            _protectorAI = new ProtectorAI(protectorAIView, new PatrolAIModel(protectorWayPoint),
                protectorAIDestinationSetter, protectorAIPatrolPath);
            _protectorAI.Init();
            _protectedZone = new ProtectedZone(protectedZoneTrigger, new List<IProtector> { _protectorAI });
            _protectedZone.Init();
            _stalkerAI.Start();
        }

        private void FixedUpdate()
        {
            if (_simplePatrolAI != null) _simplePatrolAI.FixedUpdate();
            if (_stalkerAI != null) _stalkerAI.FixedUpdate();
        }

        private void OnDestroy()
        {
            _protectorAI.DeInit();
            _protectedZone.DeInit();
        }

        private void RecalculateAIPath()
        {
            _stalkerAI.RecalculatePath();
        }
    }
}
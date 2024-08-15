using System;
using GameStates;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Entities.Enemies
{
    public class EnemyConfiguration : MonoBehaviour
    {
        [SerializeField] private EnemySo[] entities;

        private bool _isInitialized;
        
        private void OnEnable()
        {
            if (_isInitialized)
            {
                GameState.IdleState.IdleStateStarted += Init;
            }
        }

        private void OnDisable()
        {
            GameState.IdleState.IdleStateStarted -= Init;
        }

        public void Init()
        {
            if (!_isInitialized)
            {
                GameState.IdleState.IdleStateStarted += Init;
                _isInitialized = true;
            }
            
            GetRandomEntity();
            Entities.Enemy.Data = GetRandomEntity();
            Entities.Enemy.Init();
        }

        private EnemySo GetRandomEntity()
        {
            for (int i = 0; i < entities.Length; i++)
            {
                if (RandomChance.Random(entities[i].SpawnChance))
                {
                    return entities[i];
                }
            }

            return entities[Random.Range(0, entities.Length)];
        }
    }
}
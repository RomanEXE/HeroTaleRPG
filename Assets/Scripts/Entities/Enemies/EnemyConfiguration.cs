using DefaultNamespace;
using GameStates;
using UnityEngine;

namespace Entities.Enemies
{
    public class EnemyConfiguration : MonoBehaviour
    {
        [SerializeField] private EntityDataSo enemyData;

        private void OnDisable()
        {
            GameState.IdleState.IdleStateStarted -= Configure;
        }

        private void Configure()
        {
            Fight.Enemy.Init(enemyData);
            Fight.Enemy.gameObject.SetActive(false);
        }

        public void Init()
        {
            GameState.IdleState.IdleStateStarted += Configure;
        }
    }
}
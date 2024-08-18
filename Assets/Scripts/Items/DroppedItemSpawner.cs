using Lean.Pool;
using UnityEngine;

namespace Items
{
    public class DroppedItemSpawner : MonoBehaviour
    {
        public static DroppedItemSpawner Instance { get; private set; }
        
        [SerializeField] private SpriteRenderer droppedItemPrefab;
        [SerializeField] private float despawnTime;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void SpawnItem(ItemSo itemSo, Vector3 spawnPosition)
        {
            SpriteRenderer spawnedItem = LeanPool.Spawn(droppedItemPrefab, spawnPosition, Quaternion.identity);
            spawnedItem.sprite = itemSo.Icon;
            LeanPool.Despawn(spawnedItem, despawnTime);
        }
    }
}
using Lean.Pool;
using UnityEngine;

namespace Inventory.Items
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

        public void SpawnItem(Item item, Vector3 spawnPosition)
        {
            SpriteRenderer spawnedItem = LeanPool.Spawn(droppedItemPrefab, spawnPosition, Quaternion.identity);
            spawnedItem.sprite = item.Icon;
            LeanPool.Despawn(spawnedItem, despawnTime);
        }
    }
}
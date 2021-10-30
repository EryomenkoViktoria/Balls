using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField]
    private Block blockPrefab;

    private int playWidth = 8;
    private float distanceBetweenBloñks = 0.7f;
    private int rowSpawned;
    private List<Block> blocksSpawned = new List<Block>();

    private void OnEnable()
    {
        for (int i = 0; i < 1; i++)
            SpawnRowOfBlock();
    }
    public void SpawnRowOfBlock()
    {
        foreach (var block in blocksSpawned)
        {
            if (block != null)
                block.transform.position += Vector3.down * distanceBetweenBloñks;
        }

        for (int i = 0; i < playWidth; i++)
        {
            if (UnityEngine.Random.Range(0, 100) <= 30)

            {
                var block = Instantiate(blockPrefab, GetPosition(i), Quaternion.identity);
                int hits = UnityEngine.Random.Range(1, 3) + rowSpawned;
                block.SetHits(hits);
                blocksSpawned.Add(block);
            }
        }
        rowSpawned++;
    }

    private Vector3 GetPosition(int i)
    {
        Vector3 position = transform.position;
        position += Vector3.right * i * distanceBetweenBloñks;
        return position;
    }
}

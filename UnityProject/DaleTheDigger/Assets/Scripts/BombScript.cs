using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour
{
    public GameObject bombPrefab;
    public float bombForce = 5.0f;
    public float bombRadius = 2.0f;
    public float bombTimer = 2.0f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ThrowBomb();
        }
    }

    private void ThrowBomb()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0.0f;

        Vector3 throwDirection = (mousePosition - transform.position).normalized;

        GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
        Rigidbody2D bombRb = bomb.GetComponent<Rigidbody2D>();

        bombRb.velocity = throwDirection * bombForce;

        StartCoroutine(ExplodeAfterDelay(bomb));
    }

    private IEnumerator ExplodeAfterDelay(GameObject bomb)
    {
        yield return new WaitForSeconds(bombTimer);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(bomb.transform.position, bombRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Block"))
            {
                CollectAndDestroyBlock(collider.gameObject);
            }
        }

        Destroy(bomb);
    }

    private void CollectAndDestroyBlock(GameObject block)
    {
        TileDataPlaceholder tdp = block.GetComponent<TileDataPlaceholder>();
        int coinWorth = tdp.thisTile.coinWorth;

        int amountToDrop = 1; // Default amount dropped

        if (Random.value <= 0.05f) // 5% chance for double drop
        {
            amountToDrop = 2; // Double drop
        }

        // Determine the type of material and add it to the inventory
        switch (tdp.thisTile.tileType)
        {
            case TileTypes.Rock:
                Inventory.Rocks += amountToDrop;
                Inventory.Rockcoins += coinWorth * amountToDrop;
                break;
            case TileTypes.Ore:
                Inventory.Ores += amountToDrop;
                Inventory.Orescoins += coinWorth * amountToDrop;
                break;
            case TileTypes.Gemstone:
                Inventory.Gemstones += amountToDrop;
                Inventory.Gemstonecoins += coinWorth * amountToDrop;
                break;
                // Add more cases for other tile types if needed
        }

        Inventory.Totalcoins += coinWorth * amountToDrop; // Add coins to the total

        // Destroy the block
        Destroy(block);
    }
}
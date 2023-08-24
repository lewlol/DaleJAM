using UnityEngine;
using System.Collections;
using TMPro;

public class BombScript : MonoBehaviour
{
    public GameObject bombPrefab;
    public float bombForce = 5.0f;
    public float bombRadius = 2.0f;
    public float bombTimer = 2.0f;

    public MeshTextAppear mta;
    public TextMeshProUGUI bombCount;

    private bool canThrowBomb = true; // Add this variable
    private float throwCooldown = 3.0f; // Add this variable

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && canThrowBomb && Inventory.bombs > 0) // Check if the player has bombs and cooldown is over
        {
            ThrowBomb();
        }
    }

    private void ThrowBomb()
    {
        canThrowBomb = false; // Disable bomb throwing
        Inventory.bombs--; // Decrement the bomb count

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0.0f;

        Vector3 throwDirection = (mousePosition - transform.position).normalized;

        GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
        Rigidbody2D bombRb = bomb.GetComponent<Rigidbody2D>();

        bombRb.velocity = throwDirection * bombForce;

        StartCoroutine(ExplodeAfterDelay(bomb));
        bombCount.text = Inventory.bombs.ToString();
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
                mta.GenerateText(collider.gameObject.transform.position, 2f, "+1 " + collider.gameObject.GetComponent<TileDataPlaceholder>().thisTile.name, 30);
            }
        }

        Destroy(bomb);

        yield return new WaitForSeconds(throwCooldown); // Add this line
        canThrowBomb = true; // Re-enable bomb throwing
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
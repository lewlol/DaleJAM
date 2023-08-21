using UnityEngine;

public class MiningScript : MonoBehaviour
{
    public float miningRange = 2.0f;
    public float holdDuration = 2.0f;
    public Material highlightMaterial;

    private GameObject lastHighlightedBlock;
    private Material originalMaterial;
    private float holdTimer;
    private bool isHolding;
    private Vector3 originalBlockPosition;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (lastHighlightedBlock != null && lastHighlightedBlock != hit.collider?.gameObject)
        {
            RestoreOriginalMaterial();
            isHolding = false;
            holdTimer = 0.0f;
        }

        if (hit.collider != null && hit.collider.CompareTag("Block") && IsInRange(hit.collider.gameObject))
        {
            HighlightBlock(hit.collider.gameObject);

            if (Input.GetMouseButton(0))
            {
                if (!isHolding)
                {
                    isHolding = true;
                    originalBlockPosition = hit.collider.transform.position;
                }

                if (PlayerMovement.stamina > 0) // Check if the player has enough stamina
                {
                    holdTimer += Time.deltaTime;

                    if (holdTimer >= holdDuration)
                    {
                        BlockStats(hit);
                        Destroy(hit.collider.gameObject);
                        RestoreOriginalMaterial();
                        isHolding = false;
                        holdTimer = 0.0f;
                    }
                }
                else
                {
                    // Display a message to the user indicating not enough stamina
                    Debug.Log("Not enough stamina to break this block!");
                }
            }
            else
            {
                isHolding = false;
                holdTimer = 0.0f;
            }
        }
        else
        {
            isHolding = false;
            holdTimer = 0.0f;
        }
    }

    private bool IsInRange(GameObject block)
    {
        float distance = Vector2.Distance(transform.position, block.transform.position);
        return distance <= miningRange;
    }

    private void HighlightBlock(GameObject block)
    {
        if (block != lastHighlightedBlock)
        {
            RestoreOriginalMaterial();
            lastHighlightedBlock = block;

            originalMaterial = block.GetComponent<Renderer>().material;
            block.GetComponent<Renderer>().material = highlightMaterial;
        }
    }

    private void RestoreOriginalMaterial()
    {
        if (lastHighlightedBlock != null && originalMaterial != null)
        {
            lastHighlightedBlock.GetComponent<Renderer>().material = originalMaterial;
            lastHighlightedBlock = null;
        }
    }

    private void BlockStats(RaycastHit2D hit)
    {
        // when a block is broken

        PlayerMovement.stamina--;


        TileDataPlaceholder tdp = hit.collider.gameObject.GetComponent<TileDataPlaceholder>();
        Inventory.Totalcoins += tdp.thisTile.coinWorth;

        if (tdp.thisTile.tileType == TileTypes.Rock)
        {
            Inventory.Rocks++;
            Inventory.Rockcoins += tdp.thisTile.coinWorth;
        }
        else if (tdp.thisTile.tileType == TileTypes.Ore)
        {
            Inventory.Ores++;
            Inventory.Orescoins += tdp.thisTile.coinWorth;
        }
        else if (tdp.thisTile.tileType == TileTypes.Gemstone)
        {
            Inventory.Gemstones++;
            Inventory.Gemstonecoins += tdp.thisTile.coinWorth;
        }
    }
}
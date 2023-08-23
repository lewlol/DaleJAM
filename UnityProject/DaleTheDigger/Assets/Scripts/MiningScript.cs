using UnityEngine;
using TMPro;
using System.Collections;

public class MiningScript : MonoBehaviour
{
    public float miningRange = 2.0f;
    public float holdDuration = 2.0f;
    public Material highlightMaterial;

    private GameObject lastHighlightedBlock;
    private Material originalMaterial;
    private Material outlineMaterial; // Assign the outline material in the inspector
    private float holdTimer;
    private bool isHolding;
    private Vector3 originalBlockPosition;

    public GameObject outofstaminaui;
    public TextMeshProUGUI insufficientPowerText;

    private bool isInsufficientPowerTextActive = false;
    private Coroutine insufficientPowerCoroutine;

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
                    // Additional check for breaking power
                    TileDataPlaceholder tdp = hit.collider.gameObject.GetComponent<TileDataPlaceholder>();
                    int requiredBreakingPower = tdp.thisTile.breakingpower;
                    int playerBreakingPower = PlayerMovement.breakingpower;

                    if (playerBreakingPower >= requiredBreakingPower) // Player has enough breaking power
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
                        if (!isInsufficientPowerTextActive)
                        {
                            insufficientPowerText.gameObject.SetActive(true);
                            insufficientPowerCoroutine = StartCoroutine(HideInsufficientPowerTextAfterDelay());
                            isInsufficientPowerTextActive = true;
                        }
                        Debug.Log("Pickaxe not strong enough to break this block!");
                    }
                }
                else
                {
                    // Display a message to the user indicating not enough stamina
                    Debug.Log("Not enough stamina to break this block!");
                    outofstaminaui.SetActive(true);
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
            block.GetComponent<Renderer>().material = outlineMaterial; // Use the outline material here
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
        PlayerMovement.stamina--;
        int fortuneLevel = PlayerMovement.fortune;

        TileDataPlaceholder tdp = hit.collider.gameObject.GetComponent<TileDataPlaceholder>();
        int coinWorth = tdp.thisTile.coinWorth;

        //5% chance every level
        float chanceForDoubleDrop = 0.05f * fortuneLevel;

        if (Random.value <= chanceForDoubleDrop) // Check if the player gets double drops
        {
            Inventory.Totalcoins += coinWorth * 2;

            if (tdp.thisTile.tileType == TileTypes.Rock)
            {
                Inventory.Rocks += 2;
                Inventory.Rockcoins += coinWorth * 2;
            }
            else if (tdp.thisTile.tileType == TileTypes.Ore)
            {
                Inventory.Ores += 2;
                Inventory.Orescoins += coinWorth * 2;
            }
            else if (tdp.thisTile.tileType == TileTypes.Gemstone)
            {
                Inventory.Gemstones += 2;
                Inventory.Gemstonecoins += coinWorth * 2;
            }
        }
        else // Regular drop
        {
            Inventory.Totalcoins += coinWorth;

            if (tdp.thisTile.tileType == TileTypes.Rock)
            {
                Inventory.Rocks++;
                Inventory.Rockcoins += coinWorth;
            }
            else if (tdp.thisTile.tileType == TileTypes.Ore)
            {
                Inventory.Ores++;
                Inventory.Orescoins += coinWorth;
            }
            else if (tdp.thisTile.tileType == TileTypes.Gemstone)
            {
                Inventory.Gemstones++;
                Inventory.Gemstonecoins += coinWorth;
            }
        }
    }

    private IEnumerator HideInsufficientPowerTextAfterDelay()
    {
        yield return new WaitForSeconds(2.0f);
        insufficientPowerText.gameObject.SetActive(false);
        isInsufficientPowerTextActive = false;
    }
}
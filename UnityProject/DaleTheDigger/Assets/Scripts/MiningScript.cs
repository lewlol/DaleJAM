using UnityEngine;
using TMPro;
using System.Collections;

public class MiningScript : MonoBehaviour
{
    public float holdDuration = 2f;
    public Material highlightMaterial;

    private GameObject lastHighlightedBlock;
    private Material originalMaterial;
    private float holdTimer;
    private bool isHolding;
    private Vector3 originalBlockPosition;

    public GameObject outofstaminaui;
    public TextMeshProUGUI insufficientPowerText;

    private bool isInsufficientPowerTextActive = false;
    private Coroutine insufficientPowerCoroutine;

    private Vector3 originalPosition; // Store the original position of the block
    private Vector3 shakeOffset; // Store the current shake offset

    public MeshTextAppear tma;
    int amountDropped;
    private void Start()
    {
        originalPosition = Vector3.zero; // Initialize originalPosition
        shakeOffset = Vector3.zero; // Initialize shakeOffset
    }

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

                if (PlayerMovement.stamina > 0)
                {
                    TileDataPlaceholder tdp = hit.collider.gameObject.GetComponent<TileDataPlaceholder>();
                    int requiredBreakingPower = tdp.thisTile.breakingpower;
                    int playerBreakingPower = PlayerMovement.breakingpower;

                    if (playerBreakingPower >= requiredBreakingPower)
                    {
                        holdTimer += Time.deltaTime;

                        // Apply shaking effect while mining
                        float shakeMagnitude = 0.05f; // Adjust the magnitude as needed
                        shakeOffset = Random.insideUnitCircle * shakeMagnitude;
                        hit.collider.transform.position = originalPosition + shakeOffset;

                        if (holdTimer >= holdDuration)
                        {
                            BlockStats(hit);
                            Vector2 blockpos = hit.collider.transform.position;
                            string text = tdp.thisTile.name;
                            RestoreOriginalMaterial();
                            isHolding = false;
                            holdTimer = 0.0f;

                            //Text 
                            tma.GenerateText(blockpos, 1, "+" + amountDropped + " " + text, 30);

                            StartCoroutine(DestroyDelay(hit));
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
        return distance <= Artefacts.miningrange;
    }

    private void HighlightBlock(GameObject block)
    {
        if (block != lastHighlightedBlock)
        {
            RestoreOriginalMaterial();
            lastHighlightedBlock = block;

            originalMaterial = block.GetComponent<Renderer>().material;
            block.GetComponent<Renderer>().material = block.GetComponent<Renderer>().material; // Use the outline material here
            originalPosition = block.transform.position; // Store the original position
        }
    }

    private void RestoreOriginalMaterial()
    {
        if (lastHighlightedBlock != null && originalMaterial != null)
        {
            lastHighlightedBlock.GetComponent<Renderer>().material = originalMaterial;
            //lastHighlightedBlock.GetComponentInChildren<SpriteRenderer>().enabled = false;
            lastHighlightedBlock.transform.position = originalPosition; // Restore the original position
            lastHighlightedBlock = null;
        }
    }


    private void BlockStats(RaycastHit2D hit)
    {
        float currentStaminaChance = Mathf.Clamp(Artefacts.staminachance, 0.0f, 1.0f);
        if (Random.value <= currentStaminaChance)
        {
            PlayerMovement.stamina--;
        }

        int fortuneLevel = PlayerMovement.fortune;

        TileDataPlaceholder tdp = hit.collider.gameObject.GetComponent<TileDataPlaceholder>();
        int coinWorth = tdp.thisTile.coinWorth;

        //5% chance every level
        float chanceForDoubleDrop = 0.05f * fortuneLevel;

        if (Random.value <= chanceForDoubleDrop) // Check if the player gets double drops
        {
            Inventory.Totalcoins += coinWorth * 2;
            amountDropped = 2;
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
            amountDropped = 1;
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

    public IEnumerator DestroyDelay(RaycastHit2D hit)
    {
        hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        hit.collider.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(2f);
        Destroy(hit.collider.gameObject);
    }
}
using UnityEngine;

public class MiningScript : MonoBehaviour
{
    public float miningRange = 2.0f; // Adjust this range as needed
    public float holdDuration = 2.0f; // Time in seconds to hold down
    public float shakeIntensity = 0.05f; // Intensity of the shake
    public Material highlightMaterial;

    private GameObject lastHighlightedBlock;
    private Material originalMaterial;
    private float holdTimer;
    private bool isHolding;
    private Vector3 originalBlockPosition;
    private bool isShaking;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (lastHighlightedBlock != null && (lastHighlightedBlock != hit.collider?.gameObject || !IsInRange(hit.collider?.gameObject)))
        {
            RestoreOriginalMaterial();
            isHolding = false;
            holdTimer = 0.0f;
            isShaking = false;
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

                holdTimer += Time.deltaTime;

                if (holdTimer >= holdDuration)
                {
                    Destroy(hit.collider.gameObject);
                    RestoreOriginalMaterial();
                    isHolding = false;
                    holdTimer = 0.0f;
                    isShaking = false;
                }
                else
                {
                    isShaking = true;
                }
            }
            else
            {
                isHolding = false;
                holdTimer = 0.0f;
                isShaking = false;
            }
        }
        else
        {
            isHolding = false;
            holdTimer = 0.0f;
            isShaking = false;
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

        if (isHolding)
        {
            if (isShaking)
            {
                ShakeBlock(block);
            }
            else
            {
                block.transform.position = originalBlockPosition;
            }
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

    private void ShakeBlock(GameObject block)
    {
        float xOffset = Random.Range(-shakeIntensity, shakeIntensity);
        float yOffset = Random.Range(-shakeIntensity, shakeIntensity);
        block.transform.position = originalBlockPosition + new Vector3(xOffset, yOffset, 0);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class PressurePlateTrap : MonoBehaviour
{
    public GameObject particles;
    public Light2D explosionLight;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(ExplodeAfterDelay(gameObject));
        }
    }

    private IEnumerator ExplodeAfterDelay(GameObject pressurePlate)
    {
        yield return new WaitForSeconds(0);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(pressurePlate.transform.position, 5);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Block"))
            {
                CollectAndDestroyBlock(collider.gameObject);
            }
        }

        StartCoroutine(LightIncrease());
        explosionLight.pointLightOuterRadius += 0.5f;

        BoxCollider2D bx = GetComponent<BoxCollider2D>();
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        bx.enabled = false;
        sr.enabled = false;
        particles.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        Destroy(pressurePlate);
    }

    private void CollectAndDestroyBlock(GameObject block)
    {
        TileDataPlaceholder tdp = block.GetComponent<TileDataPlaceholder>();
        int coinWorth = tdp.thisTile.coinWorth;

        // Destroy the block
        Destroy(block);
    }

    IEnumerator LightIncrease()
    {
        explosionLight.pointLightOuterRadius += 0.5f;
        yield return new WaitForSeconds(0.1f);
        explosionLight.pointLightOuterRadius += 0.5f;
        yield return new WaitForSeconds(0.1f);
        explosionLight.pointLightOuterRadius += 0.5f;
        yield return new WaitForSeconds(0.1f);
        explosionLight.pointLightOuterRadius += 0.5f;
        yield return new WaitForSeconds(0.1f);
        explosionLight.pointLightOuterRadius += 0.5f;
        yield return new WaitForSeconds(0.1f);
        explosionLight.pointLightOuterRadius += 0.5f;
        yield return new WaitForSeconds(0.1f);
        explosionLight.pointLightOuterRadius = 0f;
    }
}

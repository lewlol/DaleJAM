using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject Player;
    public GameObject DeathSpawnPoint;
    public GameObject otherui;
    public GameObject sleepui;
    public HealthStamUI hs;

    public GameObject indicatorText;

    public GameObject fadeIn;
    public GameObject fadeOut;
    public void Respawn()
    {
        StartCoroutine(Died());
    }
    public void AffectHealthUI(int mh, int h)
    {
        hs.UpdateHealthUI(mh, h);
    }

    IEnumerator Died()
    {
        Player.GetComponent<CapsuleCollider2D>().enabled = false;
        Player.GetComponent<SpriteRenderer>().enabled = false;
        indicatorText.GetComponent<TextMeshProUGUI>().text = "You Died!";
        Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(5);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1.4f);
        fadeIn.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        fadeIn.SetActive(true);
        fadeOut.SetActive(false);
        //clears inventory
        Inventory.deathinventory();
        otherui.SetActive(false);
        sleepui.SetActive(true);
        Player.transform.position = DeathSpawnPoint.transform.position;
        indicatorText.GetComponent<TextMeshProUGUI>().text = null;
    }
}

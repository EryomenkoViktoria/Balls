using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    private int hitsRemaing = 5;
    private SpriteRenderer spriteRenderer;
    private TextMeshPro text;
    private BoxCollider2D boxCollider2D;
    new ParticleSystem particleSystem;
    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        particleSystem = GetComponent<ParticleSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        text = GetComponentInChildren<TextMeshPro>();
    }

    private void UpdateVisualState()
    {
        text.SetText(hitsRemaing.ToString());
        spriteRenderer.color = Color.Lerp(Color.white, Color.red, hitsRemaing / 10f);
    }

    private async void OnCollisionEnter2D(Collision2D collision)
    {
        hitsRemaing--;
        if (hitsRemaing > 0)
            UpdateVisualState();
        else
        {
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            text.enabled = false;
            particleSystem.Play();
            await Task.Delay(1600);
            Destroy(gameObject);
        }
    }

    internal void SetHits(int hits)
    {
        hitsRemaing = hits;
        UpdateVisualState();
    }
}

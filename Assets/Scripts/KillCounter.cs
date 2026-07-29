using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI killCountText;

    private int killCount = 0;
    private Vector3 originalScale;

    // Animation settings
    [SerializeField] private float punchScale = 1.3f;
    [SerializeField] private float punchDuration = 0.15f;
    private float punchTimer;
    private bool isPunching;

    void Start()
    {
        originalScale = killCountText.rectTransform.localScale;
        UpdateDisplay();
    }

    void Update()
    {
        if (isPunching)
        {
            punchTimer -= Time.unscaledDeltaTime;

            if (punchTimer > 0f)
            {
                // Scale up phase (first half)
                float t = 1f - (punchTimer / punchDuration);
                float scale;

                if (t < 0.5f)
                {
                    // Scale up
                    scale = Mathf.Lerp(1f, punchScale, t * 2f);
                }
                else
                {
                    // Scale back down
                    scale = Mathf.Lerp(punchScale, 1f, (t - 0.5f) * 2f);
                }

                killCountText.rectTransform.localScale = originalScale * scale;
            }
            else
            {
                killCountText.rectTransform.localScale = originalScale;
                isPunching = false;
            }
        }
    }

    /// <summary>
    /// Call this from ZombieDeath when a zombie is killed.
    /// </summary>
    public void RegisterKill()
    {
        killCount++;
        UpdateDisplay();

        // Trigger scale punch animation
        isPunching = true;
        punchTimer = punchDuration;
    }

    private void UpdateDisplay()
    {
        killCountText.text = $"Kills: {killCount}";
    }

    public int GetKillCount()
    {
        return killCount;
    }
}

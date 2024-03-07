using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
    public TextMeshProUGUI ClicksTotalText;
    public TextMeshProUGUI CountdownText;
    public float clickCooldownDuration = 5f;
    private float clickCooldownTimer = 0f;
    private float TotalClicks = 0f;
    public Button ClickButton; // Reference to your UI button
    public GameObject Exit_btn; // Reference to the second button GameObject

    private void Start()
    {
        clickCooldownTimer = 0f;
    }

    private void Update()
    {
        clickCooldownTimer += Time.deltaTime;

        if (clickCooldownTimer >= clickCooldownDuration)
        {
            ClickButton.interactable = false; // Disable the button

            // Activate the second button GameObject:
            Exit_btn.SetActive(true); // Enable the second button
        }

        float remainingTime = Mathf.Max(0f, clickCooldownDuration - clickCooldownTimer);
        CountdownText.text = $"Countdown: {remainingTime:F1} s";
    }

    public void AddClicks()
    {
        TotalClicks++;
        ClicksTotalText.text = TotalClicks.ToString("0");
        clickCooldownTimer = 0f;
    }
}


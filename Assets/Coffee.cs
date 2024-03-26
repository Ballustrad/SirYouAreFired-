using MoreMountains.CorgiEngine;
using UnityEngine;
using UnityEngine.UI;

public class Coffee : MonoBehaviour
{

    int coffeeAmount;
    [SerializeField] Health health;
    int maxAmount;

    private float timer = 0f;
    private float interval = 1f;
    private bool isAlive = true; // Bool�en pour suivre si le personnage est en vie ou non
    public Image foregroundImage; // Image de foreground de la barre de progression
    public Image backgroundImage;
    private void Awake()
    {
        coffeeAmount = 100;
        maxAmount = 100;
    }

    private void Update()
    {
        if (isAlive) // V�rifie si le personnage est en vie avant d'incr�menter le timer
        {
            timer += Time.deltaTime; // Incr�mente le timer avec le temps �coul� depuis la derni�re frame

            if (timer >= interval)
            {
                LooseCoffee(10); // Appelle la fonction lorsque le timer atteint l'intervalle
                timer = 0f; // R�initialise le timer
            }
        }
        if (foregroundImage != null)
        {
            // Calculer la taille relative de la barre de progression en fonction de coffeeAmount
            float fillAmount = (float)coffeeAmount / maxAmount;
            // Limiter la taille de la barre de progression pour qu'elle ne d�passe pas la taille de l'image de background
            fillAmount = Mathf.Clamp01(fillAmount);
            // Appliquer la taille relative � l'image de foreground
            foregroundImage.fillAmount = fillAmount;
        }
    }

    public void LooseCoffee(int amount)
    {
        coffeeAmount -= amount;
        if (coffeeAmount < 0)
        {
            health.Kill();
            isAlive = false; // Met � jour le bool�en pour indiquer que le personnage est mort
        }
    }

    public void GainCoffee(int amount)
    {
        coffeeAmount += amount;
        if (coffeeAmount > maxAmount)
        {
            coffeeAmount = maxAmount;
        }
    }


}

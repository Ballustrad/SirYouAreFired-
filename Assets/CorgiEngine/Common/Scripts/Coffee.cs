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

    private void Awake()
    {
        coffeeAmount = 100;
        maxAmount = 100;
        foregroundImage = GameManager.Instance.forgroundBar;

    }

    private void Update()
    {
        if (isAlive) // V�rifie si le personnage est en vie avant d'incr�menter le timer
        {
            timer += Time.deltaTime; // Incr�mente le timer avec le temps �coul� depuis la derni�re frame

            if (timer >= interval)
            {
                LooseCoffee(5); // Appelle la fonction lorsque le timer atteint l'intervalle
                timer = 0f; // R�initialise le timer
            }

            float fillamount = (float)coffeeAmount / (float)maxAmount;
            foregroundImage.fillAmount = fillamount;
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
        Debug.Log("ui");
    }


}

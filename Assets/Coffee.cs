using MoreMountains.CorgiEngine;
using UnityEngine;

public class Coffee : MonoBehaviour
{

    int coffeeAmount;
    [SerializeField] Health health;
    int maxAmount;

    private float timer = 0f;
    private float interval = 1f;
    private bool isAlive = true; // Booléen pour suivre si le personnage est en vie ou non

    private void Awake()
    {
        coffeeAmount = 100;
        maxAmount = 100;
    }

    private void Update()
    {
        if (isAlive) // Vérifie si le personnage est en vie avant d'incrémenter le timer
        {
            timer += Time.deltaTime; // Incrémente le timer avec le temps écoulé depuis la dernière frame

            if (timer >= interval)
            {
                LooseCoffee(10); // Appelle la fonction lorsque le timer atteint l'intervalle
                timer = 0f; // Réinitialise le timer
            }
        }
    }

    public void LooseCoffee(int amount)
    {
        coffeeAmount -= amount;
        if (coffeeAmount < 0)
        {
            health.Kill();
            isAlive = false; // Met à jour le booléen pour indiquer que le personnage est mort
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

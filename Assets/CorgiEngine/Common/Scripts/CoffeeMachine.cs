using UnityEngine;

public class CoffeeMachine : MonoBehaviour
{
    private float timer = 0f;
    private float interval = 5f;
    bool canUseCoffeeMachine = true;
    private void Update()
    {
        if (!canUseCoffeeMachine)
        {
            timer += Time.deltaTime; // Incr�mente le timer avec le temps �coul� depuis la derni�re frame

            if (timer >= interval)
            {
                canUseCoffeeMachine = true; // Appelle la fonction lorsque le timer atteint l'intervalle
                timer = 0f; // R�initialise le timer
            }
        }

    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("canUSeCoffeeMachine");
            if (Input.GetKeyDown(KeyCode.I) && canUseCoffeeMachine == true)
            {
                other.GetComponent<Coffee>().GainCoffee(50);
                canUseCoffeeMachine = false;
                Debug.Log("usedCoffeemachine");
            }

        }
    }
}

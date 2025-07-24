using UnityEngine;

public class SpinManager : MonoBehaviour
{
    public void Spin()
    {
        int number = Random.Range(1, 1000);
        Debug.Log(number);
        if (number <= 2)
        {
            Debug.Log("Mythic!");
        }else if (number <= 10)
        {
            Debug.Log("Legendary!");
        } else if (number <= 100)
        {
            Debug.Log("Epic!");
        } else if (number <= 500)
        {
            Debug.Log("Rare!");
        }
        else
        {
            Debug.Log("Common");
        }
        
        
    }
}

using UnityEngine;
using UnityEngine.UI;

public class BubbleSortCubes : MonoBehaviour
{
    [SerializeField] private GameObject[] cubes = new GameObject[7];
    [SerializeField] private Button startButton;
    [SerializeField] private int offset;
    private int place = 0;

    private void Start()
    {
        startButton.onClick.AddListener(StartButton);
    }
    private void StartButton()
    {
        for (int i = 0; i < cubes.Length - 1; i++)
        {
            for (int j = 0; j < cubes.Length - i - 1; j++)
            {
                if (cubes[j].transform.localScale.magnitude < cubes[j + 1].transform.localScale.magnitude)
                {
                    var temp = cubes[j];
                    cubes[j] = cubes[j + 1];
                    cubes[j + 1] = temp;
                }
            }
        }
        for (int i = cubes.Length- 1;i >= 0 ; i--)
        {
            cubes[i].transform.position = new Vector3(0, 0, place);
            place += offset;
        }
    }
    
}



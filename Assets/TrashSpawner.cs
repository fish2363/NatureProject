using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject trashPre;
    public List<Transform> trashPosition;
    public bool isLeft;

    public IEnumerator TrashPatturn(float str)
    {
        while(str > 1)
        {
            print("¼ÒÈ¯Áß");
            int randPos = Random.Range(0,2);
            print(randPos);
            GameObject trash = Instantiate(trashPre, trashPosition[randPos].position, trashPosition[randPos].rotation);
            isLeft = trash.transform.position.x >= 0.04f;
            if (isLeft)
                trash.GetComponent<MoveTrash>().MoveMe(Vector2.left, str);
            else
                trash.GetComponent<MoveTrash>().MoveMe(Vector2.right, str);
            str --;
            yield return new WaitForSecondsRealtime(Random.Range(1,3));
        }

    }
}

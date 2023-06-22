using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class DisplayBag : MonoBehaviour
{
    public BagObject bag;
    public int NUMBER_OF_COLUMNS;
    public int Y_BETWEEN; 
    public int X_START;
    public int Y_START;
    Dictionary<BagSlot, GameObject> groceriesDisplayed = new Dictionary<BagSlot, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }
    
    public void UpdateDisplay()
    {
        for(int i = 0; i < bag.Container.Count; i++){
            if(groceriesDisplayed.ContainsKey(bag.Container[i])){
                groceriesDisplayed[bag.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = bag.Container[i].amount.ToString("n0");
            }else{
                var obj = Instantiate( bag.Container[i].grocery.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = bag.Container[i].amount.ToString("n0");
                groceriesDisplayed.Add(bag.Container[i], obj);
            }
        }
    }
    public void CreateDisplay()
    {
        for(int i = 0; i < bag.Container.Count; i++){
            var obj = Instantiate( bag.Container[i].grocery.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = bag.Container[i].amount.ToString("n0");
            groceriesDisplayed.Add(bag.Container[i], obj);
        }
    }

    public Vector3 GetPosition(int i){
        return new Vector3(X_START, Y_START + (-Y_BETWEEN * (i/NUMBER_OF_COLUMNS)), 0);
    }
}

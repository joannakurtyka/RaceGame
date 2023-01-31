using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityStandardAssets.Utility;

public class SetterOfPoints : MonoBehaviour
{
    private Dictionary<Collider2D, bool> _triggerStates = new Dictionary<Collider2D, bool>();
    public List<Collider2D> _currentTriggers { get; private set; } = new List<Collider2D>();
    private bool _on = true;
    private GameObject findedCar;
    private int massCar;
    private int prefMass = 0;
    public GameObject floatingPointsText1;
    public GameObject floatingPointsText2;
    public GameObject cFloatingPointsText1;
    public GameObject cFloatingPointsText2;


    private void Start()
    {
        findedCar = GameObject.Find("car_red_1"); 
        
    }
  
    private void FixedUpdate()
    {
        for (var i = 0; i < _currentTriggers.Count; i++)
        {
            var trigger = _currentTriggers[i];
            // If the trigger is no more, for whatever reason, remove it.
            if (!trigger)
            {
                _triggerStates.Remove(trigger);
                _currentTriggers.Remove(trigger);
                continue;
            }

            // If _currentTriggers has a collider w$$anonymous$$ch _triggerStates doesn't have, somet$$anonymous$$ng
            // weird has happened (it should not be possible), so default to scrapping it.
            // It'll get added again next FixedUpdate if it is still OnTriggerStay'ing.
            if (!_triggerStates.ContainsKey(trigger))
            {
                _currentTriggers.Remove(trigger);
            }
            else
            {
                // T$$anonymous$$s is the exciting part. FixedUpdate runs before the OnTrigger***, so we can
                // check here what the results are after the last OnTrigger*** calls came in.
                // They all set the state to "true" when adding or stay'ing a trigger, so if its
                // state is false here, then it is no longer stay'ing, and OnTriggerExit has not
                // been called to remove it, so we do it here.
                if (!_triggerStates[trigger])
                {
                    _triggerStates.Remove(trigger);
                    _currentTriggers.Remove(trigger);
                }
                else
                {
                    // Reset state to "false", so the coming OnTrigger*** calls can update them again.
                    _triggerStates[trigger] = false;
                }
            }
        }
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Stopper")
        {
            //if the object is not already in the list
            if (!_triggerStates.ContainsKey(other))
            {
                //add the object to the list
                _triggerStates.Add(other, true);
                _currentTriggers.Add(other);
            }


            massCar = (prefMass==0)?findedCar.GetComponent<ObiectMass>().mObiectMass : prefMass;
         //   Debug.Log("Car mass " + massCar+" PreffMass"+ prefMass );
           
            if (_currentTriggers.Count > 1)
            {

              
                for (int i = 0; i < _currentTriggers.Count; i++)
                {
                    _currentTriggers[i].GetComponent<ObiectMass>().mObiectMass = massCar - 1;
                }
               
                _currentTriggers[Random.Range(0,2)].GetComponent<ObiectMass>().mObiectMass = massCar * 2;
            //    DestroyImmediate(floatingPointsText1);
                                
                Vector3 floatP1 = _currentTriggers[1].transform.position;
                floatP1.y = floatP1.y + 0.3f;

                floatingPointsText1.layer = 3;
                floatingPointsText1.GetComponent<AutoMoveAndRotate>().moveUnitsPerSecond.value.y = -2;
                floatingPointsText1.GetComponent<TextMesh>().text = _currentTriggers[1].GetComponent<ObiectMass>().mObiectMass.ToString();
                if (cFloatingPointsText1 != null)
                {
                    Destroy(cFloatingPointsText1,0.8f);
                }
                cFloatingPointsText1 = Instantiate(floatingPointsText1, floatP1, Quaternion.identity);


             //   Debug.Log("1 count "+ "_currentTriggers.Count " + _currentTriggers[1].name + "  " + _currentTriggers[1].GetComponent<ObiectMass>().mObiectMass);
                
                

            }
            else { _currentTriggers[0].GetComponent<ObiectMass>().mObiectMass = massCar - 1; 
                }

            Vector3 floatP2 = _currentTriggers[0].transform.position;
            floatP2.y = floatP2.y + 0.3f;
          //  DestroyImmediate(floatingPointsText2);
            floatingPointsText2.layer = 5;
            floatingPointsText2.GetComponent<AutoMoveAndRotate>().moveUnitsPerSecond.value.y = -2;
            floatingPointsText2.GetComponent<TextMesh>().text = _currentTriggers[0].GetComponent<ObiectMass>().mObiectMass.ToString();
            if (cFloatingPointsText2 != null)
            {
                Destroy(cFloatingPointsText2, 0.8f);
            }
            cFloatingPointsText2 = Instantiate(floatingPointsText2, floatP2, Quaternion.identity);
            //Debug.Log("0 " + _currentTriggers[0].name + "  " + _currentTriggers[0].GetComponent<ObiectMass>().mObiectMass);
          
            prefMass++;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Stopper")
        {
            if (!_triggerStates.ContainsKey(other))
            {
                //add the object to the list
                _triggerStates.Add(other, true);
                _currentTriggers.Add(other);
            }
            else
            {
                _triggerStates[other] = true;
            }

        }

    }

    // Called when a trigger exits.
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Stopper")
        {

            _triggerStates.Remove(other);
            _currentTriggers.Remove(other);
        }
        
    }

    public void ResetRegisteredTriggers()
    {
   
            _currentTriggers.Clear();
            _triggerStates.Clear();
        
    }

    public void Toggle(bool on, bool resetCurrentTriggers = true)
    {
        _on = on;
        if (resetCurrentTriggers)
            ResetRegisteredTriggers();
    }
}

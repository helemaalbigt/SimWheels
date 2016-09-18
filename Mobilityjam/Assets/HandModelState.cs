using UnityEngine;
using System.Collections;

public class HandModelState : MonoBehaviour {



    public GameObject _handOpenState;
    public GameObject _handCloseState;


    void Start() {

        SetHandTo(HandType.Open);
    }

    public enum HandType { Open,Close, Pointing}
    void SetHandTo(HandType handState)
    {

        _handCloseState.SetActive(false);
        _handCloseState.SetActive(false);

        switch (handState)
        {
            case HandType.Open:
                _handOpenState.SetActive(true);
                break;
            case HandType.Close:
            case HandType.Pointing:
                _handCloseState.SetActive(true);
                break;
        }



    }
}

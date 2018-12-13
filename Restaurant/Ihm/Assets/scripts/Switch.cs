using Library.Utils;
using Library.Utils.DTO;
using Library.Utils.Nomenclature;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Switch : MonoBehaviour, IObservable
{
    private int Code;
    private List<Observer> observers = new List<Observer>();
    private TransportationService transportationService;

    // Use this for initialization
    void Start()
    {
        Debug.Log("start");
        InitListener();
    }

    private void InitListener()
    {
        GlobalFactory factory = GlobalFactory.GetInstance();
        this.transportationService = factory.GetTransportationService(LocationEnum.IHM);
    }

    // Update is called once per frame
    void Update()
    {
        CommandeDTO commande = transportationService.ReceiveUpdate();

        if (commande != null)
        {
            Debug.Log("Before switch");
            switch (commande.CommandeType)
            {
                case CommandeEnum.BOUGER_CUISINIER:
                    Notify(commande.Argument);
                    Debug.Log("order");
                    break;
                    /*case 002:
                        Notify("partyChief counter");
                        break;
                    case 003:
                        Notify("partyChief 2");
                        break;
                    case 004:
                        Notify("partyChief 3");
                        break;
                    case 005:
                        Notify("cooker 1");
                        break;
                    case 006:
                        Notify("kitchenCommis 1");
                        break;
                    case 007:
                        Notify("plongeur 1");
                        break;
                    case 008:
                        Notify("client 0");
                        break;
                    case 009:
                        Notify("client 1 x y y");
                        break;
                    case 010:
                        Notify("client 2");
                        break;
                    case 011:
                        Notify("client 3 nbr");
                        break;
                    case 012:
                        Notify("serveur 0");
                        break;
                    case 013:
                        Notify("serveur 1 x y");
                        break;
                    case 014:
                        Notify("commis 0");
                        break;
                    case 015:
                        Notify("commis 1 x y");
                        break;
                    case 016:
                        Notify("rowChief 0");
                        break;
                    case 017:
                        Notify("rowChief 1 x y y");
                        break;*/
            }
        }
    }

    public void Notify(string str)
    {
        foreach (var observer in observers)
        {
            observer.OnNotify(str);
        }
    }

    public void AddObserver(Observer observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(Observer observer)
    {
        observers.Remove(observer);
    }
}

using System;
using System.Diagnostics;
using Mirror;
using UnityEngine;

namespace StepingMars._Project.Scripts.Network
{
    
    enum ConnectionType
    {
        Client,
        Host,
        Server
    }

    public class TestNetworkManager : MonoBehaviour
    {
        [SerializeField] private ConnectionType _connectionType;      
        [SerializeField] private NetworkManager _networkManager;


        [ContextMenu("Start Manager")]
        public void StartTheManager()
        {
            switch (_connectionType)
            {
                case ConnectionType.Client:
                {
                    _networkManager.StartClient();
                    break;        
                }
                case ConnectionType.Host:
                {
                    _networkManager.StartHost();
                    break;        
                }
                case ConnectionType.Server:
                {
                    _networkManager.StartServer();
                    break;        
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

    }
}

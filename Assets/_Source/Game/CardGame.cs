using System.Collections;
using System.Collections.Generic;
using _Source.Core;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Source.Game
{
    public class CardGame : MonoBehaviour
    {
        private static CardGame _instance;
        private Dictionary<CardInstance, CardView> cardDictionary;
        [SerializeField] public List<CardAsset> cardAssets;

        private CardGame()
        {
            cardAssets = new List<CardAsset>();
        }
        private void Awake() 
        {
            if (_instance != null)
            {
                Debug.LogWarning("Error"); 
            }
            _instance = this; 
        } 
 
        public static CardGame GetInstance() 
        { 
            return _instance; 
        }

        public void StartGame()
        {
            foreach (CardAsset asset in cardAssets)
            {
                CreateCard(asset, 0);
            }
        }

        public void CreateCardView(CardInstance cardInstance)
        {
            GameObject obj = null;
            obj = GameObject.Instantiate(cardInstance.GetCardAsset().GetCardPrefab());
            obj.AddComponent<CardView>();
            obj.GetComponent<CardView>().Init(cardInstance);
            cardDictionary[cardInstance] = obj.GetComponent<CardView>();
        }

        public void CreateCard(CardAsset cardAsset, int layoutId)
        {
            CardInstance cardInstance = new CardInstance(cardAsset);
            cardDictionary.Add(cardInstance, null);
            CreateCardView(cardInstance);
            cardInstance.MoveToLayout(layoutId);
        }
    }
}

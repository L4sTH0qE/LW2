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
        public Dictionary<CardInstance, CardView> _cardDictionary = new Dictionary<CardInstance, CardView>();
        [SerializeField] public List<CardAsset> _cardAssets;

        private CardGame()
        {
            _cardAssets = new List<CardAsset>();
        }
        private void Awake() 
        {
            if (_instance != null)
            {
                Debug.LogWarning("Error"); 
            }
            _instance = this; 
            StartGame();
        } 
 
        public static CardGame GetInstance() 
        { 
            return _instance; 
        }

        public void StartGame()
        {
            foreach (CardAsset asset in _cardAssets)
            {
                CreateCard(asset, 2);
            }
        }

        public void CreateCardView(CardInstance cardInstance)
        {
            GameObject obj = null;
            obj = Instantiate(cardInstance.GetCardAsset().GetCardPrefab());
            obj.AddComponent<CardView>();
            if (obj.TryGetComponent(out CardView view))
            {
                view.Init(cardInstance);
                view.transform.localPosition = Vector3.zero;
            }
            _cardDictionary[cardInstance] = obj.GetComponent<CardView>();
        }

        public void CreateCard(CardAsset cardAsset, int layoutId)
        {
            CardInstance cardInstance = new CardInstance(cardAsset);
            cardInstance.GetCardAsset().GetCardPrefab().transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            _cardDictionary.Add(cardInstance, null);
            CreateCardView(cardInstance);
            cardInstance.MoveToLayout(layoutId);
        }
        
        public List<CardInstance> GetCardsInLayout(int layoutId)
        {
            List<CardInstance> cards = new List<CardInstance>();
            foreach (var card in _cardDictionary.Keys)
            {
                if (card.LayoutId == layoutId)
                {
                    cards.Add(card);
                }
            }
            return cards;
        }
    }
}

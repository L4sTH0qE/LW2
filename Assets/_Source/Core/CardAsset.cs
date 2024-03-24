using _Source.Core;
using UnityEngine;

namespace _Source.Core
{
  [CreateAssetMenu(menuName="SO/new Card", fileName="Card")]
  public class CardAsset : ScriptableObject
  {
    [SerializeField] private ColorsEnum _color;
    [SerializeField] private NamesEnum _name;
    [SerializeField] private GameObject _cardPrefab;

    public ColorsEnum GetColor()
    {
      return _color;
    }
    
    public NamesEnum GetName()
    {
      return _name;
    }
       
    public GameObject GetCardPrefab()
    {
      return _cardPrefab;
    }
  }
}
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace Credits
{
    public class Credits : MonoBehaviour
    {
        [SerializeField] private RectTransform creditTextTrans;
        [SerializeField] private float tweenTime;
        [SerializeField] private float creditTime;

        private string artText = "Art\nfrom www.Kenny.nl";

        private void Awake()
        {
            creditTextTrans.localScale = Vector3.zero;
        }

        private void Start()
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Append(creditTextTrans.DOScale(Vector3.one, tweenTime)
                                           .SetEase(Ease.OutElastic));
            sequence.AppendInterval(creditTime);
            sequence.Append(creditTextTrans.DOScale(Vector3.zero, tweenTime)
                                           .SetEase(Ease.OutSine)
                                           .OnStepComplete(() => ChangeCredit()));

            sequence.Append(creditTextTrans.DOScale(Vector3.one, tweenTime)
                                           .SetEase(Ease.OutElastic));
            sequence.AppendInterval(creditTime);
            sequence.AppendCallback(() => GameManager.Instance.NextScene());
            sequence.Play();
        }

        private void ChangeCredit()
        {
            creditTextTrans.GetComponent<TextMeshProUGUI>().text = artText;
        }
    }
}
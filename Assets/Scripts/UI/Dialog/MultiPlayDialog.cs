using UniRx;

namespace Reversi.Dialog
{
    public class MultiPlayDialog : DialogBase
    {
        public override void Initialize(DialogArgBase argBase)
        {
            var arg = ConvertArg<MultiPlayDialogArg>(argBase);

            _titleText.text = arg.TitleText;

            _closeButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    arg.CloseSubject?.OnNext(Unit.Default);
                    DialogManager.Instance.Close(this);
                })
                .AddTo(this);
        }
    }

    public class MultiPlayDialogArg : DialogArgBase
    {
        public MultiPlayDialogArg(string titleText, Subject<Unit> closeSubject) : base(titleText, closeSubject)
        {
        }
    }
}
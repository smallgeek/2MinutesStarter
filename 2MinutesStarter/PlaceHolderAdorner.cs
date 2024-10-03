using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;

namespace TwoMinutesStarter
{
    /// <summary>
    /// プレースホルダー用の装飾
    /// </summary>
    class PlaceHolderAdorner : Adorner
    {
        private readonly ContentPresenter contentPresenter;

        public PlaceHolderAdorner(UIElement adornedElement, string placeHolder) : base(adornedElement)
        {
            IsHitTestVisible = false;

            contentPresenter = new ContentPresenter();
            contentPresenter.Content = placeHolder;
            contentPresenter.Opacity = 0.5;

            // 書式をコピー
            var fontSizeBinding = new Binding("FontSize") { Mode = BindingMode.OneWay };
            fontSizeBinding.Source = adornedElement;
            contentPresenter.SetBinding(Control.FontSizeProperty, fontSizeBinding);

            // コントロールが非表示になったときにプレースホルダーも非表示にする
            var isVisibleBinding = new Binding("IsVisible");
            isVisibleBinding.Source = adornedElement;
            isVisibleBinding.Converter = new BooleanToVisibilityConverter();
            SetBinding(VisibilityProperty, isVisibleBinding);
        }

        protected override int VisualChildrenCount => 1;

        private Control Control => (Control)AdornedElement;

        protected override Visual GetVisualChild(int index) => contentPresenter;

        protected override Size MeasureOverride(Size constraint)
        {
            contentPresenter.Measure(Control.RenderSize);
            return Control.RenderSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            contentPresenter.Arrange(new Rect(finalSize));
            return finalSize;
        }
    }
}

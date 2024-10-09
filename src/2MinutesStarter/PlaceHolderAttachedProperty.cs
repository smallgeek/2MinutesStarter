using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace TwoMinutesStarter
{
    /// <summary>
    /// テキストボックスにプレースホルダーを表示するための添付プロパティ
    /// </summary>
    public static class PlaceHolderAttachedProperty
    {
        /// <summary>
        /// PlaceHolder 依存関係プロパティ
        /// </summary>
        public static readonly DependencyProperty PlaceHolderProperty =
            DependencyProperty.RegisterAttached(
                "PlaceHolder", 
                typeof(string), 
                typeof(PlaceHolderAttachedProperty),
                new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnPlaceHolderChanged)));

        public static string GetPlaceHolder(DependencyObject obj)
        {
            return (string)obj.GetValue(PlaceHolderProperty);
        }

        public static void SetPlaceHolder(DependencyObject obj, string value)
        {
            obj.SetValue(PlaceHolderProperty, value);
        }

        /// <summary>
        /// プレースホルダーが変更された時のイベント
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnPlaceHolderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (Control)d;

            control.Loaded += Control_OnLoad;

            if (control is TextBox t)
            {
                t.GotKeyboardFocus += Control_OnGotKeyboardFocus;
                t.LostKeyboardFocus += Control_OnLoad;
                t.TextChanged += Control_OnGotKeyboardFocus;
            }
        }

        /// <summary>
        /// コントロール表示時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Control_OnLoad(object sender, RoutedEventArgs e)
        {
            var control = (Control)sender;
            
            if (ShouldShowPlaceHolder(control))
            {
                ShowPlaceHolder(control);
            }
        }

        /// <summary>
        /// コントロールにフォーカスが移動したときのイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Control_OnGotKeyboardFocus(object sender, RoutedEventArgs e)
        {
            var control = (Control)sender;
            
            if (ShouldShowPlaceHolder(control))
            {
                ShowPlaceHolder(control);
            }
            else
            {
                HidePlaceHolder(control);
            }
        }

        /// <summary>
        /// プレースホルダーが必要かどうか
        /// </summary>
        /// <param name="control"></param>
        /// <returns>trueの場合はプレースホルダーを表示する</returns>
        private static bool ShouldShowPlaceHolder(Control control)
        {
            if (control is TextBox t)
            {
                return !t.IsFocused && t.Text == string.Empty;
            }
            return false;
        }

        /// <summary>
        /// プレースホルダーを表示する
        /// </summary>
        /// <param name="control"></param>
        private static void ShowPlaceHolder(Control control)
        {
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(control);

            if (layer != null)
            {
                layer.Add(new PlaceHolderAdorner(control, GetPlaceHolder(control)));
            }
        }

        /// <summary>
        /// プレースホルダーを非表示にする
        /// </summary>
        /// <param name="control"></param>
        private static void HidePlaceHolder(Control control)
        {
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(control);

            if (layer == null)
            {
                return;
            }

            Adorner[] adorners = layer.GetAdorners(control);
            if (adorners == null)
            {
                return;
            }

            foreach (var adorner in adorners)
            {
                if (adorner is PlaceHolderAdorner)
                {
                    adorner.Visibility = Visibility.Hidden;
                    layer.Remove(adorner);
                }
            }
        }
    }
}

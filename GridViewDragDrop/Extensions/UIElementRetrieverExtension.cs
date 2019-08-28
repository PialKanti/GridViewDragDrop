using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace GridViewDragDrop.Extensions
{
    public static class UIElementRetrieverExtension
    {
        public static ScrollViewer GetScrollViewer(this DependencyObject element)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(element, i);
                if (child != null && child is ScrollViewer)
                    return (ScrollViewer)child;
                else
                {
                    ScrollViewer childOfChild = GetScrollViewer(child);
                    if (childOfChild != null)

                        return childOfChild;
                }
            }
            return null;

        }
    }
}

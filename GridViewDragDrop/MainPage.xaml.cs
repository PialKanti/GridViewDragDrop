using GridViewDragDrop.Model;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.UI.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using GridViewDragDrop.Extensions;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GridViewDragDrop
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<Place> placeList;

        public List<Place> PlaceList
        {
            get { return placeList; }
            set { placeList = value; }
        }

        public MainPage()
        {
            this.InitializeComponent();
            placeList = GetPlaces(15);
            TitleListCVS.Source = PlaceList;
        }

        private List<Place> GetPlaces(int count)
        {
            List<Place> titleList = new List<Place>();
            for (int i = 0; i < count; i++)
            {
                titleList.Add(new Place { Title = "Place " + (i + 1) });
            }
            return titleList;
        }

        private void PlaceGrid_Holding(object sender, HoldingRoutedEventArgs e)
        {
            Debug.WriteLine("PlaceGrid Holding " + e.HoldingState);
            if(e.HoldingState == HoldingState.Completed || e.HoldingState == HoldingState.Canceled)
            {
                SampleGridView.GetScrollViewer().VerticalScrollMode = ScrollMode.Disabled;
            }
            else
            {
                SampleGridView.GetScrollViewer().VerticalScrollMode = ScrollMode.Enabled;
            }
        }
    }
}

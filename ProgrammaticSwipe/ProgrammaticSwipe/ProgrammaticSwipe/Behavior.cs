using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Control.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewSample
{
   public class Behavior : Behavior<ContentPage>
    {

        #region Fields
        private Syncfusion.ListView.XForms.SfListView ListView;
        private ContactsViewModel viewModel;
        #endregion

        #region Methods
        protected override void OnAttachedTo(ContentPage bindable)
        {
            ListView = bindable.FindByName<Syncfusion.ListView.XForms.SfListView>("listView");
           Button button= bindable.FindByName<Button>("ToSwipeButton");
            button.Clicked += Button_Clicked;

            viewModel = new ContactsViewModel();
            ListView.BindingContext = viewModel;
            ListView.ItemsSource = viewModel.contactsinfo;

            base.OnAttachedTo(bindable);
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            Device.BeginInvokeOnMainThread(async () =>
            {
                VisualContainer visualContainer = ListView.GetVisualContainer();
                int count = visualContainer.Children.Count();
                Random r = new Random();
                int index = r.Next(0, count);
                var swipeController = ListView.GetType().GetRuntimeProperties().FirstOrDefault(ptyname => ptyname.Name == "SwipeController").GetValue(ListView);
                var item = visualContainer.Children[0];
                if (item is SwipeView)
                    return;
                var swipeItem = item.GetType().GetRuntimeProperties().FirstOrDefault(x => x.Name == "ListViewItemInfo").GetValue(item);
                if (swipeItem == null)
                    return;
                var iteminfo = swipeItem as ListViewItemInfoBase;
                var position = iteminfo.GetType().GetRuntimeProperties().FirstOrDefault(x => x.Name == "InitialPosition");
                position.SetValue(iteminfo, 10);
                var swipeStarted = swipeController.GetType().GetRuntimeMethods().FirstOrDefault(methd => methd.Name == "ProcessTouchMove");
                swipeStarted.Invoke(swipeController, new object[] { iteminfo, new Point(120, 10) });
                await Task.Delay(1000);
            });

            //You can call this method to reset the swiped item 
            //listView.ResetSwipe();   

        }

        #endregion
    }
}

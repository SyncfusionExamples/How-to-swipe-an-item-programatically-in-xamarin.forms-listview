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
            Button rightSwipeButton = bindable.FindByName<Button>("RightSwipe");
            Button leftSwipeButton = bindable.FindByName<Button>("LeftSwipe");
            rightSwipeButton.Clicked += RightSwipeButton_Clicked; ;
            leftSwipeButton.Clicked += LeftSwipeButton_Clicked; ;

            viewModel = new ContactsViewModel();
            ListView.BindingContext = viewModel;
            ListView.ItemsSource = viewModel.contactsinfo;

            base.OnAttachedTo(bindable);
        }

        private void LeftSwipeButton_Clicked(object sender, EventArgs e)
        {
            ListView.SwipeItem(viewModel.contactsinfo[1], 200);
        }

        private void RightSwipeButton_Clicked(object sender, EventArgs e)
        {
            ListView.SwipeItem(viewModel.contactsinfo[1], -150);
        }
        #endregion
    }
}

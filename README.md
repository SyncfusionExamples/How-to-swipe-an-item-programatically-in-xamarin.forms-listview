# How to swipe an item programmatically in xamarin.forms listview?

This example demonstrates how to swipe an item programmatically in xamarin.forms listview.

## Sample

```xaml
<StackLayout>
    <Grid HeightRequest="50">
        <Button x:Name="RightSwipe" Text="Right Swipe Button" />
        <Button x:Name="LeftSwipe" Text="Left Swipe Button" Grid.Column="1"/>
    </Grid>
    <listView:SfListView x:Name="listView" ItemSize="70" SelectionMode="Single" AllowSwiping="True" ItemSpacing="0,0,5,0" >

        <listView:SfListView.LeftSwipeTemplate>
            <DataTemplate>
                <ViewCell>
                    <ViewCell.View>
                        <Grid BackgroundColor="SlateBlue"  HorizontalOptions="Fill" VerticalOptions="Fill">
                            <Label Text="Left Swipe Template" TextColor="White" VerticalOptions="Center" HorizontalOptions="Center"/>
                        </Grid>
                    </ViewCell.View>
                </ViewCell>
            </DataTemplate>
        </listView:SfListView.LeftSwipeTemplate>

        <listView:SfListView.RightSwipeTemplate>
            <DataTemplate>
                <ViewCell>
                    <ViewCell.View>
                        <Grid BackgroundColor="SlateBlue" HorizontalOptions="Fill" VerticalOptions="Fill">
                            <Label Text="Right Swipe Template" TextColor="White" VerticalOptions="Center"/>
                        </Grid>
                    </ViewCell.View>
                </ViewCell>
            </DataTemplate>
        </listView:SfListView.RightSwipeTemplate>

        <listView:SfListView.ItemTemplate>
            <DataTemplate>
                <ViewCell>
                    <ViewCell.View>
                        <code>
                        . . .
                        . . .
                        <code>
                    </ViewCell.View>
                </ViewCell>
            </DataTemplate>
        </listView:SfListView.ItemTemplate>
    </listView:SfListView>
</StackLayout>

Code Behind :
Button rightSwipeButton = bindable.FindByName<Button>("RightSwipe");
Button leftSwipeButton = bindable.FindByName<Button>("LeftSwipe");
rightSwipeButton.Clicked += RightSwipeButton_Clicked;
leftSwipeButton.Clicked += LeftSwipeButton_Clicked;

private void LeftSwipeButton_Clicked(object sender, EventArgs e)
{
    ListView.SwipeItem(viewModel.contactsinfo[1], 200);
}

private void RightSwipeButton_Clicked(object sender, EventArgs e)
{
    ListView.SwipeItem(viewModel.contactsinfo[1], -150);
}
```

## Requirements to run the demo

* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/)
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## Troubleshooting

### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

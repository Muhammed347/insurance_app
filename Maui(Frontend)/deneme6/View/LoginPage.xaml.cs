using deneme6.ViewModel;
using CommunityToolkit.Maui.Behaviors;

namespace deneme6.View;

public partial class LoginPage : ContentPage
{
    private PersonsViewModel model_view;
    public LoginPage(PersonsViewModel viewModel)
	{
		InitializeComponent();
        model_view = viewModel;
		BindingContext=viewModel;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        
        // Check if both name and password pass the validation
        if (nameValidator.IsValid && passwordValidator.IsValid)
        {
            string name = entryName.Text;
            string password = txtPass.Text;
            await model_view.ControlAsync(name, password);
        }
        else
        {
            // Display an error message if validation fails
            if (!nameValidator.IsValid)
            {
                await DisplayAlert("Error", nameValidator.ToString(), "OK");
            }
            else
            {
                await DisplayAlert("Error", passwordValidator.ToString(), "OK");
            }
        }
    }
}

/*
 <Grid
        ColumnDefinitions="*,*"
        ColumnSpacing="5"
        RowDefinitions="*,Auto"
        RowSpacing="0">
        <CollectionView ItemsSource="{Binding Persons}"
                         SelectionMode="None"
                         Grid.ColumnSpan="2">
            <CollectionView.ItemTemplate>
                <DataTemplate x:DataType="model:Person">
                    <Grid Padding="10">
                        <Frame HeightRequest="125" Style="{StaticResource CardView}">
                            <Grid Padding="0" ColumnDefinitions="125,*">
                                <VerticalStackLayout
                                    Grid.Column="1"
                                    VerticalOptions="Center"
                                    Padding="10">
                                    <Label Style="{StaticResource LargeLabel}" Text="{Binding Name}" />
                                    <Label Style="{StaticResource MediumLabel}" Text="{Binding Password}" />
                                </VerticalStackLayout>
                            </Grid>
                        </Frame>
                    </Grid>
                </DataTemplate>
            </CollectionView.ItemTemplate>
        </CollectionView>

        <Button Text="Get Monkeys" 
                Command="{Binding GetPersonsCommand}"
                IsEnabled="{Binding IsNotBusy}"
                Grid.Row="1"
                Grid.Column="0"
                Style="{StaticResource ButtonOutline}"
                Margin="8"/>

        <ActivityIndicator IsVisible="{Binding IsBusy}"
                           IsRunning="{Binding IsBusy}"
                           HorizontalOptions="Fill"
                           VerticalOptions="Center"
			   Color="{StaticResource Primary}"
                           Grid.RowSpan="2"
                           Grid.ColumnSpan="2"/>
    </Grid>
 */
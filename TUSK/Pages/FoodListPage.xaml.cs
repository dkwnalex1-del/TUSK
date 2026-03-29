using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using System.Linq;
using Microsoft.Maui.Storage;

namespace TUSK;

public partial class FoodListPage : ContentPage
{
    List<string> items = new List<string>();

    public FoodListPage()
	{
		InitializeComponent();

	}
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
        
    }

    private void ShowInput_Clicked(object sender, EventArgs e)
    {
        InputSection.IsVisible = !InputSection.IsVisible;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        string data = string.Join(";", items);
        Preferences.Set("ChecklistData", data);
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        string savedData = Preferences.Get("ChecklistData", "");

        if (!string.IsNullOrEmpty(savedData))
        {
            items = savedData.Split(';').ToList();
            RefreshList();
        }
    }

    void RefreshList()
    {
        ChecklistCollectionView.ItemsSource = null;
        ChecklistCollectionView.ItemsSource = items;
        UpdateExpiredItems();
    }

    private void ConfirmAddItem_Clicked(object sender, EventArgs e)
    {
        string food = FoodNameEntry.Text;

        if (string.IsNullOrWhiteSpace(food))
            return;

        string expiry = "";

        if(HasExpiryCheckBox.IsChecked == true)
        {
            expiry = ExpiryDatePicker.Date.ToString();
        }

        string item = $"{food}|{expiry}";
        items.Add(item);

        RefreshList();

        // reset the UI after confirm
        FoodNameEntry.Text = "";
        HasExpiryCheckBox.IsChecked = false;
        InputSection.IsVisible = false;
    }

    private void DeleteItem_Clicked(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        var item = button?.BindingContext as string;

        if (item != null)
        {
            items.Remove(item);
            RefreshList();
        }
    }

    private void HasExpiryCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        ExpiryDatePicker.IsVisible = e.Value;
    }

    void UpdateExpiredItems()
    {
        List<string> expiredFoods = new List<string>();

        foreach (string item in items)
        {
            string[] parts = item.Split('|');
            string foodName = parts[0];

            if (parts.Length > 1 && !string.IsNullOrWhiteSpace(parts[1]))
            {
                DateTime expiryDate;

                if (DateTime.TryParse(parts[1], out expiryDate))
                {
                    if (expiryDate.Date < DateTime.Today)
                    {
                        expiredFoods.Add(foodName);
                    }
                }
            }
        }

        if (expiredFoods.Count > 0)
            ExpiredItemsLabel.Text = "Expired: " + string.Join(", ", expiredFoods);
        else
            ExpiredItemsLabel.Text = "Expired: None";
    }


}
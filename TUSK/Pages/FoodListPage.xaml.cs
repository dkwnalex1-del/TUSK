using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using Plugin.LocalNotification;
using Plugin.LocalNotification.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TUSK;

public partial class FoodListPage : ContentPage
{
    //create a list to store all items entered 
    List<string> items = new List<string>();

    public FoodListPage()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);

    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
        
    }

    //function that allows users to collaps the add item menu or open it.
    private void ShowInput_Clicked(object sender, EventArgs e)
    {
        InputSection.IsVisible = !InputSection.IsVisible;
    }

    //saves the data entered when users exit the page into preferences, combines all the data entered into a single string separated by ; 
    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        string data = string.Join(";", items);
        Preferences.Set("ChecklistData", data);
    }


    //checks if the list items has any data, if it exists load the data separated by ;
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

    //updates CollectionView and makes sure anything entered thats expired is put in there, and saves the list to preferences
    void RefreshList()
    {
        var displayItems = new List<string>();

        foreach (string item in items)
        {
            string[] parts = item.Split('|');
            string foodName = parts[0];
            string expiry = parts.Length > 1 ? parts[1] : "No Expiry Date Added";

            displayItems.Add($"{foodName} (Expires: {expiry})");
        }

        ChecklistCollectionView.ItemsSource = displayItems;
        UpdateExpiredItems();
    }

    //triggered by confirm button that appears when users add an item. changes all data entered to string format.
    private async void ConfirmAddItem_Clicked(object sender, EventArgs e)
    {
        string food = FoodNameEntry.Text;

        if (string.IsNullOrWhiteSpace(food))
            return;

        string expiry = "No Expiry Date Added";
        int notificationId = 0;

        if (HasExpiryCheckBox.IsChecked == true)
        {
            
            expiry = ExpiryDatePicker.Date.ToString();
            notificationId = Preferences.Get("NotifIdCounter", 0) + 1;
            Preferences.Set("NotifIdCounter", notificationId);

            var request = new NotificationRequest
            {
                NotificationId = notificationId,
                Title = "Food Expiry Reminder",
                Description = $"{food} expires today!",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = ExpiryDatePicker.Date
                    //NotifyTime = DateTime.Now.AddSeconds(10) - for testing notifs

                }
            };
            await LocalNotificationCenter.Current.Show(request);
        }

        string item = $"{food}|{expiry}|{notificationId}";
        items.Add(item);
        // Save data immediately
        string data = string.Join(";", items);
        Preferences.Set("ChecklistData", data);

        RefreshList();

        // reset the UI after confirm
        FoodNameEntry.Text = "";
        HasExpiryCheckBox.IsChecked = false;
        InputSection.IsVisible = false;
    }

    //delete item method for items that is linked to its own delete button
    private void DeleteItem_Clicked(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        var displayItem = button?.BindingContext as string;

        //if empty
        if (displayItem == null)
            return;
        // Find original item
        string fullItem = null;

        foreach (string i in items)
        {
            string[] parts = i.Split('|');

            string formatted = parts.Length > 1
                ? $"{parts[0]} (Expires: {parts[1]})"
                : parts[0];

            if (formatted == displayItem)
            {
                fullItem = i;
                break;
            }
        }

        if (fullItem != null)
        {
            var parts = fullItem.Split('|');

            if (parts.Length > 2 && int.TryParse(parts[2], out int notificationId) && notificationId > 0)
            {
                LocalNotificationCenter.Current.Cancel(notificationId);
            }

            items.Remove(fullItem);

            Preferences.Set("ChecklistData", string.Join(";", items));

            RefreshList();
        }
    }

    //shows or hides the datepicker for expiry date based on if the checkbox is checked or not
    private void HasExpiryCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        ExpiryDatePicker.IsVisible = e.Value;
    }

    //checks if any items in the list are expired and updates the label to show which items are expired or if there are none
    void UpdateExpiredItems()
    {
        //create a list to store all expired items
        List<string> expiredFoods = new List<string>();

        //loop through all items in the list and check if they have an expiry date, if they do check if its expired and add it to the expired foods list
        foreach (string item in items)
        {
            //split the item into food name and expiry date using | as the separator
            string[] parts = item.Split('|');
            string foodName = parts[0];

            //check if there is an expiry date and if its not empty or whitespace
            if (parts.Length > 1 && !string.IsNullOrWhiteSpace(parts[1]) && parts[1] !="No Expiry Date Added")
            {
                DateTime expiryDate;


                //try to convert the string to DateTime, if it succeeds check if the expiry date is before today and if it is add it to the expired foods list
                if (DateTime.TryParse(parts[1], out expiryDate))
                {
                    if (expiryDate.Date <= DateTime.Today)
                    {
                        expiredFoods.Add(foodName);
                    }
                }
            }
        }

        //update the label to show the expired items or show that there are none
        if (expiredFoods.Count > 0)
            ExpiredItemsLabel.Text = "Expired: " + string.Join(", ", expiredFoods);
        else
            ExpiredItemsLabel.Text = "Expired: None";
    }


}
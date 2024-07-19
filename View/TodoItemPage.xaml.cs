using _2320559.Data;
using _2320559.Models;

namespace _2320559.View;

[QueryProperty("Item","Item")]
public partial class TodoItemPage : ContentPage
{
	TodoItem item;
	public TodoItem Item
	{ 
		get => BindingContext as TodoItem; 
		set => BindingContext= value;
	}
	TodoItemDatabase _database;
	public TodoItemPage(TodoItemDatabase todoItemDatabase)
	{
		InitializeComponent();
		_database = todoItemDatabase;
	}

    async void OnSaveClicked (object sender, EventArgs e)
    {
		if (string.IsNullOrWhiteSpace(Item.Name))
		{
			await DisplayAlert("Name Required", "Place enter a name for the todo item.", "Ok");
			return;
		}
		await _database.SaveItemAsync(Item);
		await Shell.Current.GoToAsync("..");
    }
	async void OnDeleteClicked(object sender,EventArgs e)
	{
		if (Item.ID == 0)
			return;
		await _database.DeleteItemAsync(Item);
		await Shell.Current.GoToAsync("..");	
	}

	async void OnCancelClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("..");
	}
}

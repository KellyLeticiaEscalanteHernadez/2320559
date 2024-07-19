using System.Collections.ObjectModel;
using _2320559.Models;
using _2320559.Data;
namespace _2320559.View;

public partial class TodoListPage : ContentPage
{
    TodoItemDatabase _database;
    public ObservableCollection<TodoItem> Items { get; set; } = new();

    public TodoListPage(TodoItemDatabase todoItemDatabase)
    {
        InitializeComponent();
        _database = todoItemDatabase;
        BindingContext = this;
    }
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        var items = await _database.GetItemsAsync();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Items.Clear();
            foreach (var item in items)
                Items.Add(item);
        });
    }
    async void OnItemAdded(object sender,EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(TodoItemPage), true, new Dictionary<string, object>
        {
            ["Item"] = new TodoItem()
        });
    }

     private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not TodoItem item)
            return;
        await Shell.Current.GoToAsync(nameof(TodoItemPage), true, new Dictionary<string, object>
        {
            ["Item"] = item
        });
    }
}
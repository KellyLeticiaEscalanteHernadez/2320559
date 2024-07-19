using _2320559.View;
namespace _2320559
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TodoItemPage),typeof(TodoItemPage));   
        }
    }
}

using BlazorCRUD.Shared.Models;
using System.Net.Http.Json;
namespace BlazorCRUD.Client.Pages{
    public partial class Todo{
        private string? TodoText;
        private TodoItem newTodo = new TodoItem();
        private List<TodoItem> todos = new();
        static readonly HttpClient client = new HttpClient();
        private void AddTodo()
        {
            if (!string.IsNullOrWhiteSpace(TodoText))
            {
                todos.Add(new TodoItem { Title = TodoText, DateAdded = DateTime.Now });
                TodoText = string.Empty;
            }
        }
        protected override async Task OnInitializedAsync()
        {
            todos = await service.GetFromJsonAsync<List<TodoItem>>("api/todo");
        }
        private async Task PostTodo()
        {
            if (!string.IsNullOrWhiteSpace(TodoText))
            {
                newTodo = new TodoItem { Title = TodoText, DateAdded = DateTime.Now };
                await service.PostAsJsonAsync("api/todo", newTodo);
                TodoText = string.Empty;
                await OnInitializedAsync();
            }
            
        }
    }
}   
    
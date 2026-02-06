namespace ToDo.Services;

public class UpdateUIService
{
    public event Action? OnUpdate;
    public void Update() => OnUpdate?.Invoke();
}
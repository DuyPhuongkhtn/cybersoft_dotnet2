public class UserService {
    public event Action? OnChanged;
    private string currentUser;

    public string CurrentUser {
        get {
            return currentUser;
        }
    }

    public void Login(string userName) {
        currentUser = userName;
        NotifyStateChanged();
    }

    public void Logout() {
        currentUser = string.Empty;
        NotifyStateChanged();
    }

    // viết hàm kiểm tra xem người dùng đã đăng nhập chưa
    public bool IsAuthenticated() {
        return !string.IsNullOrEmpty(currentUser);
    }

    private void NotifyStateChanged() {
        if(OnChanged != null) {
            // thông báo cho Blazor biết rằng dữ liệu đã thay đổi
            OnChanged.Invoke();
        }
    }
}
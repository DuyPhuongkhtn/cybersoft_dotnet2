using Microsoft.AspNetCore.SignalR;

public class ChatHub: Hub {
    // server nhận event từ client
    public async Task SendPrivateMessage(string user, string message) {
        // gửi event đến clients
        Console.WriteLine("SendPrivateMessage");
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    public async Task SendGroupMessage(string group, string user, string message) {
        // gửi event đến clients trong group
        Console.WriteLine("SendGroupMessage");
        await Clients.Group(group).SendAsync("ReceiveMessageGroup", group, user, message);
    }

    public async Task JoinGroup(string group, string user) {
        Console.WriteLine("JoinGroup");
        await Groups.AddToGroupAsync(Context.ConnectionId, group);

        // gửi event thông báo user A đã join group
        await Clients.Group(group).SendAsync("ReceiveMessageGroup", group, "System", $"{user} joined {group}");
    }

    // rời nhóm
    public async Task LeaveGroup(string group, string user) {
        Console.WriteLine("LeaveGroup");
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, group);

        // gửi event thông báo user A đã rời group
        await Clients.Group(group).SendAsync("ReceiveMessageGroup", group, "System", $"{user} left {group}");
    }
}
class LuxuryRoom: Room {
    private string extraService;
    public string ExtraService {
        get { return extraService; }
        set { extraService = value; }
    }

    public LuxuryRoom(
        string roomId,
        string roomName,
        double basePrice,
        string extraService
    ): base(roomId, roomName, basePrice) {
        this.extraService = extraService;
    }

    // do hàm calculatePrice của class cha là abstract nên class con
    // phải định nghĩa lại hàm này
    public override double calculatePrice(){
        return this.BasePrice + 100;
    }

    public override void displayInfo(){
        base.displayInfo();
        Console.WriteLine($"Extra Service: {extraService}");
    }
}
class SuiteRoom: Room {
    private string extraService;
    public string ExtraService {
        get { return extraService; }
        set { extraService = value; }
    }
    private string premiumService;
    public string PremiumService {
        get { return premiumService; }
        set { premiumService = value; }
    }

    public SuiteRoom(
        string roomId,
        string roomName,
        double basePrice,
        string extraService,
        string premiumService
    ): base(roomId, roomName, basePrice) {
        this.extraService = extraService;
        this.premiumService = premiumService;
    }

    public override double calculatePrice(){
        return BasePrice + 200;
    }

}
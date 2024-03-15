namespace AuthWeb.Session {
    public interface ISessionState {
        string? Token { get; set; }
    }

    public class SessionState: ISessionState {
        public string? Token { get; set; }
    }
}

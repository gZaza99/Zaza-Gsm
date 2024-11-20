namespace ZazaGsm.View
{
    public static class ErrorHandler
    {
        public enum Code
        {
            ConnectionFailure,
            DataNotFound,
            SavingError,
            InvalidData
        }
        /// <summary> The action that called when ErrorCode set. </summary>
        public static Action? ShowError;
        private static Code? _errorCode;
        /// <summary>Sets the member ErrorCode and calls the action ShowError if it's not null.</summary>
        public static Code? ErrorCode
        {
            get => _errorCode;
            set 
            {
                _errorCode = value;

                switch (value)
                {
                    case null:
                        break;
                    case Code.ConnectionFailure:
                        Title = "Csatlakozási hiba";
                        break;
                    case Code.DataNotFound:
                        Title = "Nincs találat";
                        break;
                    case Code.SavingError:
                        Title = "Mentési hiba";
                        break;
                    case Code.InvalidData:
                        Title = "Érvénytelen adat";
                        break;
                }

                if (value != null)
                    ShowError?.Invoke();
            }
        }
        public static string? ErrorMessage { get; set; } = null;
        public static string? Title { get; set; } = null;
        public static Exception? Exception { get; set; } = null;
    }
}

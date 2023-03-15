namespace FVA.IPV.ReportPublication.Model.Configuration
{
    public interface IAppConfiguration
    {
        public string LogPathSettingName { get; set; }
    }

    public class DefaultAppConfiguration : IAppConfiguration
    {
        public string? LogPathSettingName { get; set; }
    }
}
